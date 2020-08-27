using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Service.Models
{
    [Serializable]
    public class Artical
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Quantity { get; set; }
        [DataMember]
        public double Price { get; set; }
    }
}