using CamBam.CAD;
using CamBam.CAM;
using CamBam.Geom;
using CamBam.Library;
using CamBam.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace CamBam.Extensions
{
  public static class CamBamExtenstions
  {

    //
    //  UI Stuff
    //
#region UI

    //
    // SystemTabs
    //
    private static TabControl _tabs = null;

    /// <summary>
    /// Get the TabControl in SystemTabs
    /// </summary>
    /// <param name="systemtabs"></param>
    /// <returns></returns>
    public static TabControl Tabs(this CamBam.UI.SystemTabs systemtabs)
    {
      if (_tabs == null && systemtabs != null)
        foreach (Control c in systemtabs.Controls)
          if (c is TabControl)
            return _tabs = c as TabControl;

      return _tabs;
    }

    /// <summary>
    /// Get the dividerpanel for SystemTabs
    /// </summary>
    /// <param name="systemtabs"></param>
    /// <returns></returns>
    public static Control DividerPanel(this SystemTabs systemtabs)
    {
      return systemtabs.Parent.Parent;
    }

    //
    // Property Inspector
    //

    private static PropertyInfo _propertyListProp   = typeof(XPropertyGrid).GetProperty("PropertyList", BindingFlags.Instance | BindingFlags.NonPublic);
    private static FieldInfo    _propertyListField  = typeof(XPropertyGrid).GetField   ("PropertyList", BindingFlags.Instance | BindingFlags.NonPublic);

    public static XPropertyList PropertyList(this XPropertyGrid grid)
    {  
      if      (_propertyListField != null)
        return _propertyListField.GetValue(grid) as XPropertyList;
      else if (_propertyListProp  != null)
        return _propertyListProp .GetValue(grid,null) as XPropertyList; 
      
      return null;
    }

    //
    // ICADView
    //

    /// <summary>
    /// Extension to ZoomToFit
    /// 
    /// Original does not take Toolpaths into account
    /// </summary>
    /// <param name="icadview"></param>
    public static void ZoomToFitEx(this ICADView icadview)
    {
      if (icadview.CADFile == null || icadview.ViewProjection == null)
          return;

      PointF     empty  = PointF.Empty;
      PointF     point  = PointF.Empty;
      Matrix4x4F matrix = new Matrix4x4F(icadview.ViewProjection.ViewMatrix4x4F);

      matrix.m[12] = 0;
      matrix.m[13] = 0;

      icadview.CADFile.GetScreenExtentsEx(ref empty, ref point, matrix);
      icadview.ViewProjection.ZoomToFitScreenPoints(empty, point);
      icadview.RefreshView();
    }

#endregion // UI

    //
    // Compatibility Stuff
    //
#region Compatibility 0.9.8 vs 1.0.0

    //
    // Below an example of a method to equalize the differences between v0.9.8P and v1.0
    // It uses reflection to determine the type of attribute and to set and get it's value.
    //

    private static PropertyInfo _lineColorProp  = typeof(Display3D).GetProperty("LineColor");
    private static FieldInfo    _lineColorField = typeof(Display3D).GetField   ("LineColor");

    /// <summary>
    /// Check if LineColor is a property
    /// </summary>
    public static bool IsLineColorProperty
    {
      get
      {
        return _lineColorProp != null;
      }
    }

    /// <summary>
    /// Setter for LineColor, Circumvent the differences between 0.9.8 and 1.0.0
    /// </summary>
    /// <param name="d3d"></param>
    /// <param name="color"></param>
    public static void LineColor(this Display3D d3d, Color color)
    {
      if      (_lineColorProp  != null)
        _lineColorProp.SetValue(d3d,color,null);
      else if (_lineColorField != null)
        _lineColorField.SetValue(d3d,color);
    }

    /// <summary>
    /// Getter for LineColor, Circumvent the differences between 0.9.8 and 1.0.0
    /// </summary>
    /// <param name="d3d"></param>
    /// <returns></returns>
    public static Color LineColor(this Display3D d3d)
    {
      if      (_lineColorProp  != null)
        return (Color)_lineColorProp.GetValue(d3d,null);
      else if (_lineColorField != null)
        return (Color)_lineColorField.GetValue(d3d);

      return Color.White;
    }

#endregion // Compatibility 0.9.8 vs 1.0.0

    //
    // CADFile & Co Stuff
    //
#region CADFile, Parts, MOPs and Tools

    //
    // Extents
    //
    /// <summary>
    /// Extension to GetScreenExtents
    /// 
    /// Original does not take Toolpaths into account
    /// </summary>
    /// <param name="cadfile"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <param name="t"></param>
    public static void GetScreenExtentsEx(this CADFile cadfile, ref PointF min, ref PointF max, Matrix4x4F t)
    {
      cadfile.GetScreenExtents(ref min, ref max, t);

      PointF localMin = PointF.Empty;
      PointF localMax = PointF.Empty;

      foreach (CAMPart part in cadfile.Parts)
      {
        foreach (MachineOp mop in part.MachineOps)
        {
          if (mop.Toolpaths2 != null)
          {
            foreach (ToolpathItem item in mop.Toolpaths2.Toolpaths)
            {
              item.Toolpath.GetScreenExtents(ref localMin, ref localMax, item.Toolpath.Transform * t, CamBamConfig.Defaults.ViewProjectionMode == ProjectionModes.Perspective);

              if (double.IsNaN(min.X) || double.IsNaN(max.X) || 
                  double.IsNaN(min.Y) || double.IsNaN(max.Y))
              {
                min = localMin;
                max = localMax;

                continue;
              }

              if (!double.IsNaN(        localMax.X))
                max.X = Math.Max(max.X, localMax.X);

              if (!double.IsNaN(        localMax.Y))
                max.Y = Math.Max(max.Y, localMax.Y);

              if (!double.IsNaN(        localMin.X))
                min.X = Math.Min(min.X, localMin.X);

              if (!double.IsNaN(        localMin.Y))
                min.Y = Math.Min(min.Y, localMin.Y);
            }
          }
        }
      }
    }


    //
    // Parts
    //

    public static CAMPart FirstPart(this CADFile file)
    {
      return file.Parts != null && file.Parts.Count != 0 ? file.Parts[0] : null;
    }

    public static CAMPart FirstPart(this ICADView view)
    {
      CADFile file = view.CADFile;

      return file != null ? file.FirstPart() : null;
    }

    public static CAMPart ActivePart(this ICADView view)
    {
      return view.CADFile != null ? view.CADFile.ActivePart() : null;
    }

    public static CAMPart ActivePart(this CADFile file)
    {
      return file.ActivePart;
    }

    //
    // MOPs
    //

    public static MachineOp FirstMOP(this CAMPart part)
    {
      return part.MachineOps != null && part.MachineOps.Count !=0 ? part.MachineOps[0] : null;
    }

    public static MachineOp FirstMOP(this CADFile file)
    {
      CAMPart part = file.FirstPart();

      return part != null ? part.FirstMOP() : null;
    }

    public static MachineOp FirstMOP(this ICADView view)
    {
      CADFile file = view.CADFile;

      return file != null ? file.FirstMOP() : null;
    }

    public static MachineOp ActiveMOP(this CAMPart part)
    {
      return part.FirstMOP();
    }

    public static MachineOp ActiveMOP(this CADFile file)
    {
      CAMPart part = file.ActivePart();

      return part != null ? part.ActiveMOP() : null;
    }

    public static MachineOp ActiveMOP(this ICADView view)
    {
      return view.CADFile != null ? view.CADFile.ActiveMOP() : null;
    }

    //
    // Tools
    //

    public static ToolDefinition FirstTool(this CAMPart part)
    {
      MachineOp mop = part.FirstMOP();

      return mop != null ? mop.CurrentTool() : null;
    }
   
    public static ToolDefinition FirstTool(this CADFile file)
    {
      CAMPart part = file.FirstPart();

      return part != null ? part.FirstTool() : null;
    }

    public static ToolDefinition FirstTool(this ICADView view)
    {
      return view.CADFile != null ? view.CADFile.FirstTool() : null;
    }

    public static ToolDefinition ActiveTool(this CAMPart part)
    {
      MachineOp mop = part.ActiveMOP();

      return mop != null ? mop.CurrentTool() : null;
    }
   
    public static ToolDefinition ActiveTool(this CADFile file)
    {
      CAMPart part = file.ActivePart();

      return part != null ? part.ActiveTool() : null;
    }

    public static ToolDefinition ActiveTool(this ICADView view)
    {
      ToolDefinition tool = view.CADFile != null ? view.CADFile.ActiveTool() : null;

      return tool != null  ? tool : (view.CADFile != null ? view.CADFile.FirstTool() : null);
    }

    public static ToolDefinition ActiveTool(this CamBamUI ui)
    { 
      return ui.ActiveView != null  ? ui.ActiveView.ActiveTool() : null;
    }

    public static ToolDefinition CurrentTool(this MachineOp mop)
    {
      ToolDefinition def = mop.CurrentTool;

      if (def == null)
        def = new ToolDefinition(mop.Name + " current (from MOP)",mop.ToolNumber.Value,mop.ToolDiameter.Value,0,2);

      if (mop.ToolDiameter.Value != def.Diameter)
        def.Diameter    = mop.ToolDiameter.Value;

      if (mop.ToolProfile .Value != def.ToolProfile)
        def.ToolProfile = mop.ToolProfile .Value;

      if (mop.ToolNumber  .Value != def.Index)
        def.Index       = mop.ToolNumber  .Value;

      return def;
    }

    #endregion // CADFile, Parts, MOPs and Tools


    //
    // Circles, Lines, PolyLines, Arcs, Extrusion & Co Stuff
    //
#region Geometrics

    //
    // Points & Co
    //
    public static Point3F Add(this Point3F p1, Point3F p2) 
    {
      p1.X += p2.X;
      p1.Y += p2.Y;
      p1.Z += p2.Z;

      return p1;
    }

    public static Point3F DivideBy(this Point3F p1, double d) 
    {
      p1.X /= d;
      p1.Y /= d;
      p1.Z /= d;

      return p1;
    }

    //
    // Surfaces & Co
    //
    public static Surface JoinWith(this Surface surf, double tolerance, params Surface[] others)
    {
      List<Entity> list = new List<Entity>(others.Length + 1);

      if (surf.Faces.Length != 0 || surf.Points.Count != 0)
        list.Add(surf);

      list.AddRange(others);

      surf.CloneFrom(SurfaceUtils.JoinSurfaces2(list, tolerance));

      return surf;
    }

    public static Surface JoinWith(this Surface surf, params Surface[] others)
    {
      return surf.JoinWith(0, others);
    }

    //
    // Tolerance Extrude
    //
    public static Surface Extrude(this Polyline curve,  double tolerance, double height, double taper)
    {
      Vector3F normal = Vector3F.Undefined;

      if (curve.HasArcs && tolerance != 0)
        curve = curve.RemoveArcs(Math.Abs(tolerance));

      if (curve.Points.Count < 2)
          return null;

      if (curve.Points.Count > 2)
        normal = Vector3F.CrossProduct(new Vector3F(curve.Points[0].Point, curve.Points[1].Point), 
                                       new Vector3F(curve.Points[0].Point, curve.Points[2].Point));

      if (normal.IsUndefined)
          normal = new Vector3F(0, 0, -1);

      normal = normal.Unit();

      Surface      surface     = new Surface();
      Point3FArray curvePoints = new Point3FArray(2 * (curve.Points.Count + 1), true);

      foreach (PolylineItem item in curve.Points)
        curvePoints.Add(item.Point);

      int count = curvePoints.Count;

      for (int j = 0; j != curve.Points.Count; j++)
      {
        Point3F item = curvePoints[j];

        item.X = item.X + normal.X * height;
        item.Y = item.Y + normal.Y * height;
        item.Z = item.Z + normal.Z * height;

        curvePoints.Add(item);
      }

      surface.Points = curvePoints;

      List<TriangleFace> triangleFaces = new List<TriangleFace>();

      for (int k = 0; k != (count - 1); k++)
      {
        triangleFaces.Add(new TriangleFace(k, k +         1, k + count + 1));
        triangleFaces.Add(new TriangleFace(k, k + count + 1, k + count    ));
      }

      if (curve.Closed)
      {
        triangleFaces.Add(new TriangleFace(count - 1,     0,     count    ));
        triangleFaces.Add(new TriangleFace(count - 1, count, 2 * count - 1));
      }

      surface.Faces = triangleFaces.ToArray();

      if (height < 0)
        surface.InvertFaces();

      return surface;
    }

    public static Surface Extrude(this Circle   circle, double tolerance, double height, double taper)
    {
      return circle.ToPolyline().Extrude(tolerance, height, taper);
    }

    public static Surface Extrude(this Arc      arc,    double tolerance, double height, double taper)
    {
      return arc.   ToPolyline().Extrude(tolerance, height, taper);
    }

    public static Surface Extrude(this Line     line,   double tolerance, double height, double taper)
    {
      return line.  ToPolyline().Extrude(tolerance, height, taper);
    }

    //
    // Steps Extrude
    //

    public static Surface Extrude(this Polyline curve,  int steps, double height, double taper)
    {
      Vector3F normal = Vector3F.Undefined;

      taper = (taper < 0 ? -1f : 1f) - taper;

      if (curve.Points.Count < 2)
        return null;

      if (steps < 2)
        return null;

      steps = ((steps / 4) + ((steps % 4) != 0 ? 4 : 0)) * 4;

      if (curve.Points.Count > 2)
        normal = Vector3F.CrossProduct(new Vector3F(curve.Points[0].Point, curve.Points[1].Point), new Vector3F(curve.Points[0].Point, curve.Points[2].Point));

      if (normal.IsUndefined)
        normal = new Vector3F(0, 0, -1);

      normal = normal.Unit();

      Surface surface = new Surface();

      for (double i = 0; i <= 1; i = i + 1 / (double)steps)
        surface.Points.Add(curve.GetParametricPoint(i));

      int num = 0;

      Point3F sumBase   = new Point3F(0,0,0);
      Point3F sumHeight = new Point3F(0,0,0);

      for (double j = 0; j <= 1; j = j + 1 / (double)steps)
      {
        Point3F item = surface.Points[num];

        sumBase = sumBase.Add(item);

        item.X = (item.X * taper) + (normal.X * height);
        item.Y = (item.Y * taper) + (normal.Y * height);
        item.Z =  item.Z          + (normal.Z * height);

        sumHeight = sumHeight.Add(item);

        surface.Points.Add(item);

        num++;
      }

      sumBase  .DivideBy(num);
      sumHeight.DivideBy(num);

      TriangleFace[] faces = new TriangleFace[(num + (curve.Closed ? 1 : 0)) * 2];

      int k;

      for (k = 0; k < num - 1; k++)
      {
        faces [k * 2    ] = new TriangleFace(k, k +       1, k + num + 1);
        faces [k * 2 + 1] = new TriangleFace(k, k + num + 1, k + num    );
      }

      if (curve.Closed)
      {
        faces [k * 2    ] = new TriangleFace(num - 1,   0,     num    );
        faces [k * 2 + 1] = new TriangleFace(num - 1, num, 2 * num - 1);
      }

      surface.Faces = faces;

      return surface;
    }

    public static Surface Extrude(this Circle   circle, int steps, double height, double taper)
    {
      return circle.ToPolyline().Extrude(steps, height, taper);
    }

    public static Surface Extrude(this Arc      arc,    int steps, double height, double taper)
    {
      return arc.   ToPolyline().Extrude(steps, height, taper);
    }

    public static Surface Extrude(this Line     line,   int steps, double height, double taper)
    {
      return line.  ToPolyline().Extrude(steps, height, taper);
    }

#endregion // Geometrics

  }
}
