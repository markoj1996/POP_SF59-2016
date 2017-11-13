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

            InicijalizujVrednosti(namestaj, operacija);
        }

        private void InicijalizujVrednosti(Namestaj namestaj, Operacija operacija)
        {
            this.namestaj = namestaj;
            this.operacija = operacija;

            this.tbNaziv.Text = namestaj.Naziv;

            foreach (var tipNamestaja in Projekat.Instance.TipNamestaja)
            {
                cbTipNamestaja.Items.Add(tipNamestaja);
            }

            foreach (TipNamestaja tipNamestaja in cbTipNamestaja.Items)
            {
                if (tipNamestaja.Id == namestaj.Id)
                {
                    cbTipNamestaja.SelectedItem = tipNamestaja;
                    break;
                }
            }
        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {

            var listaNamestaja = Projekat.Instance.Namestaj;
            var izabraniTipNamestaja = (TipNamestaja) cbTipNamestaja.SelectedItem;

            switch (operacija)
            {
                case Operacija.Dodavanje:
                    var noviNamestaj = new Namestaj()
                    {
                        Id = listaNamestaja.Count + 1,
                        Naziv = this.tbNaziv.Text,
                        TipNamestajaId = izabraniTipNamestaja.Id
                    };
                    listaNamestaja.Add(noviNamestaj);
                    break;
                case Operacija.Izmena:
                    foreach (var n in listaNamestaja)
                    {
                        if (n.Id == namestaj.Id)
                        {
                            n.Naziv = this.tbNaziv.Text;
                            n.TipNamestajaId = izabraniTipNamestaja.Id;
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }
            Projekat.Instance.Namestaj = listaNamestaja;
            Close();
        }

        private void Izadji(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
