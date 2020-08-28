using Marija_Bozic_Dan_57.Helper;
using Marija_Bozic_Dan_57.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marija_Bozic_Dan_57
{
    class Program
    {
        static void Main(string[] args)
        {            
            Meni.Meni meni = new Meni.Meni();
            meni.AddOption(ConnectionService.GetAllArticals, "Show all aricals");
            meni.AddOption(ConnectionService.AddNewArtical, "Add new artical");
            meni.AddOption(ConnectionService.ChangePriceOfArtical, "Change Price Of Artical");
            meni.AddOption(ConnectionService.BuyArticals, "Buy articals");
            meni.RunOption();
            Console.ReadKey();
        }
    }
}
