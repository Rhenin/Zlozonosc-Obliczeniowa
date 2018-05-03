using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Security.Policy;


namespace Zlozonosc
{


    class Program
    {               
        private static void Main(string[] args)
        {
            var dataFilePath = Directory.GetCurrentDirectory();
            Console.WriteLine(dataFilePath);

           
            Menu.MainMenu();


            Console.WriteLine();
            Console.ReadLine();
        }


    }
}
