using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Menu.cs")]

namespace Zlozonosc
{
    static class Lab1
    {
        #region sortowanie babelkowe
        public static int[] Sortowanie(int[] tabsort)
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

       

        #region Wczytywanie z pliku txt
       
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

        #region random without duplicates
        public static int[] RandDuplicate()
        {
            

            Random random = new Random();
            int[] numbers = new int[1000];

            for (int i = 0; i < numbers.Length; i++)
            {
                while (numbers[i] == 0)
                {
                    int z = random.Next(1, 14430);
                    if (!numbers.Contains(z))
                    {
                        numbers[i] = z;
                    }
                  
                }
            }

          
            return numbers;
        }
        #endregion

        #region ciag fibb
        internal static unsafe void Fibb(int ileIte)
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
