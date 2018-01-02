using POP_SF59_2016_GUI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP_SF59_2016.Model
{
    public class DodatnaUsluga : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private bool obrisan;
        private string naziv;
        private double cena;
        private double pdv;
        private double ukupanIznos;


        public double UkupanIznos
        {
            get { return ukupanIznos; }
            set { ukupanIznos = value; }
        }


        public double PDV
        {
            get { return pdv; }
            set { pdv = value; }
        }


        public double Cena
        {
            get { return cena; }
            set { cena = value; }
        }


        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }

        public bool Obrisan
        {
            get { return obrisan; }
            set { obrisan = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return $"{Id},{Naziv},{Cena},{UkupanIznos}" ;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public static DodatnaUsluga GetById(int id)
        {
            foreach (var usluga in Projekat.Instance.DodatnaUsluga)
            {
                if (usluga.Id == id)
                {
                    return usluga;
                }
            }
            return null;
        }

        public double UkupnaCena(DodatnaUsluga usluga)
        {
            double ukupno = 0;
            ukupno = (usluga.cena * (1+usluga.PDV/100));
            return ukupno;
        }

        public object Clone()
        {
            return new DodatnaUsluga()
            {
                Id = id,
                Naziv = naziv,
                Cena = cena,
                PDV = pdv,
                Obrisan = obrisan,
                UkupanIznos = ukupanIznos,
            };
        }

        public static void UcitajUsluge()
        {
            using (SqlConnection connection = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                connection.Open();

                DataSet ds = new DataSet();

                SqlCommand uslugaCommand = connection.CreateCommand();
                uslugaCommand.CommandText = @"SELECT * FROM DODATNEUSLUGE";
                SqlDataAdapter daUsluge = new SqlDataAdapter();
                daUsluge.SelectCommand = uslugaCommand;
                daUsluge.Fill(ds, "DodatneUsluge");

                foreach (DataRow row in ds.Tables["DodatneUsluge"].Rows)
                {
                    DodatnaUsluga k = new DodatnaUsluga();
                    k.Id = (int)row["Id"];
                    k.Obrisan = (bool)row["Obrisan"];
                    k.Naziv = (string)row["Naziv"];
                    k.Cena = (double)row["Cena"];
                    k.PDV = (double)row["PDV"];
                    k.UkupanIznos = (double)row["UkupanIznos"];

                    Aplikacija.Instance.DodatnaUsluga.Add(k);
                }
            }
        }
        public static void DodajUslugu(DodatnaUsluga n)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"INSERT INTO DODATNEUSLUGE (ID,NAZIV,OBRISAN,CENA,PDV,UKUPANIZNOS) VALUES (@ID,@Naziv,@Obrisan,@Cena,@PDV,@UkupanIznos)";

                command.Parameters.Add(new SqlParameter("@ID", n.Id));
                command.Parameters.Add(new SqlParameter("@Naziv", n.Naziv));
                command.Parameters.Add(new SqlParameter("@Obrisan", n.Obrisan));
                command.Parameters.Add(new SqlParameter("@Cena", n.Cena));
                command.Parameters.Add(new SqlParameter("@PDV", n.PDV));
                command.Parameters.Add(new SqlParameter("@UkupanIznos", n.UkupanIznos));

                command.ExecuteNonQuery();
            }
        }
        public static void ObrisiUslugu(DodatnaUsluga n)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                if (n.Id != 0)//ako postoji u bazi
                {
                    conn.Open();

                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = @"UPDATE DODATNEUSLUGE SET OBRISAN=@Obrisan WHERE ID=@Id";

                    command.Parameters.Add(new SqlParameter("@Id", n.Id));
                    command.Parameters.Add(new SqlParameter("@Obrisan", n.Obrisan));

                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
