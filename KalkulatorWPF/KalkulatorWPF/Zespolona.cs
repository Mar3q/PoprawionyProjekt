using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalkulatorWPF
{
    class LiczbaZespolona : IOperacjeLiczbyZespolone
    {
        protected double rzeczywista; //Czesc rzeczywista liczby zespolonej.
        private double urojona;       //Czesc urojona liczby zespolonej.

        public LiczbaZespolona() { }//konstruktor domyślny
        public LiczbaZespolona(double rzeczywista, double urojona)
        {
            this.rzeczywista = rzeczywista;
            this.urojona = urojona;
        }//konstruktor parametryczny

         
        public virtual double PobierzRzeczywista
        {
            get { return rzeczywista; }
            set { rzeczywista = value; }
        } //Wlasciwosci do odczytu i ustawiania pola rzeczywista
        public double PobierzUrojona
        {
            get { return urojona; }
            set { urojona = value; }
        }//Wlasciwosci do odczytu i ustawiania pola urojona


        public virtual string Wypisz()
        {
            if (urojona < 0)
                return (Math.Round(rzeczywista, 2) + "" + Math.Round(urojona, 2) + "j");
            else
                return (Math.Round(rzeczywista, 2) + " + " + Math.Round(urojona, 2) + "j");
        }//Metoda wirtualna zwracająca pola.

        //Metody wykonujące elementarne opercje na liczbie zespolonej i jako parametr pobieraja liczbe zespolona.
        public void Dodawanie(LiczbaZespolona a)
        {
            double czescRzeczywista = rzeczywista + a.rzeczywista;
            double czescUrojona = urojona + a.urojona;
            rzeczywista = czescRzeczywista;
            urojona = czescUrojona;
        }
        public void Odejmowanie(LiczbaZespolona a)
        {
            double czescRzeczywista = rzeczywista - a.rzeczywista;
            double czescUrojona = urojona - a.urojona;
            rzeczywista = czescRzeczywista;
            urojona = czescUrojona;
        }
        public void Mnozenie(LiczbaZespolona a)
        {
            double czescRzeczywista = (rzeczywista * a.rzeczywista) - (urojona * a.urojona);
            double czescUrojona = (rzeczywista * a.urojona) + (urojona * a.rzeczywista);
            rzeczywista = czescRzeczywista;
            urojona = czescUrojona;
        }
        public void Dzielenie(LiczbaZespolona a)
        {
            double czescRzeczywista = (((rzeczywista * a.rzeczywista)+(urojona*a.urojona)) / (a.rzeczywista * a.rzeczywista + a.urojona * a.urojona));
            double czescUrojona = (((urojona * a.rzeczywista)-(rzeczywista*a.urojona)) / (a.rzeczywista * a.rzeczywista + a.urojona * a.urojona));
            rzeczywista = czescRzeczywista;
            urojona = czescUrojona;
        }
        public double Moduł(LiczbaZespolona a)
        {
            return Math.Round(Math.Sqrt(a.rzeczywista * a.rzeczywista + a.urojona * a.urojona), 2);
        }
    }
}
