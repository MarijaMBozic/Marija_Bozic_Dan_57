using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marija_Bozic_Dan_57.ValidationInput
{
    public static class Validation
    {
        public static int ValidateInt()
        {
            int number;
            while (Int32.TryParse(Console.ReadLine(), out number) == false)
            {
                Console.Write("Error - incorrectly entered value, try again: ");
            }
            return number;
        }

        public static double ValidateInput()
        {
            double number;
            while (Double.TryParse(Console.ReadLine(), out number) == false)
            {
                Console.Write("Error - incorrectly entered value, try again: : ");
            }
            return number;
        }
    }
}
