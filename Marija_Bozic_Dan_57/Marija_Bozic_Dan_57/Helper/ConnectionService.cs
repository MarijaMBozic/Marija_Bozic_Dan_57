using Marija_Bozic_Dan_57.ServiceReference1;
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
                a.Quantity = int.Parse(Console.ReadLine());
                Console.WriteLine("Insert price of artical:");
                a.Price = double.Parse(Console.ReadLine());             

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
                Console.WriteLine("Insert new price for {0} :", name);
                artical.Price = double.Parse(Console.ReadLine());

                service.UpdateArtical(artical);
            }
        }
    }
}
