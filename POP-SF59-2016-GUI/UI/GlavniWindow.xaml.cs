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
            OsveziPrikaz(Projekat.Instance.Namestaj,Projekat.Instance.Korisnik,Projekat.Instance.Akcija,Projekat.Instance.TipNamestaja);
        }

 
        public void OsveziPrikaz(List<Namestaj>namestaj,List<Korisnik>korisnik, List<Akcija>akcija ,List<TipNamestaja>tip)
        {
            lbNamestaj.Items.Clear();

            foreach (var n in namestaj)
            {
                if (n.Obrisan == false)
                {
                    lbNamestaj.Items.Add(n);
                }

            }
            lbNamestaj.SelectedIndex = 0;

            lbKorisnici.Items.Clear();
            foreach (var k in korisnik)
            {
                if (k.Obrisan == false)
                {
                    lbKorisnici.Items.Add(k);
                }

            }
            lbKorisnici.SelectedIndex = 0;

            lbAkcije.Items.Clear();
            foreach (var a in akcija)
            {
                if (a.Obrisan == false)
                {
                    lbAkcije.Items.Add(a);
                }

            }
            lbAkcije.SelectedIndex = 0;

            lbTipNamestaja.Items.Clear();
            foreach (var t in tip)
            {
                if (t.Obrisan == false)
                {
                    lbTipNamestaja.Items.Add(t);
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
            OsveziPrikaz(Projekat.Instance.Namestaj, Projekat.Instance.Korisnik, Projekat.Instance.Akcija, Projekat.Instance.TipNamestaja);
        }

        private void IzmeniN_Click(object sender, RoutedEventArgs e)
        {
            var izabraniNamestaj = (Namestaj)lbNamestaj.SelectedItem;
            var NamestajProzor = new NamestajWindow(izabraniNamestaj, NamestajWindow.Operacija.Izmena);
            NamestajProzor.ShowDialog();
            OsveziPrikaz(Projekat.Instance.Namestaj, Projekat.Instance.Korisnik, Projekat.Instance.Akcija, Projekat.Instance.TipNamestaja);
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
                OsveziPrikaz(Projekat.Instance.Namestaj, Projekat.Instance.Korisnik, Projekat.Instance.Akcija, Projekat.Instance.TipNamestaja);
            }
        }

        private void PretraziN_Click(object sender, RoutedEventArgs e)
        {
            var PretragaProzor = new PretragaNamestajaWindow();
            Close();
            PretragaProzor.ShowDialog();
            
        }

        private void SortirajN_Click(object sender, RoutedEventArgs e)
        {
            string tip = cbTipSortiranjaN.Text;

            if (tip == "Po ID")
            {
                List<Namestaj> sortirana = Projekat.Instance.Namestaj.OrderBy(o => o.Id).ToList();
                OsveziPrikaz(sortirana, Projekat.Instance.Korisnik, Projekat.Instance.Akcija, Projekat.Instance.TipNamestaja);
            }
            else if (tip == "Po nazivu")
            {
                List<Namestaj> sortirana = Projekat.Instance.Namestaj.OrderBy(o => o.Naziv).ToList();
                OsveziPrikaz(sortirana, Projekat.Instance.Korisnik, Projekat.Instance.Akcija, Projekat.Instance.TipNamestaja);
            }
            else if (tip == "Po sifri")
            {
                List<Namestaj> sortirana = Projekat.Instance.Namestaj.OrderBy(o => o.Sifra).ToList();
                OsveziPrikaz(sortirana, Projekat.Instance.Korisnik, Projekat.Instance.Akcija, Projekat.Instance.TipNamestaja);
            }
            else if (tip == "Po ceni")
            {
                List<Namestaj> sortirana = Projekat.Instance.Namestaj.OrderBy(o => o.JedinicnaCena).ToList();
                OsveziPrikaz(sortirana, Projekat.Instance.Korisnik, Projekat.Instance.Akcija, Projekat.Instance.TipNamestaja);
            }
            else if (tip == "Po kolicini")
            {
                List<Namestaj> sortirana = Projekat.Instance.Namestaj.OrderBy(o => o.KolicinaUMagacinu).ToList();
                OsveziPrikaz(sortirana, Projekat.Instance.Korisnik, Projekat.Instance.Akcija, Projekat.Instance.TipNamestaja);
            }
            else if (tip == "Po tipu")
            {
                List<Namestaj> sortirana = Projekat.Instance.Namestaj.OrderBy(o => o.TipNamestajaId).ToList();
                OsveziPrikaz(sortirana, Projekat.Instance.Korisnik, Projekat.Instance.Akcija, Projekat.Instance.TipNamestaja);
            }

        }

        private void Osvezi_Click(object sender, RoutedEventArgs e)
        {
            OsveziPrikaz(Projekat.Instance.Namestaj, Projekat.Instance.Korisnik, Projekat.Instance.Akcija, Projekat.Instance.TipNamestaja);
        }

            private void DodajT_Click(object sender, RoutedEventArgs e)
        {
            var noviTipNamestaja = new TipNamestaja()
            {
                Naziv = ""
            };
            var TipNamestajaProzor = new TipNamestajaWindow(noviTipNamestaja, TipNamestajaWindow.OperacijaT.Dodavanje);
            TipNamestajaProzor.ShowDialog();
            OsveziPrikaz(Projekat.Instance.Namestaj, Projekat.Instance.Korisnik, Projekat.Instance.Akcija, Projekat.Instance.TipNamestaja);
        }

        private void IzmeniT_Click(object sender, RoutedEventArgs e)
        {
            var izabraniTipNamestaja = (TipNamestaja)lbTipNamestaja.SelectedItem;
            var TipNamestajaProzor = new TipNamestajaWindow(izabraniTipNamestaja, TipNamestajaWindow.OperacijaT.Izmena);
            TipNamestajaProzor.ShowDialog();
            OsveziPrikaz(Projekat.Instance.Namestaj, Projekat.Instance.Korisnik, Projekat.Instance.Akcija, Projekat.Instance.TipNamestaja);
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
                OsveziPrikaz(Projekat.Instance.Namestaj, Projekat.Instance.Korisnik, Projekat.Instance.Akcija, Projekat.Instance.TipNamestaja);
            }
        }

        private void PretraziT_Click(object sender, RoutedEventArgs e)
        {
            var PretragaProzor = new PretragaTipaNamestajaWindow();
            Close();
            PretragaProzor.ShowDialog();

        }

        private void SortirajT_Click(object sender, RoutedEventArgs e)
        {
            string tip = cbTipSortiranjaT.Text;

            if (tip == "Po ID")
            {
                List<TipNamestaja> sortirana = Projekat.Instance.TipNamestaja.OrderBy(o => o.Id).ToList();
                OsveziPrikaz(Projekat.Instance.Namestaj, Projekat.Instance.Korisnik, Projekat.Instance.Akcija, sortirana);
            }
            else if (tip == "Po nazivu")
            {
                List<TipNamestaja> sortirana = Projekat.Instance.TipNamestaja.OrderBy(o => o.Naziv).ToList();
                OsveziPrikaz(Projekat.Instance.Namestaj, Projekat.Instance.Korisnik, Projekat.Instance.Akcija, sortirana);
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
            OsveziPrikaz(Projekat.Instance.Namestaj, Projekat.Instance.Korisnik, Projekat.Instance.Akcija, Projekat.Instance.TipNamestaja);
        }

        private void IzmeniK_Click(object sender, RoutedEventArgs e)
        {
            var izabraniKorisnik = (Korisnik)lbKorisnici.SelectedItem;
            var KorisnikProzor = new KorisnikWindow(izabraniKorisnik, KorisnikWindow.OperacijaK.Izmena);
            KorisnikProzor.ShowDialog();
            OsveziPrikaz(Projekat.Instance.Namestaj, Projekat.Instance.Korisnik, Projekat.Instance.Akcija, Projekat.Instance.TipNamestaja);
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
                OsveziPrikaz(Projekat.Instance.Namestaj, Projekat.Instance.Korisnik, Projekat.Instance.Akcija, Projekat.Instance.TipNamestaja);
            }
        }


        private void PretraziK_Click(object sender, RoutedEventArgs e)
        {
            var PretragaProzor = new PretragaKorsnikaWindow();
            Close();
            PretragaProzor.ShowDialog();

        }

        private void SortirajK_Click(object sender, RoutedEventArgs e)
        {
            string tip = cbTipSortiranjaK.Text;

            if (tip == "Po ID")
            {
                List<Korisnik> sortirana = Projekat.Instance.Korisnik.OrderBy(o => o.Id).ToList();
                OsveziPrikaz(Projekat.Instance.Namestaj, sortirana, Projekat.Instance.Akcija, Projekat.Instance.TipNamestaja);
            }
            else if (tip == "Po imenu")
            {
                List<Korisnik> sortirana = Projekat.Instance.Korisnik.OrderBy(o => o.Ime).ToList();
                OsveziPrikaz(Projekat.Instance.Namestaj, sortirana, Projekat.Instance.Akcija, Projekat.Instance.TipNamestaja);
            }
            else if (tip == "Po prezimenu")
            {
                List<Korisnik> sortirana = Projekat.Instance.Korisnik.OrderBy(o => o.Prezime).ToList();
                OsveziPrikaz(Projekat.Instance.Namestaj, sortirana, Projekat.Instance.Akcija, Projekat.Instance.TipNamestaja);
            }
            else if (tip == "Po korisnickom imenu")
            {
                List<Korisnik> sortirana = Projekat.Instance.Korisnik.OrderBy(o => o.KorisnickoIme).ToList();
                OsveziPrikaz(Projekat.Instance.Namestaj, sortirana, Projekat.Instance.Akcija, Projekat.Instance.TipNamestaja);
            }
            else if (tip == "Po lozinci")
            {
                List<Korisnik> sortirana = Projekat.Instance.Korisnik.OrderBy(o => o.Lozinka).ToList();
                OsveziPrikaz(Projekat.Instance.Namestaj, sortirana, Projekat.Instance.Akcija, Projekat.Instance.TipNamestaja);
            }

        }

        private void DodajA_Click(object sender, RoutedEventArgs e)
        {
            var novaAkcija = new Akcija()
            {
                DatumPocetka = new DateTime(),
                DatumZavrsetka = new DateTime(),
                Popust = 0,
                NamestajNaPopustuId = new List<int>()
            };
            var AkcijaProzor = new AkcijaWindow(novaAkcija, AkcijaWindow.OperacijaA.Dodavanje);
            AkcijaProzor.ShowDialog();
            OsveziPrikaz(Projekat.Instance.Namestaj, Projekat.Instance.Korisnik, Projekat.Instance.Akcija, Projekat.Instance.TipNamestaja);
        }

        private void IzmeniA_Click(object sender, RoutedEventArgs e)
        {
            var izabranaAkcija = (Akcija)lbAkcije.SelectedItem;
            var AkcijaProzor = new AkcijaWindow(izabranaAkcija, AkcijaWindow.OperacijaA.Izmena);
            AkcijaProzor.ShowDialog();
            OsveziPrikaz(Projekat.Instance.Namestaj, Projekat.Instance.Korisnik, Projekat.Instance.Akcija, Projekat.Instance.TipNamestaja);
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
                OsveziPrikaz(Projekat.Instance.Namestaj, Projekat.Instance.Korisnik, Projekat.Instance.Akcija, Projekat.Instance.TipNamestaja);
            }
        }

        private void SortirajA_Click(object sender, RoutedEventArgs e)
        {
            string tip = cbTipSortiranjaA.Text;

            if (tip == "Po ID")
            {
                List<Akcija> sortirana = Projekat.Instance.Akcija.OrderBy(o => o.Id).ToList();
                OsveziPrikaz(Projekat.Instance.Namestaj, Projekat.Instance.Korisnik, sortirana, Projekat.Instance.TipNamestaja);
            }
            else if (tip == "Po datumu pocetka")
            {
                List<Akcija> sortirana = Projekat.Instance.Akcija.OrderBy(o => o.DatumPocetka).ToList();
                OsveziPrikaz(Projekat.Instance.Namestaj, Projekat.Instance.Korisnik, sortirana, Projekat.Instance.TipNamestaja);
            }
            else if (tip == "Po datumu zavrsetka")
            {
                List<Akcija> sortirana = Projekat.Instance.Akcija.OrderBy(o => o.DatumZavrsetka).ToList();
                OsveziPrikaz(Projekat.Instance.Namestaj, Projekat.Instance.Korisnik, sortirana, Projekat.Instance.TipNamestaja);
            }
            else if (tip == "Po popustu")
            {
                List<Akcija> sortirana = Projekat.Instance.Akcija.OrderBy(o => o.Popust).ToList();
                OsveziPrikaz(Projekat.Instance.Namestaj, Projekat.Instance.Korisnik, sortirana, Projekat.Instance.TipNamestaja);
            }

        }

        private void Izadji_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
