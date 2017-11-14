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
            var listaNamestaja = Projekat.Instance.Namestaj;
            string tip = cbTipPretrage.Text;
            List<Namestaj> namestaj = new List<Namestaj>();

            if (tip == "Po nazivu")
            {
                string naziv = tbPronadji.Text;
                foreach (var n in Projekat.Instance.Namestaj)
                {
                    if (n.Naziv == naziv)
                    {
                        namestaj.Add(n);
                        GlavniWindow g = new GlavniWindow();
                        this.Close();
                        g.Show();
                        g.OsveziPrikaz(namestaj, Projekat.Instance.Korisnik, Projekat.Instance.TipNamestaja);
                    }
                }
            }
            else if(tip == "Po sifri")
            {
                string sifra = tbPronadji.Text;
                foreach (var n in Projekat.Instance.Namestaj)
                {
                    if (n.Sifra == sifra)
                    {
                        namestaj.Add(n);
                        GlavniWindow g = new GlavniWindow();
                        this.Close();
                        g.Show();
                        g.OsveziPrikaz(namestaj, Projekat.Instance.Korisnik, Projekat.Instance.TipNamestaja);
                    }
                }
            }
            else if (tip == "Po tipu")
            {
                string tipN = tbPronadji.Text;
                foreach (var n in Projekat.Instance.Namestaj)
                {
                    foreach (var t in Projekat.Instance.TipNamestaja)
                    {
                        if (n.TipNamestajaId == t.Id && t.Naziv == tipN)
                        {
                            namestaj.Add(n);
                            GlavniWindow g = new GlavniWindow();
                            this.Close();
                            g.Show();
                            g.OsveziPrikaz(namestaj, Projekat.Instance.Korisnik, Projekat.Instance.TipNamestaja);
                        }
                    }   
                }
            }
        }
    }
}
