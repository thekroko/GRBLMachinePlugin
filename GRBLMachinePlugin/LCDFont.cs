using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing.Text;
using System.Drawing;
using System.Runtime.InteropServices;

namespace GRBLMachine
{
  public class LCDFont
  {
    private static PrivateFontCollection fonts = new PrivateFontCollection();

    static LCDFont()
    {
      byte[] fontData  = Properties.Resources.DSEG14Classic_BoldItalic;
      IntPtr fontBytes = Marshal.AllocHGlobal(fontData.Length);

      Marshal.Copy         (fontData, 0, fontBytes, fontData.Length);
      fonts  .AddMemoryFont(fontBytes,              fontData.Length);
      Marshal.FreeHGlobal  (fontBytes);
    }

    public static Font Load(float size = 16.0F)
    {
      return new Font(fonts.Families[0], size, FontStyle.Bold | FontStyle.Italic);
    }
  }
}
