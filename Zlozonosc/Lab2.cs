using System;
using System.Collections.Concurrent;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Diagnostics;
using System.Windows.Markup;


[assembly: InternalsVisibleTo("Menu.cs")]
[assembly: InternalsVisibleTo("Program.cs")]
namespace Zlozonosc
{
    
    class Lab2
    {
        #region read words to linked list
        internal static LinkedList<dList> ReadWords()
        {
           
            List<string> myEngStrings = utility.ReadFromFIle("engSmall.txt");
            List<string> myPolStrings = utility.ReadFromFIle("polSmall.txt");

            LinkedList<dList> lwList = new LinkedList<dList>();
            for (int i = 0; i < myEngStrings.Count(); i++)
            {
                lwList.AddLast(new dList(myEngStrings[i], myPolStrings[myPolStrings.Count - i - 1]));
            }
            return lwList;
        }
        #endregion
 
        #region search for words
        internal static void Search(List<string> toFind, LinkedList<dList> lwList)
        {
            string fileName = null;
            Console.WriteLine("Podaj nazwe pliku do jakiego chcesz zapisac dane wykresu: ");
            fileName = Console.ReadLine();
            TextWriter doWykresu = new StreamWriter(Directory.GetCurrentDirectory() + "/" + fileName + ".csv", true);
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
                var newLine = string.Format("{0};{1}",
                k.ToString(), sw.Elapsed.TotalMilliseconds);
                sw.Reset();
                doWykresu.WriteLine(newLine.ToString());
                Console.WriteLine();

            }
            doWykresu.Close();

        }
        #endregion

        #region display words
        internal static void WriteAll(LinkedList<dList> words)
        {
            int i = 1;
            foreach (var w in words)
            {
                
                Console.WriteLine($"{i}. English: {w.English}   Polish: {w.Polish}");
                i++;
            }
        }
        #endregion

        
        internal static BST.Node OperationsOnTree(LinkedList<dList> dict)
        {
            List<string> toFind = utility.Generate("engSmall.txt", "toFindS.txt");
            BST.Node root = null;
            BST.Tree bst = new BST.Tree();
            List<dList> data  = dict.ToList(); 

            for (int i = 0; i < data.Count; i++)
            {
                root = bst.Insert(root, data[i]);
            }

                                
           for (int i = 0; i < toFind.Count; i++)
            {
                bst.LookFor(root, toFind[i], i);
                    
            }                     
                Console.WriteLine();

            
            return root;
        }
        
            
            
        
        

     

    }
}
