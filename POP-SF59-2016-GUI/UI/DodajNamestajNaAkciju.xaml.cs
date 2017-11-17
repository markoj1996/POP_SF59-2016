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

        Akcija akcija;

        public DodajNamestajNaAkciju(Akcija akcija)
        {
            InitializeComponent();
            this.akcija = akcija;
            Osvezi();
        }

        public void Osvezi()
        {
            lbNamestaj.Items.Clear();

            foreach (var n in Projekat.Instance.Namestaj)
            {
                if (n.Obrisan == false)
                {
                    lbNamestaj.Items.Add(n);
                }
                lbNamestaj.SelectedIndex = 0;
            }
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            Namestaj Izabrani = (Namestaj)lbNamestaj.SelectedItem;
            akcija.NamestajNaPopustuId.Add(Izabrani.Id);
            Close();
        }
    }
}
