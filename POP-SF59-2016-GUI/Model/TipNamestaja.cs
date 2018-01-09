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
    public class TipNamestaja : INotifyPropertyChanged,ICloneable
    {

        private int id;
        private string naziv;
        private bool obrisan;

        public bool Obrisan
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
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
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return Naziv;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public static TipNamestaja GetById(int id)
        {
            foreach (var tipNamestaja in Aplikacija.Instance.TipNamestaja)
            {
                if (tipNamestaja.Id == id)
                {
                    return tipNamestaja;
                }
            }
            return null;
        }

        public object Clone()
        {
            return new TipNamestaja()
            {
                Naziv = naziv,
                Id = id,
                Obrisan = obrisan
            };
        }

        public static void UcitajTipNamestaja()
        {
            using (SqlConnection connection = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                connection.Open();

                DataSet ds = new DataSet();

                SqlCommand tipNametajaCommand = connection.CreateCommand();
                tipNametajaCommand.CommandText = @"SELECT * FROM TIPNAMESTAJA";
                SqlDataAdapter daTipNamestaja = new SqlDataAdapter();
                daTipNamestaja.SelectCommand = tipNametajaCommand;
                daTipNamestaja.Fill(ds, "TipNamestaja");

                foreach (DataRow row in ds.Tables["TipNamestaja"].Rows)
                {
                    TipNamestaja n = new TipNamestaja();
                    n.Id = (int)row["Id"];
                    n.Naziv = (string)row["Naziv"];
                    n.Obrisan = (bool)row["Obrisan"]; 

                    Aplikacija.Instance.TipNamestaja.Add(n);
                }
            }
        }

        public static void DodajTipNamestaja(TipNamestaja tn)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"INSERT INTO TIPNAMESTAJA (ID,NAZIV,OBRISAN) VALUES (@ID,@Naziv,@Obrisan)";

                command.Parameters.Add(new SqlParameter("@ID", tn.Id));
                command.Parameters.Add(new SqlParameter("@Naziv", tn.Naziv));
                command.Parameters.Add(new SqlParameter("@Obrisan", tn.Obrisan));

                command.ExecuteNonQuery();
            }
        }

        public static void ObrisiTip(TipNamestaja n)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                if (n.Id != 0)//ako postoji u bazi
                {
                    conn.Open();

                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = @"UPDATE TIPNAMESTAJA SET OBRISAN=@Obrisan WHERE ID=@Id";

                    command.Parameters.Add(new SqlParameter("@Id", n.Id));
                    command.Parameters.Add(new SqlParameter("@Obrisan", n.Obrisan));

                    command.ExecuteNonQuery();
                }
            }
        }
        public static void IzmeniTip(TipNamestaja n)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                if (n.Id != 0)//ako postoji u bazi
                {
                    conn.Open();

                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = @"UPDATE TIPNAMESTAJA SET NAZIV=@Naziv, OBRISAN=@Obrisan WHERE ID=@Id";

                    command.Parameters.Add(new SqlParameter("@Id", n.Id));
                    command.Parameters.Add(new SqlParameter("@Naziv", n.Naziv));
                    command.Parameters.Add(new SqlParameter("@Obrisan", n.Obrisan));

                    command.ExecuteNonQuery();
                }
            }
        }

    }
}
