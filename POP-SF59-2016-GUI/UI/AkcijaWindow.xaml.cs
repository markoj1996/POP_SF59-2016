using POP_SF59_2016.Model;
using POP_SF59_2016.Util1;
using POP_SF59_2016_GUI.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        public Namestaj izabraniNamestaj { get; set; }

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
            this.akcija = akcija;
            this.operacija = operacija;


            tbDatumPocetka.DataContext = akcija;
            tbDatumZavrsetka.DataContext = akcija;
            tbPopust.DataContext = akcija;

        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listaAkcija = Aplikacija.Instance.Akcija;

            switch (operacija)
            {
                case OperacijaA.Dodavanje:
                    akcija.Id = Aplikacija.Instance.Akcija.Count + 1;
                    Aplikacija.Instance.Akcija.Add(akcija);
                    Akcija.DodajAkciju(akcija);
                    break;
                case OperacijaA.Izmena:
                    foreach (var a in listaAkcija)
                    {
                        if (a.Id == akcija.Id)
                        {
                            a.Obrisan = akcija.Obrisan;
                            a.DatumPocetka = akcija.DatumPocetka;
                            a.DatumZavrsetka = akcija.DatumZavrsetka;
                            a.Popust = akcija.Popust;
                            Akcija.IzmeniAkciju(akcija);
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }
            GenericSerialize.Serialize("akcije.xml", listaAkcija);
            Close();
        }

        private void Izadji(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
