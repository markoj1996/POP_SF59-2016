using POP_SF59_2016.Model;
using POP_SF59_2016.Util1;
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
    /// Interaction logic for NamestajWindow.xaml
    /// </summary>
    public partial class NamestajWindow : Window
    {

        public enum Operacija
        {
            Dodavanje,
            Izmena
        }
        private Namestaj namestaj;
        private Operacija operacija;

        public NamestajWindow(Namestaj namestaj,Operacija operacija)
        {
            InitializeComponent();

            this.namestaj = namestaj;
            this.operacija = operacija;

            cbTipNamestaja.ItemsSource = Aplikacija.Instance.TipNamestaja;
            cbAkcija.ItemsSource = Aplikacija.Instance.Akcija;


            tbNaziv.DataContext = namestaj;
            tbSifra.DataContext = namestaj;
            tbCena.DataContext = namestaj;
            tbKolicina.DataContext = namestaj;
            cbTipNamestaja.DataContext = namestaj;
            cbAkcija.DataContext = namestaj;
            
        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listaNamestaja = Aplikacija.Instance.Namestaj;
            var izabraniTipNamestaja = (TipNamestaja) cbTipNamestaja.SelectedItem;
            var izabranaAkcija =  (Akcija) cbAkcija.SelectedItem;

            switch (operacija)
            {
                case Operacija.Dodavanje:
                    namestaj.Id = Aplikacija.Instance.Namestaj.Count + 1;
                    Aplikacija.Instance.Namestaj.Add(namestaj);
                    Namestaj.DodajNamestaj(namestaj);
                    break;
                case Operacija.Izmena:
                    foreach (var n in listaNamestaja)
                    {
                        if (n.Id == namestaj.Id)
                        {
                            n.Naziv = namestaj.Naziv;
                            n.Sifra = namestaj.Sifra;
                            n.JedinicnaCena = namestaj.JedinicnaCena;
                            n.KolicinaUMagacinu = namestaj.KolicinaUMagacinu;
                            n.TipNamestaja = namestaj.TipNamestaja;
                            n.Akcija = namestaj.Akcija;
                            Namestaj.IzmeniNamestaj(namestaj);
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }
            GenericSerialize.Serialize("namestaj.xml", listaNamestaja);
            Close();
        }

        private void Izadji(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
