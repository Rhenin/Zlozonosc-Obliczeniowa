using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zlozonosc
{
    static class Lab1
    {
        #region sortowanie babelkowe
        private static int[] Sortowanie(int[] tabsort)
        {
            Console.WriteLine("Sortowanie i tworzenie wykresu, prosze czekac!");

           

            string nazwa = null;
            Console.WriteLine("Podaj nazwe pliku do jakiego chcesz zapisac dane wykresu: ");
            nazwa = Console.ReadLine();            
            TextWriter doWykresu = new StreamWriter(Directory.GetCurrentDirectory() + "/" + nazwa + ".csv", true);

            int[] temp = new int[tabsort.Length];

            Stopwatch sw = new Stopwatch();
            for (int k = 2; k < tabsort.Length + 1; k++)
            {
                
                int t = 0;
                for (t = 0; t < tabsort.Length; t++)
                {
                    temp[t] = tabsort[t];
                }

               
                sw.Start();
                for (int j = 0; j < k; j++)
                {
                    for (int i = 0; i < k - j - 1; i++)
                    {
                        if (temp[i] > temp[i + 1])
                        {
                            var a = temp[i];
                            temp[i] = temp[i + 1];
                            temp[i + 1] = a;
                            
                        }


                    }
                }
                sw.Stop();


                var newLine = string.Format("{0},{1},",
                        k.ToString(), sw.Elapsed.TotalMilliseconds);
                sw.Reset();
                doWykresu.WriteLine(newLine.ToString());
            }

            doWykresu.Close();
            Console.WriteLine($"Czas Sortowania ={sw.Elapsed.TotalMilliseconds}ms");

            /*foreach (var i in tabsort)
                Console.WriteLine(i);*/

            return temp;
        }
        #endregion

        #region zapisywanie do txt
        public static void SaveToFileTxt(int[] doZapisu)
        {
            string nazwa = null;
            Console.WriteLine("Podaj nazwe pliku do jakiego chcesz zapisac: ");
            nazwa = Console.ReadLine();


            var stringBuilder = new StringBuilder();

            /*DirectoryInfo dataDir = new DirectoryInfo(@"C:\Users\Rhenin\source\Learning\C#Data");
            dataDir.Create();

            int[] daneDoSortowania =
            {5, 3, 4, 5, 6, 10, 1, 2, 3, 4, 5, 6, 10, 20, 14, 15, 16, 2, 4, 7};*/

            string dataFilePath = Directory.GetCurrentDirectory() + "/" + nazwa + ".txt"; 


            foreach (var arrayElement in doZapisu)
            {
                stringBuilder.AppendLine(arrayElement.ToString());
            }

            File.WriteAllText(dataFilePath, stringBuilder.ToString());


        }
        #endregion

        #region zapisywanie do csv
        public static void SaveToFileCsv(int[] doZapisu)
        {
            string nazwa = null;
            Console.WriteLine("Podaj nazwe pliku do jakiego chcesz zapisac: ");
            nazwa = Console.ReadLine();
            var stringBuilder = new StringBuilder();

            string dataFilePath = Directory.GetCurrentDirectory() + "/" + nazwa + ".csv";





            foreach (var arrayElement in doZapisu)
            {
                var newLine = string.Format("{0},{1}", arrayElement.ToString(), Environment.NewLine);
                stringBuilder.Append(newLine);
            }

            File.WriteAllText(dataFilePath, stringBuilder.ToString());


        }
        #endregion

        #region menu
        public static void Menu(int[] data)
        {


            Console.Clear();
            Console.WriteLine("Lab 1.");
            Console.WriteLine("1. Wczytanie danych z pliku txt.");
            Console.WriteLine("2. Sortowanie wczytanych danych.");
            Console.WriteLine("3. Zapis danych do txt.");
            Console.WriteLine("4. Zapis danych do csv.");
            Console.WriteLine("5. Ciag fibonacciego ");
            Console.WriteLine("6. Cofnij");



            Console.Write("Wybierz zadanie");
            Console.WriteLine();
            ConsoleKeyInfo choice = Console.ReadKey(true);
            string zmiana = choice.Key.ToString();

            switch (zmiana)
            {
                case "D1":
                    {
                        int[] doSortowania = ReadFromTxt();
                        Console.WriteLine("Wczytano z pliku txt.");
                        Console.ReadKey(true); 
                        Menu(doSortowania);
                    }
                    break;
                case "D2":
                    {
                        int[] poSortowaniu = Sortowanie(data);
                        Console.WriteLine("Posortowano wczytane dane");
                        Console.ReadKey(true);
                        Menu(poSortowaniu);
                    }
                    break;
                case "D3":
                    {
                        SaveToFileTxt(data);
                        Console.WriteLine("Zapisano do txt");
                        Console.ReadKey(true);
                        Menu(data);
                    }
                    break;
                case "D4":
                    {
                        SaveToFileCsv(data);
                        Console.WriteLine("Zapisano do csv");
                        Console.ReadKey(true);
                        Menu(data);

                    }
                    break;
                case "D5":
                    {
                        Console.WriteLine("Ciag fib");
                        int ileIte = 0;
                        Console.Write("Wpisz ilość iteracji: ");
                        ileIte = Convert.ToInt32(Console.ReadLine());
                        Fibb(ileIte);
                        Console.ReadKey(true);
                        Menu(data);

                    }
                    break;
                case "D6":
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

        }
        #endregion

        #region Wczytywanie z pliku txt
        public static int[] ReadFromTxt()
        {
            string dataFilePath = Directory.GetCurrentDirectory() + "\\liczby.txt"; ;
            StreamReader myFile = new StreamReader(dataFilePath);
            string myString = myFile.ReadToEnd();
            myFile.Close();


            string[] stringSeparators = new string[] { "\r\n" };
            string[] afterSplit = myString.Split(stringSeparators, StringSplitOptions.None);


            int[] myNumbers = new int[afterSplit.Length - 1];

            for (int i = 0; i < afterSplit.Length - 1; i++)
            {
                // myNumbers[i] = Convert.ToDouble(afterSplit[i]);
                Int32.TryParse(afterSplit[i], out myNumbers[i]);
            }

            #region dodawanie tablicy odwrotnej

           /* int[] myNumbers2 = new int[2 * afterSplit.Length - 2];
            for (int i = 0; i < afterSplit.Length - 1; i++)
            {
                myNumbers2[i] = myNumbers[i];
            }

            Array.Reverse(myNumbers);

            int j = 0;
            for (int i = afterSplit.Length - 1; i < 2 * afterSplit.Length - 2; i++)
            {
                myNumbers2[i] = myNumbers[j];
                j++;
            }*/
            #endregion


            Console.WriteLine();
            Console.WriteLine();
            return myNumbers;
        }
        #endregion

        #region generowanie losowych liczb
        private static int[] Losowe()
        {
            Random random = new Random();
            int[] liczby = new int[10000];

            for (int i = 0; i < 10000; i++)
            {
                liczby[i] = random.Next(1, 10000);
            }
            return liczby;
        }
        #endregion

        #region ciag fibb
        private static unsafe void Fibb(int ileIte)
        {
           

            int* fib = stackalloc int[ileIte];
            int* p = fib;

            *p++ = *p++ = 1;
            for (int i = 2; i < ileIte; ++i, ++p)
            {
               
                *p = p[-1] + p[-2];
               
            }
           
            for (int i = 0; i < ileIte; ++i)
            {
                Console.WriteLine(fib[i]);
            }
        }
        #endregion
    }
}
