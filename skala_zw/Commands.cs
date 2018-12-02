using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using zza = ZwSoft.ZwCAD.ApplicationServices;
using zzr = ZwSoft.ZwCAD.Runtime;


namespace skala_zw
{
    public class Commands
    {
        [zzr.CommandMethod("PI_skala")]

        public void Skalaokno()
        {
            Okno_skala win = new Okno_skala(506, 239);
            zza.Application.ShowModalWindow(win);
        }
    }
}
