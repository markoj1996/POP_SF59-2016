using POP_SF59_2016.Util1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF59_2016.Model
{
    public class Projekat
    {
        public static Projekat Instance { get; } = new Projekat();

        private List<Namestaj> namestaj;
        private List<TipNamestaja> tipNamestaja;

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
        }

    }
}
