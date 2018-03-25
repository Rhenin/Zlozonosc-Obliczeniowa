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
        #region menu
        public static void Menu(int[] data)
        {


            Console.Clear();
            Console.WriteLine("Laboratorium z Zlozeniosc Obliczeniowa.");
            Console.WriteLine("1. Zadania z Lab1");
            Console.WriteLine("2. Zadania z Lab2");
            Console.WriteLine("3. Zakonczenie dzialania programu");



            Console.Write("Wybierz zadanie");
            Console.WriteLine();
            ConsoleKeyInfo choice = Console.ReadKey(true);
            string zmiana = choice.Key.ToString();

            switch (zmiana)
            {
                case "D1":
                    {
                        Lab1.Menu(data);
                    }
                    break;
               
                case "D3":
                    {
                        Console.WriteLine("Bywaj");
                        Console.ReadKey(true);
                        Environment.Exit(1);
                    }
                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine("Niepoprawna akcja!");
                    Console.ReadKey(true);
                    Menu(data);
                    break;
            }

            Console.WriteLine();

        }
        #endregion
        private static void Main(string[] args)
        {
            var dataFilePath = Directory.GetCurrentDirectory();
            Console.WriteLine(dataFilePath);
            int[] data = new int[1];
            Menu(data);
           

            Console.WriteLine();
            Console.ReadLine();
        }


    }
}
