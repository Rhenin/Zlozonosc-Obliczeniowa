using System;
using System.IO;


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
