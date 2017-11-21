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
    /// Interaction logic for PretragaKorsnikaWindow.xaml
    /// </summary>
    public partial class PretragaKorsnikaWindow : Window
    {
        public PretragaKorsnikaWindow()
        {
            InitializeComponent();
        }

        private void PretragaNaziva(object sender, RoutedEventArgs e)
        {
            string tip = cbTipPretrage.Text;
            ObservableCollection<Korisnik> korisnici = new ObservableCollection<Korisnik>();

            if (tip == "Po imenu")
            {
                string ime = tbPronadji.Text;
                foreach (var k in Projekat.Instance.Korisnik)
                {
                    if (k.Ime.Contains(ime))
                    {
                        korisnici.Add(k);
                        
                    }
                }
                GlavniWindow g = new GlavniWindow(Projekat.Instance.Namestaj, korisnici, Projekat.Instance.Akcija, Projekat.Instance.TipNamestaja);
                this.Close();
                g.Show();
            }
            else if (tip == "Po prezimenu")
            {
                string prezime = tbPronadji.Text;
                foreach (var k in Projekat.Instance.Korisnik)
                {
                    if (k.Prezime.Contains(prezime))
                    {
                        korisnici.Add(k);
                        
                    }
                }
                GlavniWindow g = new GlavniWindow(Projekat.Instance.Namestaj, korisnici, Projekat.Instance.Akcija, Projekat.Instance.TipNamestaja);
                this.Close();
                g.Show();
            }
            else if (tip == "Po korisnickom imenu")
            {
                string korisnickoIme = tbPronadji.Text;
                foreach (var k in Projekat.Instance.Korisnik)
                {
                    if (k.KorisnickoIme.Contains(korisnickoIme))
                    {
                        korisnici.Add(k);
                        
                    }
                }
                GlavniWindow g = new GlavniWindow(Projekat.Instance.Namestaj, korisnici, Projekat.Instance.Akcija, Projekat.Instance.TipNamestaja);
                this.Close();
                g.Show();
            }
        }
    }
}
