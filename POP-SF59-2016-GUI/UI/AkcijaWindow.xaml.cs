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
    /// Interaction logic for AkcijaWindow.xaml
    /// </summary>
    public partial class AkcijaWindow : Window
    {

        public enum OperacijaA
        {
            Dodavanje,
            Izmena
        }

        private Akcija akcija;
        private OperacijaA operacija;

        public AkcijaWindow(Akcija akcija,OperacijaA operacija)
        {
            InitializeComponent();
            InicijalizujVrednosti(akcija,operacija);
        }

        private void InicijalizujVrednosti(Akcija akcija, OperacijaA operacija)
        {
            this.akcija = akcija;
            this.operacija = operacija;

        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {

            var listaAkcija = Projekat.Instance.Akcija;

            switch (operacija)
            {
                case OperacijaA.Dodavanje:
                    string datumPocetka = tbDatumPocetka.Text;
                    string datumZavrsetka = tbDatumZavrsetka.Text;
                    string popust = tbPopust.Text;

                    var novaAkcija = new Akcija()
                    {
                        Id = listaAkcija.Count + 1,
                        DatumPocetka = DateTime.Parse(datumPocetka),
                        DatumZavrsetka = DateTime.Parse(datumZavrsetka),
                        Popust = Decimal.Parse(popust)
                    };
                    listaAkcija.Add(novaAkcija);
                    break;
                case OperacijaA.Izmena:
                    string datumPocetkai = tbDatumPocetka.Text;
                    string datumZavrsetkai = tbDatumZavrsetka.Text;
                    string popusti = tbPopust.Text;

                    foreach (var a in listaAkcija)
                    {
                        if (a.Id == akcija.Id)
                        {
                            a.DatumPocetka = DateTime.Parse(datumPocetkai);
                            a.DatumZavrsetka = DateTime.Parse(datumZavrsetkai);
                            a.Popust = Decimal.Parse(popusti);
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }
            Projekat.Instance.Akcija = listaAkcija;
            Close();
        }

        private void Izadji(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
