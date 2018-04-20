using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Zlozonosc
{
    
    class Lab2
    {
        #region menu
        public static void Menu(List<dList> data)
        {


            Console.Clear();
            Console.WriteLine("Lab2.");
            Console.WriteLine("1. Wczytanie danych z txt");
            Console.WriteLine("8. Cofnij");



            Console.Write("Wybierz zadanie");
            Console.WriteLine();
            ConsoleKeyInfo choice = Console.ReadKey(true);
            string zmiana = choice.Key.ToString();

            switch (zmiana)
            {
                case "D1":
                {
                    data = ReadWords();
                    Console.WriteLine("Wczytano z pliku txt.");
                    Console.ReadKey(true);
                        Menu(data);
                }
                    break;
                case "D2":
                {
                    WriteAll(data);
                    Console.ReadLine();
                    Console.ReadKey(true);
                        Menu(data);
                }
                    break;

                case "D8":
                {
                    
                    Program.Menu();
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


        private static List<dList> ReadWords()
        {
            string engFilePath = Directory.GetCurrentDirectory() + "\\eng.txt"; 
            StreamReader myEngFile = new StreamReader(engFilePath);
            string myEngString = myEngFile.ReadToEnd();
            myEngFile.Close();


            string polFilePath = Directory.GetCurrentDirectory() + "\\pol.txt"; 
            StreamReader myPolFile = new StreamReader(polFilePath);
            string myPolString = myPolFile.ReadToEnd();
            myPolFile.Close();

            string[] stringSeparatorsEng = new string[] { "\n" };
            string[] stringSeparatorsPol = new string[] { "\r\n" };
            string[] afterSplitEng = myEngString.Split(stringSeparatorsEng, StringSplitOptions.None);
            string[] afterSplitPol = myPolString.Split(stringSeparatorsPol, StringSplitOptions.None);


            
            List<dList> lwList = new List<dList>();

            for (int i = 0; i < afterSplitEng.Length - 1; i++)
            {
                lwList.Add(new dList(afterSplitEng[i], afterSplitPol[i]));
            }
           

            return lwList;
        }

        private static void WriteAll(List<dList> words)
        {
            int i = 1;
            foreach (var w in words)
            {
                
                Console.WriteLine($"{i}. English: {w.English}   Polish: {w.Polish}");
                i++;
            }
        }
    }
}
