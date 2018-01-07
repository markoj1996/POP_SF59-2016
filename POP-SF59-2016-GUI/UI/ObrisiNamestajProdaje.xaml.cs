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
    /// Interaction logic for ObrisiNamestajProdaje.xaml
    /// </summary>
    public partial class ObrisiNamestajProdaje : Window
    {
        public Namestaj izabraniNamestaj { get; set; }
        ProdajaNamestaja prodaja;

        public ObrisiNamestajProdaje(ProdajaNamestaja prodaja)
        {
            InitializeComponent();
            this.prodaja = prodaja;
            NamestajKolone();
        }

        private void NamestajKolone()
        {
            List<Namestaj> namestaj = new List<Namestaj>();
            foreach (var id in prodaja.NamestajZaProdajuId)
            {
                foreach (var n in Aplikacija.Instance.Namestaj)
                {
                    if (id == n.Id)
                    {
                        namestaj.Add(n);
                    }
                }
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

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            prodaja.NamestajZaProdajuId.Remove(izabraniNamestaj.Id);
            Close();
        }

        private void Izadji_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
