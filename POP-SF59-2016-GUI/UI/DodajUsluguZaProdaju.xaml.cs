using POP_SF59_2016.Model;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for DodajUsluguNaAkciju.xaml
    /// </summary>
    public partial class DodajUsluguZaProdaju : Window
    {

        ICollectionView view;
        public DodatnaUsluga izabranaUsluga { get; set; }
        ProdajaNamestaja prodaja;

        public DodajUsluguZaProdaju(ProdajaNamestaja prodaja)
        {
            InitializeComponent();
            this.prodaja = prodaja;
            UslugeKolone();
        }

        private void UslugeKolone()
        {
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

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.DodatnaUsluga);
            view.Filter = UslugaFilter;
            dgUsluge.ItemsSource = Projekat.Instance.DodatnaUsluga;
            dgUsluge.IsSynchronizedWithCurrentItem = true;
            dgUsluge.DataContext = this;
        }

        private bool UslugaFilter(object obj)
        {
            return !((DodatnaUsluga)obj).Obrisan;
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            prodaja.DodatneUsluge.Add(izabranaUsluga.Id);
            Close();
        }

        private void Izadji_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
