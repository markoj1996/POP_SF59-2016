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
    public class ProdajaNamestaja : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private bool obrisan;
        private ObservableCollection<int> namestajZaProdajuId = new ObservableCollection<int>();
        private DateTime datumProdaje;
        private string brojRacuna;
        private string kupac;
        private ObservableCollection<int> dodatneUsluge = new ObservableCollection<int>();
        private ObservableCollection<Namestaj> namestajZaProdaju = new ObservableCollection<Namestaj>();


        [XmlIgnore]
        public ObservableCollection<Namestaj> NamestajZaProdaju
        {
            get
            {
                Namestaj namestaj=null;
                foreach (var id in NamestajZaProdajuId)
                {
                    namestaj = Namestaj.GetById(id);
                    
                }
                namestajZaProdaju.Add(namestaj);
                return namestajZaProdaju;
            }
            set
            {

                namestajZaProdaju = value;
                foreach (var n in namestajZaProdaju)
                {
                    NamestajZaProdajuId.Add(n.Id);
                }
                OnPropertyChanged("NamestajZaProdaju");
            }
        }


        public ObservableCollection<int> DodatneUsluge
        {
            get { return dodatneUsluge; }
            set
            {
                dodatneUsluge = value;
                OnPropertyChanged("DodatneUsluge");
            }
        }


        public string Kupac
        {
            get { return kupac; }
            set
            {
                kupac = value;
                OnPropertyChanged("Kupac");
            }
        }

        public string BrojRacuna
        {
            get { return brojRacuna; }
            set
            {
                brojRacuna = value;
                OnPropertyChanged("BrojRacuna");
            }
        }


        public DateTime DatumProdaje
        {
            get { return datumProdaje; }
            set
            {
                datumProdaje = value;
                OnPropertyChanged("DatumProdaje");
            }
        }


        public ObservableCollection<int> NamestajZaProdajuId
        {
            get { return namestajZaProdajuId; }
            set
            {
                namestajZaProdajuId = value;
                OnPropertyChanged("NamestajZaProdajuId");
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

        public override string ToString()
        {
            return $"{Id},{DatumProdaje},{BrojRacuna},{Kupac}";
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return new ProdajaNamestaja()
            {
                Id = id,
                Obrisan = obrisan,
                NamestajZaProdajuId = namestajZaProdajuId,
                DatumProdaje = datumProdaje,
                BrojRacuna = brojRacuna,
                Kupac = kupac
            };
        }

        public static void UcitajProdaju()
        {
            using (SqlConnection connection = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                connection.Open();

                DataSet ds = new DataSet();

                SqlCommand prodajaCommand = connection.CreateCommand();
                prodajaCommand.CommandText = @"SELECT * FROM PRODAJA";
                SqlDataAdapter daprodaja = new SqlDataAdapter();
                daprodaja.SelectCommand = prodajaCommand;
                daprodaja.Fill(ds, "Prodaja");

                foreach (DataRow row in ds.Tables["Prodaja"].Rows)
                {
                    ProdajaNamestaja n = new ProdajaNamestaja();
                    n.Id = (int)row["Id"];
                    n.DatumProdaje = (DateTime)row["DatumProdaje"];
                    n.BrojRacuna = (string)row["BrojRacuna"];
                    n.Kupac = (string)row["Kupac"];
                    n.DodatneUsluge.Add((int)row["ID"]);
                    n.NamestajZaProdajuId.Add((int)row["Id"]);

                    Aplikacija.Instance.Prodaja.Add(n);
                }
            }
        }

        public static void DodajProdaju(ProdajaNamestaja pn)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                conn.Open();
               
                SqlCommand command = conn.CreateCommand();
                command.CommandText = @"INSERT INTO PRODAJA (ID,DATUMPRODAJE,BROJRACUNA,KUPAC) VALUES (@ID,@DatumProdaje,@BrojRacuna,@Kupac)";

                command.Parameters.Add(new SqlParameter("@ID", pn.Id));
                command.Parameters.Add(new SqlParameter("@DatumProdaje", pn.DatumProdaje));
                command.Parameters.Add(new SqlParameter("@BrojRacuna", pn.BrojRacuna));
                command.Parameters.Add(new SqlParameter("@Kupac", pn.Kupac));

                command.ExecuteNonQuery();

                Random rnd = new Random();
                int id = rnd.Next(10, 10000);
                foreach (var n in pn.NamestajZaProdajuId)
                {
                    SqlCommand command2 = conn.CreateCommand();
                    command2.CommandText = @"INSERT INTO NAMESTAJZAPRODAJU (ID,NAMESTAJID,PRODAJAID) VALUES (@Idp,@NamestajID,@ProdajaID)";
                    command2.Parameters.Add(new SqlParameter("@IDp", id));
                    command2.Parameters.Add(new SqlParameter("@NamestajID", n));
                    command2.Parameters.Add(new SqlParameter("@ProdajaID", pn.Id));
                    command2.ExecuteNonQuery();
                    id++;
                }

                Random rnd2 = new Random();
                int id2 = rnd.Next(10, 10000);
                foreach (var n in pn.DodatneUsluge)
                {
                    SqlCommand command3 = conn.CreateCommand();
                    command3.CommandText = @"INSERT INTO USLUGEPRODAJE (ID,DODATNEUSLUGAID,PRODAJAID) VALUES (@Idp,@UslugaID,@ProdajaID)";
                    command3.Parameters.Add(new SqlParameter("@IDp", id2));
                    command3.Parameters.Add(new SqlParameter("@UslugaID", n));
                    command3.Parameters.Add(new SqlParameter("@ProdajaID", pn.Id));
                    command3.ExecuteNonQuery();
                    id2++;
                }
            }

        }

        public static void IzmeniProdaju(ProdajaNamestaja n)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONNECTION_STRING))
            {
                if (n.Id != 0)//ako postoji u bazi
                {
                    conn.Open();

                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = @"UPDATE PRODAJA SET DATUMPRODAJE=@DatumProdaje,BROJRACUNA=@BrojRacuna,KUPAC=@Kupac where ID=@ID";

                    command.Parameters.Add(new SqlParameter("@ID", n.Id));
                    command.Parameters.Add(new SqlParameter("@DatumProdaje", n.DatumProdaje));
                    command.Parameters.Add(new SqlParameter("@BrojRacuna", n.BrojRacuna));
                    command.Parameters.Add(new SqlParameter("@Kupac", n.Kupac));

                    command.ExecuteNonQuery();

                    SqlCommand command3 = conn.CreateCommand();
                    command3.CommandText = @"DELETE FROM NAMESTAJZAPRODAJU WHERE PRODAJAID=@ID";
                    command3.Parameters.Add(new SqlParameter("@ID", n.Id));
                    command3.ExecuteNonQuery();
    

                    Random rnd = new Random();
                    int id = rnd.Next(10, 10000);
                    foreach (var pn in n.NamestajZaProdajuId)
                    {
                        SqlCommand command2 = conn.CreateCommand();
                        command2.CommandText = @"INSERT INTO NAMESTAJZAPRODAJU (ID,NAMESTAJID,PRODAJAID) VALUES (@Idp,@NamestajID,@ProdajaID)";
                        command2.Parameters.Add(new SqlParameter("@IDp", id));
                        command2.Parameters.Add(new SqlParameter("@NamestajID", pn));
                        command2.Parameters.Add(new SqlParameter("@ProdajaID", n.Id));
                        command2.ExecuteNonQuery();
                        id++;
                    }

                    SqlCommand command4 = conn.CreateCommand();
                    command4.CommandText = @"DELETE FROM USLUGEPRODAJE WHERE PRODAJAID=@ID";
                    command4.Parameters.Add(new SqlParameter("@ID", n.Id));
                    command4.ExecuteNonQuery();


                    Random rnd2 = new Random();
                    int id2 = rnd.Next(10, 10000);
                    foreach (var pn in n.DodatneUsluge)
                    {
                        SqlCommand command5 = conn.CreateCommand();
                        command5.CommandText = @"INSERT INTO USLUGEPRODAJE (ID,DODATNEUSLUGAID,PRODAJAID) VALUES (@Idp,@UslugaID,@ProdajaID)";
                        command5.Parameters.Add(new SqlParameter("@IDp", id2));
                        command5.Parameters.Add(new SqlParameter("@UslugaID", pn));
                        command5.Parameters.Add(new SqlParameter("@ProdajaID", n.Id));
                        command5.ExecuteNonQuery();
                        id2++;
                    }

                }
            }
        }

    }
}
