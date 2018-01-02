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
    public class Namestaj : INotifyPropertyChanged,ICloneable
    {
        private int id;
        private string naziv;
        private string sifra;
        private double jedinicnaCena;
        private int tipNamestajaId;
        private bool obrisan;
        private int kolicinaUMagacinu;
        private int akcijaId;
        private TipNamestaja tipNamestaja;
        private Akcija akcija;

        public double CenaSaAkcijom()
        {
            double Cena = 0;
            var akcije = Projekat.Instance.Akcija;
            foreach (var a in akcije)
            {
                if (akcijaId == a.Id)
                {
                    double popust = (a.Popust / 100) * jedinicnaCena;
                    Cena = jedinicnaCena - popust;
                    return Cena;
                }
            }
            return Cena;
        }


        [XmlIgnore]
        public Akcija Akcija
        {
            get
            {
                if (akcija == null)
                {
                    akcija = Akcija.GetById(AkcijaId);
                }
                return akcija;
            }
            set
            {
                akcija = value;
                AkcijaId = akcija.Id;
                OnPropertyChanged("Akcija");
            }
        }

        [XmlIgnore]
        public TipNamestaja TipNamestaja
        {
            get
            {
                if (tipNamestaja == null)
                {
                    tipNamestaja = TipNamestaja.GetById(TipNamestajaId);
                }
                return tipNamestaja;
            }
            set
            {
                tipNamestaja = value;
                TipNamestajaId = tipNamestaja.Id;
                OnPropertyChanged("TipNamestaja");
            }
        }

        public int AkcijaId
        {
            get { return akcijaId; }
            set
            {
                akcijaId = value;
                OnPropertyChanged("AkcijaId");
            }
        }

        public int KolicinaUMagacinu
        {
            get { return kolicinaUMagacinu; }
            set
            {
                kolicinaUMagacinu = value;
                OnPropertyChanged("KolicinaUMagacinu");
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


        public int TipNamestajaId
        {
            get { return tipNamestajaId; }
            set
            {
                tipNamestajaId = value;
                OnPropertyChanged("TipNamestajaId");
            }
        }


        public double JedinicnaCena
        {
            get { return jedinicnaCena; }
            set
            {
                jedinicnaCena = value;
                OnPropertyChanged("JedinicnaCena");
            }
        }


        public string Sifra
        {
            get { return sifra; }
            set
            {
                sifra = value;
                OnPropertyChanged("Sifra");
            }
        }


        public string Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }


        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            foreach (var tip in Projekat.Instance.TipNamestaja)
            {
                if (tip.Id == TipNamestajaId)
                {
                    return $"{Id},{Naziv},{Sifra},{JedinicnaCena},{tip.Naziv}";
                }
            }
            return $"{Naziv},{Sifra},{JedinicnaCena}";
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public static Namestaj GetById(int id)
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

        public object Clone()
        {
            return new Namestaj()
            {
                Id = id,
                Naziv = naziv,
                JedinicnaCena = jedinicnaCena,
                Sifra = sifra,
                Obrisan = obrisan,
                KolicinaUMagacinu = kolicinaUMagacinu,
                TipNamestaja = tipNamestaja,
                TipNamestajaId = tipNamestajaId,
            };
        }

        public static void UcitajNamestaj()
        {
            using (SqlConnection connection = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                connection.Open();

                DataSet ds = new DataSet();

                SqlCommand nametajCommand = connection.CreateCommand();
                nametajCommand.CommandText = @"SELECT * FROM NAMESTAJ";
                SqlDataAdapter daNamestaj = new SqlDataAdapter();
                daNamestaj.SelectCommand = nametajCommand;
                daNamestaj.Fill(ds, "Namestaj");

                foreach (DataRow row in ds.Tables["Namestaj"].Rows)
                {
                    Namestaj n = new Namestaj();
                    n.Id = (int)row["Id"];
                    n.Naziv = (string)row["Naziv"];
                    n.Sifra = (string)row["Sifra"];
                    n.JedinicnaCena = (double)row["JedinicnaCena"];
                    n.TipNamestajaId = (int)row["TipNamestaja"];
                    n.Obrisan = (bool)row["Obrisan"];
                    n.KolicinaUMagacinu = (int)row["KolicinaUMagacinu"];
                    n.AkcijaId = (int)row["AkcijaId"];

                    Aplikacija.Instance.Namestaj.Add(n);
                }
            }
        }

        public static void DodajNamestaj(Namestaj n)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"INSERT INTO NAMESTAJ (ID,NAZIV,SIFRA,JEDINICNACENA,TIPNAMESTAJA,OBRISAN,KOLICINAUMAGACINU,AKCIJAID) VALUES (@ID,@Naziv, @Sifra,@JedinicnaCena,@TipaNamestaja,@Obrisan,@KolicinaUMagacinu,@AkcijaId)";

                command.Parameters.Add(new SqlParameter("@ID", n.Id));
                command.Parameters.Add(new SqlParameter("@Naziv", n.Naziv));
                command.Parameters.Add(new SqlParameter("@Sifra", n.Sifra));
                command.Parameters.Add(new SqlParameter("@JedinicnaCena", n.JedinicnaCena));
                command.Parameters.Add(new SqlParameter("@TipNamestaja", n.TipNamestaja.Id));
                command.Parameters.Add(new SqlParameter("@Obrisan", 0));
                command.Parameters.Add(new SqlParameter("@KolicinaUMagacinu", n.KolicinaUMagacinu));
                command.Parameters.Add(new SqlParameter("@AkcijaId", n.Akcija.Id));

                command.ExecuteNonQuery();
            }
        }

    }
}
