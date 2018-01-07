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
    /// Interaction logic for ObrisiUsluguProdaje.xaml
    /// </summary>
    public partial class ObrisiUsluguProdaje : Window
    {
        public DodatnaUsluga izabranaUsluga { get; set; }
        ProdajaNamestaja prodaja;

        public ObrisiUsluguProdaje(ProdajaNamestaja prodaja)
        {
            InitializeComponent();
            this.prodaja = prodaja;
            UslugeKolone();
        }

        private void UslugeKolone()
        {
            List<DodatnaUsluga> usluge = new List<DodatnaUsluga>();
            foreach (var id in prodaja.DodatneUsluge)
            {
                foreach (var n in Aplikacija.Instance.DodatnaUsluga)
                {
                    if (id == n.Id)
                    {
                        usluge.Add(n);
                    }
                }
            }

            DataGridTextColumn column1 = new DataGridTextColumn();
            column1.Header = "Id";
            column1.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column1.Binding = new Binding("Id");
            dgDodatneUsluge.Columns.Add(column1);

            DataGridTextColumn column2 = new DataGridTextColumn();
            column2.Header = "Naziv";
            column2.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column2.Binding = new Binding("Naziv");
            dgDodatneUsluge.Columns.Add(column2);

            DataGridTextColumn column3 = new DataGridTextColumn();
            column3.Header = "Ukupna cena";
            column3.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column3.Binding = new Binding("UkupanIznos");
            dgDodatneUsluge.Columns.Add(column3);


            dgDodatneUsluge.ItemsSource = usluge;
            dgDodatneUsluge.IsSynchronizedWithCurrentItem = true;
            dgDodatneUsluge.DataContext = this;
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            prodaja.DodatneUsluge.Remove(izabranaUsluga.Id);
            Close();
        }
        private void Izadji_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
