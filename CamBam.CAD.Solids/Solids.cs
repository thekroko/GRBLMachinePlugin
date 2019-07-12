using CamBam.Extensions;
using CamBam.Geom;
using CamBam.Values;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;
using System.Xml;
using CamBam.CAD.Solids.UI;

namespace CamBam.CAD.Solids
{
  [Serializable]
  [XmlRoot("solid")]
  public class Solid : Surface
  {

    [CamBam.Values.HasAdvancedProperties]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [XmlRoot("solidProp")]
    public class SolidProps
    {
      public SolidProps()
      {
        DefaultSteps = 45;
      }

      [Browsable(false)]
      [XmlAttribute(AttributeName = "type", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
      public virtual string TypeName
      {
        get { return GetType().FullName; }
        set {                            }
      }

      [Browsable(false)]
      [XmlIgnore]
      public virtual string Name
      {
        get
        {
          string[] dots = GetType().FullName.Split('+')[0].Split('.');
          return dots[dots.Length - 1] + " Defaults";
        }
      }

      [Category   ("(General)")]
      [DisplayName("Position")]
      [Description("The default position where to draw the solid")]
      [CBKeyValue]
      public Point3F DefaultPosition { get; set; }

      [Category   ("(General)")]
      [DisplayName("Steps")]
      [Description("The default number of steps to render the solid with")]
      [CBKeyValue]
      public int DefaultSteps        { get; set; }

      public override string ToString()
      {
        return "Click [...] to edit";
      }
    }

    protected SolidProps props;

    [Browsable(false)]
    [XmlIgnore]
    public SolidProps Props
    {
      get { return props != null ? props : props = CreateProps(); }
      set { props = value;                                        }
    }

    protected virtual SolidProps CreateProps()
    {
      try               { return Activator.CreateInstance(Type.GetType(GetType().FullName + "+" + GetType().Name + "Props")) as SolidProps; }
      catch (Exception) { return new SolidProps();                                                                                          }
    }

    [Browsable(false)]
    [XmlAttribute(AttributeName = "type", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
    public virtual string TypeName
    {
      get { return GetType().Name; }
      set {                        }
    }

    [XmlIgnore]
    [Browsable(false)]
    public virtual string DisplayName
    {
      get { return GetType().Name; }
    }

    [XmlIgnore]
    [Browsable(false)]
    public virtual DrawSolidPanel UI { get { return new DrawSolidWithPositionPanel(); } }
  }


  [Serializable]
  [XmlRoot("cylinder")]
  public class Cylinder : Solid
  {

    public class CylinderProps : SolidProps
    {
      public CylinderProps()
      {
        Diameter = 15;
        Height   = 30;
        Taper    = 0;
      }

      [Category   ("Cylinder")]
      [DisplayName("Diameter")]
      [Description("The cylinder's default diameter")]
      [CBKeyValue]
      public double Diameter { get; set; }

      [Category   ("Cylinder")]
      [DisplayName("Height")]
      [Description("The cylinder's default height")]
      [CBKeyValue]
      public double Height   { get; set; }

      [Category   ("Cylinder")]
      [DisplayName("Taper")]
      [Description("The cylinder's default taper")]
      [CBKeyValue]
      public double Taper    { get; set; }
    }

    /// <summary>
    /// Constructor to satisfy XML serialization
    /// </summary>
    public Cylinder()
    {
    }

    public Cylinder(double radius, double height, int steps = 45, double taper = 0f)
    {
      this.CloneFrom(new Circle(0,0,radius).Extrude(steps, height, taper));

      if (height < 0)
        InvertFaces();
    }

    public Cylinder(double radius, double height, double taper) : this (radius, height, 45, taper)
    {
    }

    public Cylinder(Point3F position, double radius, double height, int steps = 45, double taper = 0f) : this(radius, height, steps, taper)
    {
      Transform.Translate(position);
      ApplyTransformation();
      Transform = Matrix4x4F.Identity;
    }

    public Cylinder(Point3F position, double radius, double height, double taper) : this(position, radius, height, 45, taper)
    {
    }
    
    public override Entity Clone()
    {
      Cylinder clone = new Cylinder();

      clone.CloneFrom(this);

      return clone;
    }

    public override DrawSolidPanel UI { get { return new DrawCylinderPanel(); } }
  }


  [Serializable]
  [XmlRoot("rod")]
  public class Rod : Solid
  {
    public class RodProps : SolidProps
    {
      public RodProps()
      {
        Diameter = 15;
        Height   = 30;
        Taper    = 0;
      }

      [Category   ("Rod")]
      [DisplayName("Diameter")]
      [Description("The rod's default diameter")]
      [CBKeyValue]
      public double Diameter { get; set; }

      [Category   ("Rod")]
      [DisplayName("Height")]
      [Description("The rod's default height")]
      [CBKeyValue]
      public double Height   { get; set; }

      [Category   ("Rod")]
      [DisplayName("Taper")]
      [Description("The rod's default taper")]
      [CBKeyValue]
      public double Taper    { get; set; }
    }

    /// <summary>
    /// Constructor to satisfy XML serialization
    /// </summary>
    public Rod()
    {
    }

    public Rod(double radius, double height, int steps = 45, double taper = 0f)
    {
      Surface s   = new Circle(            0,0,         radius).Extrude(      steps, height, taper);
      Disc    top = new Disc  (new Point3F(0,0,height), radius * (1 - taper), steps);
      Disc    bot = new Disc  (                         radius,               steps);

      bot.InvertFaces();

      this.CloneFrom(new Surface().JoinWith(top,s,bot));

      if (height < 0)
        InvertFaces();
    }

    public Rod(double radius, double height, double taper) : this (radius, height, 45, taper)
    {
    }

    public Rod(Point3F position, double radius, double height, int steps = 45, double taper = 0f) : this(radius, height, steps, taper)
    {
      Transform.Translate(position);
      ApplyTransformation();
      Transform = Matrix4x4F.Identity;
    }

    public Rod(Point3F position, double radius, double height, double taper) : this(position, radius, height, 45, taper)
    {
    }

    public override Entity Clone()
    {
      Rod clone = new Rod();

      clone.CloneFrom(this);

      return clone;
    }

    public override DrawSolidPanel UI { get { return new DrawRodPanel(); } }
  }


  [Serializable]
  [XmlRoot("disc")]
  public class Disc : Solid
  {
    public class DiscProps : SolidProps
    {
      public DiscProps()
      {
        Diameter = 15;
      }

      [Category   ("Disc")]
      [DisplayName("Diameter")]
      [Description("The disc's default diameter")]
      [CBKeyValue]
      public double Diameter { get; set; }
    }

    /// <summary>
    /// Constructor to satisfy XML serialization
    /// </summary>
    public Disc()
    {
    }

    public Disc(double radius, int steps = 45)
    {
      // @TODO optimize this, now it's a flat cylinder with taper 1 so there are many points in the center which are all 0.0.0
      this.CloneFrom(new Circle(0,0,radius).Extrude(steps, 0, 1f));
    }

    public Disc(Point3F position, double radius, int steps = 45) : this (radius, steps)
    {
      Transform.Translate(position);
      ApplyTransformation();
      Transform = Matrix4x4F.Identity;
    }

    public override Entity Clone()
    {
      Disc clone = new Disc();

      clone.CloneFrom(this);

      return clone;
    }

    public override DrawSolidPanel UI { get { return new DrawDiscPanel(); } }
  }

  [Serializable]
  [XmlRoot("sphere")]
  public class Sphere: Solid
  {
    public class SphereProps : SolidProps
    {
      public SphereProps()
      {
        Diameter = 15;
        Domes    = Domes.Both;
      }

      [Category   ("Sphere")]
      [DisplayName("Diameter")]
      [Description("The sphere's default diameter")]
      [CBKeyValue]
      public double Diameter { get; set; }

      [Category   ("Sphere")]
      [DisplayName("Domes")]
      [Description("The sphere's default domes")]
      [CBKeyValue]
      public Domes Domes     { get; set; }
    }

    public enum Domes
    {
      Both,
      Top,
      Bottom
    }

    /// <summary>
    /// Constructor to satisfy XML serialization
    /// </summary>
    public Sphere()
    {
    }

    /// <summary>
    /// Create a sphere (or one of it's domes) at 0,0,0 with radius specified
    /// </summary>
    /// <param name="radius"></param>
    /// <param name="steps"></param>
    /// <param name="domes"></param>
    public Sphere(double radius, int steps = 45, Domes domes = Domes.Both) : this()
    {
      BuildDomes(radius, steps, domes);
    }

    /// <summary>
    /// Create a sphere (or one of it's domes) at 'position' with radius specified
    /// </summary>
    /// <param name="position"></param>
    /// <param name="radius"></param>
    /// <param name="steps"></param>
    /// <param name="domes"></param>
    public Sphere(Point3F position, double radius, int steps = 45, Domes domes = Domes.Both) : this (radius, steps, domes)
    {
      Transform.Translate(position);
      ApplyTransformation();
      Transform = Matrix4x4F.Identity;
    }

    public override Entity Clone()
    {
      Sphere clone = new Sphere();

      clone.CloneFrom(this);

      return clone;
    }

    public override DrawSolidPanel UI { get { return new DrawSpherePanel(); } }

    private void BuildDomes(double radius, int steps, Domes domes)
    {
      Polyline curve  = new Circle(0,0,radius).ToPolyline();

      // we need steps to be dividable by 4 !!
      steps = ((steps / 4) + ((steps % 4) != 0 ? 4 : 0)) * 4;

      // the circle acts as our equator being positioned at 0,0,0
      List<Point3F> equator = new List<Point3F>(steps + 1);

      // fill the equator
      for (double i = 0; i <= 1; i = i + 1 / (double)steps)
        equator.Add(curve.GetParametricPoint(i));

      // close the point count
      equator.Add(curve.GetParametricPoint(0));

      int equ = equator.Count;
      int num = 0;

      // here our top dome will have it's points
      LinkedList<Point3F> spherePointsTop = new LinkedList<Point3F>();

      double height = 0;
      double factor = 1;

      // Domes.Top starts at the first increment
      if (domes == Domes.Top)
      {
        // insert the equator
        foreach (Point3F p in equator)
          spherePointsTop.AddFirst(p);

        num++;
      }

      if (domes == Domes.Both || domes == Domes.Top)
      {
        // build the top dome
        for (int stp = 0; stp != (steps / 4); stp++)
        {
          // use the equator's points to build the height rings
          height = (equator[stp < (equ -1) ? stp + 1 : 0].Y);
          factor = (equator[stp < (equ -1) ? stp + 1 : 0].X) / radius;

          for (int cnt = 0; cnt != equ; cnt++)
          {
            Point3F item = equator[cnt];

            item.X *= factor;
            item.Y *= factor;
            item.Z =  height;

            spherePointsTop.AddFirst(item);
          }

          num++;
        }
      }

      // here our bottom dome will have it's points
      LinkedList<Point3F> spherePointsBottom = new LinkedList<Point3F>();

      if (domes == Domes.Both || domes == Domes.Bottom)
      {
        // build the bottom dome
        for (int stp = ((steps / 2) + (steps / 4)) - 1; stp != steps; stp++)
        {
          // use the equator's points to build the height rings
          height = (equator[stp < (equ -1) ? stp + 1 : 0].Y);
          factor = (equator[stp < (equ -1) ? stp + 1 : 0].X) / radius;

          for (int cnt = 0; cnt != equ; cnt++)
          {
            Point3F item = equator[cnt];

            item.X *= factor;
            item.Y *= factor;
            item.Z =  height;

            spherePointsBottom.AddFirst(item);
          }

          num ++;
        }
      }

      // combine top and bottom dome into our points list
      Points.AddRange(spherePointsTop   .ToArray());
      Points.AddRange(spherePointsBottom.ToArray());

      // build triange list
      List<TriangleFace> faces = new List<TriangleFace>(Points.Count * 2);

      for (int stp = 0; stp != (num - 1); stp++)
      {
        for (int k = 0; k < (equ - 1); k++)
        {
          int idxp = (stp * equ) +  k;

          faces.Add(new TriangleFace(idxp, idxp +       1, idxp + equ + 1));
          faces.Add(new TriangleFace(idxp, idxp + equ + 1, idxp + equ    ));
        }
      }

      Faces = faces.ToArray();
    }
  }
}
