using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF59_2016.Model
{
    public class ProdajaNamestaja : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private bool obrisan;
        private List<int> namestajZaProdajuId = new List<int>();
        private DateTime datumProdaje;
        private string brojRacuna;
        private string kupac;

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


        public List<int> NamestajZaProdajuId
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
    }
}
