using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


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
