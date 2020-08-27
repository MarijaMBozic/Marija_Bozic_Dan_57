using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marija_Bozic_Dan_57.Meni
{
    public class Meni
    {
        public List<Options> listOptions;

        public Meni()
        {
            listOptions = new List<Options>();
        }

        public void AddOption(FunctionsOptions function, string text)
        {
            Options newOption = new Options(function, text);
            listOptions.Add(newOption);
        }

        public void MenuOptions()
        {
            Console.WriteLine("Options:");
            int numOfOption = 1;
            foreach(Options o in listOptions)
            {
                Console.WriteLine("{0}-{1}", numOfOption, o.Tekst);
                numOfOption++;
            }

            Console.WriteLine();
            Console.WriteLine("0-Back");
            Console.WriteLine("-----------------------------------");
        }

        public int ReadOptionFromUser()
        {
            Console.WriteLine("Choose option(0-{0})", listOptions.Count);
            int choosenOption = ValidateInput();
            if(choosenOption<0 || choosenOption>listOptions.Count)
            {
                Console.WriteLine("The entered option is invalid");
                return -1;
            }
            return choosenOption;
        }

        public void ExecuteOption(int numberOfoption)
        {
            if (numberOfoption > 0 && numberOfoption <= listOptions.Count)
            {
                listOptions[numberOfoption - 1].Functions();
            }
            Console.WriteLine();
        }

        public void RunOption()
        {
            int choosenOption;
            do
            {
                MenuOptions();
                choosenOption = ReadOptionFromUser();
                ExecuteOption(choosenOption);
            } while (choosenOption != 0);
        }

        public static int ValidateInput()
        {
            int number;
            while (Int32.TryParse(Console.ReadLine(), out number) == false)
            {
                Console.Write("Error - incorrectly entered value, try again: ");
            }
            return number;
        }

    }
}
