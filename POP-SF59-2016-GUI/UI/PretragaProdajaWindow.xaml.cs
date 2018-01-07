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
                string ime = tbPronadji.Text.ToLower();
                foreach (var p in Projekat.Instance.Prodaja)
                {
                    if (p.Kupac.ToLower().Contains(ime))
                    {
                        prodaje.Add(p);
                        
                    }
                }
                ProdavacGlavniWindow pg = new ProdavacGlavniWindow();
                this.Close();
                pg.Show();
            }
            else if (tip == "Po broju racuna")
            {
                string br = tbPronadji.Text.ToLower();
                foreach (var p in Projekat.Instance.Prodaja)
                {
                    if (p.BrojRacuna.ToLower().Contains(br))
                    {
                        prodaje.Add(p);
                        
                    }
                }
                ProdavacGlavniWindow pg = new ProdavacGlavniWindow();
                this.Close();
                pg.Show();
            }
            else if (tip == "Po datumu prodaje")
            {
                string datum = tbPronadji.Text.ToLower();
                foreach (var p in Projekat.Instance.Prodaja)
                {
                    if (p.DatumProdaje.ToString() == datum)
                    {
                        prodaje.Add(p);
                        
                    }
                }
                ProdavacGlavniWindow pg = new ProdavacGlavniWindow();
                this.Close();
                pg.Show();
            }
            else if (tip == "Po prodatom komadu")
            {
                string prodatiKomad = tbPronadji.Text.ToLower();
                foreach (var p in Projekat.Instance.Prodaja)
                {
                    foreach (var n in p.NamestajZaProdaju)
                    {
                        if (n.Naziv.ToLower().Contains(prodatiKomad))
                        {
                            prodaje.Add(p);
                            break;
                        }
                    }
                }
                ProdavacGlavniWindow pg = new ProdavacGlavniWindow();
                this.Close();
                pg.Show();
            }
        }
    }
}
