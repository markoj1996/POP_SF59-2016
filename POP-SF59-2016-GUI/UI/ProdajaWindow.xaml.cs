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

        public Namestaj izabraniNamestaj { get; set; }

        public ProdajaWindow(ProdajaNamestaja prodaja, Operacija operacija)
        {
            InitializeComponent();

            this.prodaja = prodaja;
            this.operacija = operacija;

            tbKupac.DataContext = prodaja;
            tbBrojRacuna.DataContext = prodaja;
            dgNamestaj.DataContext = prodaja;

            NamestajKolone();
            UslugeKolone();
            
        }

        private void UslugeKolone()
        {

            DataGridTextColumn column1 = new DataGridTextColumn();
            column1.Header = "Id";
            column1.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column1.Binding = new Binding();
            dgUsluge.Columns.Add(column1);

            /*DataGridTextColumn column2 = new DataGridTextColumn();
            column2.Header = "Naziv";
            column2.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column2.Binding = new Binding("Naziv");
            dgUsluge.Columns.Add(column2);


            DataGridTextColumn column3 = new DataGridTextColumn();
            column3.Header = "Cena";
            column3.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column3.Binding = new Binding("UkupanIznos");
            dgUsluge.Columns.Add(column3);*/

            dgUsluge.ItemsSource = prodaja.DodatneUsluge;
            dgUsluge.IsSynchronizedWithCurrentItem = true;
            dgUsluge.DataContext = this;
        }

        private void NamestajKolone()
        {
            dgNamestaj.ItemsSource = prodaja.NamestajZaProdajuId;
            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            dgNamestaj.DataContext = this;

            DataGridTextColumn column1 = new DataGridTextColumn();
            column1.Header = "Id";
            column1.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column1.Binding = new Binding();
            dgNamestaj.Columns.Add(column1);

            /*DataGridTextColumn column2 = new DataGridTextColumn();
            column2.Header = "Naziv";
            column2.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column2.Binding = new Binding("Naziv");
            dgNamestaj.Columns.Add(column2);

            DataGridTextColumn column3 = new DataGridTextColumn();
            column3.Header = "Cena";
            column3.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column3.Binding = new Binding("Cena");
            dgNamestaj.Columns.Add(column3);*/

            
        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            DateTime datum = DateTime.Now;
            var listaProdaja = Projekat.Instance.Prodaja;

            switch (operacija)
            {
                case Operacija.Dodavanje:
                    prodaja.Id = listaProdaja.Count + 1;
                    prodaja.DatumProdaje = datum;
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

        private void DodajN_Click(object sender, RoutedEventArgs e)
        {
            DodajNamestajZaProdaju dnp = new DodajNamestajZaProdaju(prodaja);
            dnp.ShowDialog();
        }

        private void DodajU_Click(object sender, RoutedEventArgs e)
        {
            DodajUsluguZaProdaju dnp = new DodajUsluguZaProdaju(prodaja);
            dnp.ShowDialog();          
        }

        private void Izadji(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
