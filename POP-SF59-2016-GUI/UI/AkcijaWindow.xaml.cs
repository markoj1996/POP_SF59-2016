using POP_SF59_2016.Model;
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
            OsveziAkcije();
        }

        public void OsveziAkcije()
        {
            lbNamestaj.Items.Clear();
            foreach (var id in akcija.NamestajNaPopustuId)
            {
                foreach (var n in Projekat.Instance.Namestaj)
                {
                    if (id == n.Id)
                    {
                        lbNamestaj.Items.Add(n);
                    }
                }
            }
        }

        private void InicijalizujVrednosti(Akcija akcija, OperacijaA operacija)
        {
            this.akcija = akcija;
            this.operacija = operacija;

            this.tbDatumPocetka.Text = akcija.DatumPocetka.ToString();
            this.tbDatumZavrsetka.Text = akcija.DatumZavrsetka.ToString();
            this.tbPopust.Text = akcija.Popust.ToString("0.##");
            foreach (var name in Projekat.Instance.Namestaj)
            {
                foreach (var id in akcija.NamestajNaPopustuId)
                {
                    if (name.Id == id)
                    {
                        this.lbNamestaj.Items.Add(name);
                    }
                }          
            }
        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            List<Namestaj> namestaj = new List<Namestaj>();
            List<int> naPopustu = new List<int>();
            var listaAkcija = Projekat.Instance.Akcija;


            foreach (var n in lbNamestaj.Items)
            {
                Namestaj nam = (Namestaj)n;
                namestaj.Add(nam);

            }

            switch (operacija)
            {

                case OperacijaA.Dodavanje:
                    string datumPocetka = tbDatumPocetka.Text;
                    string datumZavrsetka = tbDatumZavrsetka.Text;
                    string popust = tbPopust.Text;
                    foreach (var n in namestaj)
                    {
                        naPopustu.Add(n.Id);
                    }
                    

                    var novaAkcija = new Akcija()
                    {
                        Id = listaAkcija.Count + 1,
                        DatumPocetka = DateTime.Parse(datumPocetka),
                        DatumZavrsetka = DateTime.Parse(datumZavrsetka),
                        Popust = Decimal.Parse(popust),
                        NamestajNaPopustuId = naPopustu
                    };
                    listaAkcija.Add(novaAkcija);
                    break;
                case OperacijaA.Izmena:
                    string datumPocetkai = tbDatumPocetka.Text;
                    string datumZavrsetkai = tbDatumZavrsetka.Text;
                    string popusti = tbPopust.Text;
                    foreach (var n in namestaj)
                    {
                        naPopustu.Add(n.Id);
                    }

                    foreach (var a in listaAkcija)
                    {
                        if (a.Id == akcija.Id)
                        {
                            a.DatumPocetka = DateTime.Parse(datumPocetkai);
                            a.DatumZavrsetka = DateTime.Parse(datumZavrsetkai);
                            a.Popust = Decimal.Parse(popusti);
                            a.NamestajNaPopustuId = naPopustu;
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

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            DodajNamestajNaAkciju dna = new DodajNamestajNaAkciju(akcija);
            dna.ShowDialog();
            OsveziAkcije();
        }
    }
}
