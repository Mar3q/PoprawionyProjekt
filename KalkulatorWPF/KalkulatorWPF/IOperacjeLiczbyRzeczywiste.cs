using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalkulatorWPF
{
    interface IOperacjeLiczbyRzeczywiste
    {
        double Dodawanie(LiczbaRzeczywista a);
        double Odejmowanie(LiczbaRzeczywista a);
        double Mnozenie(LiczbaRzeczywista a);
        double Dzielenie(LiczbaRzeczywista a);
        double Pierwiastek(LiczbaRzeczywista a);
        double sin(double a);
        double cos(double a);
        double silnia(LiczbaRzeczywista a);
    }
}
