using Marija_Bozic_Dan_57.ServiceReference1;
using Marija_Bozic_Dan_57.ValidationInput;
using Service;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marija_Bozic_Dan_57.Helper
{
    public static class ConnectionService
    {
        public static int numOfBill = 0;
        public static void GetAllArticals()
        {          
            using (Service1Client service = new Service1Client())
            {
                List<Artical> listArticals = service.GetAllArticals().ToList();
                Console.WriteLine("All aricals:");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("{0, -5} {1, 20} {2, 10} ", "[NAME]", "[QUANTITY]", "[PRICE]");
                foreach (Artical item in listArticals)
                {
                    Console.WriteLine("{0, 5} {1, 13} {2, 15}",  item.Name, item.Quantity, item.Price);
                    Console.WriteLine("-----------------------------------------");
                }
            }            
        }
        public static void AddNewArtical()
        {
            using (Service1Client service = new Service1Client())
            {
                Artical a = new Artical();
                Console.WriteLine("Insert artical name:");
                a.Name = Console.ReadLine();
                if (service.GetArticalByName(a.Name) != null)
                {
                    Console.WriteLine("Artical by name {0} already exists!", a.Name.ToUpper());
                    return;
                }
                Console.WriteLine("Insert quantity of artical:");
                a.Quantity = Validation.ValidateInt();
                Console.WriteLine("Insert price of artical:");
                a.Price = Validation.ValidateInput();             

                service.AddNewArtical(a);
            }
        }
        public static void ChangePriceOfArtical()
        {
            using (Service1Client service = new Service1Client())
            {
                Console.WriteLine("Insert artical name:");
                string name = Console.ReadLine();
                Artical artical = service.GetArticalByName(name);
                if (artical == null)
                {
                    Console.WriteLine("Artical by name {0} doesn't exists!", name.ToUpper());
                    return;
                }
                Console.WriteLine("Insert new price for {0} :", name);
                artical.Price = Validation.ValidateInput();

                service.UpdateArtical(artical);
            }
        }

        public static void BuyArticals()
        {
            List<Artical> listOfArticals = new List<Artical>();
            using (Service1Client service = new Service1Client())
            {
                while (true)
                {
                    Console.WriteLine("\nIf you want to quit, press q:");
                    Console.WriteLine("\nIf you do not want any new articles, press x:");
                    Console.WriteLine("\nElse\nInsert name of artical:");
                    string input = Console.ReadLine();

                    if (input.ToLower() == "x")
                    {
                        if(listOfArticals.Count>0)
                        {
                            numOfBill++;
                            service.AddArticalToBill(listOfArticals.ToArray(), numOfBill);
                        }                        
                        break;
                    }
                    else if(input.ToLower()=="q")
                    {
                        break;
                    }

                    Artical a = service.GetArticalByName(input);
                    if(a==null)
                    {
                        Console.WriteLine("We dont have artical under the name: {0}", input.ToUpper());
                        continue;
                    }
                    Console.WriteLine("\nInsert quantity of artical:");
                    int inputQuantity = Validation.ValidateInt();
                    a.Quantity = inputQuantity;
                    if(service.CheckQuantity(a))
                    {
                        listOfArticals.Add(a);
                    }
                    else
                    {
                        Console.WriteLine("We do not have the desired amount of : {0}", input.ToUpper());
                        continue;
                    }                                
                }               
            }           
        }
    }
}
