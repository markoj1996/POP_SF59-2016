using POP_SF59_2016.Model;
using POP_SF59_2016_GUI.Model;
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
    /// Interaction logic for PretragaUslugaWindow.xaml
    /// </summary>
    public partial class PretragaUslugaWindow : Window
    {
        public PretragaUslugaWindow()
        {
            InitializeComponent();
        }

        private void PretragaNaziva(object sender, RoutedEventArgs e)
        {
            string tip = cbTipPretrage.Text;
            ObservableCollection<DodatnaUsluga> usluga = new ObservableCollection<DodatnaUsluga>();

            if (tip == "Po nazivu")
            {
                string naziv = tbPronadji.Text.ToLower();
                foreach (var t in Aplikacija.Instance.DodatnaUsluga)
                {
                    if (t.Naziv.ToLower().Contains(naziv))
                    {
                        usluga.Add(t);

                    }
                }
                GlavniWindow g = new GlavniWindow(Aplikacija.Instance.Namestaj, Aplikacija.Instance.Korisnik, Aplikacija.Instance.Akcija, Aplikacija.Instance.TipNamestaja, usluga);
                this.Close();
                g.Show();
            }
        }
    }
}
