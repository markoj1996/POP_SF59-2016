using POP_SF59_2016.Model;
using POP_SF59_2016_GUI.Model;
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
    /// Interaction logic for DetaljiWindow.xaml
    /// </summary>
    public partial class DetaljiWindow : Window
    {

        double ukupno;
        List<double> ceneNamestaja = new List<double>();
        List<double> ceneUsluga = new List<double>();
        ProdajaNamestaja prodaja;

        public DetaljiWindow(ProdajaNamestaja prodaja)
        {
            InitializeComponent();
            this.prodaja = prodaja;

            tbDatum.DataContext = prodaja;
            tbKupac.DataContext = prodaja;
            tbBrojRacuna.DataContext = prodaja;
            NamestajKolone();
            UslugeKolone();

            tbUkupnaCena.Text = UkupnaCena().ToString();
        }

        public double UkupnaCena()
        {
            foreach (var cena in ceneNamestaja)
            {
                ukupno = ukupno + cena;
            }
            foreach (var cenaU in ceneUsluga)
            {
                ukupno = ukupno + cenaU;
            }
            return ukupno;
            
        }

        private void NamestajKolone()
        {
            List<Namestaj> listaProdatog = new List<Namestaj>();
            listaProdatog=Namestaj.UcitajProdatiNamestaj(prodaja);
         
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

            dgNamestaj.ItemsSource = listaProdatog;
            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            dgNamestaj.DataContext = this;
        }

        private void UslugeKolone()
        {

            List<DodatnaUsluga> listaUsluga = new List<DodatnaUsluga>();
            listaUsluga = DodatnaUsluga.UcitajUslugeProdaje(prodaja);

            DataGridTextColumn column1 = new DataGridTextColumn();
            column1.Header = "Id";
            column1.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column1.Binding = new Binding("Id");
            dgUsluge.Columns.Add(column1);

            DataGridTextColumn column2 = new DataGridTextColumn();
            column2.Header = "Naziv";
            column2.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column2.Binding = new Binding("Naziv");
            dgUsluge.Columns.Add(column2);


            DataGridTextColumn column3 = new DataGridTextColumn();
            column3.Header = "Cena";
            column3.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column3.Binding = new Binding("UkupanIznos");
            dgUsluge.Columns.Add(column3);

            dgUsluge.ItemsSource = listaUsluga;
            dgUsluge.IsSynchronizedWithCurrentItem = true;
            dgUsluge.DataContext = this;
        }
        private void Izadji_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
