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

        public static string CreateBillTxt(int numOfBill)
        {
            string timeStamp = DateTime.Now.ToString("ddMMyyyyhhmmss");
            string pathBill = AppDomain.CurrentDomain.BaseDirectory + @"\BillFiles\"+string.Format("Bill_{0}_{1}.txt", numOfBill, timeStamp);

            return pathBill;
        }
    }
}