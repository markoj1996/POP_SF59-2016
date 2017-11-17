using POP_SF59_2016.Model;
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
            InicijalizujVrednosti(korisnik, operacija);
        }

        private void InicijalizujVrednosti(Korisnik korisnik, OperacijaK operacija)
        {
            this.korisnik = korisnik;
            this.operacija = operacija;

            this.tbIme.Text = korisnik.Ime;
            this.tbPrezime.Text = korisnik.Prezime;
            this.tbKorisnickoIme.Text = korisnik.KorisnickoIme;
            this.tbLozinka.Text = korisnik.Lozinka;
            this.cbTipKorisnika.Text = korisnik.TipKorisnika;
        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {

            var listaKorisnika = Projekat.Instance.Korisnik;
            var izabraniTipKorisnika = cbTipKorisnika.Text;

            switch (operacija)
            {
                case OperacijaK.Dodavanje:
                    var noviKorisnik = new Korisnik()
                    {
                        Id = listaKorisnika.Count + 1,
                        Ime = this.tbIme.Text,
                        Prezime = this.tbPrezime.Text,
                        KorisnickoIme = this.tbKorisnickoIme.Text,
                        Lozinka = this.tbLozinka.Text,
                        TipKorisnika = izabraniTipKorisnika
                    };
                    listaKorisnika.Add(noviKorisnik);
                    break;
                case OperacijaK.Izmena:
                    foreach (var k in listaKorisnika)
                    {
                        if (k.Id == korisnik.Id)
                        {
                            k.Ime = this.tbIme.Text;
                            k.Prezime = this.tbPrezime.Text;
                            k.KorisnickoIme = this.tbKorisnickoIme.Text;
                            k.Lozinka = this.tbLozinka.Text;
                            k.TipKorisnika = izabraniTipKorisnika;
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }
            Projekat.Instance.Korisnik = listaKorisnika;
            Close();
        }

        private void Izadji(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
