using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF59_2016.Model
{
    public class Akcija
    {
        public int Id { get; set; }

        public bool Obrisan { get; set; }

        public DateTime DatumPocetka { get; set; }

        public DateTime DatumZavrsetka { get; set; }

        public decimal Popust { get; set; }

        public List<int> NamestajNaPopustuId { get; set; }

        public Namestaj nadji(int id)
        {
            foreach (var namestaj in Projekat.Instance.Namestaj)
            {
                if (namestaj.Id == id)
                {
                    return namestaj;
                }
            }
            return null;
        }

        public override string ToString()
        {
            List<string> listaImena= new List<string>();
            foreach (var id in NamestajNaPopustuId)
            {
                Namestaj nadjeni = nadji(id);
                listaImena.Add(nadjeni.Naziv);
            }
            var result = string.Join(",", listaImena.ToArray());
            return $"{DatumPocetka},{DatumZavrsetka},{Popust},{result}";
        }

    }
}
