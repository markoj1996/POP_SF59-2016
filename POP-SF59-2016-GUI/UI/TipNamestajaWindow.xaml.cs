using POP_SF59_2016.Model;
using POP_SF59_2016.Util1;
using POP_SF59_2016_GUI.Model;
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

        private TipNamestaja tipNamestaja;
        private OperacijaT operacija;

        public TipNamestajaWindow(TipNamestaja tip, OperacijaT operacija)
        {
            InitializeComponent();
            this.tipNamestaja = tip;
            this.operacija = operacija;

            tbNaziv.DataContext = tip;
        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {

            var listaTipaNamestaja = Projekat.Instance.TipNamestaja;

            switch (operacija)
            {
                case OperacijaT.Dodavanje:
                    tipNamestaja.Id = Aplikacija.Instance.TipNamestaja.Count + 1;
                    Aplikacija.Instance.TipNamestaja.Add(tipNamestaja);
                    TipNamestaja.DodajTipNamestaja(tipNamestaja);
                    break;
                case OperacijaT.Izmena:
                    foreach (var k in listaTipaNamestaja)
                    {
                        if (k.Id == tipNamestaja.Id)
                        {
                            k.Naziv = tipNamestaja.Naziv;
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }
            GenericSerialize.Serialize("tipNamestaja.xml", listaTipaNamestaja);
            Close();
        }
        private void Izadji(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
