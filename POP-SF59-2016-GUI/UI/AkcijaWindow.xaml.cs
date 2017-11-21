using POP_SF59_2016.Model;
using POP_SF59_2016.Util1;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for AkcijaWindow.xaml
    /// </summary>
    public partial class AkcijaWindow : Window
    {
        public Namestaj izabraniNamestaj { get; set; }

        public enum OperacijaA
        {
            Dodavanje,
            Izmena
        }

        private Akcija akcija;
        private OperacijaA operacija;

        public AkcijaWindow(Akcija akcija,OperacijaA operacija)
        {
            InitializeComponent();
            this.akcija = akcija;
            this.operacija = operacija;

            tbDatumPocetka.DataContext = akcija;
            tbDatumZavrsetka.DataContext = akcija;
            tbPopust.DataContext = akcija;
            dgNamestaj.DataContext = akcija;

            NamestajKolone();
        }

        private void NamestajKolone()
        {
            List<Namestaj> nadjeni= new List<Namestaj>();
            foreach (var a in akcija.NamestajNaPopustuId)
            {
                nadjeni.Add(Namestaj.GetById(a));     
            }
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

            dgNamestaj.ItemsSource = nadjeni;
            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            dgNamestaj.DataContext = this;
        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listaAkcija = Projekat.Instance.Akcija;

            switch (operacija)
            {
                case OperacijaA.Dodavanje:
                    akcija.Id = listaAkcija.Count + 1;
                    listaAkcija.Add(akcija);
                    break;
                case OperacijaA.Izmena:
                    foreach (var a in listaAkcija)
                    {
                        if (a.Id == akcija.Id)
                        {
                            a.Obrisan = akcija.Obrisan;
                            a.DatumPocetka = akcija.DatumPocetka;
                            a.DatumZavrsetka = akcija.DatumZavrsetka;
                            a.Popust = akcija.Popust;
                            a.NamestajNaPopustuId = akcija.NamestajNaPopustuId;
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }
            GenericSerialize.Serialize("akcije.xml", listaAkcija);
            Close();
        }

        private void Izadji(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            DodajNamestajNaAkciju dna = new DodajNamestajNaAkciju(akcija);
            dna.ShowDialog();
        }
    }
}
