using POP_SF59_2016.Model;
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
        static List<Akcija> Akcije { get; set; } = new List<Akcija>();

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

            var tn1 = new TipNamestaja()
            {
                Id = 1,
                Naziv = "aaa"
            };

            TipoviNamestaja.Add(tn1);

            var n1 = new Namestaj()
            {
                Id = 1,
                Naziv = "a",
                Sifra = "a123",
                JedinicnaCena = 20,
                TipNamestaja = tn1,
                KolicinaUMagacinu = 2
            };

            Namestaj.Add(n1);

            var a1 = new Akcija()
            {
                Id = 1,
                DatumPocetka = new DateTime(2017, 11, 3),
                DatumZavrsetka = new DateTime(2017, 11, 5),
                Popust = 10
            };

            Akcije.Add(a1);

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
                Console.WriteLine("3. Rad sa akcijama");
                Console.WriteLine("0. Izlaz");

                izbor = int.Parse(Console.ReadLine());

            } while (izbor < 0 || izbor > 3);

            

            switch (izbor)
            {
                case 1:
                    IspisiMeniNamestaja();
                    break;
                case 2:
                    IspisiMeniTipaNamestaja();
                    break;
                case 3:
                    IspisiMeniAkcija();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

        private static void IspisiMeniAkcija()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("=== Meni akcija ===");
                Console.WriteLine("1. Izlistaj akcije");
                Console.WriteLine("2. Dodaj novu akciju");
                Console.WriteLine("3. Izmeni postojecu akciju");
                Console.WriteLine("4. Obrisi postojecu akciju");
                Console.WriteLine("0. Povratak u glavni meni");

                izbor = int.Parse(Console.ReadLine());

            } while (izbor < 0 || izbor > 4);


            switch (izbor)
            {
                case 1:
                    IzlistajAkcije();
                    break;
                case 2:
                    DodajAkciju();
                    break;
                case 3:
                    IzmeniAkciju();
                    break;
                case 4:
                    ObrisiAkciju();
                    break;
                case 0:
                    IspisGlavnogMenija();
                    break;
                default:
                    break;
            }
        }

        private static void ObrisiAkciju()
        {
            Console.WriteLine("=== Brisanje akcije ===");
            Console.WriteLine("Unesite Id akcije za brisanje: ");
            int unos = int.Parse(Console.ReadLine());

            foreach (var akcija in Akcije)
            {
                if (akcija.Id == unos)
                {
                    akcija.Obrisan = true;
                    IspisiMeniAkcija();
                }
            }
        }

        private static void IzmeniAkciju()
        {
            var nova = new Akcija();

            Console.WriteLine("=== Izmena akcije ===");
            Console.WriteLine("Unesite Id akcije za izmenu: ");
            int unos = int.Parse(Console.ReadLine());
            foreach (var akcija in Akcije)
            {
                if (akcija.Id == unos)
                {
                    Console.WriteLine("=== Izmena akcije ===");
                    nova.Id = akcija.Id;
                    Console.WriteLine("Unesite datum pocetka: ");
                    nova.DatumPocetka = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Unesite datum zavrsetka: ");
                    nova.DatumZavrsetka = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Unesite popust: ");
                    nova.Popust = decimal.Parse(Console.ReadLine());

                    Akcije.Remove(akcija);
                    Akcije.Add(nova);
                    IspisiMeniAkcija();
                }
            }
        }

        private static void DodajAkciju()
        {
            var nova = new Akcija();
            Console.WriteLine("=== Dodavanje akcije ===");
            nova.Id = Akcije.Count + 1;
            Console.WriteLine("Unesite datum pocetka: ");
            nova.DatumPocetka = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Unesite datum zavrsetka: ");
            nova.DatumZavrsetka = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Unesite popust: ");
            nova.Popust = decimal.Parse(Console.ReadLine());

            Akcije.Add(nova);
            IspisiMeniAkcija();
        }

        private static void IzlistajAkcije()
        {
            Console.WriteLine("=== Izlistavanje akcija ===");
            for (int i = 0; i < Akcije.Count; i++)
            {
                if (Akcije[i].Obrisan == false)
                {
                    Console.WriteLine($"{i + 1}. datum pocetka:{Akcije[i].DatumPocetka},datum zavrsetka{Akcije[i].DatumZavrsetka},popust: {Akcije[i].Popust}");
                }
            }

            IspisiMeniAkcija();
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
                Console.WriteLine("0. Povratak u glavni meni");

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
