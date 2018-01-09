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
    /// Interaction logic for DodajNamestajNaAkciju.xaml
    /// </summary>
    public partial class DodajNamestajNaAkciju : Window
    {
        public Namestaj izabraniNamestaj { get; set; }
        Akcija akcija;

        public DodajNamestajNaAkciju(Akcija akcija)
        {
            InitializeComponent();
            this.akcija = akcija;
            NamestajKolone();
        }

        private void NamestajKolone()
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
            column3.Binding = new Binding("CenaSaAkcijom");
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

            dgNamestaj.ItemsSource = Projekat.Instance.Namestaj;
            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            dgNamestaj.DataContext = this;
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            izabraniNamestaj.AkcijaId = akcija.Id;
            Close();
        }

        private void Izadji_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
