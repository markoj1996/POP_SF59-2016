using POP_SF59_2016_GUI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF59_2016.Model
{
    public enum TipKorisnika
    {
        Administrator,
        Prodavac
    }
    public class Korisnik : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private bool obrisan;
        private string ime;
        private string prezime;
        private string korisnickoIme;
        private string lozinka;
        private string tipKorisnika;

        public string TipKorisnika
        {
            get { return tipKorisnika; }
            set
            {
                tipKorisnika = value;
                OnPropertyChanged("TipKorisnika");
            }
        }


        public string Lozinka
        {
            get { return lozinka; }
            set
            {
                lozinka = value;
                OnPropertyChanged("Lozinka");
            }
        }


        public string KorisnickoIme
        {
            get { return korisnickoIme; }
            set
            {
                korisnickoIme = value;
                OnPropertyChanged("Korisnickoime");
            }
        }


        public string Prezime
        {
            get { return prezime; }
            set
            {
                prezime = value;
                OnPropertyChanged("Prezime");
            }
        }


        public string Ime
        {
            get { return ime; }
            set
            {
                ime = value;
                OnPropertyChanged("Ime");
            }
        }


        public bool Obrisan
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }


        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return new Korisnik
            {
                Id = id,
                Ime = ime,
                Prezime = prezime,
                KorisnickoIme = korisnickoIme,
                Lozinka = lozinka,
                Obrisan = obrisan,
                TipKorisnika = tipKorisnika
            };
        }

        public override string ToString()
        {
            return $"{Ime},{Prezime},{KorisnickoIme},{TipKorisnika}";
        }

        public static void UcitajKorisnike()
        {
            using (SqlConnection connection = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                connection.Open();

                DataSet ds = new DataSet();

                SqlCommand korisnikCommand = connection.CreateCommand();
                korisnikCommand.CommandText = @"SELECT * FROM KORISNICI";
                SqlDataAdapter daKorisnik = new SqlDataAdapter();
                daKorisnik.SelectCommand = korisnikCommand;
                daKorisnik.Fill(ds, "Korisnici");

                foreach (DataRow row in ds.Tables["Korisnici"].Rows)
                {
                    Korisnik k = new Korisnik();
                    k.Id = (int)row["Id"];
                    k.Ime = (string)row["Ime"];
                    k.Prezime = (string)row["Prezime"];
                    k.KorisnickoIme = (string)row["KorisnickoIme"];
                    k.Lozinka = (string)row["Lozinka"];
                    k.TipKorisnika = (string)row["TipKorisnika"];
                    k.Obrisan = (bool)row["Obrisan"];

                    Aplikacija.Instance.Korisnik.Add(k);
                }
            }
        }

        public static void DodajKorisnika(Korisnik n)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"INSERT INTO KORISNICI (ID,IME,PREZIME,KORISNICKOIME,LOZINKA,OBRISAN,TIPKORISNIKA) VALUES (@ID,@Ime, @Prezime,@KorisnickoIme,@Lozinka,@Obrisan,@TipKorisnika)";

                command.Parameters.Add(new SqlParameter("@ID", n.Id));
                command.Parameters.Add(new SqlParameter("@Ime", n.Ime));
                command.Parameters.Add(new SqlParameter("@Prezime", n.Prezime));
                command.Parameters.Add(new SqlParameter("@KorisnickoIme", n.KorisnickoIme));
                command.Parameters.Add(new SqlParameter("@Lozinka", n.Lozinka));
                command.Parameters.Add(new SqlParameter("@Obrisan", n.Obrisan));
                command.Parameters.Add(new SqlParameter("@TipKorisnika", n.TipKorisnika));

                command.ExecuteNonQuery();
            }
        }
        public static void ObrisiKorisnika(Korisnik n)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                if (n.Id != 0)//ako postoji u bazi
                {
                    conn.Open();

                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = @"UPDATE KORISNICI SET OBRISAN=@Obrisan WHERE ID=@Id";

                    command.Parameters.Add(new SqlParameter("@Id", n.Id));
                    command.Parameters.Add(new SqlParameter("@Obrisan", n.Obrisan));

                    command.ExecuteNonQuery();
                }
            }
        }
        public static void IzmeniKorisnika(Korisnik n)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                if (n.Id != 0)//ako postoji u bazi
                {
                    conn.Open();

                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = @"UPDATE KORISNICI SET OBRISAN=@Obrisan, IME=@Ime, PREZIME=@Prezime, KORISNICKOIME=@KIme, LOZINKA=@Lozinka, TIPKORISNIKA=@Tip WHERE ID=@Id";

                    command.Parameters.Add(new SqlParameter("@Id", n.Id));
                    command.Parameters.Add(new SqlParameter("@Obrisan", n.Obrisan));
                    command.Parameters.Add(new SqlParameter("@Ime", n.Ime));
                    command.Parameters.Add(new SqlParameter("@Prezime", n.Prezime));
                    command.Parameters.Add(new SqlParameter("@KIme", n.KorisnickoIme));
                    command.Parameters.Add(new SqlParameter("@Lozinka", n.Lozinka));
                    command.Parameters.Add(new SqlParameter("@Tip", n.TipKorisnika));

                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
