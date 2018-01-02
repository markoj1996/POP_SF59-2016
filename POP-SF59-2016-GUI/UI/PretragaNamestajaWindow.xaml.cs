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
    /// Interaction logic for PretragaNamestajaWindow.xaml
    /// </summary>
    public partial class PretragaNamestajaWindow : Window
    {

        public PretragaNamestajaWindow()
        {
            InitializeComponent();
        }

        private void PretragaNaziva(object sender, RoutedEventArgs e)
        {
            string tip = cbTipPretrage.Text;
            ObservableCollection<Namestaj> namestaj = new ObservableCollection<Namestaj>();

            if (tip == "Po nazivu")
            {
                string naziv = tbPronadji.Text.ToLower();
                foreach (var n in Projekat.Instance.Namestaj)
                {
                    if (n.Naziv.ToLower().Contains(naziv))
                    {
                        namestaj.Add(n);
                    }
                }
                GlavniWindow g = new GlavniWindow();
                this.Close();
                g.Show();
            }
            else if(tip == "Po sifri")
            {
                string sifra = tbPronadji.Text.ToLower();
                foreach (var n in Projekat.Instance.Namestaj)
                {
                    if (n.Sifra.ToLower().Contains(sifra))
                    {
                        namestaj.Add(n);
                    }
                }
                GlavniWindow g = new GlavniWindow();
                this.Close();
                g.Show();
            }
            else if (tip == "Po tipu")
            {
                string tipN = tbPronadji.Text.ToLower();
                foreach (var n in Projekat.Instance.Namestaj)
                {
                    foreach (var t in Projekat.Instance.TipNamestaja)
                    {
                        if (n.TipNamestajaId == t.Id && t.Naziv.ToLower().Contains(tipN))
                        {
                            namestaj.Add(n);
                        }
                    }   
                }
                GlavniWindow g = new GlavniWindow();
                this.Close();
                g.Show();
            }
        }
    }
}
