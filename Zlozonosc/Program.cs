using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;


namespace Zlozonosc
{


    class Program
    {               
        private static void Main(string[] args)
        {
            var dataFilePath = Directory.GetCurrentDirectory();
            Console.WriteLine(dataFilePath);

            Lab2.OperationsOnTree(Lab2.ReadWords());
            
            
            //Menu.MainMenu();
            
            

            Console.WriteLine();
            Console.ReadLine();
        }


    }
}
