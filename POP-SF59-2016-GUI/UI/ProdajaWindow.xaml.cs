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
    /// Interaction logic for ProdajaWindow.xaml
    /// </summary>
    public partial class ProdajaWindow : Window
    {
        private ProdajaNamestaja prodaja;
        private Operacija operacija;

        public enum Operacija
        {
            Dodavanje,
            Izmena
        }

        private Namestaj izabraniNamestaj;

        public ProdajaWindow(ProdajaNamestaja prodaja, Operacija operacija)
        {
            InitializeComponent();

            this.prodaja = prodaja;
            this.operacija = operacija;

            tbDatumProdaje.DataContext = prodaja;
            tbKupac.DataContext = prodaja;
            tbBrojRacuna.DataContext = prodaja;
            dgNamestaj.DataContext = prodaja;

            NamestajKolone();
        }

        private void NamestajKolone()
        {
            List<Namestaj> nadjeni = new List<Namestaj>();
            foreach (var a in prodaja.NamestajZaProdajuId)
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

            DataGridTextColumn column3 = new DataGridTextColumn();
            column3.Header = "Cena";
            column3.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column3.Binding = new Binding("JedinicnaCena");
            dgNamestaj.Columns.Add(column3);

            dgNamestaj.ItemsSource = nadjeni;
            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            dgNamestaj.DataContext = this;
        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listaProdaja = Projekat.Instance.Prodaja;

            switch (operacija)
            {
                case Operacija.Dodavanje:
                    prodaja.Id = listaProdaja.Count + 1;
                    listaProdaja.Add(prodaja);
                    break;
                case Operacija.Izmena:
                    foreach (var a in listaProdaja)
                    {
                        if (a.Id == prodaja.Id)
                        {
                            a.Obrisan = prodaja.Obrisan;
                            a.DatumProdaje = prodaja.DatumProdaje;
                            a.BrojRacuna = prodaja.BrojRacuna;
                            a.Kupac = prodaja.Kupac;
                            a.NamestajZaProdajuId = prodaja.NamestajZaProdajuId;
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }
            GenericSerialize.Serialize("prodaje.xml", listaProdaja);
            Close();
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            DodajNamestajZaProdaju dnp = new DodajNamestajZaProdaju(prodaja);
            dnp.ShowDialog();
        }

        private void Izadji(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
