using CamBam.Values;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System;
using System.Xml;
using System.Xml.Schema;
using System.IO;
using System.Drawing.Design;
using System.Reflection;
using System.Windows.Forms;

namespace CamBam.CAD.Solids.Plugin
{
  public enum EnabledDisabled : int
  {
    Disabled = 0,
    Enabled  = 1
  }

  [CamBam.Values.HasAdvancedProperties]
  public class SolidPluginProps
  {

    [Editor(typeof(SolidPropsCollectionEditor),typeof(UITypeEditor))]
    public class SolidsList : List<Solid.SolidProps>, IXmlSerializable
    {

      public class SolidPropsCollectionEditor : CollectionEditor
      {
        public SolidPropsCollectionEditor(Type type) : base(type)
        {
        }

        protected override bool CanRemoveInstance(object value)
        {
          return false;
        }

        protected override CollectionForm CreateCollectionForm()
        {
          CollectionForm form = base.CreateCollectionForm();
          Type           t    = form.GetType();
          FieldInfo      f;
        
          if ((f = t.GetField("addButton",   BindingFlags.Instance | BindingFlags.NonPublic)) != null)
            (f.GetValue(form) as Control).Visible = false;
        
          if ((f = t.GetField("removeButton",BindingFlags.Instance | BindingFlags.NonPublic)) != null)
            (f.GetValue(form) as Control).Visible = false;

          if ((f = t.GetField("downButton",  BindingFlags.Instance | BindingFlags.NonPublic)) != null)
            (f.GetValue(form) as Control).Visible = false;

          if ((f = t.GetField("upButton",    BindingFlags.Instance | BindingFlags.NonPublic)) != null)
            (f.GetValue(form) as Control).Visible = false;

          return form;
        }
      }


      public SolidsList() : base()
      {
      }

      public Solid.SolidProps this[Solid index]
      {
        get
        {
          foreach (Solid.SolidProps prop in this)
            if (index.Props.GetType().Equals(prop.GetType()))
              return prop;

          return index.Props;
        }
      }

      public bool Contains(Type type)
      {
        Solid.SolidProps instance = (Activator.CreateInstance(type) as Solid).Props;

        foreach (Solid.SolidProps prop in this)
          if (instance.GetType().Equals(prop.GetType()))
            return true;

        return false;
      }

      public XmlSchema GetSchema()
      {
        return null;
      }

      public void ReadXml(XmlReader reader)
      {
        string myName = reader.Name;

        reader.MoveToContent();

        bool isEmptyElement = reader.IsEmptyElement;

        reader.ReadStartElement();

        if (isEmptyElement)
          return;

        while (true)
        {
          if (reader.NodeType == XmlNodeType.EndElement && reader.Name == myName)
            break;

          string elemName  = reader.Name;
          Type   type      = null;
          string xsiType   = reader.GetAttribute("xsi:type");

          if (!string.IsNullOrEmpty(xsiType))
            type = Type.GetType(xsiType);

          if (type != null)
          { 
            string s = "<"+ elemName +">" + reader.ReadInnerXml() + "</" + elemName + ">";

            Add((Solid.SolidProps)(new XmlSerializer(type)).Deserialize(new StringReader(s)));
          }
          else
            reader.Skip();
        }
        reader.Read();
      }

      public void WriteXml(XmlWriter writer)
      {
        foreach(Solid.SolidProps prop in this)
          new XmlSerializer(prop.GetType()).Serialize(writer, prop);
      }
    }

    public SolidPluginProps()
    {
      EnableMenus = EnabledDisabled.Enabled;
    }

    [Category   ("(General)")]
    [DisplayName("'Solids' menus")]
    [Description("Enable or disable the 'Solids' menu items")]
    [CBKeyValue]
    public EnabledDisabled EnableMenus { get; set; }

    [Category   ("Solids")]
    [DisplayName("Draw Solids as Surface")]
    [Description("Draw the solids as plain surface for compatibility with CamBam installations without this Plugin")]
    [CBKeyValue]
    public bool DrawAsSurface          { get; set; }

    [Category   ("Solids")]
    [DisplayName("Solid Types")]
    [Description("Properties per Solid Type")]
    [CBKeyValue]
    [Editor(typeof(SolidsList.SolidPropsCollectionEditor),typeof(UITypeEditor))]
    public SolidsList Solids           { get; set; }

    public override string ToString()
    {
      return "Click [...] to edit";
    }
  }
}