using POP_SF59_2016.Model;
using POP_SF59_2016_GUI.UI;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POP_SF59_2016_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            OsveziPrikaz();
        }

        private void OsveziPrikaz()
        {
            lbNamestaj.Items.Clear();

            foreach (var tipNamestaja in Projekat.Instance.TipNamestaja)
            {
                if (tipNamestaja.Obrisan == false)
                {
                    lbNamestaj.Items.Add(tipNamestaja);
                }

            }
            lbNamestaj.SelectedIndex = 0;
        }


        private void DodajNamestaj_Click(object sender, RoutedEventArgs e)
        {
            var noviTipNamestaja = new TipNamestaja()
            {
                Naziv = ""
            };
            var TipNamestajaProzor = new TipNamestajaWindow(noviTipNamestaja,TipNamestajaWindow.OperacijaT.Dodavanje);
            TipNamestajaProzor.ShowDialog();
            OsveziPrikaz();
        }

        private void IzmeniNamestaj_Click(object sender, RoutedEventArgs e)
        {
            var izabraniTipNamestaja =(TipNamestaja) lbNamestaj.SelectedItem;
            var TipNamestajaProzor = new TipNamestajaWindow(izabraniTipNamestaja, TipNamestajaWindow.OperacijaT.Izmena);
            TipNamestajaProzor.ShowDialog();
            OsveziPrikaz();
        }

        private void Zatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Obrisi_Click(object sender, RoutedEventArgs e)
        {
            var izabranTipNamestaja = (TipNamestaja) lbNamestaj.SelectedItem;
            var listaTipaNamestaja = Projekat.Instance.TipNamestaja;

            if(MessageBox.Show($"Da li zelite da obrisete: {izabranTipNamestaja.Naziv}", "Brisanje", MessageBoxButton.YesNo)==MessageBoxResult.Yes)
            {
                foreach (var n in listaTipaNamestaja)
                {
                    if (n.Id == izabranTipNamestaja.Id)
                    {
                        n.Obrisan = true;
                    }
                }
                Projekat.Instance.TipNamestaja = listaTipaNamestaja;
                OsveziPrikaz();
            }
        }
    }
}
