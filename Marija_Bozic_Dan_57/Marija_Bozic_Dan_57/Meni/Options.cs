using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marija_Bozic_Dan_57.Meni
{
    public delegate void FunctionsOptions();
    public class Options
    {
        public string Tekst { get; set; }
        public FunctionsOptions Functions { get; set; }
        
        public Options(FunctionsOptions functions, string tekst)
        {
            this.Functions = functions;
            this.Tekst = tekst;
        }
    }
}
