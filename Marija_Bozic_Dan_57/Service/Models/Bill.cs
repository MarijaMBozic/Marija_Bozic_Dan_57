using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Service.Models
{
    [Serializable]
    public class Bill
    {
        [DataMember]
        public int BrojRacuna { get; set; }
        [DataMember]
        public DateTime TimeStamp { get; set; }
        [DataMember]
        public double TotalPrice { get; set; }
        [DataMember]
        public List<Artical> ListArticals { get; set; }

        public Bill()
        {
            BrojRacuna++;
        }
    }
}