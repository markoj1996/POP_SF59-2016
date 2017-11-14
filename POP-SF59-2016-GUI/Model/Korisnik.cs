﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF59_2016.Model
{
    /*public enum TipKorisnika
    {
        Administrator=0,
        Prodavac=1
    }*/
    public class Korisnik
    {
        public int Id { get; set; }

        public bool Obrisan { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string KorisnickoIme { get; set; }

        public string Lozinka { get; set; }

        public string TipKorisnika { get; set; }

        public override string ToString()
        {
            return $"{Ime},{Prezime},{KorisnickoIme},{TipKorisnika}";
        }
    }
}