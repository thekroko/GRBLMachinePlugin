using CamBam.CAD;
using CamBam.CAD.Solids;
using CamBam.Extensions;
using CamBam.Geom;
using CamBam.UI;
using System;

namespace GRBLMachine
{
  /// <summary>
  /// Abstract base class for all tools to be used by GRBLMachine
  /// </summary>
  public abstract class Tool
  {
    protected const double   _90rads = Math.PI / 2;

    protected       Surface  _tool;

    /// <summary>
    /// Do the desired painting
    /// </summary>
    /// <param name="d3d"></param>
    public virtual void Paint(Display3D d3d)
    {
      if (_tool != null)
        _tool.Paint(d3d);
    }

    /// <summary>
    /// Do the desired translation
    /// </summary>
    /// <param name="xm"></param>
    public virtual void ApplyTransformation(Matrix4x4F xm)
    {
      if (_tool != null)
        _tool.ApplyTransformation(xm);
    }

    /// <summary>
    /// Create a shank, compensates with a taper for differences in flute- and shank diameters
    /// </summary>
    /// <param name="shankdiameter"></param>
    /// <param name="flutediameter"></param>
    /// <param name="shanklength"></param>
    /// <param name="flutelength"></param>
    /// <returns></returns>
    protected Surface BuildShank(double shankdiameter, double flutediameter, double shanklength, double flutelength)
    {
      double h = (shankdiameter - flutediameter) * 2.0;

      Surface shank = new Rod(new Point3F(0,0,flutelength + Math.Abs(h)), shankdiameter / 2, shanklength - Math.Abs(h));

      if (h  < 0)
        return shank.JoinWith(new Rod(new Point3F(0,0,flutelength + 0), flutediameter / 2, -h, 1f - (shankdiameter / flutediameter)));

      if (h  > 0)
        return shank.JoinWith(new Rod(new Point3F(0,0,flutelength + h), shankdiameter / 2, -h, 1f - (flutediameter / shankdiameter)));

      return shank;
    }
  }

  /// <summary>
  /// Visual representation of an endmill
  /// </summary>
  public class EndMill : Tool
  {

    public EndMill(double diameter, double flutelength, double shankdiameter, double totallength)
    {
      if (diameter      == 0)
        diameter      = GRBLMachinePlugin.Props.DefaultToolDiameter;
          
      if (flutelength   == 0)
        flutelength   = GRBLMachinePlugin.Props.DefaultToolFluteLength;

      if (shankdiameter == 0)
        shankdiameter = GRBLMachinePlugin.Props.DefaultToolShankDiameter;

      if (totallength   == 0)
        totallength   = GRBLMachinePlugin.Props.DefaultToolTotalLength;


      Surface flute = new Rod(diameter / 2, flutelength);

      _tool         = flute.JoinWith(BuildShank(shankdiameter, diameter, Math.Max(0,totallength - flutelength), flutelength));
    }
  }

  /// <summary>
  /// Visual representation of a V-Cutter
  /// </summary>
  public class V_Cutter : Tool
  {
    protected Circle _diameterCircle;
    public V_Cutter(double diameter, double angle, double shankdiameter, double totaltheight)
    {
      if (shankdiameter == 0)
        shankdiameter = diameter * 0.6;

      if (angle         == 0)
        angle         = GRBLMachinePlugin.Props.DefaultToolVAngle;

          
      if (totaltheight  == 0)
        totaltheight  = GRBLMachinePlugin.Props.DefaultToolFluteLength;


      double  h     = Math.Tan(_90rads * ((90f - (angle / 2f)) / 90f)) * (shankdiameter / 2);

      Surface cone  = new Rod(new Point3F(0,0,h), shankdiameter / 2, -h, 1f); // taper with 1f makes it a cone ;)

      _tool         = cone.JoinWith(BuildShank(shankdiameter,   shankdiameter, Math.Max(0,totaltheight - h), h));

      // compensate the V-Cutter's 0.0.0 for the desired cutting diameter
      double  dh    = Math.Tan(_90rads * ((90f - (angle / 2f)) / 90f)) * (diameter / 2);

      _tool.Transform . Translate(0,0, -dh);
      _tool.ApplyTransformation();
      _tool.Transform = Matrix4x4F.Identity;

      // an extra circle is drawn at the diameter 0.0.0
      _diameterCircle = new Circle(0,0, diameter / 2);
    }

    public override void Paint(Display3D d3d)
    {
      base.Paint(d3d);

      d3d.LineWidth = 3;
      _diameterCircle.Paint(d3d);
    }

    public override void ApplyTransformation(Matrix4x4F xm)
    {
      base.ApplyTransformation(xm);

      _diameterCircle.ApplyTransformation(xm);
    }
  }

  /// <summary>
  /// Visual representation of a laser. Basically a V-Cutter with fixed length and angle
  /// </summary>
  public class Laser : V_Cutter
  {
    public Laser(double diameter) : base(diameter,5,2,20)
    {
    }
  }

  /// <summary>
  /// Visual representation of a drill
  /// </summary>
  public class Drill : Tool
  {
    public Drill(double diameter, double flutelength, double shankdiameter, double totallength)
    {
      if (diameter      == 0)
        diameter      = GRBLMachinePlugin.Props.DefaultToolDiameter;

      if (shankdiameter == 0)
        shankdiameter = diameter * 0.6;

      if (flutelength   == 0)
        flutelength   = GRBLMachinePlugin.Props.DefaultToolFluteLength;

      if (totallength  == 0)
        totallength   = GRBLMachinePlugin.Props.DefaultToolFluteLength;


      double  h     = Math.Tan(_90rads * ((90f - (90f / 2f)) / 90f)) * (diameter / 2);

      // tip of the drill
      Surface cone  = new Rod(new Point3F(0,0,h),diameter / 2,              -h, 1f); // taper with 1f makes it a cone ;)
      // drill body
      Surface flute = new Rod(new Point3F(0,0,h),diameter / 2, flutelength - h);

      _tool         = cone.JoinWith(flute, BuildShank(shankdiameter,  diameter, Math.Max(0,totallength - flutelength), flutelength));
    }
  }

  /// <summary>
  /// Visual representation of a drill
  /// </summary>
  public class BallNose : Tool
  {
    public BallNose(double diameter, double flutelength, double shankdiameter, double totallength)
    {
      if (diameter      == 0)
        diameter      = GRBLMachinePlugin.Props.DefaultToolDiameter;

      if (shankdiameter == 0)
        shankdiameter = diameter * 0.6;

      if (flutelength   == 0)
        flutelength   = GRBLMachinePlugin.Props.DefaultToolFluteLength;

      if (totallength  == 0)
        totallength   = GRBLMachinePlugin.Props.DefaultToolFluteLength;


      double  h     = diameter / 2;

      // the ball tip
      Surface dome  = new Sphere(new Point3F(0,0,h), diameter / 2, 45, Sphere.Domes.Bottom);
      // the mill body
      Surface flute = new Rod   (new Point3F(0,0,h), diameter / 2, flutelength - h);

      _tool         = dome.JoinWith(flute, BuildShank(shankdiameter,      diameter, Math.Max(0,totallength - flutelength), flutelength));
    }

  }

}