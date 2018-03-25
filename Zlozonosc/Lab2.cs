using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zlozonosc
{
    class Lab2
    {
        #region menu
        public static void Menu(int[] data)
        {


            Console.Clear();
            Console.WriteLine("Lab2.");
            Console.WriteLine("1. Wczytanie danych z txt");
            Console.WriteLine("2. Quick Sort");
            Console.WriteLine("3. Cofnij");



            Console.Write("Wybierz zadanie");
            Console.WriteLine();
            ConsoleKeyInfo choice = Console.ReadKey(true);
            string zmiana = choice.Key.ToString();

            switch (zmiana)
            {
                case "D1":
                {
                    int[] doSortowania = Lab1.ReadFromTxt();
                    Menu(doSortowania);
                }
                    break;
                case "D2":
                {
                    QS(data);
                }
                    break;

                case "D3":
                {
                    Program.Menu(data);
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

        }#endregion

        private static int[] QS(int[] tabsort)
        {


            return tabsort;
        }
    }
}
