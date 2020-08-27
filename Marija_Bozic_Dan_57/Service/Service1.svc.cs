﻿using Service.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {        
        public List<Artical> GetAllArticals()
        {
            List<Artical> allArticals = new List<Artical>();
            string fileName = FilesPath.GetDirectoryPathArtica;
            
            if (File.Exists(fileName))
            {
                using (StreamReader reader = File.OpenText(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] lineData = line.Split(',');
                        Artical a = new Artical();
                        a.Name = lineData[0];
                        a.Quantity = int.Parse(lineData[1]);
                        a.Price = double.Parse(lineData[2]);
                        allArticals.Add(a);
                    }
                }
            }
            else
            {
                Console.WriteLine("File {0} dont exist.", fileName);
            }
            return allArticals;
        }

        public void UpdateArtical(Artical artical)
        {
            string fileName = FilesPath.GetDirectoryPathArtica;
            List<Artical> articalList = GetAllArticals();

            using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                foreach(Artical art in articalList)
                {
                    if(art.Name==artical.Name)
                    {
                        art.Price = artical.Price;
                    }
                    writer.WriteLine("{0},{1},{2}", art.Name, art.Quantity, art.Price);
                }                
            }
        }

        public void AddNewArtical(Artical artical)
        {
            string fileName = FilesPath.GetDirectoryPathArtica;
            List<Artical> articalList= GetAllArticals();
            articalList.Add(artical);

            using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                foreach(Artical a in articalList)
                {
                    writer.WriteLine("{0},{1},{2}", a.Name, a.Quantity, a.Price);
                }                
            }
        }

        public Artical GetArticalByName(string name)
        {
            List<Artical> articalList = GetAllArticals();
            foreach (Artical item in articalList)
            {
                if(item.Name.ToLower()== name.ToLower())
                {
                    return item;
                }
            }
            return null;
        }
    }
}