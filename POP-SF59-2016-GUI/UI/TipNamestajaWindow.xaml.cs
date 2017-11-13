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
    /// Interaction logic for TipNamestajaWindow.xaml
    /// </summary>
    public partial class TipNamestajaWindow : Window
    {
        public enum OperacijaT
        {
            Dodavanje,
            Izmena
        }

        private TipNamestaja TipNamestaja;
        private OperacijaT Operacija;

        public TipNamestajaWindow(TipNamestaja tip,OperacijaT operacija)
        {
            InitializeComponent();

            InicijalizujVrednosti(tip, operacija);
        }

        private void InicijalizujVrednosti(TipNamestaja tipNamestaja, OperacijaT operacija)
        {
            this.TipNamestaja = tipNamestaja;
            this.Operacija = operacija;

            this.tbNaziv.Text = TipNamestaja.Naziv;

        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {

            var listaTipaNamestaja = Projekat.Instance.TipNamestaja;

            switch (Operacija)
            {
                case OperacijaT.Dodavanje:
                    var noviTipNamestaja = new TipNamestaja()
                    {
                        Id = listaTipaNamestaja.Count + 1,
                        Naziv = this.tbNaziv.Text
                    };
                    listaTipaNamestaja.Add(noviTipNamestaja);
                    break;
                case OperacijaT.Izmena:
                    foreach (var n in listaTipaNamestaja)
                    {
                        if (n.Id == TipNamestaja.Id)
                        {
                            n.Naziv = this.tbNaziv.Text;
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }
            Projekat.Instance.TipNamestaja = listaTipaNamestaja;
            Close();
        }
        private void Izadji(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
