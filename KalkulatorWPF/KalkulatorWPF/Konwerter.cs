using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalkulatorWPF
{
    class Konwerter : IKonwertuj
    {
        //Metody zamieniajaće ciag znakow na liczbe i vice versa
        public double NaLiczbeZmiennoprzecinkowa(string ciag)
        {
            double dane = Convert.ToDouble(ciag);
            return dane;
        }
        public string NaCiagZnakow(double liczba)
        {
            string ciag = Convert.ToString(liczba);
            return ciag;
        }
        
        //Metody zamieniające stopnie na radiany i vice versa
        public double StopnieNaRadiany(double kat)
        {
            return Math.PI * kat / 180.0;
        } 
        public double RadianyNaStopnie(double kat)
        {
            return Math.PI * kat / 180.0;
        }
    }
}
