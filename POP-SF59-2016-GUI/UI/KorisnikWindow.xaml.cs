using POP_SF59_2016.Model;
using POP_SF59_2016.Util1;
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
using System.Windows.Shapes;

namespace POP_SF59_2016_GUI.UI
{
    /// <summary>
    /// Interaction logic for KorisnikWindow.xaml
    /// </summary>
    public partial class KorisnikWindow : Window
    {

        public enum OperacijaK
        {
            Dodavanje,
            Izmena
        }

        private Korisnik korisnik;
        private OperacijaK operacija;

        public KorisnikWindow(Korisnik korisnik,OperacijaK operacija)
        {
            InitializeComponent();
            this.korisnik = korisnik;
            this.operacija = operacija;

            tbIme.DataContext = korisnik;
            tbPrezime.DataContext = korisnik;
            tbKorisnickoIme.DataContext = korisnik;
            tbLozinka.DataContext = korisnik;
            cbTipKorisnika.DataContext = korisnik;
        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {

            var listaKorisnika = Projekat.Instance.Korisnik;
            var izabraniTipKorisnika = cbTipKorisnika.Text;

            switch (operacija)
            {
                case OperacijaK.Dodavanje:
                    korisnik.Id = listaKorisnika.Count + 1;
                    korisnik.TipKorisnika = izabraniTipKorisnika;
                    listaKorisnika.Add(korisnik);
                    break;
                case OperacijaK.Izmena:
                    foreach (var k in listaKorisnika)
                    {
                        if (k.Id == korisnik.Id)
                        {
                            k.Ime = korisnik.Ime;
                            k.Prezime = korisnik.Prezime;
                            k.KorisnickoIme = korisnik.KorisnickoIme;
                            k.Lozinka = korisnik.Lozinka;
                            k.TipKorisnika = korisnik.TipKorisnika;
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }
            GenericSerialize.Serialize("korisnici.xml", listaKorisnika);
            Close();
        }

        private void Izadji(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
