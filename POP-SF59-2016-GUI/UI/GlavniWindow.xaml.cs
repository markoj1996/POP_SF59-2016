using POP_SF59_2016.Model;
using POP_SF59_2016.Util1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public Namestaj izabraniNamestaj { get; set; }
        public Korisnik izabraniKorisnik { get; set; }
        public TipNamestaja izabraniTip { get; set; }
        public Akcija izabranaAkcija { get; set; }

        public enum Operacija
        {
            Dodavanje,
            Izmena
        }
        public GlavniWindow(ObservableCollection<Namestaj>namestaj, ObservableCollection<Korisnik>korisnici, ObservableCollection<Akcija>akcije, ObservableCollection<TipNamestaja>tipNamestaja)
        {
            InitializeComponent();
            NamestajKolone(namestaj);
            KorisnikKolone(korisnici);
            AkcijeKolone(akcije);
            TipKolone(tipNamestaja);

        }

        private void NamestajKolone(ObservableCollection<Namestaj> namestaj)
        { 
            DataGridTextColumn column1 = new DataGridTextColumn();
            column1.Header = "Id";
            column1.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column1.Binding = new Binding("Id");
            dgNamestaj.Columns.Add(column1);

            DataGridTextColumn column2 = new DataGridTextColumn();
            column2.Header = "Naziv";
            column2.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column2.Binding = new Binding("Naziv");
            dgNamestaj.Columns.Add(column2);


            DataGridTextColumn column3 = new DataGridTextColumn();
            column3.Header = "Cena";
            column3.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column3.Binding = new Binding("JedinicnaCena");
            dgNamestaj.Columns.Add(column3);

            DataGridTextColumn column4 = new DataGridTextColumn();
            column4.Header = "Kolicina";
            column4.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column4.Binding = new Binding("KolicinaUMagacinu");
            dgNamestaj.Columns.Add(column4);

            DataGridTextColumn column5 = new DataGridTextColumn();
            column5.Header = "Tip namestaja";
            column5.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column5.Binding = new Binding("TipNamestaja");
            dgNamestaj.Columns.Add(column5);

            dgNamestaj.ItemsSource = namestaj;
            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            dgNamestaj.DataContext = this;
        }

        private void DodajN_Click(object sender, RoutedEventArgs e)
        {
            var noviNamestaj = new Namestaj()
            {
                Naziv = ""
            };
            var NamestajProzor = new NamestajWindow(noviNamestaj, NamestajWindow.Operacija.Dodavanje);
            NamestajProzor.ShowDialog();
        }

        private void IzmeniN_Click(object sender, RoutedEventArgs e)
        {

            Namestaj kopija = (Namestaj)izabraniNamestaj.Clone();
            var NamestajProzor = new NamestajWindow(kopija, NamestajWindow.Operacija.Izmena);
            NamestajProzor.ShowDialog();
        }

        private void ObrisiN_Click(object sender, RoutedEventArgs e)
        {
            var listaNamestaja = Projekat.Instance.Namestaj;

            if (MessageBox.Show($"Da li zelite da obrisete: {izabraniNamestaj.Naziv}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var n in listaNamestaja)
                {
                    if (n.Id == izabraniNamestaj.Id)
                    {
                        n.Obrisan = true;
                        break;
                    }
                }
                GenericSerialize.Serialize("namestaj.xml", listaNamestaja);
            }
        }

        private void PretraziN_Click(object sender, RoutedEventArgs e)
        {
            var PretragaProzor = new PretragaNamestajaWindow();
            Close();
            PretragaProzor.ShowDialog();

        }

        private void Osvezi_Click(object sender, RoutedEventArgs e)
        {
            dgNamestaj.Columns.Clear();
            dgKorisnici.Columns.Clear();
            dgAkcije.Columns.Clear();
            dgTipNamestaja.Columns.Clear();
            NamestajKolone(Projekat.Instance.Namestaj);
            KorisnikKolone(Projekat.Instance.Korisnik);
            AkcijeKolone(Projekat.Instance.Akcija);
            TipKolone(Projekat.Instance.TipNamestaja);
        }

        private void TipKolone(ObservableCollection<TipNamestaja> tipNamestaja)
        {
            DataGridTextColumn column1 = new DataGridTextColumn();
            column1.Header = "Id";
            column1.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column1.Binding = new Binding("Id");
            dgTipNamestaja.Columns.Add(column1);

            DataGridTextColumn column2 = new DataGridTextColumn();
            column2.Header = "Naziv";
            column2.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column2.Binding = new Binding("Naziv");
            dgTipNamestaja.Columns.Add(column2);

            dgTipNamestaja.ItemsSource = tipNamestaja;
            dgTipNamestaja.IsSynchronizedWithCurrentItem = true;
            dgTipNamestaja.DataContext = this;
        }

        private void DodajT_Click(object sender, RoutedEventArgs e)
        {

            var noviTipNamestaja = new TipNamestaja()
            {
                Naziv = ""
            };
            var TipNamestajaProzor = new TipNamestajaWindow(noviTipNamestaja, TipNamestajaWindow.OperacijaT.Dodavanje);
            TipNamestajaProzor.ShowDialog();
        }

        private void IzmeniT_Click(object sender, RoutedEventArgs e)
        {
            TipNamestaja kopija = (TipNamestaja)izabraniTip.Clone();
            var TipNamestajaProzor = new TipNamestajaWindow(kopija, TipNamestajaWindow.OperacijaT.Izmena);
            TipNamestajaProzor.ShowDialog();
        }

        private void ObrisiT_Click(object sender, RoutedEventArgs e)
        {
            var listaTipaNamestaja = Projekat.Instance.TipNamestaja;

            if (MessageBox.Show($"Da li zelite da obrisete: {izabraniTip.Naziv}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var n in listaTipaNamestaja)
                {
                    if (n.Id == izabraniTip.Id)
                    {
                        n.Obrisan = true;
                        break;
                    }
                }
                GenericSerialize.Serialize("tipNamestaja.xml", listaTipaNamestaja);
            }
        }

        private void PretraziT_Click(object sender, RoutedEventArgs e)
        {
            var PretragaProzor = new PretragaTipaNamestajaWindow();
            Close();
            PretragaProzor.ShowDialog();

        }

        private void KorisnikKolone(ObservableCollection<Korisnik> korisnici)
        {
            DataGridTextColumn column1 = new DataGridTextColumn();
            column1.Header = "Id";
            column1.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column1.Binding = new Binding("Id");
            dgKorisnici.Columns.Add(column1);

            DataGridTextColumn column2 = new DataGridTextColumn();
            column2.Header = "Ime";
            column2.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column2.Binding = new Binding("Ime");
            dgKorisnici.Columns.Add(column2);


            DataGridTextColumn column3 = new DataGridTextColumn();
            column3.Header = "Prezime";
            column3.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column3.Binding = new Binding("Prezime");
            dgKorisnici.Columns.Add(column3);

            DataGridTextColumn column4 = new DataGridTextColumn();
            column4.Header = "Korisnicko ime";
            column4.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column4.Binding = new Binding("KorisnickoIme");
            dgKorisnici.Columns.Add(column4);

            DataGridTextColumn column5 = new DataGridTextColumn();
            column5.Header = "Lozinka";
            column5.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column5.Binding = new Binding("Lozinka");
            dgKorisnici.Columns.Add(column5);

            DataGridTextColumn column6 = new DataGridTextColumn();
            column6.Header = "Tip korisnika";
            column6.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column6.Binding = new Binding("TipKorisnika");
            dgKorisnici.Columns.Add(column6);

            dgKorisnici.ItemsSource = korisnici;
            dgKorisnici.IsSynchronizedWithCurrentItem = true;
            dgKorisnici.DataContext = this;
        }
        private void DodajK_Click(object sender, RoutedEventArgs e)
        {
            var noviKorisnik = new Korisnik()
            {
                Ime = "",
            };
            var KorisnikProzor = new KorisnikWindow(noviKorisnik, KorisnikWindow.OperacijaK.Dodavanje);
            KorisnikProzor.ShowDialog();
        }

        private void IzmeniK_Click(object sender, RoutedEventArgs e)
        {
            Korisnik kopija = (Korisnik)izabraniKorisnik.Clone();
            var KorisnikProzor = new KorisnikWindow(kopija, KorisnikWindow.OperacijaK.Izmena);
            KorisnikProzor.ShowDialog();
        }

        private void ObrisiK_Click(object sender, RoutedEventArgs e)
        {
            var listaKorisnika = Projekat.Instance.Korisnik;

            if (MessageBox.Show($"Da li zelite da obrisete: {izabraniKorisnik.Ime}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var k in listaKorisnika)
                {
                    if (k.Id == izabraniKorisnik.Id)
                    {
                        k.Obrisan = true;
                        break;
                    }
                }
                GenericSerialize.Serialize("korisnicij.xml", listaKorisnika);
            }
        }

        private void PretraziK_Click(object sender, RoutedEventArgs e)
        {
            var PretragaProzor = new PretragaKorsnikaWindow();
            Close();
            PretragaProzor.ShowDialog();

        }

        private void AkcijeKolone(ObservableCollection<Akcija> akcije)
        {
            DataGridTextColumn column1 = new DataGridTextColumn();
            column1.Header = "Id";
            column1.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column1.Binding = new Binding("Id");
            dgAkcije.Columns.Add(column1);

            DataGridTextColumn column2 = new DataGridTextColumn();
            column2.Header = "Datum pocetka";
            column2.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column2.Binding = new Binding("DatumPocetka");
            dgAkcije.Columns.Add(column2);

            DataGridTextColumn column3 = new DataGridTextColumn();
            column3.Header = "Datum zavrsetka";
            column3.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column3.Binding = new Binding("DatumZavrsetka");
            dgAkcije.Columns.Add(column3);

            DataGridTextColumn column4 = new DataGridTextColumn();
            column4.Header = "Popust";
            column4.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column4.Binding = new Binding("Popust");
            dgAkcije.Columns.Add(column4);

            dgAkcije.ItemsSource = akcije;
            dgAkcije.IsSynchronizedWithCurrentItem = true;
            dgAkcije.DataContext = this;
        }

        private void DodajA_Click(object sender, RoutedEventArgs e)
        {
            var novaAkcija = new Akcija()
            {
                
            };
            var AkcijaProzor = new AkcijaWindow(novaAkcija, AkcijaWindow.OperacijaA.Dodavanje);
            AkcijaProzor.ShowDialog();
        }
        private void IzmeniA_Click(object sender, RoutedEventArgs e)
        {
            Akcija kopija = (Akcija)izabranaAkcija.Clone();
            var AkcijaProzor = new AkcijaWindow(kopija, AkcijaWindow.OperacijaA.Izmena);
            AkcijaProzor.ShowDialog();
        }

        private void ObrisiA_Click(object sender, RoutedEventArgs e)
        {
            var listaAkcija = Projekat.Instance.Akcija;

            if (MessageBox.Show($"Da li zelite da obrisete: {izabranaAkcija.Id}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var a in listaAkcija)
                {
                    if (a.Id == izabranaAkcija.Id)
                    {
                        //a.Obrisan = true;
                        break;
                    }
                }
                GenericSerialize.Serialize("akcije.xml", listaAkcija);
            }
        }
        private void Izadji_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
