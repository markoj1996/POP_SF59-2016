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
    /// Interaction logic for UslugaWindow.xaml
    /// </summary>
    public partial class UslugaWindow : Window
    {

        public enum OperacijaU
        {
            Dodavanje,
            Izmena
        }

        private DodatnaUsluga usluga;
        private OperacijaU operacija;

        public UslugaWindow(DodatnaUsluga usluga, OperacijaU operacija)
        {
            InitializeComponent();
            this.usluga = usluga;
            this.operacija = operacija;

            tbNaziv.DataContext = usluga;
            tbCena.DataContext = usluga;
            tbPDV.DataContext = usluga;
            tbUkupnaCena.DataContext = usluga;
        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listaUsluga = Aplikacija.Instance.DodatnaUsluga;

            switch (operacija)
            {
                case OperacijaU.Dodavanje:
                    usluga.Id = Aplikacija.Instance.DodatnaUsluga.Count + 1;
                    usluga.UkupanIznos = usluga.UkupanIznos;
                    Aplikacija.Instance.DodatnaUsluga.Add(usluga);
                    DodatnaUsluga.DodajUslugu(usluga);
                    break;
                case OperacijaU.Izmena:
                    foreach (var a in listaUsluga)
                    {
                        if (a.Id == usluga.Id)
                        {
                            a.Obrisan = usluga.Obrisan;
                            a.Naziv = usluga.Naziv;
                            a.Cena = usluga.Cena;
                            a.PDV = usluga.PDV;
                            a.UkupanIznos = usluga.UkupanIznos;
                            DodatnaUsluga.IzmeniUslugu(usluga);
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }
            //GenericSerialize.Serialize("usluge.xml", listaUsluga);
            Close();
        }

        private void Izadji(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

