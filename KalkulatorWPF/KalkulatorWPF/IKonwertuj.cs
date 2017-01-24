using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalkulatorWPF
{
    interface IKonwertuj
    {
        double NaLiczbeZmiennoprzecinkowa(string ciag);
        string NaCiagZnakow(double liczba);
        double StopnieNaRadiany(double angle);
        double RadianyNaStopnie(double angle);
        
    }
}
