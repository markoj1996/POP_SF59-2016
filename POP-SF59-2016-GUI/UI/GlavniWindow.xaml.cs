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
    /// Interaction logic for GlavniWindow.xaml
    /// </summary>
    public partial class GlavniWindow : Window
    {
        private Namestaj namestaj;
        private Korisnik korisnik;
        private Akcija akcija;
        private TipNamestaja tipNamestaja;
        private Operacija operacija;

        public enum Operacija
        {
            Dodavanje,
            Izmena
        }
        public GlavniWindow()
        {
            InitializeComponent();
            OsveziPrikaz();
        }

 
        private void OsveziPrikaz()
        {
            lbNamestaj.Items.Clear();

            foreach (var namestaj in Projekat.Instance.Namestaj)
            {
                if (namestaj.Obrisan == false)
                {
                    lbNamestaj.Items.Add(namestaj);
                }

            }
            lbNamestaj.SelectedIndex = 0;

            lbKorisnici.Items.Clear();
            foreach (var korisnik in Projekat.Instance.Korisnik)
            {
                if (korisnik.Obrisan == false)
                {
                    lbKorisnici.Items.Add(korisnik);
                }

            }
            lbKorisnici.SelectedIndex = 0;

            lbAkcije.Items.Clear();
            foreach (var akcija in Projekat.Instance.Akcija)
            {
                if (akcija.Obrisan == false)
                {
                    lbAkcije.Items.Add(akcija);
                }

            }
            lbAkcije.SelectedIndex = 0;

            lbTipNamestaja.Items.Clear();
            foreach (var tip in Projekat.Instance.TipNamestaja)
            {
                if (tip.Obrisan == false)
                {
                    lbTipNamestaja.Items.Add(tip);
                }

            }
            lbTipNamestaja.SelectedIndex = 0;
        }

        private void DodajN_Click(object sender, RoutedEventArgs e)
        {
            var noviNamestaj = new Namestaj()
            {
                Naziv = ""
            };
            var NamestajProzor = new NamestajWindow(noviNamestaj, NamestajWindow.Operacija.Dodavanje);
            NamestajProzor.ShowDialog();
            OsveziPrikaz();
        }

        private void IzmeniN_Click(object sender, RoutedEventArgs e)
        {
            var izabraniNamestaj = (Namestaj)lbNamestaj.SelectedItem;
            var NamestajProzor = new NamestajWindow(izabraniNamestaj, NamestajWindow.Operacija.Izmena);
            NamestajProzor.ShowDialog();
            OsveziPrikaz();
        }

        private void ObrisiN_Click(object sender, RoutedEventArgs e)
        {
            var izabranNamestaj = (Namestaj)lbNamestaj.SelectedItem;
            var listaNamestaja = Projekat.Instance.Namestaj;

            if (MessageBox.Show($"Da li zelite da obrisete: {izabranNamestaj.Naziv}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var n in listaNamestaja)
                {
                    if (n.Id == izabranNamestaj.Id)
                    {
                        n.Obrisan = true;
                    }
                }
                Projekat.Instance.Namestaj = listaNamestaja;
                OsveziPrikaz();
            }
        }

        private void DodajT_Click(object sender, RoutedEventArgs e)
        {
            var noviTipNamestaja = new TipNamestaja()
            {
                Naziv = ""
            };
            var TipNamestajaProzor = new TipNamestajaWindow(noviTipNamestaja, TipNamestajaWindow.OperacijaT.Dodavanje);
            TipNamestajaProzor.ShowDialog();
            OsveziPrikaz();
        }

        private void IzmeniT_Click(object sender, RoutedEventArgs e)
        {
            var izabraniTipNamestaja = (TipNamestaja)lbTipNamestaja.SelectedItem;
            var TipNamestajaProzor = new TipNamestajaWindow(izabraniTipNamestaja, TipNamestajaWindow.OperacijaT.Izmena);
            TipNamestajaProzor.ShowDialog();
            OsveziPrikaz();
        }

        private void ObrisiT_Click(object sender, RoutedEventArgs e)
        {
            var izabranTipNamestaja = (TipNamestaja)lbTipNamestaja.SelectedItem;
            var listaTipaNamestaja = Projekat.Instance.TipNamestaja;

            if (MessageBox.Show($"Da li zelite da obrisete: {izabranTipNamestaja.Naziv}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var n in listaTipaNamestaja)
                {
                    if (n.Id == izabranTipNamestaja.Id)
                    {
                        n.Obrisan = true;
                    }
                }
                Projekat.Instance.TipNamestaja = listaTipaNamestaja;
                OsveziPrikaz();
            }
        }

        private void DodajK_Click(object sender, RoutedEventArgs e)
        {
            var noviKorisnik = new Korisnik()
            {
                Ime = "",
                Prezime = "",
                KorisnickoIme = "",
                Lozinka = "",
            };
            var KorisnikProzor = new KorisnikWindow(noviKorisnik, KorisnikWindow.OperacijaK.Dodavanje);
            KorisnikProzor.ShowDialog();
            OsveziPrikaz();
        }

        private void IzmeniK_Click(object sender, RoutedEventArgs e)
        {
            var izabraniKorisnik = (Korisnik)lbKorisnici.SelectedItem;
            var KorisnikProzor = new KorisnikWindow(izabraniKorisnik, KorisnikWindow.OperacijaK.Izmena);
            KorisnikProzor.ShowDialog();
            OsveziPrikaz();
        }

        private void ObrisiK_Click(object sender, RoutedEventArgs e)
        {
            var izabranKorisnik = (Korisnik)lbKorisnici.SelectedItem;
            var listaKorisnika = Projekat.Instance.Korisnik;

            if (MessageBox.Show($"Da li zelite da obrisete: {izabranKorisnik.Ime}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var k in listaKorisnika)
                {
                    if (k.Id == izabranKorisnik.Id)
                    {
                        k.Obrisan = true;
                    }
                }
                Projekat.Instance.Korisnik = listaKorisnika;
                OsveziPrikaz();
            }
        }

        private void DodajA_Click(object sender, RoutedEventArgs e)
        {
            var novaAkcija = new Akcija()
            {
                DatumPocetka = new DateTime(2017,1,1) ,
                DatumZavrsetka = new DateTime(2017, 1, 1),
                Popust = 10
            };
            var AkcijaProzor = new AkcijaWindow(novaAkcija, AkcijaWindow.OperacijaA.Dodavanje);
            AkcijaProzor.ShowDialog();
            OsveziPrikaz();
        }

        private void IzmeniA_Click(object sender, RoutedEventArgs e)
        {
            var izabranaAkcija = (Akcija)lbAkcije.SelectedItem;
            var AkcijaProzor = new AkcijaWindow(izabranaAkcija, AkcijaWindow.OperacijaA.Izmena);
            AkcijaProzor.ShowDialog();
            OsveziPrikaz();
        }

        private void ObrisiA_Click(object sender, RoutedEventArgs e)
        {
            var izabranaAkcija = (Akcija)lbAkcije.SelectedItem;
            var listaAkcija = Projekat.Instance.Akcija;

            if (MessageBox.Show($"Da li zelite da obrisete: {izabranaAkcija.Id}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var a in listaAkcija)
                {
                    if (a.Id == izabranaAkcija.Id)
                    {
                        a.Obrisan = true;
                    }
                }
                Projekat.Instance.Akcija = listaAkcija;
                OsveziPrikaz();
            }
        }

        private void Izadji_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
