using POP_SF59_2016.Model;
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
    /// Interaction logic for PretragaProdajaWindow.xaml
    /// </summary>
    public partial class PretragaProdajaWindow : Window
    {
        public PretragaProdajaWindow()
        {
            InitializeComponent();
        }

        private void PretragaNaziva(object sender, RoutedEventArgs e)
        {
            var listaProdaja = Projekat.Instance.Prodaja;
            string tip = cbTipPretrage.Text;
            ObservableCollection<ProdajaNamestaja> prodaje = new ObservableCollection<ProdajaNamestaja>();

            if (tip == "Po kupcu")
            {
                string ime = tbPronadji.Text;
                foreach (var p in Projekat.Instance.Prodaja)
                {
                    if (p.Kupac.Contains(ime))
                    {
                        prodaje.Add(p);
                        
                    }
                }
                ProdavacGlavniWindow pg = new ProdavacGlavniWindow(prodaje);
                this.Close();
                pg.Show();
            }
            else if (tip == "Po broju racuna")
            {
                string br = tbPronadji.Text;
                foreach (var p in Projekat.Instance.Prodaja)
                {
                    if (p.BrojRacuna.Contains(br))
                    {
                        prodaje.Add(p);
                        
                    }
                }
                ProdavacGlavniWindow pg = new ProdavacGlavniWindow(prodaje);
                this.Close();
                pg.Show();
            }
            else if (tip == "Po datumu prodaje")
            {
                string datum = tbPronadji.Text;
                foreach (var p in Projekat.Instance.Prodaja)
                {
                    if (p.DatumProdaje.ToString() == datum)
                    {
                        prodaje.Add(p);
                        
                    }
                }
                ProdavacGlavniWindow pg = new ProdavacGlavniWindow(prodaje);
                this.Close();
                pg.Show();
            }
            else if (tip == "Po prodatom komadu")
            {
                string prodatiKomad = tbPronadji.Text;
                foreach (var p in Projekat.Instance.Prodaja)
                {
                }
            }
        }
    }
}
