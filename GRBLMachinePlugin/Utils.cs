using CamBam.CAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GRBLMachine.Utils
{
  public static class Utils
  {

    /// <summary>
    /// Convert machine- and/or working units from GRBLMachine units to CamBam units
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="type"></param>
    /// <param name="offset"></param>
    /// <param name="wanted"></param>
    /// <param name="reportunits"></param>
    /// <param name="cambamunits"></param>
    /// <returns></returns>
    public static double GetWorkOrMachinePosition(this double pos, PosType type, double offset, PosType wanted, InchMM reportunits = InchMM.Millimeters, Units cambamunits = Units.Millimeters)
    {
      double p = pos;

      //◾If  WPos:  is given and MPos is wanted, use  MPos = WPos + WCO .
      //◾If  MPos:  is given and WPos is wanted, use  WPos = MPos - WCO .
      if      (type == PosType.WorkCoordinates    && wanted == PosType.MachineCoordinates)
        p = pos + offset;
      else if (type == PosType.MachineCoordinates && wanted == PosType.WorkCoordinates)
        p = pos - offset;

      p = GetUnitsFromReportAndDrawing(p, reportunits, cambamunits);

      return p; 
    }

    /// <summary>
    /// Convert machine- and/or working units from GRBLMachine units to GRBLMachine units
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="type"></param>
    /// <param name="offset"></param>
    /// <param name="wanted"></param>
    /// <param name="reportunits"></param>
    /// <param name="units"></param>
    /// <returns></returns>
    public static double GetWorkOrMachinePosition(this double pos, PosType type, double offset, PosType wanted, InchMM reportunits, InchMM units)
    {
      return pos.GetWorkOrMachinePosition(type, offset, wanted, reportunits, (units == InchMM.Inches) ?                                Units.Inches 
                                                                                                      : (units == InchMM.Millimeters ? Units.Millimeters 
                                                                                                                                     : Units.Unknown));
    }


    /// <summary>
    /// Convert GRBL reporting units to CamBam units
    /// </summary>
    /// <param name="p"></param>
    /// <param name="reportunits"></param>
    /// <param name="cambamunits"></param>
    /// <returns></returns>
    public static double GetUnitsFromReportAndDrawing(this double p, InchMM reportunits, Units cambamunits)
    {
      if      (reportunits == InchMM.Millimeters)
      {
        switch (cambamunits)
        {
          case Units.Centimeters: p /= 10;              break;
          case Units.Meters:      p /= 1000;            break;
          case Units.Inches:      p /= 25.4;            break;
          case Units.Thousandths: p /= 25.4; p *= 1000; break;
        }
      }
      else if (reportunits == InchMM.Inches)
      {
        switch (cambamunits)
        {
          case Units.Centimeters: p *= 2.54;            break;
          case Units.Meters:      p *= 25.4; p /= 1000; break;
          case Units.Millimeters: p *= 25.4;            break;
          case Units.Thousandths: p *= 1000;            break;
        }
      }

      return p;
    }

    public static double GetUnitsFromReportAndDrawing(this double p, InchMM reportunits, InchMM units)
    {
      return p.GetUnitsFromReportAndDrawing(reportunits, (units == InchMM.Inches) ?                                Units.Inches 
                                                                                  : (units == InchMM.Millimeters ? Units.Millimeters 
                                                                                                                 : Units.Unknown));
    }
  }
}
