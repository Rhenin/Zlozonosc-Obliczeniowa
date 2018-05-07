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
        #region BubbleSort
        public static List<int> BubbleSort(List<string> tabsortList)
        {
            Console.WriteLine("Sorting... Please Wait!");
            int[] tabsort = new int[tabsortList.Count];
            tabsort = utility.StringToInts(tabsortList).ToArray();
            string fileName = null;
            Console.WriteLine("Name a file in which you want to save Stopwatch data: ");
            fileName = Console.ReadLine();
            TextWriter doWykresu = new StreamWriter(Directory.GetCurrentDirectory() + "/" + fileName + ".csv", true);
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
                var newLine = string.Format("{0};{1}",
                        k.ToString(), sw.Elapsed.TotalMilliseconds);
                sw.Reset();
                doWykresu.WriteLine(newLine.ToString());
            }
            doWykresu.Close();
            List<int> tempList = temp.ToList();
            Console.WriteLine($"Czas Sortowania ={sw.Elapsed.TotalMilliseconds}ms");
            return tempList;
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
