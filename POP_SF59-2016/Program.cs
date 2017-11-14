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
        static List<Korisnik> Korisnici { get; set; } = new List<Korisnik>();
        static List<ProdajaNamestaja> Prodaje { get; set; } = new List<ProdajaNamestaja>();

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


            var listaT = Projekat.Instance.TipNamestaja;
            Projekat.Instance.TipNamestaja = listaT;
            foreach (var stavka in listaT)
            {
                TipoviNamestaja.Add(stavka);

            }
            
            var listaN = Projekat.Instance.Namestaj;
            Projekat.Instance.Namestaj = listaN;
            foreach (var stavka in listaN)
            {
                Namestaj.Add(stavka);

            }


            var listaK = Projekat.Instance.Korisnik;
            Projekat.Instance.Korisnik = listaK;
            foreach (var stavka in listaK)
            {
                Korisnici.Add(stavka);
            }

            var listaA = Projekat.Instance.Akcija;
            Projekat.Instance.Akcija = listaA;
            foreach (var stavka in listaA)
            {
                Akcije.Add(stavka);
            }
            
            var listaP = Projekat.Instance.Prodaja;
            Projekat.Instance.Prodaja = listaP;
            foreach (var stavka in listaP)
            {
                Prodaje.Add(stavka);
            }

            Prijava();


        }

        private static void Prijava()
        {

            Console.WriteLine($"==== Prijava ====");
            Console.WriteLine("Korisnicko ime: ");
            string korisnickoIme = Console.ReadLine();
            Console.WriteLine("Lozinka: ");
            string lozinka = Console.ReadLine();

            for (int i = 0; i < Korisnici.Count; i++)
            {
                if (Korisnici[i].KorisnickoIme == korisnickoIme && Korisnici[i].Lozinka == lozinka)
                {
                    if (Korisnici[i].TipKorisnika == TipKorisnika.Administrator)
                    {
                        IspisGlavnogMenijaAdministratora();
                    }
                    else
                    {
                        IspisGlavnogMenijaProdavca();
                    }

                }
                else
                {
                    continue;
                }
                Console.WriteLine("Pogresno korisnicko ime ili lozinka");
            }
                    /*foreach (var korisnik in Korisnici)
                    {
                        Console.WriteLine($"==== Prijava ====");
                        Console.WriteLine("Korisnicko ime: ");
                        string korisnickoIme = Console.ReadLine();
                        Console.WriteLine("Lozinka: ");
                        string lozinka = Console.ReadLine();
                        if (korisnik.KorisnickoIme == korisnickoIme && korisnik.Lozinka == lozinka)
                        {
                            if (korisnik.TipKorisnika == TipKorisnika.Administrator)
                            {
                                IspisGlavnogMenijaAdministratora();
                            }
                            else
                            {
                                IspisGlavnogMenijaProdavca();
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    Console.WriteLine("Pogresno korisnicko ime ili lozinka");*/

        }

        private static void IspisGlavnogMenijaAdministratora()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("=== Meni Administratora ===");
                Console.WriteLine("1. Rad sa namestajem");
                Console.WriteLine("2. Rad sa akcijama");
                Console.WriteLine("3. Rad sa korisnicima");
                Console.WriteLine("4. Rad sa tipom namestaja");
                Console.WriteLine("0. Izlaz");

                izbor = int.Parse(Console.ReadLine());

            } while (izbor < 0 || izbor > 4);



            switch (izbor)
            {
                case 1:
                    IspisiMeniNamestaja();
                    break;
                case 2:
                    IspisiMeniAkcija();
                    break;
                case 3:
                    IspisiMeniKorisnika();
                    break;
                case 4:
                    IspisiMeniTipaNamestaja();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

        private static void IspisGlavnogMenijaProdavca()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("=== Meni Prodavca ===");
                Console.WriteLine("1. Rad sa prodajama");
                Console.WriteLine("0. Izlaz");

                izbor = int.Parse(Console.ReadLine());

            } while (izbor < 0 || izbor > 1);

            switch (izbor)
            {
                case 1:
                    IspisiMeniProdaja();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
        /*
        private static void IspisGlavnogMenija()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("1. Rad sa namestajem");
                Console.WriteLine("2. Rad sa tipom namestaja");
                Console.WriteLine("3. Rad sa akcijama");
                Console.WriteLine("4. Rad sa korisnicima");
                Console.WriteLine("5. Rad sa prodajama");
                Console.WriteLine("0. Izlaz");

                izbor = int.Parse(Console.ReadLine());

            } while (izbor < 0 || izbor > 5);

            

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
                case 4:
                    IspisiMeniKorisnika();
                    break;
                case 5:
                    IspisiMeniProdaja();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }*/

        private static void IspisiMeniProdaja()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("=== Meni prodaje namestaja ===");
                Console.WriteLine("1. Izlistaj prodaje");
                Console.WriteLine("2. Dodaj prodaju");
                Console.WriteLine("3. Izmeni prodaju");
                Console.WriteLine("4. Obrisi prodaju");
                Console.WriteLine("0. Povratak u glavni meni");

                izbor = int.Parse(Console.ReadLine());

            } while (izbor < 0 || izbor > 4);


            switch (izbor)
            {
                case 1:
                    IzlistajProdaje();
                    break;
                case 2:
                    DodajProdaju();
                    break;
                case 3:
                    IzmeniProdaju();
                    break;
                case 4:
                    ObrisiProdaju();
                    break;
                case 0:
                    IspisGlavnogMenijaProdavca();
                    break;
                default:
                    break;
            }
        }

        private static void ObrisiProdaju()
        {
            Console.WriteLine("=== Brisanje prodaje ===");
            Console.WriteLine("Unesite Id prodaje za brisanje: ");
            int unos = int.Parse(Console.ReadLine());

            foreach (var prodaja in Prodaje)
            {
                if (prodaja.Id == unos)
                {
                    prodaja.Obrisan = true;
                    GenericSerialize.Serialize<ProdajaNamestaja>("prodaje.xml", Prodaje);
                    IspisiMeniProdaja();
                }
            }
        }

        private static void IzmeniProdaju()
        {
            var nova = new ProdajaNamestaja();

            Console.WriteLine("=== Izmena prodaje ===");
            Console.WriteLine("Unesite Id prodaje za izmenu: ");
            int unos = int.Parse(Console.ReadLine());
            foreach (var prodaja in Prodaje)
            {
                if (prodaja.Id == unos)
                {
                    Console.WriteLine("=== Izmena prodaje ===");
                    Console.WriteLine("=== Dodavanje prodaje ===");
                    nova.Id = prodaja.Id;
                    Console.WriteLine("Unesite datum prodaje: ");
                    nova.DatumProdaje = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Unesite kupca: ");
                    nova.Kupac = Console.ReadLine();
                    Console.WriteLine("Unesite broj racuna: ");
                    nova.BrojRacuna = Console.ReadLine();

                    Prodaje.Remove(prodaja);
                    Prodaje.Add(nova);
                    GenericSerialize.Serialize<ProdajaNamestaja>("prodaje.xml", Prodaje);
                    IspisiMeniProdaja();

                }
            }
        }

        private static void DodajProdaju()
        {
            var nova = new ProdajaNamestaja();
            Console.WriteLine("=== Dodavanje prodaje ===");
            nova.Id = Prodaje.Count + 1;
            Console.WriteLine("Unesite datum prodaje: ");
            nova.DatumProdaje = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Unesite kupca: ");
            nova.Kupac = Console.ReadLine();
            Console.WriteLine("Unesite broj racuna: ");
            nova.BrojRacuna = Console.ReadLine();

            Prodaje.Add(nova);
            GenericSerialize.Serialize<ProdajaNamestaja>("prodaje.xml", Prodaje);
            IspisiMeniProdaja();
        }

        private static void IzlistajProdaje()
        {
            Console.WriteLine("=== Izlistavanje prodaja ===");
            for (int i = 0; i < Prodaje.Count; i++)
            {
                if (Prodaje[i].Obrisan == false)
                {
                    Console.WriteLine($"{i + 1}. datum prodaje: {Prodaje[i].DatumProdaje} , kupac: {Prodaje[i].Kupac} , broj racuna: {Prodaje[i].BrojRacuna}");
                    Console.WriteLine("Kupljeni namestaj");
                    foreach (var namestaj in Namestaj)
                    {
                        if (Prodaje[i].NamestajZaProdajuId.Contains(namestaj.Id))
                        {
                            Console.WriteLine(namestaj.Naziv);
                        }
                    }
                }
            }

            IspisiMeniProdaja();
        }

        private static void IspisiMeniKorisnika()
        {
            int izbor = 0;
            do
            {
                Console.WriteLine("=== Meni korisnika ===");
                Console.WriteLine("1. Izlistaj korisnike");
                Console.WriteLine("2. Dodaj korisnika");
                Console.WriteLine("3. Izmeni korisnika");
                Console.WriteLine("4. Obrisi korisnika");
                Console.WriteLine("0. Povratak u glavni meni");

                izbor = int.Parse(Console.ReadLine());

            } while (izbor < 0 || izbor > 4);


            switch (izbor)
            {
                case 1:
                    IzlistajKorisnike();
                    break;
                case 2:
                    DodajKorisnika();
                    break;
                case 3:
                    IzmeniKorisnike();
                    break;
                case 4:
                    ObrisiKorisnike();
                    break;
                case 0:
                    IspisGlavnogMenijaAdministratora();
                    break;
                default:
                    break;
            }
        }

        private static void ObrisiKorisnike()
        {
            Console.WriteLine("=== Brisanje korisnika ===");
            Console.WriteLine("Unesite Id korisnika za brisanje: ");
            int unos = int.Parse(Console.ReadLine());

            foreach (var korisnik in Korisnici)
            {
                if (korisnik.Id == unos)
                {
                    korisnik.Obrisan = true;
                    GenericSerialize.Serialize<Korisnik>("korisnici.xml", Korisnici);
                    IspisiMeniKorisnika();
                }
            }
        }

        private static void IzmeniKorisnike()
        {
            var novi = new Korisnik();

            Console.WriteLine("=== Izmena korisnika ===");
            Console.WriteLine("Unesite Id korisnika za izmenu: ");
            int unos = int.Parse(Console.ReadLine());
            foreach (var korisnik in Korisnici)
            {
                if (korisnik.Id == unos)
                {
                    Console.WriteLine("=== Izmena korisnika ===");
                    novi.Id = korisnik.Id;
                    Console.WriteLine("Unesite ime: ");
                    novi.Ime = Console.ReadLine();
                    Console.WriteLine("Unesite prezime: ");
                    novi.Prezime = Console.ReadLine();
                    Console.WriteLine("Unesite korisnicko ime: ");
                    novi.KorisnickoIme = Console.ReadLine();
                    Console.WriteLine("Unesite lozinku: ");
                    novi.Lozinka = Console.ReadLine();

                    Korisnici.Remove(korisnik);
                    Korisnici.Add(novi);
                    GenericSerialize.Serialize<Korisnik>("korisnici.xml", Korisnici);
                    IspisiMeniKorisnika();

                }
            }
        }

        private static void DodajKorisnika()
        {
            var novi = new Korisnik();
            Console.WriteLine("=== Dodavanje korisnika ===");
            novi.Id = Korisnici.Count + 1;
            Console.WriteLine("Unesite ime: ");
            novi.Ime = Console.ReadLine();
            Console.WriteLine("Unesite prezime: ");
            novi.Prezime = Console.ReadLine();
            Console.WriteLine("Unesite korisnicko ime: ");
            novi.KorisnickoIme = Console.ReadLine();
            Console.WriteLine("Unesite lozinku: ");
            novi.Lozinka = Console.ReadLine();

            Korisnici.Add(novi);
            GenericSerialize.Serialize<Korisnik>("korisnici.xml", Korisnici);
            IspisiMeniKorisnika();
        }

        private static void IzlistajKorisnike()
        {
            Console.WriteLine("=== Izlistavanje korisnika ===");
            for (int i = 0; i < Korisnici.Count; i++)
            {
                if (Korisnici[i].Obrisan == false)
                {
                    Console.WriteLine($"{i + 1}. ime: {Korisnici[i].Ime}, prezime: {Korisnici[i].Prezime}, korisnicko ime: {Korisnici[i].KorisnickoIme} , tip korisnika: {Korisnici[i].TipKorisnika}");
                }
            }

            IspisiMeniKorisnika();
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
                    IspisGlavnogMenijaAdministratora();
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
                    GenericSerialize.Serialize<Akcija>("akcije.xml", Akcije);
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
                    GenericSerialize.Serialize<Akcija>("akcije.xml", Akcije);
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
            GenericSerialize.Serialize<Akcija>("akcije.xml", Akcije);
            IspisiMeniAkcija();
        }

        private static void IzlistajAkcije()
        {
            Console.WriteLine("=== Izlistavanje akcija ===");
            for (int i = 0; i < Akcije.Count; i++)
            {
                if (Akcije[i].Obrisan == false)
                {
                    Console.WriteLine($"{i + 1}. datum pocetka: {Akcije[i].DatumPocetka} , datum zavrsetka {Akcije[i].DatumZavrsetka} , popust: {Akcije[i].Popust}");
                    Console.WriteLine("Namestaj na akciji: ");
                    foreach (var namestaj in Namestaj)
                    {
                        if (Akcije[i].NamestajNaPopustuId.Contains(namestaj.Id))
                        {
                            Console.WriteLine(namestaj.Naziv);
                        }
                    }
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
                    IspisGlavnogMenijaAdministratora();
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
                    GenericSerialize.Serialize<TipNamestaja>("tipNamestaja.xml", TipoviNamestaja);
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
                    GenericSerialize.Serialize<TipNamestaja>("tipNamestaja.xml", TipoviNamestaja);
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
            GenericSerialize.Serialize<TipNamestaja>("tipNamestaja.xml", TipoviNamestaja);
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
                Console.WriteLine("5. Pretrazi namestaj");
                Console.WriteLine("0. Povratak u glavni meni");

                izbor = int.Parse(Console.ReadLine());

            } while (izbor < 0 || izbor > 5);


            switch (izbor)
            {
                case 1:
                    IzlistajNamestaj(Namestaj);
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
                case 5:
                    PretraziNamestaj();
                    break;
                case 0:
                    IspisGlavnogMenijaAdministratora();
                    break;
                default:
                    break;
            }
        }

        private static void PretraziNamestaj()
        {
            Console.WriteLine("Unesite naziv za pretragu: ");
            string naziv = Console.ReadLine();
            List<Namestaj> pronadjeni = new List<Namestaj>();

            foreach (var namestaj in Namestaj)
            {
                if (namestaj.Naziv == naziv)
                {
                    pronadjeni.Add(namestaj);
                }
            }
            IzlistajNamestaj(pronadjeni);

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
                    GenericSerialize.Serialize<Namestaj>("namestaj.xml", Namestaj);
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
                        Console.WriteLine("Unesite id tipa namestaja: ");
                        int IdTipa = int.Parse(Console.ReadLine());

                        foreach (var tipNamestaja in TipoviNamestaja)
                        {
                            if (tipNamestaja.Id == IdTipa)
                            {
                                trazeniTip = tipNamestaja;
                            }
                        }

                    } while (trazeniTip == null);

                    novi.TipNamestajaId = trazeniTip.Id;

                    Namestaj.Remove(Namestaj1);
                    Namestaj.Add(novi);
                    GenericSerialize.Serialize<Namestaj>("namestaj.xml", Namestaj);
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
                Console.WriteLine("Unesite id tipa namestaja: ");
                int IdTipa = int.Parse(Console.ReadLine());

                foreach (var tipNamestaja in TipoviNamestaja)
                {
                    if (tipNamestaja.Id == IdTipa)
                    {
                        trazeniTip = tipNamestaja;
                    }
                }

            } while (trazeniTip == null);

            novi.TipNamestajaId = trazeniTip.Id;

            Namestaj.Add(novi);
            GenericSerialize.Serialize<Namestaj>("namestaj.xml",Namestaj);
            IspisiMeniNamestaja();

        }

        private static void IzlistajNamestaj(List<Namestaj> namestaj)
        {
            Console.WriteLine("=== Izlistavanje namestaja ===");
            for (int i = 0; i < namestaj.Count; i++)
            {
                if(namestaj[i].Obrisan==false)
                {
                    Console.WriteLine($"{namestaj[i].Id}.{namestaj[i].Naziv}, cena: {namestaj[i].JedinicnaCena},");
                }            
            }

            IspisiMeniNamestaja();
        }
    }
}
