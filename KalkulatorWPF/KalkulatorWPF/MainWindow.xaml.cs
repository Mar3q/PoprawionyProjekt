using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KalkulatorWPF
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LiczbaZespolona zespolona1;
        private LiczbaZespolona zespolona2;
        private LiczbaRzeczywista rzeczywista1 = new LiczbaRzeczywista();
        private LiczbaRzeczywista rzeczywista2 = new LiczbaRzeczywista();
        private Konwerter konwertuj = new Konwerter();
        private Operacja ostatniaoperacja;
        private enum Operacja
        {
            brak = 0,
            dodawanie,
            odejmowanie,
            mnożenie,
            dzielenie,
            sin,
            cos,
            wynik
        }

        public MainWindow()
        {
            InitializeComponent();
            UkryjGridy();
        }
        

        #region Obsługa Przycisków Panelu Głównego
        private void Przycisk_Zespolone(object sender, RoutedEventArgs e)
        {
            PanelWyborGlowny.Visibility = Visibility.Hidden;
            PanelGlownyZespolone.Visibility = Visibility.Visible;
        }
        private void Przycisk_Rzeczywiste(object sender, RoutedEventArgs e)
        {
            PanelWyborGlowny.Visibility = Visibility.Hidden;
            PokazGridy();
        }
        private void Przycisk_Zamknij(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        #endregion

        #region Metody Kalkulatora dla licz rzeczywistych
        //Metody zarządzające Gridami  
        private void UkryjGridy()
        {
            PanelOperatoryRzeczywiste.Visibility = Visibility.Hidden;
            PanelFunkcjiRzeczywiste.Visibility = Visibility.Hidden;
            PanelWyświetlaniaRzeczywiste.Visibility = Visibility.Hidden;

            PanelGlownyZespolone.Visibility = Visibility.Hidden;
            PanelOperacjiZespolone.Visibility = Visibility.Hidden;
            PanelWynikuZespolone.Visibility = Visibility.Hidden;
        }
        private void PokazGridy()
        {
            PanelOperatoryRzeczywiste.Visibility = Visibility.Visible;
            PanelFunkcjiRzeczywiste.Visibility = Visibility.Visible;
            PanelWyświetlaniaRzeczywiste.Visibility = Visibility.Visible;
        }
        //Metody pomocnicze
        private void WyczyscOknoWyniku()
        {
            OkienkoWynikowe.Text = String.Empty;
        }
        private void KomunikatBledu()
        {
            MessageBox.Show("Sprawdź poprawność wprowadzonych danych!");
        }
        //Metody konwertujace wartość znajdujacą się w oknie wyniku i przypisujace ją do odpowieniego pola.
        private void PobierzPole1()
        {
            //pobiera pole tylko wtedy kiedy nie jest puste i kiedy ostatnia operacja nie jest sinusem lub cosinusem 
            if ((OkienkoWynikowe.Text != "") && (ostatniaoperacja != Operacja.sin) && (ostatniaoperacja != Operacja.cos))
            {
                try { rzeczywista1.PobierzRzeczywista = konwertuj.NaLiczbeZmiennoprzecinkowa(OkienkoWynikowe.Text); }
                catch { KomunikatBledu(); }
                WyczyscOknoWyniku();
            }
            else
            {
                WyczyscOknoWyniku();
                ostatniaoperacja = Operacja.brak;
            }
        }
        private void PobierzPole2()
        {
            if ((OkienkoWynikowe.Text != "") && (ostatniaoperacja != Operacja.sin) && (ostatniaoperacja != Operacja.cos))
            {
                try { rzeczywista2.PobierzRzeczywista = konwertuj.NaLiczbeZmiennoprzecinkowa(OkienkoWynikowe.Text); }
                catch { KomunikatBledu(); }
                WyczyscOknoWyniku();
            }
            else
            {
                WyczyscOknoWyniku();
                ostatniaoperacja = Operacja.brak;
            }
        }
        //Metoda wyswietlajaca wynik z dokładnością do części tysięcznych
        private void WyswietlWynik(double wynik)
        {   
            try { OkienkoWynikowe.Text = konwertuj.NaCiagZnakow(Math.Round(wynik, 3)); }
            catch { KomunikatBledu(); }
        }
        #endregion

        #region Obsługa Przyciskow Kalkulatora dla liczb rzeczywistych
        private void Przycisk_Liczba(object sender, RoutedEventArgs e)
        {
            OkienkoWynikowe.Text += (sender as Button).Content.ToString();
        }
        private void Przycisk_funkcji(object sender, RoutedEventArgs e)
        {
            try
            {
                PobierzPole1();
                               
                string wybor = (sender as Button).Content.ToString();
                switch (wybor)
                {
                    case "+":
                        ostatniaoperacja = Operacja.dodawanie;
                        break;
                    case "-":                    
                        ostatniaoperacja = Operacja.odejmowanie;
                        break;
                    case "*":
                        ostatniaoperacja = Operacja.mnożenie;
                        break;
                    case "/":
                        ostatniaoperacja = Operacja.dzielenie;
                        break;
                    case "!":
                        WyswietlWynik(rzeczywista1.silnia(rzeczywista1));
                        break;
                    case "√":
                        WyswietlWynik(rzeczywista1.Pierwiastek(rzeczywista1));
                        break;
                    case "C":
                        OkienkoWynikowe.Text = "";
                        rzeczywista1.PobierzRzeczywista = 0;
                        rzeczywista2.PobierzRzeczywista = 0;
                        break;
                    case "π":
                        rzeczywista1.PobierzRzeczywista = Math.PI;
                        OkienkoWynikowe.Text = rzeczywista1.Wypisz();
                        break;
                    case "sin":
                        double kat = rzeczywista1.PobierzRzeczywista;
                        double stopnie = konwertuj.RadianyNaStopnie(rzeczywista1.PobierzRzeczywista);
                        OkienkoWynikowe.Text = "Sin(" + kat + "°) = " + rzeczywista1.sin(stopnie) + Environment.NewLine +
                        "Sin(" + kat + "rad) = " + rzeczywista1.sin(kat);
                        ostatniaoperacja = Operacja.sin;
                        break;
                    case "cos":
                        double kat2 = rzeczywista1.PobierzRzeczywista;
                        double stopnie2 = konwertuj.RadianyNaStopnie(rzeczywista1.PobierzRzeczywista);
                        OkienkoWynikowe.Text = "Cos(" + kat2 + "°) = " + rzeczywista1.cos(stopnie2) + Environment.NewLine +
                        "Cos(" + kat2 + "rad) = " + rzeczywista1.cos(kat2);
                        ostatniaoperacja = Operacja.cos;
                        break;
                    default:
                        WyczyscOknoWyniku();
                        break;
                }
                
            }
            catch
            {
                KomunikatBledu();
            }
            
        }
        private void Przycisk_Wynik(object sender, RoutedEventArgs e)
        {
            try
            {
                PobierzPole2();

                switch (ostatniaoperacja)
                {
                    case Operacja.dodawanie:
                        WyswietlWynik(rzeczywista1.Dodawanie(rzeczywista2));
                        break;
                    case Operacja.odejmowanie:
                        WyswietlWynik(rzeczywista1.Odejmowanie(rzeczywista2));
                        break;
                    case Operacja.mnożenie:
                        WyswietlWynik(rzeczywista1.Mnozenie(rzeczywista2));
                        break;
                    case Operacja.dzielenie:
                        WyswietlWynik(rzeczywista1.Dzielenie(rzeczywista2));
                        break;
                    default:
                        WyczyscOknoWyniku();
                        break;
                }
            }
            catch
            {
                KomunikatBledu();
            }
        }
        private void Przycisk_PowrotMenu(object sender, RoutedEventArgs e)
        {
            UkryjGridy();
            PanelWyborGlowny.Visibility = Visibility.Visible;
        }

        #endregion

        #region Obsługa Przyciskow Kalkulatora dla liczb zespolonych
        private void PrzyciskOperacja_Zespolone(object sender, RoutedEventArgs e)
        {   
            WynikT.Text = (sender as Button).Content.ToString(); //Pobiera z przycisku wartość która przechowuje i przypisuje do okna wyniku.
            PanelOperacjiZespolone.Visibility = Visibility.Visible;
            PanelGlownyZespolone.Visibility = Visibility.Hidden;
        }
        private void PrzyciskOblicz_Zespolone(object sender, RoutedEventArgs e)
        {
            //Jesli nie podamy 1 liczby zespolonej to zostanie wpisana w niej miejsce liczba 0.
            if ((r1.Text == "") && (i1.Text == ""))
            {
                r1.Text = "0";
                i1.Text = "0";
            }
            //Jesli nie podamy 2 liczby zespolonej to zostanie wpisana w te miejsce jeszcze raz pierwsza liczba.
            if ((r2.Text == "") && (i2.Text == ""))
            {
                r2.Text = r1.Text;
                i2.Text = i1.Text;
            }
            try
            {   //Tworzy 2 Liczby zespolone, pobierajac odpowiednie pola i konwertuje na odpowiedni typ.
                zespolona1 = new LiczbaZespolona(konwertuj.NaLiczbeZmiennoprzecinkowa(r1.Text), konwertuj.NaLiczbeZmiennoprzecinkowa(i1.Text));
                zespolona2 = new LiczbaZespolona(konwertuj.NaLiczbeZmiennoprzecinkowa(r2.Text), konwertuj.NaLiczbeZmiennoprzecinkowa(i2.Text));
            }
            catch
            {
                KomunikatBledu();
                r1.Text = "0";
                i1.Text = "0";
                r2.Text = "0";
                i2.Text = "0";
            }

            //WynikT.Text przechowuje znak operacji która wybralismy
            switch (WynikT.Text)
            {
                case ("+"):
                    zespolona1.Dodawanie(zespolona2);
                    WynikT.Text = "("+r1.Text +" + "+ i1.Text + "j)+(" + r2.Text + " + " + i2.Text + "j) =" + Environment.NewLine + zespolona1.Wypisz();
                    PanelOperacjiZespolone.Visibility = Visibility.Hidden;
                    break;
                case ("-"):
                    zespolona1.Odejmowanie(zespolona2);
                    WynikT.Text = "(" + r1.Text + " + " + i1.Text + "j)-(" + r2.Text + " + " + i2.Text + "j) =" + Environment.NewLine + zespolona1.Wypisz();
                    PanelOperacjiZespolone.Visibility = Visibility.Hidden;
                    break;
                case ("*"):
                    zespolona1.Mnozenie(zespolona2);
                    WynikT.Text = "(" + r1.Text + " + " + i1.Text + "j)*(" + r2.Text + " + " + i2.Text + "j) =" + Environment.NewLine + zespolona1.Wypisz();
                    PanelOperacjiZespolone.Visibility = Visibility.Hidden;
                    break;
                case ("/"):
                    zespolona1.Dzielenie(zespolona2);
                    WynikT.Text = "(" + r1.Text + " + " + i1.Text + "j)/(" + r2.Text + " + " + i2.Text + "j) =" + Environment.NewLine + zespolona1.Wypisz();
                    PanelOperacjiZespolone.Visibility = Visibility.Hidden;
                    break;
                case ("|z|"):
                    zespolona1.Moduł(zespolona1);
                    zespolona2.Moduł(zespolona2);
                    WynikT.Text = "| " + r1.Text + " + " + i1.Text + "j | ="+ zespolona1.Moduł(zespolona1) + Environment.NewLine +
                    "| " + r2.Text + " + " + i2.Text + "j | =" + zespolona2.Moduł(zespolona2);
                    PanelOperacjiZespolone.Visibility = Visibility.Hidden;
                    break;
                default:
                    WyczyscOknoWyniku();
                    break;
            }
            PanelWynikuZespolone.Visibility = Visibility.Visible;
        }
        private void PrzyciskPowrot_Zespone(object sender, RoutedEventArgs e)
        {
            PanelWynikuZespolone.Visibility = Visibility.Hidden;
            PanelGlownyZespolone.Visibility = Visibility.Visible;
            PanelOperacjiZespolone.Visibility = Visibility.Hidden;
            Czysc(); //Wychodzac z panelu obliczen czyscimy odpowiednie pola 
        }
        private void PrzyciskWyjscie_Zespolone(object sender, RoutedEventArgs e)
        {
            PanelOperacjiZespolone.Visibility = Visibility.Hidden;
            PanelGlownyZespolone.Visibility = Visibility.Hidden;
            PanelWyborGlowny.Visibility = Visibility.Visible;
        }
        //Metoda czyszczaca textboxy w ktorch przechowyalismy liczby zespolone
        public void Czysc()
        {
            r1.Text = String.Empty;
            i1.Text = String.Empty;
            r2.Text = String.Empty;
            i2.Text = String.Empty;
        }
        #endregion
    }
}
