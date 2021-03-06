﻿using System;
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

    }
}
