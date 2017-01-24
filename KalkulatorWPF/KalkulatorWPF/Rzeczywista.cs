using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalkulatorWPF
{
    class LiczbaRzeczywista : LiczbaZespolona , IOperacjeLiczbyRzeczywiste
    {

        public LiczbaRzeczywista(){}
        public LiczbaRzeczywista(double rzeczywista)
        {   
            this.rzeczywista = rzeczywista;
        }
        public override double PobierzRzeczywista
        {
            get { return rzeczywista; }
            set { rzeczywista = value; }
        } // Nadpisanie wlasciwosci z Klasy nadrzędnej Zespolona
        public override string Wypisz()
        {
            return rzeczywista + "";
        }           // Nadpisanie metody z Klasy nadrzędnej Zespolona

        public double Dodawanie(LiczbaRzeczywista a)
        {
            return rzeczywista += a.rzeczywista;
        }
        public double Odejmowanie(LiczbaRzeczywista a)
        {
            return rzeczywista -= a.rzeczywista;
        }
        public double Mnozenie(LiczbaRzeczywista a)
        {
            return rzeczywista *= a.rzeczywista;
        }
        public double Dzielenie(LiczbaRzeczywista a)
        {
            return rzeczywista /= a.rzeczywista;
        }
        public double Pierwiastek(LiczbaRzeczywista a)
        {
            return rzeczywista = Math.Sqrt(a.rzeczywista);
        }
        public double sin(double a)
        {
            return rzeczywista = Math.Sin(a);
        }
        public double cos(double a)
        {
            return rzeczywista = Math.Cos(a);
        }
        public double silnia(LiczbaRzeczywista a)
        {
            if (a.rzeczywista > 150)
                return rzeczywista = 1;
            else 
            {
                double s = 1;
                for (int i = 1; i <= a.rzeczywista; ++i)
                    s *= i;
                rzeczywista = s;
                return rzeczywista;
            }
        }
       
    }
}
