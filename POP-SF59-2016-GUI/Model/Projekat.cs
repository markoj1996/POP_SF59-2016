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
        private List<Akcija> akcija;
        private List<ProdajaNamestaja> prodaja;

        private Projekat()
        {
            Korisnik = GenericSerialize.Deserialize<Korisnik>("korisnici.xml");
            TipNamestaja = GenericSerialize.Deserialize<TipNamestaja>("tipNamestaja.xml");
            Namestaj = GenericSerialize.Deserialize<Namestaj>("namestaj.xml");
        }

       /* public List<ProdajaNamestaja> Prodaja
        {
            get
            {
                this.prodaja = GenericSerialize.Deserialize<ProdajaNamestaja>("prodaje.xml");
                return prodaja;
            }
            set
            {
                this.prodaja = value;
                GenericSerialize.Serialize<ProdajaNamestaja>("prodaje.xml", prodaja);
            }
        }

        public List<Akcija> Akcija
        {
            get
            {
                this.akcija = GenericSerialize.Deserialize<Akcija>("akcije.xml");
                return akcija;
            }
            set
            {
                this.akcija = value;
                GenericSerialize.Serialize<Akcija>("akcije.xml", akcija);
            }
        }

        public List<Korisnik> Korisnik
        {
            get
            {
                this.korisnik = GenericSerialize.Deserialize<Korisnik>("korisnici.xml");
                return korisnik;
            }
            set
            {
                this.korisnik = value;
                GenericSerialize.Serialize<Korisnik>("korisnici.xml", korisnik);
            }
        }


        public List<Namestaj> Namestaj
        {
            get
            {
                this.namestaj = GenericSerialize.Deserialize<Namestaj>("namestaj.xml");
                return namestaj;
            }
            set
            {
                this.namestaj = value;
                GenericSerialize.Serialize<Namestaj>("namestaj.xml", namestaj);
            }
        }

        public List<TipNamestaja> TipNamestaja
        {
            get
            {
                this.tipNamestaja = GenericSerialize.Deserialize<TipNamestaja>("tipNamestaja.xml");
                return tipNamestaja;
            }
            set
            {
                this.tipNamestaja = value;
                GenericSerialize.Serialize<TipNamestaja>("tipNamestaja.xml", tipNamestaja);
            }
        }*/

    }
}
