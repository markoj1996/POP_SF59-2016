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
                string ime = tbPronadji.Text.ToLower();
                foreach (var k in Projekat.Instance.Korisnik)
                {
                    if (k.Ime.ToLower().Contains(ime))
                    {
                        korisnici.Add(k);
                        
                    }
                }
                GlavniWindow g = new GlavniWindow();
                this.Close();
                g.Show();
            }
            else if (tip == "Po prezimenu")
            {
                string prezime = tbPronadji.Text.ToLower();
                foreach (var k in Projekat.Instance.Korisnik)
                {
                    if (k.Prezime.ToLower().Contains(prezime))
                    {
                        korisnici.Add(k);
                        
                    }
                }
                GlavniWindow g = new GlavniWindow();
                this.Close();
                g.Show();
            }
            else if (tip == "Po korisnickom imenu")
            {
                string korisnickoIme = tbPronadji.Text.ToLower();
                foreach (var k in Projekat.Instance.Korisnik)
                {
                    if (k.KorisnickoIme.ToLower().Contains(korisnickoIme))
                    {
                        korisnici.Add(k);
                        
                    }
                }
                GlavniWindow g = new GlavniWindow();
                this.Close();
                g.Show();
            }
        }
    }
}
