using POP_SF59_2016.Util1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF59_2016.Model
{
    public class Projekat
    {
        public static Projekat Instance { get; } = new Projekat();

        public ObservableCollection<Namestaj> Namestaj;
        public ObservableCollection<TipNamestaja> TipNamestaja;
        public ObservableCollection<Korisnik> Korisnik;
        public ObservableCollection<Akcija> Akcija;
        public ObservableCollection<ProdajaNamestaja> Prodaja;

        private Projekat()
        {
            Korisnik = GenericSerialize.Deserialize<Korisnik>("korisnici.xml");
            TipNamestaja = GenericSerialize.Deserialize<TipNamestaja>("tipNamestaja.xml");
            Namestaj = GenericSerialize.Deserialize<Namestaj>("namestaj.xml");
            Akcija = GenericSerialize.Deserialize<Akcija>("akcije.xml");
            Prodaja = GenericSerialize.Deserialize<ProdajaNamestaja>("prodaje.xml");
        }
    }
}