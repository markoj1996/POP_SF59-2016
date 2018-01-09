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
    /// Interaction logic for ProdavacGlavniWindow.xaml
    /// </summary>
    public partial class ProdavacGlavniWindow : Window
    {
        public ProdajaNamestaja izabranaProdaja { get; set; }

        public enum Operacija
        {
            Dodavanje,
            Izmena
        }

        public ProdavacGlavniWindow(ObservableCollection<ProdajaNamestaja>prodaja)
        {
            InitializeComponent();
            ProdajeKolone(prodaja);
        }

        private void ProdajeKolone(ObservableCollection<ProdajaNamestaja>prodaja)
        { 
            /*DataGridTextColumn column1 = new DataGridTextColumn();
            column1.Header = "Id";
            column1.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column1.Binding = new Binding("Id");
            dgProdaje.Columns.Add(column1);*/

            DataGridTextColumn column2 = new DataGridTextColumn();
            column2.Header = "Datum Prodaje";
            column2.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column2.Binding = new Binding("DatumProdaje");
            dgProdaje.Columns.Add(column2);


            DataGridTextColumn column3 = new DataGridTextColumn();
            column3.Header = "Kupac";
            column3.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column3.Binding = new Binding("Kupac");
            dgProdaje.Columns.Add(column3);

            DataGridTextColumn column4 = new DataGridTextColumn();
            column4.Header = "Broj Racuna";
            column4.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column4.Binding = new Binding("BrojRacuna");
            dgProdaje.Columns.Add(column4);

            dgProdaje.ItemsSource = prodaja;
            dgProdaje.IsSynchronizedWithCurrentItem = true;
            dgProdaje.DataContext = this;
        }
         private void DodajP_Click(object sender, RoutedEventArgs e)
         {
             var novaProdaja = new ProdajaNamestaja()
             {
                 
             };
             var ProdajaProzor = new ProdajaWindow(novaProdaja, ProdajaWindow.Operacija.Dodavanje);
             ProdajaProzor.ShowDialog();
         }

         private void IzmeniP_Click(object sender, RoutedEventArgs e)
         {
             ProdajaNamestaja kopija = (ProdajaNamestaja)izabranaProdaja.Clone();
             var ProdajaProzor = new ProdajaWindow(izabranaProdaja, ProdajaWindow.Operacija.Izmena);
             ProdajaProzor.ShowDialog();
         }


        private void PretraziP_Click(object sender, RoutedEventArgs e)
        {
             var PretragaProzor = new PretragaProdajaWindow();
             Close();
             PretragaProzor.ShowDialog();

        }

        private void Detalji_Click(object sender, RoutedEventArgs e)
        {
            DetaljiWindow dw = new DetaljiWindow(izabranaProdaja);
            dw.Show();
        }

        private void Osvezi_Click(object sender, RoutedEventArgs e)
         {
             dgProdaje.Columns.Clear();
             ProdajeKolone(Aplikacija.Instance.Prodaja);
         }

         private void Izadji_Click(object sender, RoutedEventArgs e)
         {
             Close();
         }
    }
}
