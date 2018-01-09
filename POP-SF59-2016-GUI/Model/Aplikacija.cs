using POP_SF59_2016.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF59_2016_GUI.Model
{
    class Aplikacija
    {
        public const string CONNECTION_STRING = @"Integrated Security=true;
                                          Initial Catalog=SalonN;
                                          Data Source=MARKO-PC\SQLEXPRESS";

        public ObservableCollection<Namestaj> Namestaj { get; set; }
        public ObservableCollection<TipNamestaja> TipNamestaja { get; set; }
        public ObservableCollection<Akcija> Akcija { get; set; }
        public ObservableCollection<Korisnik> Korisnik { get; set; }
        public ObservableCollection<DodatnaUsluga> DodatnaUsluga { get; set; }
        public ObservableCollection<ProdajaNamestaja> Prodaja { get; set; }

        //singleton pattern; Jedan objekat klase Aplikacija postoji u celom programu. Svi delovi programa koriste ovaj objekat
        private static Aplikacija instance = new Aplikacija();

        public static Aplikacija Instance
        {
            get
            {
                return instance;
            }
        }

        private Aplikacija()
        {
            Namestaj = new ObservableCollection<Namestaj>();
            TipNamestaja = new ObservableCollection<TipNamestaja>();
            Akcija = new ObservableCollection<Akcija>();
            Korisnik = new ObservableCollection<Korisnik>();
            DodatnaUsluga = new ObservableCollection<DodatnaUsluga>();
            Prodaja = new ObservableCollection<ProdajaNamestaja>();

        }
    }
}
