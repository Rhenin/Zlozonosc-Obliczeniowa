using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Zlozonosc
{
    class Node
    {
        public int value;
        public Node left;
        public Node right;
    }

    class Tree
    {
        public Node insert(Node root, int v)
        {
            if (root == null)
            {
                root = new Node();
                root.value = v;
            }
            else if (v < root.value)
            {
                root.left = insert(root.left, v);
            }
            else
            {
                root.right = insert(root.right, v);
            }

            return root;
        }

        public void traverse(Node root)
        {
            if (root == null)
            {
                return;
            }

            traverse(root.left);
            traverse(root.right);
        }
    }


    class Lab2
    {
        #region menu
        public static void Menu(int[] data)
        {


            Console.Clear();
            Console.WriteLine("Lab2.");
            Console.WriteLine("1. Wczytanie danych z txt");
            Console.WriteLine("2. Quick Sort");
            Console.WriteLine("3. Save to txt");
            Console.WriteLine("4. Save to csv");
            Console.WriteLine("5. bst");
            Console.WriteLine("6. MaxHeap");
            Console.WriteLine("7. MinHeap");
            Console.WriteLine("8. Cofnij");



            Console.Write("Wybierz zadanie");
            Console.WriteLine();
            ConsoleKeyInfo choice = Console.ReadKey(true);
            string zmiana = choice.Key.ToString();

            switch (zmiana)
            {
                case "D1":
                {
                    int[] doSortowania = Lab1.ReadFromTxt();
                    Console.WriteLine("Wczytano z pliku txt.");
                    Console.ReadKey(true);
                        Menu(doSortowania);
                }
                    break;
                case "D2":
                {
                    int[] poSortowaniu = Qs(data,0,data.Length - 1);
                    Console.WriteLine("Posortowano wczytane dane");
                    Console.ReadKey(true);
                    Menu(poSortowaniu);
                    }
                    break;
                case "D3":
                {
                   Lab1.SaveToFileTxt(data);
                    Console.WriteLine("Zapisano do txt");
                    Console.ReadKey(true);
                    Menu(data);

                    }
                    break;
                case "D4":
                {
                    Lab1.SaveToFileCsv(data);
                    Console.WriteLine("Zapisano do csv");
                    Console.ReadKey(true);
                    Menu(data);
                    }
                    break;

                case "D5":
                {
                    BST(data);
                    Console.WriteLine("BST");
                    Console.ReadKey(true);
                    Menu(data);
                }
                    break;
                case "D6":
                {
                    BinaryHeap test = new BinaryHeap();
                    int[] heap = test.BuildMaxHeap(data);
                    Console.WriteLine("MaxHeap");
                    Console.ReadKey(true);
                    Menu(data);
                }
                    break;
                case "D7":
                {
                    BinaryHeap test = new BinaryHeap();
                    int[] heap = test.BuildMinHeap(data);
                    Console.WriteLine("MinHeap");
                    Console.ReadKey(true);
                    Menu(data);
                }
                    break;
                case "D8":
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
        #region Bst
        public static void BST(int[] data)
        {
            Node root = null;
            Tree bst = new Tree();
            Stopwatch watch = Stopwatch.StartNew();
            watch = Stopwatch.StartNew();

            for (int i = 0; i < data.Length; i++)
            {
                root = bst.insert(root, data[i]);
            }

            watch.Stop();

            Console.WriteLine("Done. Took {0} miliseconds", watch.Elapsed);
            Console.WriteLine();
            Console.WriteLine("Traversing all {0} nodes in tree...", data.Length);

            watch = Stopwatch.StartNew();
            bst.traverse(root);

            watch.Stop();

            Console.WriteLine("Done. Took {0} miliseconds", watch.Elapsed);
            Console.WriteLine();
           
        }
        #endregion
        #region QuickSort
        public static int[] Qs(int[] array, int left, int right)
        {
            var i = left;
            var j = right;
            var pivot = array[(left + right) / 2];
            while (i < j)
            {
                while (array[i] < pivot) i++;
                while (array[j] > pivot) j--;
                if (i <= j)
                {
                    // swap
                    var tmp = array[i];
                    array[i++] = array[j];  // ++ and -- inside array braces for shorter code
                    array[j--] = tmp;
                }
            }
            if (left < j) Qs(array, left, j);
            if (i < right) Qs(array, i, right);

            return array;
        }
        #endregion

        /*private static int[] Qs(int[] tabsort)
        {
            int pivotPos = tabsort.Length / 2;
            int pivot = tabsort[pivotPos];
            int[] left = new int[pivotPos];
            int[] right = new int[tabsort.Length-pivotPos];
            for (int i = 0; i < pivotPos - 1; i++)
            {
                
            }

            return tabsort;
        }*/
    }
}
