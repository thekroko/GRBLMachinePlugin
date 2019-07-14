// Decompiled with JetBrains decompiler
// Type: CamBam.CAD.MeasureEditMode
// Assembly: CamBam.CAD, Version=0.9.5729.19316, Culture=neutral, PublicKeyToken=null
// MVID: 589476B6-77CA-4BAC-B5D4-5A4FA26EE99F
// Assembly location: C:\Program Files (x86)\CamBam plus 0.9.8\CamBam.CAD.dll

using CamBam.CAD;
using CamBam.Geom;
using CamBam.UI;
using CamBam.Util;
using System.Drawing;
using System.Windows.Forms;

namespace GRBLMachine {
  public class MoveToLocationMode : EditMode {
    protected PointSelectEditMode EditMode;
    public Point3F MoveSource { get { return ToolTraceEditmode.CurrentLocation; } } 
    public Point3F MoveDestination;
    private Font Rr5GW2GfU;

    public MoveToLocationMode(ICADView iv)
      : base(iv) {
      this.MarkFileModified = false;
      this.EditMode = new PointSelectEditMode(iv);
      if (this.EditMode.ReturnStatus != CamBam.CAD.EditMode.ReturnStatusCode.Running) {
        this.ReturnStatus = this.EditMode.ReturnStatus;
      } else {
        this.MoveDestination = Point3F.Undefined;
      }
    }

    public override bool Repeat() {
      this.MoveDestination = Point3F.Undefined;
      this.ReturnStatus = CamBam.CAD.EditMode.ReturnStatusCode.Running;
      this.EditMode.ReturnStatus = CamBam.CAD.EditMode.ReturnStatusCode.Running;
      return true;
    }

    public override void OnPaint(ICADView iv, Display3D d3d) {
      if (this.ReturnStatus != CamBam.CAD.EditMode.ReturnStatusCode.Running)
        return;
      d3d.ModelTransform = Matrix4x4F.Identity;
      d3d.LineColor = Color.Chartreuse;
      d3d.DrawPoint(this.EditMode.CurrentPoint, 3f);
      if (!this.MoveSource.IsUndefined) {
        d3d.LineWidth = 0.0f;
        d3d.DrawPoint(this.MoveSource, 3f);
        if (!this.EditMode.CurrentPoint.IsUndefined) {
          Line3F line3F = new Line3F(this.MoveSource, this.EditMode.CurrentPoint);
          d3d.DrawLine(this.MoveSource, this.EditMode.CurrentPoint);
          PointF screen = this._ActiveView.DrawingToScreen(new Point3F((line3F.p1.X + line3F.p2.X) / 2.0, (line3F.p1.Y + line3F.p2.Y) / 2.0, (line3F.p1.Z + line3F.p2.Z) / 2.0));
          if (this.Rr5GW2GfU == null)
            this.Rr5GW2GfU = new Font(FontFamily.GenericSansSerif, 10f);
          d3d.DrawText("moveDist="+line3F.Length().ToString(), this.Rr5GW2GfU, Color.Chartreuse, Color.Transparent, (double)screen.X + 5.0, (double)screen.Y + 5.0, true);
        }
      }
      base.OnPaint(iv, d3d);
    }

    private void UpdatePointLocation() {
      if (this.EditMode.ReturnStatus == CamBam.CAD.EditMode.ReturnStatusCode.OK && this.EditMode.ReturnValue is Point3F) {
          this.MoveDestination = (Point3F)this.EditMode.ReturnValue;
          this.ReturnOK();
      }
      if (this.EditMode.ReturnStatus != CamBam.CAD.EditMode.ReturnStatusCode.Cancelled)
        return;
      this.ReturnStatus = CamBam.CAD.EditMode.ReturnStatusCode.Cancelled;
    }

    public override bool OnKeyDown(object sender, KeyEventArgs e) {
      bool flag = base.OnKeyDown(sender, e);
      if (this.ReturnStatus == CamBam.CAD.EditMode.ReturnStatusCode.OK || this.ReturnStatus != CamBam.CAD.EditMode.ReturnStatusCode.Cancelled)
        return flag;
      this.ReturnValue = (object)null;
      return flag;
    }

    public override bool OnMouseDown(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Middle) {
        this.ReturnCancel();
        return true;
      }
      bool flag = this.EditMode.OnMouseDown(sender, e);
      this.UpdatePointLocation();
      if (flag)
        return flag;
      return base.OnMouseDown(sender, e);
    }

    public override bool OnMouseMove(object sender, MouseEventArgs e) {
      bool flag = this.EditMode.OnMouseMove(sender, e);
      this.UpdatePointLocation();
      if (flag)
        return flag;
      return base.OnMouseMove(sender, e);
    }

    public override bool OnMouseUp(object sender, MouseEventArgs e) {
      bool flag = this.EditMode.OnMouseUp(sender, e);
      this.UpdatePointLocation();
      if (flag)
        return flag;
      return base.OnMouseUp(sender, e);
    }

    public override void ReturnOK() {
      this.ReturnValue = (object)new Point3F[2]
      {
        this.MoveSource,
        this.MoveDestination
      };
      base.ReturnOK();
    }

    protected void _ReturnBaseOK() {
      base.ReturnOK();
    }

    public override bool AllowRepeatCancel() {
      return true;
    }
  }
}
