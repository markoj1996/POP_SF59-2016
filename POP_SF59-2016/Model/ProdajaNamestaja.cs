﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF59_2016.Model
{
    public class ProdajaNamestaja
    {
        public int Id { get; set; }

        public bool Obrisan { get; set; }

        public List<int> NamestajZaProdajuId { get; set; }

        public DateTime DatumProdaje { get; set; }

        public string BrojRacuna { get; set; }

        public string Kupac { get; set; }

    }
}
