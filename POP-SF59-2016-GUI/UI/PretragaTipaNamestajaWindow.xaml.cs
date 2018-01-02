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
    /// Interaction logic for PretragaTipaNamestajaWindow.xaml
    /// </summary>
    public partial class PretragaTipaNamestajaWindow : Window
    {
        public PretragaTipaNamestajaWindow()
        {
            InitializeComponent();
        }

        private void PretragaNaziva(object sender, RoutedEventArgs e)
        {
            string tip = cbTipPretrage.Text;
            ObservableCollection<TipNamestaja> tipNamestaja = new ObservableCollection<TipNamestaja>();

            if (tip == "Po nazivu")
            {
                string naziv = tbPronadji.Text.ToLower();
                foreach (var t in Projekat.Instance.TipNamestaja)
                {
                    if (t.Naziv.ToLower().Contains(naziv))
                    {
                        tipNamestaja.Add(t);
                        
                    }
                }
                GlavniWindow g = new GlavniWindow();
                this.Close();
                g.Show();
            }
        }
    }
}
