using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        private DateTime date;
        private decimal popust;


        //[XmlIgnore]
        //public ObservableCollection<Namestaj> NamestajNaPopustu
        //{
        //    get
        //    {
        //        foreach (var id in namestajNaPopustuId)
        //        {
        //            namestajNaPopustu.Add(Namestaj.GetById(id)); 
        //        }
        //        return namestajNaPopustu;
        //    }
        //    set
        //    {
        //        namestajNaPopustu = value;
        //        foreach (var namestaj in namestajNaPopustu)
        //        {
        //            NamestajNaPopustuId.Add(namestaj.Id);
        //            OnPropertyChanged("NamestajNaPopustu");
        //        }
                
        //    }
        //}


        //public ObservableCollection<int> NamestajNaPopustuId
        //{
        //    get { return namestajNaPopustuId; }
        //    set
        //    {
        //        namestajNaPopustuId = value;
        //        OnPropertyChanged("NamestajNaPopustuId");
        //    }
        //}


        public decimal Popust
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
            get { return date; }
            set
            {
                date = value;
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
                //NamestajNaPopustuId = namestajNaPopustuId
            };
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
            return $"{DatumPocetka},{DatumZavrsetka},{Popust}";
        }

    }
}
