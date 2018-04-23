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
        public static void Menu(LinkedList<dList> data)
        {


            Console.Clear();
            Console.WriteLine("Lab2.");
            Console.WriteLine("1. Wczytanie danych z txt");
            Console.WriteLine("2. wwypisz");
            Console.WriteLine("3. szukaj");
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
                case "D3":
                {
                    Search(Program.Generate(),data);
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


        private static LinkedList<dList> ReadWords()
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


            
            LinkedList<dList> lwList = new LinkedList<dList>();

            for (int i = 0; i < afterSplitEng.Length - 1; i++)
            {
                lwList.AddLast(new dList(afterSplitEng[i], afterSplitPol[afterSplitPol.Length - i - 1]));
            }
           

            return lwList;
        }

        private static void Search(List<string> toFind, LinkedList<dList> lwList)
        {
            string nazwa = null;
            Console.WriteLine("Podaj nazwe pliku do jakiego chcesz zapisac dane wykresu: ");
            nazwa = Console.ReadLine();
            TextWriter doWykresu = new StreamWriter(Directory.GetCurrentDirectory() + "/" + nazwa + ".csv", true);
            Stopwatch sw = new Stopwatch();
            for (int k = 1; k < toFind.Count + 1; k++)
            {
                sw.Start();
                for (int i = 0; i < k; i++)
                {
                   
                    dList found = lwList.SingleOrDefault(r => r.English == toFind[i]);

                    Console.WriteLine($"{i + 1}:Znaleziono {found.English} oraz {found.Polish}");
                }
                sw.Stop();
                var newLine = string.Format("{0},{1},",
                k.ToString(), sw.Elapsed.TotalMilliseconds);
                sw.Reset();
                doWykresu.WriteLine(newLine.ToString());
                Console.WriteLine();

            }
            doWykresu.Close();

        }

        private static void WriteAll(LinkedList<dList> words)
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
