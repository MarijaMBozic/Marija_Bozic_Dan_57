using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Service
{
  
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        List<Artical> GetAllArticals();

        [OperationContract]
        void UpdateArtical(Artical artical);

        [OperationContract]
        void AddNewArtical(Artical artical);

        [OperationContract]
        Artical GetArticalByName(string name);

        [OperationContract]
        void AddArticalToBill(List<Artical> listOfArticals, int numberOfBill);

        [OperationContract]
        void CreateBill(Bill bill, int numberOfBill);

        [OperationContract]
        void CorectArticalQuantity(List<Artical> listOfBuyArticals);

    }

    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
