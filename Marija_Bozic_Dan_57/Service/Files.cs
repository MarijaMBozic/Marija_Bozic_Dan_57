using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Service
{
    static class FilesPath
    {
        public static readonly string GetDirectoryPathArtica = AppDomain.CurrentDomain.BaseDirectory + @"\Files\Articals.txt";
        public static readonly string GetDirectoryPathBill = AppDomain.CurrentDomain.BaseDirectory + @"\BillFiles\Bill.txt";
    }
}