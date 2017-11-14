using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF59_2016.Model
{
    public class Namestaj
    {
        public int Id { get; set; }

        public bool Obrisan { get; set; }

        public string Naziv { get; set; }

        public string Sifra { get; set; }

        public double JedinicnaCena { get; set; }

        public int KolicinaUMagacinu { get; set; }

        public int TipNamestajaId { get; set; }

        public override string ToString()
        {
            foreach (var tip in Projekat.Instance.TipNamestaja)
            {
                if (tip.Id == TipNamestajaId)
                {
                    return $"{Naziv},{Sifra},{JedinicnaCena},{tip.Naziv}";
                }
            }
            return $"{Naziv},{Sifra},{JedinicnaCena}";
        }

        public static Namestaj GetById(int id)
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
    }
}
