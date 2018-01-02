using POP_SF59_2016_GUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP_SF59_2016.Model
{
    public class Akcija : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private bool obrisan;
        private DateTime datumPocetka;
        private DateTime datumZavrsetka;
        private double popust;


        public double Popust
        {
            get { return popust; }
            set
            {
                popust = value;
                OnPropertyChanged("Popust");
            }
        }


        public DateTime DatumZavrsetka
        {
            get { return datumZavrsetka; }
            set
            {
                datumZavrsetka = value;
                OnPropertyChanged("DatumZavrsetka");
            }
        }


        public DateTime DatumPocetka
        {
            get { return datumPocetka; }
            set
            {
                datumPocetka = value;
                OnPropertyChanged("DatumPocetka");
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
            return new Akcija
            {
                Id = id,
                DatumPocetka = datumPocetka,
                DatumZavrsetka = DatumZavrsetka,
                Popust = popust,
            };
        }

        public static Akcija GetById(int id)
        {
            foreach (var akcija in Projekat.Instance.Akcija)
            {
                if (akcija.Id == id)
                {
                    return akcija;
                }
            }
            return null;
        }

        public Namestaj nadji(int id)
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

        public override string ToString()
        {
            return $"Pocetak: {DatumPocetka.ToShortDateString()} Zavrsetak: {DatumZavrsetka.ToShortDateString()} Popust: {Popust}";
        }

        public static void UcitajAkcije()
        {
            using (SqlConnection connection = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                connection.Open();

                DataSet ds = new DataSet();

                SqlCommand akcijaCommand = connection.CreateCommand();
                akcijaCommand.CommandText = @"SELECT * FROM Akcija";
                SqlDataAdapter daAkcija = new SqlDataAdapter();
                daAkcija.SelectCommand = akcijaCommand;
                daAkcija.Fill(ds, "Akcija");

                foreach (DataRow row in ds.Tables["Akcija"].Rows)
                {
                    Akcija n = new Akcija();
                    n.Id = (int)row["Id"];
                    n.DatumPocetka = (DateTime)row["DatumPocetka"];
                    n.DatumZavrsetka = (DateTime)row["DatumZavrsetka"];
                    n.Obrisan = (bool)row["OObrisan"];
                    n.Popust = (double)row["Popust"];

                    Aplikacija.Instance.Akcija.Add(n);
                }
            }
        }

        public static void DodajAkciju(Akcija n)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"INSERT INTO AKCIJA (ID,OOBRISAN,DATUMPOCETKA,DATUMZAVRSETKA,POPUST) VALUES (@ID,@Obrisan, @DatumPocetka,@DatumZavrsetka,@Popust)";

                command.Parameters.Add(new SqlParameter("@ID", n.Id));
                command.Parameters.Add(new SqlParameter("@Obrisan", n.Obrisan));
                command.Parameters.Add(new SqlParameter("@DatumPocetka", n.DatumPocetka));
                command.Parameters.Add(new SqlParameter("@DatumZavrsetka", n.DatumZavrsetka));
                command.Parameters.Add(new SqlParameter("@Popust", n.Popust));

                command.ExecuteNonQuery();
            }
        }
        public static void ObrisiAkciju(Akcija n)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                if (n.Id != 0)//ako postoji u bazi
                {
                    conn.Open();

                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = @"UPDATE AKCIJA SET OOBRISAN=@Obrisan WHERE ID=@Id";

                    command.Parameters.Add(new SqlParameter("@Id", n.Id));
                    command.Parameters.Add(new SqlParameter("@Obrisan", n.Obrisan));

                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
