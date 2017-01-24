using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalkulatorWPF
{
    interface IOperacjeLiczbyZespolone
    {
        void Dodawanie(LiczbaZespolona a);
        void Odejmowanie(LiczbaZespolona a);
        void Mnozenie(LiczbaZespolona a);
        void Dzielenie(LiczbaZespolona a);
        double Moduł(LiczbaZespolona a);
        
    }
}
