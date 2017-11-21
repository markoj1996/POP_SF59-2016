﻿using POP_SF59_2016.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP_SF59_2016.Util1
{
    public class GenericSerialize
    {
        public static void Serialize<T>(string fileName, ObservableCollection<T> listToSerialize) where T : class
        {
            try
            {
                var serializer = new XmlSerializer(typeof(ObservableCollection<T>));
                using (var sw = new StreamWriter($@"../../Data/{fileName}"))
                {
                    serializer.Serialize(sw, listToSerialize);
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public static ObservableCollection<T> Deserialize<T>(string fileName) where T : class
        {
            try
            {
                var serializer = new XmlSerializer(typeof(ObservableCollection<T>));
                using (var sr = new StreamReader($@"../../Data/{fileName}"))
                {
                    return (ObservableCollection<T>)serializer.Deserialize(sr);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
