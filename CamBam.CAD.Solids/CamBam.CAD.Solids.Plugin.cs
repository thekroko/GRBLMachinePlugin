using System;
using System.Windows.Forms;
using CamBam.UI;
using System.Collections.Generic;
using System.Reflection;
using CamBam.CAD.Solids.UI;
using System.IO;
using System.Xml.Serialization;

namespace CamBam.CAD.Solids.Plugin
{
  public static class SolidsPlugin
  {
    public static SolidPluginProps Props = new SolidPluginProps();

    /// <summary>
    /// Static initializer, called as soon as a reference to this class is made. e.g. when being probed by 'InitPlugins'
    /// </summary>
    static SolidsPlugin()
    {
      //
      // since our libraries are also in the plugins folder, the default resolving will fail, load 'manually' from our folder
      //
      AppDomain.CurrentDomain.AssemblyResolve += (object sender, ResolveEventArgs args) =>
      {
        AssemblyName assyName  = new AssemblyName(args.Name);

        if (assyName.Name.ToLower() != "cambam.cad.solids")
          return null;

        string assemblyPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), assyName.Name + ".dll");

        return File.Exists(assemblyPath) ? Assembly.LoadFrom(assemblyPath) : null;
      };
    }

    public static void InitPlugin(CamBamUI ui)
    {
#if DEBUG
      MessageBox.Show("Now it's time to attach the debugger :-)","CamBam.CAD.Solids.Plugin");
#endif
      //
      // Create the menu item. It shows the config dialog
      //
      ui.Menus.mnuPlugins.DropDownItems.Add(new ToolStripMenuItem("3D Solids Plugin",null, new EventHandler((object sender, EventArgs e) =>
      {
        new PluginOptions().ShowDialog(ThisApplication.TopWindow);
      })));

      ThisApplication.TopWindow.Load        += TopWindow_Load;
      ThisApplication.TopWindow.FormClosing += TopWindow_FormClosing;
    }

    private static void TopWindow_FormClosing(object sender, FormClosingEventArgs e)
    {
      WriteConfig();
    }

    private static void TopWindow_Load(object sender, EventArgs e)
    {
      if (CADFile.ExtraTypes != null)
      {
        //
        // Load all solids (also the ones present in other plugins !!) into CamBam
        //
        List<Type> solids = new List<Type>();

        foreach (Assembly assy in AppDomain.CurrentDomain.GetAssemblies())
          try {
            foreach (Type type in assy.GetExportedTypes())
              if (type.IsSubclassOf(typeof(Solid)))
                solids.Add(type);
          }
          catch (NotSupportedException) { }

        // Let CamBam, know about our new types;
        CADFile.ExtraTypes.AddRange(solids);

        ReadConfig(solids);

        //
        // Should we create the Menu's ?
        //
        if (Props.EnableMenus == EnabledDisabled.Enabled)
        {
          //
          // Go find the Surface menu in the Draw context menu.
          //
          int index = -1;

          foreach (ToolStripItem item in CamBamUI.MainUI.Menus.mnuDraw.DropDownItems)
          {
            index++;

            if (item.Name == "mnuDrawSurface")
            {
              CamBamUI.MainUI.Menus.mnuDraw.DropDownItems.Insert(index, CreateSolidsMenu(solids));
              break;
            }
          }

          //
          // Go find the Draw menu in the View context menu.
          //
          ContextMenuStrip menu = CamBamUI.MainUI.ViewContextMenus.ContextMenuStrip;

          foreach (ToolStripItem item in menu.Items)
          {
            if (item.Name == "mnuDraw")
            {
              index = -1;

              foreach (ToolStripItem draw in (item as ToolStripDropDownItem).DropDownItems)
              {
                index++;

                //
                // Go find the Surcafe menu in the Draw context menu.
                //
                if (draw.Name == "surfaceToolStripMenuItem")
                {
                  (item as ToolStripDropDownItem).DropDownItems.Insert(index, CreateSolidsMenu(solids));
                  break;
                }
              }

              break;
            }
          }
        }
      }
    }

    private static ToolStripDropDownItem CreateSolidsMenu(List<Type> solids)
    {
      ToolStripDropDownItem solidsToolStripMenuItem = new ToolStripMenuItem("Solids") { Name = "solidsToolStripMenuItem" };

      foreach (Type type in solids)
      {
        Solid s = Activator.CreateInstance(type) as Solid;

        solidsToolStripMenuItem.DropDownItems.Add(new ToolStripMenuItem(s.DisplayName,null,(object x, EventArgs y) =>
        {
          Solid tag = (x as ToolStripMenuItem).Tag as Solid;

          new DrawSolidForm(tag).Show(ThisApplication.TopWindow);
        }) { Tag = s });
      }

      return solidsToolStripMenuItem;
    }

    /// <summary>
    /// Read from CamBam.CAD.Solids.config using standard .NET XmlSerialization
    /// </summary>
    private static void ReadConfig(List<Type> solids)
    {
      FileStream file = null;

      try {
        file                   = File.OpenRead(Path.Combine(Path.GetDirectoryName(CamBam.CamBamConfig.SystemConfigFilename),"CamBam.CAD.Solids.config"));
        SolidPluginProps props = new XmlSerializer(typeof(SolidPluginProps)).Deserialize(file) as SolidPluginProps;

        Props.EnableMenus      = props.EnableMenus;
        Props.DrawAsSurface    = props.DrawAsSurface;
        Props.Solids           = props.Solids;
      }
      catch (FileNotFoundException)     { }
      catch (InvalidOperationException) { MessageBox.Show("Definition change detected for CamBam.CAD.Solids.config\r\n\r\nAll settings reset to default", "3D Solids Plugin", MessageBoxButtons.OK, MessageBoxIcon.Information); }
      catch (Exception e)               { MessageBox.Show("Unable to open CamBam.CAD.Solids.config\r\n\r\n" + e.ToString(),                               "3D Solids Plugin", MessageBoxButtons.OK, MessageBoxIcon.Error); }
      finally
      {
        if (file != null)
          file.Close();
      }

      if (Props.Solids == null)
        Props.Solids = new SolidPluginProps.SolidsList();

      if (Props.Solids.Count != solids.Count)
      {
        foreach (Type solid in solids)
          if (!Props.Solids.Contains(solid))
            Props.Solids.Add((Activator.CreateInstance(solid) as Solid).Props);
      }
    }

    /// <summary>
    /// Write to CamBam.CAD.Solids.config using standard .NET XmlSerialization
    /// </summary>
    private static void WriteConfig()
    {
      FileStream file = null;
      try
      {
        file = File.Create(Path.Combine(Path.GetDirectoryName(CamBam.CamBamConfig.SystemConfigFilename),"CamBam.CAD.Solids.config"));
        new XmlSerializer(typeof(SolidPluginProps)).Serialize(file, Props);
      }
      catch (Exception e) { MessageBox.Show("Unable to write CamBam.CAD.Solids.config\r\n\r\n" + e.ToString(), "3D Solids Plugin", MessageBoxButtons.OK, MessageBoxIcon.Error); }
      finally
      {
        if (file != null)
          file.Close();
      }
    }
  }
}
