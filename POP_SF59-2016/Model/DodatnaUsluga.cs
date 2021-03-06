﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF59_2016.Model
{
    public class DodatnaUsluga
    {
        public int Id { get; set; }

        public bool Obrisan { get; set; }

        public string Naziv { get; set; }

        public double Cena { get; set; }

        public double PDV { get; set; }

        public List<DodatnaUsluga> DodatnaUsluge { get; set; }

        public double UkupanIznaos { get; set; }
    }
}
