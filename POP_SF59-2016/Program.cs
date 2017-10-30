﻿using POP_SF59_2016.Model;
using POP_SF59_2016.Util1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF59_2016
{
    class Program
    {
        static List<Namestaj> Namestaj { get; set; } = new List<Namestaj>();
        static List<TipNamestaja> TipoviNamestaja { get; set; } = new List<TipNamestaja>();

        static void Main(string[] args)
        {
            var s1 = new Salon()
            {
                Id = 1,
                Naziv = "Forma FTNale",
                Adresa = "Trg Dositeja Obradovica 6",
                BrojZiroRacuna = "840-00073666-83",
                Email = "kontakt@ftn.uns.ac.rs",
                MaticniBroj = 234324,
                PIB = 321560,
                Telefon = "012345",
                WebSajt = "http://www.ftn.uns.ac.rs"
            };

            var lista = Projekat.Instance.Namestaj;
            Projekat.Instance.Namestaj = lista;

            foreach (var stavka in lista)
            {
                Console.WriteLine($"{stavka.Naziv}");
            }

            var listaTipa = Projekat.Instance.TipNamestaja;
            Projekat.Instance.TipNamestaja = listaTipa;

            foreach (var stavka in listaTipa)
            {
                Console.WriteLine($"{stavka.Naziv}");
            }
   


            Console.WriteLine($"==== Dobrodosli u salon {s1.Naziv}");
            IspisGlavnogMenija();
        }

        private static void IspisGlavnogMenija()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("1. Rad sa namestajem");
                Console.WriteLine("2. Rad sa tipom namestaja");
                Console.WriteLine("0. Izlaz");

                izbor = int.Parse(Console.ReadLine());

            } while (izbor < 0 || izbor > 2);

            

            switch (izbor)
            {
                case 1:
                    IspisiMeniNamestaja();
                    break;
                case 2:
                    IspisiMeniTipaNamestaja();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

        private static void IspisiMeniTipaNamestaja()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("=== Meni Tipa Namestaja ===");
                Console.WriteLine("1. Izlistaj tip namestaja");
                Console.WriteLine("2. Dodaj novi tip namestaj");
                Console.WriteLine("3. Izmeni postojeci tip namestaj");
                Console.WriteLine("4. Obrisi postojeci tip namestaja");
                Console.WriteLine("0. Povratak u glavni meni");

                izbor = int.Parse(Console.ReadLine());

            } while (izbor < 0 || izbor > 4);


            switch (izbor)
            {
                case 1:
                    IzlistajTipNamestaja();
                    break;
                case 2:
                    DodajTipNamestaja();
                    break;
                case 3:
                    IzmeniTipNamestaja();
                    break;
                case 4:
                    ObrisiTipNamestaja();
                    break;
                case 0:
                    IspisGlavnogMenija();
                    break;
                default:
                    break;
            }
        }

        private static void ObrisiTipNamestaja()
        {
            Console.WriteLine("=== Brisanje Tipa Namestaja ===");
            Console.WriteLine("Unesite Id tipa namestaja za brisanje: ");
            int unos = int.Parse(Console.ReadLine());

            foreach (var tip in TipoviNamestaja)
            {
                if (tip.Id == unos)
                {
                    tip.Obrisan=true;  
                    IspisiMeniTipaNamestaja();
                }
            }
        }

        private static void IzmeniTipNamestaja()
        {
            var novi = new TipNamestaja();

            Console.WriteLine("=== Izmena Tipa Namestaja ===");
            Console.WriteLine("Unesite Id tipa namestaja za izmenu: ");
            int unos = int.Parse(Console.ReadLine());
            foreach (var tip in TipoviNamestaja)
            {
                if (tip.Id == unos)
                {
                    Console.WriteLine("=== Izmena Tipa Namestaja ===");
                    novi.Id = tip.Id;
                    Console.WriteLine("Unesite naziv: ");
                    novi.Naziv = Console.ReadLine();

                    TipoviNamestaja.Remove(tip);
                    TipoviNamestaja.Add(novi);
                    IspisiMeniTipaNamestaja();
                }
            }


        }

        private static void DodajTipNamestaja()
        {
            var novi = new TipNamestaja();
            Console.WriteLine("=== Dodavanje Tipa Namestaja ===");
            novi.Id = TipoviNamestaja.Count+1;
            Console.WriteLine("Unesite naziv: ");
            novi.Naziv = Console.ReadLine();

            TipoviNamestaja.Add(novi);
            IspisiMeniTipaNamestaja();

        }

        private static void IzlistajTipNamestaja()
        {
            Console.WriteLine("=== Izlistavanje tipa namestaja ===");
            for (int i = 0; i < TipoviNamestaja.Count; i++)
            {
                if(TipoviNamestaja[i].Obrisan==false)
                {
                    Console.WriteLine($"{i + 1}.{TipoviNamestaja[i].Naziv}");
                }            
            }

            IspisiMeniTipaNamestaja();
        }

        private static void IspisiMeniNamestaja()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("=== Meni Namestaja ===");
                Console.WriteLine("1. Izlistaj namestaj");
                Console.WriteLine("2. Dodaj novi namestaj");
                Console.WriteLine("3. Izmeni postojeci namestaj");
                Console.WriteLine("4. Obrisi postojeci");
                Console.WriteLine("5. Povratak u glavni meni");

                izbor = int.Parse(Console.ReadLine());

            } while (izbor < 0 || izbor > 4);


            switch (izbor)
            {
                case 1:
                    IzlistajNamestaj();
                    break;
                case 2:
                    DodajNamestaj();
                    break;
                case 3:
                    IzmeniNamestaj();
                    break;
                case 4:
                    ObrisiNamestaj();
                    break;
                case 0:
                    IspisGlavnogMenija();
                    break;
                default:
                    break;
            }
        }

        private static void ObrisiNamestaj()
        {
            Console.WriteLine("=== Brisanje namestaja ===");
            Console.WriteLine("Unesite Id namestaja za brisanje: ");
            int unos = int.Parse(Console.ReadLine());

            foreach (var Namestaj1 in Namestaj)
            {
                if (Namestaj1.Id == unos)
                {
                    Namestaj1.Obrisan=true;  
                    IspisiMeniNamestaja();
                }
            }
        }

        private static void IzmeniNamestaj()
        {
            var novi = new Namestaj();

            Console.WriteLine("=== Izmena namestaja ===");
            Console.WriteLine("Unesite Id namestaja za izmenu: ");
            int unos = int.Parse(Console.ReadLine());
            foreach (var Namestaj1 in Namestaj)
            {
                if (Namestaj1.Id == unos)
                {
                    Console.WriteLine("=== Izmena namestaja ===");
                    novi.Id = Namestaj1.Id;
                    Console.WriteLine("Unesite naziv: ");
                    novi.Naziv = Console.ReadLine();
                    Console.WriteLine("Unesite sifru: ");
                    novi.Sifra = Console.ReadLine();
                    Console.WriteLine("Unesite cenu: ");
                    novi.Obrisan = false;
                    novi.JedinicnaCena = double.Parse(Console.ReadLine());
                    Console.WriteLine("Unesite kolicinu: ");
                    novi.KolicinaUMagacinu = int.Parse(Console.ReadLine());

                    string nazivtipaNamestaja = "";
                    TipNamestaja trazeniTip = null;
                    do
                    {
                        Console.WriteLine("Unesite tip namestaja: ");
                        string nazivTipa = Console.ReadLine();

                        foreach (var tipNamestaja in TipoviNamestaja)
                        {
                            if (tipNamestaja.Naziv == nazivTipa)
                            {
                                trazeniTip = tipNamestaja;
                            }
                        }

                    } while (trazeniTip == null);

                    novi.TipNamestaja = trazeniTip;

                    Namestaj.Remove(Namestaj1);
                    Namestaj.Add(novi);
                    IspisiMeniNamestaja();
                }
            }


        }

        private static void DodajNamestaj()
        {
            var novi = new Namestaj();
            Console.WriteLine("=== Dodavanje namestaja ===");
            novi.Id = Namestaj.Count+1;
            Console.WriteLine("Unesite naziv: ");
            novi.Naziv = Console.ReadLine();
            Console.WriteLine("Unesite sifru: ");
            novi.Sifra = Console.ReadLine();
            Console.WriteLine("Unesite cenu: ");
            novi.JedinicnaCena = double.Parse(Console.ReadLine());
            Console.WriteLine("Unesite kolicinu: ");
            novi.KolicinaUMagacinu = int.Parse(Console.ReadLine());

            string nazivtipaNamestaja="";
            TipNamestaja trazeniTip=null;
            do
            {
                Console.WriteLine("Unesite tip namestaja: ");
                string nazivTipa = Console.ReadLine();

                foreach (var tipNamestaja in TipoviNamestaja)
                {
                    if (tipNamestaja.Naziv == nazivTipa)
                    {
                        trazeniTip = tipNamestaja;
                    }
                }

            } while (trazeniTip == null);

            novi.TipNamestaja = trazeniTip;

            Namestaj.Add(novi);
            IspisiMeniNamestaja();

        }

        private static void IzlistajNamestaj()
        {
            Console.WriteLine("=== Izlistavanje namestaja ===");
            for (int i = 0; i < Namestaj.Count; i++)
            {
                if(Namestaj[i].Obrisan==false)
                {
                    Console.WriteLine($"{i + 1}.{Namestaj[i].Naziv}, cena: {Namestaj[i].JedinicnaCena}, tip namestaja: {Namestaj[i].TipNamestaja.Naziv}");
                }            
            }

            IspisiMeniNamestaja();
        }
    }
}
