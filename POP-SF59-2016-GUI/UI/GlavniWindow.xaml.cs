using POP_SF59_2016.Model;
using POP_SF59_2016.Util1;
using POP_SF59_2016_GUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        ICollectionView view;
        public Namestaj izabraniNamestaj { get; set; }
        public Korisnik izabraniKorisnik { get; set; }
        public TipNamestaja izabraniTip { get; set; }
        public Akcija izabranaAkcija { get; set; }
        public DodatnaUsluga izabranaUsluga { get; set; }

        public enum Operacija
        {
            Dodavanje,
            Izmena
        }
        public GlavniWindow()
        {
            InitializeComponent();
            
            NamestajKolone();
            KorisnikKolone();
            AkcijeKolone();
            TipKolone();
            UslugeKolone();

        }

        private void NamestajKolone()
        { 
            /*DataGridTextColumn column1 = new DataGridTextColumn();
            column1.Header = "Id";
            column1.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column1.Binding = new Binding("Id");
            dgNamestaj.Columns.Add(column1);*/

            DataGridTextColumn column2 = new DataGridTextColumn();
            column2.Header = "Naziv";
            column2.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column2.Binding = new Binding("Naziv");
            dgNamestaj.Columns.Add(column2);

            DataGridTextColumn column3 = new DataGridTextColumn();
            column3.Header = "Tip namestaja";
            column3.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column3.Binding = new Binding("TipNamestaja");
            dgNamestaj.Columns.Add(column3);

            DataGridTextColumn column4 = new DataGridTextColumn();
            column4.Header = "Kolicina";
            column4.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column4.Binding = new Binding("KolicinaUMagacinu");
            dgNamestaj.Columns.Add(column4);

            DataGridTextColumn column5 = new DataGridTextColumn();
            column5.Header = "Cena";
            column5.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column5.Binding = new Binding("CenaSaAkcijom");
            dgNamestaj.Columns.Add(column5);

            /*DataGridTextColumn column6 = new DataGridTextColumn();
            column6.Header = "Akcija Id";
            column6.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column6.Binding = new Binding("AkcijaId");
            dgNamestaj.Columns.Add(column6);*/


            view = CollectionViewSource.GetDefaultView(Aplikacija.Instance.Namestaj);
            view.Filter = NamestajFilter;
            dgNamestaj.ItemsSource = view;
            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            dgNamestaj.DataContext = this;
        }

        private bool NamestajFilter(object obj)
        {
            return !((Namestaj)obj).Obrisan;
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
            var listaNamestaja = Aplikacija.Instance.Namestaj;

            if (MessageBox.Show($"Da li zelite da obrisete: {izabraniNamestaj.Naziv}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var n in listaNamestaja)
                {
                    if (n.Id == izabraniNamestaj.Id)
                    {
                        n.Obrisan = true;
                        Namestaj.ObrisiNamestaj(izabraniNamestaj);
                        view.Refresh();
                        break;
                    }
                }
                //GenericSerialize.Serialize("namestaj.xml", listaNamestaja);
                
            }
        }

        private void PretraziN_Click(object sender, RoutedEventArgs e)
        {
            var PretragaProzor = new PretragaNamestajaWindow();
            Close();
            PretragaProzor.ShowDialog();

        }

        /*private void Osvezi_Click(object sender, RoutedEventArgs e)
        {
            dgNamestaj.Columns.Clear();
            dgKorisnici.Columns.Clear();
            dgAkcije.Columns.Clear();
            dgTipNamestaja.Columns.Clear();
            dgDodatneUsluge.Columns.Clear();
            NamestajKolone(Projekat.Instance.Namestaj);
            KorisnikKolone(Projekat.Instance.Korisnik);
            AkcijeKolone(Projekat.Instance.Akcija);
            TipKolone(Projekat.Instance.TipNamestaja);
            UslugeKolone(Projekat.Instance.DodatnaUsluga);
        }*/

        private void TipKolone()
        {
            /*DataGridTextColumn column1 = new DataGridTextColumn();
            column1.Header = "Id";
            column1.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column1.Binding = new Binding("Id");
            dgTipNamestaja.Columns.Add(column1);*/

            DataGridTextColumn column2 = new DataGridTextColumn();
            column2.Header = "Naziv";
            column2.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column2.Binding = new Binding("Naziv");
            dgTipNamestaja.Columns.Add(column2);

            view = CollectionViewSource.GetDefaultView(Aplikacija.Instance.TipNamestaja);
            view.Filter = tipNamestajaFilter;
            dgTipNamestaja.ItemsSource = view;
            dgTipNamestaja.IsSynchronizedWithCurrentItem = true;
            dgTipNamestaja.DataContext = this;
        }
        private bool tipNamestajaFilter(object obj)
        {
            return !((TipNamestaja)obj).Obrisan;
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
            var listaTipaNamestaja = Aplikacija.Instance.TipNamestaja;

            if (MessageBox.Show($"Bice obisani svi namestaji ovoga tipa.Da li zelite da obrisete: {izabraniTip.Naziv}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var n in listaTipaNamestaja)
                {
                    if (n.Id == izabraniTip.Id)
                    {
                        n.Obrisan = true;
                        TipNamestaja.ObrisiTip(izabraniTip);
                        foreach (var namestaj in Aplikacija.Instance.Namestaj)
                        {
                            if (namestaj.TipNamestajaId == izabraniTip.Id)
                            {
                                namestaj.Obrisan = true;
                                Namestaj.ObrisiNamestaj(namestaj);
                            }
                        }
                        view.Refresh();
                        break;
                    }
                }
                //GenericSerialize.Serialize("tipNamestaja.xml", listaTipaNamestaja);
            }
        }

        private void PretraziT_Click(object sender, RoutedEventArgs e)
        {
            var PretragaProzor = new PretragaTipaNamestajaWindow();
            Close();
            PretragaProzor.ShowDialog();

        }

        private void KorisnikKolone()
        {
            /*DataGridTextColumn column1 = new DataGridTextColumn();
            column1.Header = "Id";
            column1.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column1.Binding = new Binding("Id");
            dgKorisnici.Columns.Add(column1);*/

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


            view = CollectionViewSource.GetDefaultView(Aplikacija.Instance.Korisnik);

            view.Filter = KorisnikFilter;
            dgKorisnici.ItemsSource = view;
            dgKorisnici.IsSynchronizedWithCurrentItem = true;
            dgKorisnici.DataContext = this;
        }
        private bool KorisnikFilter(object obj)
        {
            return !((Korisnik)obj).Obrisan;
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
            var listaKorisnika = Aplikacija.Instance.Korisnik;

            if (MessageBox.Show($"Da li zelite da obrisete: {izabraniKorisnik.Ime}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var k in listaKorisnika)
                {
                    if (k.Id == izabraniKorisnik.Id)
                    {
                        k.Obrisan = true;
                        Korisnik.ObrisiKorisnika(izabraniKorisnik);
                        view.Refresh();
                        break;
                    }
                }
                //GenericSerialize.Serialize("korisnici.xml", listaKorisnika);
            }
        }

        private void PretraziK_Click(object sender, RoutedEventArgs e)
        {
            var PretragaProzor = new PretragaKorsnikaWindow();
            Close();
            PretragaProzor.ShowDialog();

        }

        private void AkcijeKolone()
        {
            /*DataGridTextColumn column1 = new DataGridTextColumn();
            column1.Header = "Id";
            column1.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column1.Binding = new Binding("Id");
            dgAkcije.Columns.Add(column1);*/

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

            view = CollectionViewSource.GetDefaultView(Aplikacija.Instance.Akcija);

            view.Filter = AkcijaFilter;
            dgAkcije.ItemsSource = view;
            dgAkcije.IsSynchronizedWithCurrentItem = true;
            dgAkcije.DataContext = this;
        }
        private bool AkcijaFilter(object obj)
        {
            return !((Akcija)obj).Obrisan;
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
            var listaAkcija = Aplikacija.Instance.Akcija;

            if (MessageBox.Show($"Da li zelite da obrisete: {izabranaAkcija.Id}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var a in listaAkcija)
                {
                    if (a.Id == izabranaAkcija.Id)
                    {
                        a.Obrisan = true;
                        Akcija.ObrisiAkciju(izabranaAkcija);
                        foreach (var n in Aplikacija.Instance.Namestaj)
                        {
                            if (n.AkcijaId == izabranaAkcija.Id)
                            {
                                n.AkcijaId = 0;
                                n.CenaSaAkcijom = n.CenaSaAkcijom;
                                Namestaj.IzmeniNamestaj(n);
                            }
                        }
                        view.Refresh();
                        break;
                    }
                }
                //GenericSerialize.Serialize("akcije.xml", listaAkcija);
            }
        }

        private void UslugeKolone()
        {
            /*DataGridTextColumn column1 = new DataGridTextColumn();
            column1.Header = "Id";
            column1.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column1.Binding = new Binding("Id");
            dgDodatneUsluge.Columns.Add(column1);*/

            DataGridTextColumn column2 = new DataGridTextColumn();
            column2.Header = "Naziv";
            column2.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column2.Binding = new Binding("Naziv");
            dgDodatneUsluge.Columns.Add(column2);

            DataGridTextColumn column4 = new DataGridTextColumn();
            column4.Header = "PDV";
            column4.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column4.Binding = new Binding("PDV");
            dgDodatneUsluge.Columns.Add(column4);

            DataGridTextColumn column3 = new DataGridTextColumn();
            column3.Header = "Ukupna cena";
            column3.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column3.Binding = new Binding("UkupanIznos");
            dgDodatneUsluge.Columns.Add(column3);

            view = CollectionViewSource.GetDefaultView(Aplikacija.Instance.DodatnaUsluga);

            view.Filter = UslugaFilter;
            dgDodatneUsluge.ItemsSource = view;
            dgDodatneUsluge.IsSynchronizedWithCurrentItem = true;
            dgDodatneUsluge.DataContext = this;
        }

        private bool UslugaFilter(object obj)
        {
            return !((DodatnaUsluga)obj).Obrisan;
        }

        private void DodajU_Click(object sender, RoutedEventArgs e)
        {
            var novaUsluga = new DodatnaUsluga()
            {

            };
            var UslugaProzor = new UslugaWindow(novaUsluga, UslugaWindow.OperacijaU.Dodavanje);
            UslugaProzor.ShowDialog();
        }
        private void IzmeniU_Click(object sender, RoutedEventArgs e)
        {
            DodatnaUsluga kopija = (DodatnaUsluga)izabranaUsluga.Clone();
            var UslugaProzor = new UslugaWindow(kopija, UslugaWindow.OperacijaU.Izmena);
            UslugaProzor.ShowDialog();
        }

        private void ObrisiU_Click(object sender, RoutedEventArgs e)
        {
            var listaUsluga = Aplikacija.Instance.DodatnaUsluga;

            if (MessageBox.Show($"Da li zelite da obrisete: {izabranaUsluga.Naziv}", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var u in listaUsluga)
                {
                    if (u.Id == izabranaUsluga.Id)
                    {
                        u.Obrisan = true;
                        DodatnaUsluga.ObrisiUslugu(izabranaUsluga);
                        view.Refresh();
                        break;
                    }
                }
                //GenericSerialize.Serialize("usluge.xml", listaUsluga);
            }
        }

        private void PretraziU_Click(object sender, RoutedEventArgs e)
        {
            var PretragaProzor = new PretragaUslugaWindow();
            Close();
            PretragaProzor.ShowDialog();

        }

        private void Izadji_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
