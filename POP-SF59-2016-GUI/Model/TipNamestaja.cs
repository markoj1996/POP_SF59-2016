﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF59_2016.Model
{
    public class TipNamestaja
    {
        public int Id { get; set; }

        public bool Obrisan { get; set; }

        public string Naziv { get; set; }

        public override string ToString()
        {
            return Naziv;
        }

        public static TipNamestaja GetById(int id)
        {
            foreach (var tipNamestaja in Projekat.Instance.TipNamestaja)
            {
                if (tipNamestaja.Id == id)
                {
                    return tipNamestaja;
                }
            }
            return null;
        }

    }

   
}
