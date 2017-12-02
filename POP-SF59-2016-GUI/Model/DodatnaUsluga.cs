using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private int akcijaId;
        private Akcija akcija;

        public double CenaSaAkcijom()
        {
            double Ukupno = 0;
            var akcije = Projekat.Instance.Akcija;
            foreach (var a in akcije)
            {
                if (akcijaId == a.Id)
                {
                    double popust = (a.Popust / 100) * Cena;
                    Ukupno = Cena - popust;
                    return Ukupno;
                }
            }
            return Ukupno;
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

        public int AkcijaId
        {
            get { return akcijaId; }
            set
            {
                akcijaId = value;
                OnPropertyChanged("AkcijaId");
            }
        }

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
    }
}
