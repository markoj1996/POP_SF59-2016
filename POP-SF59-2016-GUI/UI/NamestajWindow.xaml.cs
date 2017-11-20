﻿using POP_SF59_2016.Model;
using POP_SF59_2016.Util1;
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

            this.namestaj = namestaj;
            this.operacija = operacija;

            cbTipNamestaja.ItemsSource = Projekat.Instance.TipNamestaja;

            tbNaziv.DataContext = namestaj;
            cbTipNamestaja.DataContext = namestaj;
        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {

            var listaNamestaja = Projekat.Instance.Namestaj;
            var izabraniTipNamestaja = (TipNamestaja) cbTipNamestaja.SelectedItem;

            switch (operacija)
            {


                case Operacija.Dodavanje:
                    namestaj.Id = listaNamestaja.Count + 1;
                    listaNamestaja.Add(namestaj);
                    break;
                case Operacija.Izmena:

                    String cenass = tbCena.Text;
                    double cenaa = double.Parse(cenass);
                    String kolicinass = tbKolicina.Text;
                    int kolicinaa = int.Parse(kolicinass);
                    foreach (var n in listaNamestaja)
                    {
                        if (n.Id == namestaj.Id)
                        {
                            n.Naziv = namestaj.Naziv;
                            n.Sifra = namestaj.Sifra;
                            n.JedinicnaCena = namestaj.JedinicnaCena;
                            n.KolicinaUMagacinu = namestaj.KolicinaUMagacinu;
                            n.TipNamestaja = namestaj.TipNamestaja;
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
