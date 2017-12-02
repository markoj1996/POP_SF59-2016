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
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            var korisnici = Projekat.Instance.Korisnik;

            if (tbUsername.Text != "" && pwPassword.Password != "")
            {
                for (int i = 0; i < korisnici.Count; i++)
                {
                    if (korisnici[i].KorisnickoIme == tbUsername.Text && korisnici[i].Lozinka == pwPassword.Password)
                    {
                        if (korisnici[i].Obrisan == false)
                        {
                            if (korisnici[i].TipKorisnika == "Administrator")
                            {
                                GlavniWindow g = new GlavniWindow(Projekat.Instance.Namestaj, Projekat.Instance.Korisnik, Projekat.Instance.Akcija, Projekat.Instance.TipNamestaja, Projekat.Instance.DodatnaUsluga);
                                g.Show();
                                this.Close();
                                break;
                            }
                            else
                            {
                                ProdavacGlavniWindow pgw = new ProdavacGlavniWindow(Projekat.Instance.Prodaja);
                                pgw.Show();
                                this.Close();
                                break;
                            }
                        }
                    }
                    else
                    {
                        continue;
                    }
                    MessageBox.Show("Pogresno korisnicko ime ili lozinka!!!");
                }
            }
            else
            {
                MessageBox.Show("Morate uneti korisnicko ime i lozinku!!!");
            }
        }
    }
}