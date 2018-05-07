using System;
using System.Collections.Generic;
using System.Linq;

namespace Zlozonosc
{
    class Menu
    {
        #region MainMenu
        public static void MainMenu()
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
                    List<string> data = new List<string>();
                    Lab1Menu(data);
                }
                    break;
                case "D2":
                {
                    LinkedList<dList> data = new LinkedList<dList>();
                    Lab2Menu(data);
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
                    MainMenu();
                    break;
            }

            Console.WriteLine();

        }
        #endregion

        #region Lab1Menu
        public static void Lab1Menu(List<string> data)
        {
            Console.Clear();
            Console.WriteLine("Lab 1.");
            Console.WriteLine("1. Wczytanie danych z pliku txt.");
            Console.WriteLine("2. Sortowanie wczytanych danych.");
            Console.WriteLine("3. Zapis danych do csv lub txt.");
            Console.WriteLine("4. Ciag fibonacciego ");
            Console.WriteLine("5. Cofnij");
            Console.Write("Wybierz zadanie");
            Console.WriteLine();
            ConsoleKeyInfo choice = Console.ReadKey(true);
            string zmiana = choice.Key.ToString();

            switch (zmiana)
            {
                case "D1":
                    {
                        Console.WriteLine("Write file name from which you want to read data.");
                        string fileName = Console.ReadLine();
                        List<string> doSortowania = utility.ReadFromFIle(fileName);
                        Console.ReadKey(true);
                        Lab1Menu(doSortowania);
                    }
                    break;
                case "D2":
                    {
                        if (!data.Any())
                        {
                            Console.WriteLine("Read data from file first.");
                            Console.ReadKey(true);
                            Menu.Lab1Menu(data);
                        }
                        else
                        {
                            List<int> poSortowaniu = Lab1.BubbleSort(data);
                            Console.WriteLine("Data has been sorted.");
                            Console.ReadKey(true);
                            Menu.Lab1Menu(utility.IntToString(poSortowaniu));
                        }
                        
                    }
                    break;
                case "D3":
                    {
                        if (!data.Any())
                        {
                            Console.WriteLine("Read data from file first.");
                            Console.ReadKey(true);
                            Menu.Lab1Menu(data);
                        }
                        else
                        {
                            utility.SaveToFileCsvOrTxt(data);
                            Console.WriteLine("Data has been saved to the file.");
                            Console.ReadKey(true);
                            Lab1Menu(data);
                        }
                        
                    }
                    break;
                case "D4":
                    {
                        Console.WriteLine("Ciag fib");
                        int ileIte = 0;
                        Console.Write("How many iterations?: ");
                        ileIte = Convert.ToInt32(Console.ReadLine());
                        Lab1.Fibb(ileIte);
                        Console.ReadKey(true);
                        Lab1Menu(data);

                    }
                    break;
                case "D5":
                    {

                        MainMenu();
                    }
                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine("Wrong Action!");
                    Console.ReadKey(true);
                    Lab1Menu(data);
                    break;
            }

            Console.WriteLine();

        }
        #endregion

        #region Lab2Menu
        public static void Lab2Menu(Object data)
        {


            Console.Clear();
            Console.WriteLine("Lab2.");
            Console.WriteLine("1. Wczytanie danych z txt");
            Console.WriteLine("2. wypisz z listy dwukierunkowej");
            Console.WriteLine("3. szukaj w liscie dwukierunkowej");
            Console.WriteLine("4. Wygeneruj drzewo bst");
            Console.WriteLine("5. Szukaj w drzewie bst");
            Console.WriteLine("8. Cofnij");
            Console.Write("Wybierz zadanie");
            Console.WriteLine();
            ConsoleKeyInfo choice = Console.ReadKey(true);
            string zmiana = choice.Key.ToString();

            switch (zmiana)
            {
                case "D1":
                    {
                        data = Lab2.ReadWords();
                        Console.WriteLine("Wczytano z pliku txt.");
                        Console.ReadKey(true);
                        Lab2Menu((LinkedList<dList>)data);
                    }
                    break;
                case "D2":
                    {
                        if (data.GetType() == typeof(LinkedList<dList>))
                        {
                            Lab2.WriteAll((LinkedList<dList>)data);
                            Console.ReadLine();
                            Console.ReadKey(true);
                            Lab2Menu(data);
                        }
                        else
                        {
                            Console.WriteLine($"Loaded Wrong Object: {data.GetType()}. switch to Diffrent function");
                        }
                        
                    }
                    break;
                case "D3":
                    {
                        if (data.GetType() == typeof(LinkedList<dList>))
                        {
                            Console.WriteLine("Podaj nazwe pliku z ktorego chcesz wczytac baze slow do szukania.");
                            string fileNameEng = Console.ReadLine();
                            Console.WriteLine("Podaj nazwe pliku z ktorego chcesz wczytac indexy");
                            string fileNameNum = Console.ReadLine();
                            Lab2.Search(utility.Generate(fileNameEng, fileNameNum), (LinkedList<dList>)data);
                            Console.ReadLine();
                            Console.ReadKey(true);
                            Lab2Menu(data);
                        }
                        else
                        {
                            Console.WriteLine($"Loaded Wrong Object: {data.GetType()}. switch to Diffrent function");
                        }

                    }
                    break;
                case "D4":
                {
                    if (data.GetType() == typeof(LinkedList<dList>))
                    {
                            if (!((LinkedList<dList>)data).Any())
                            {
                                 Console.WriteLine("Read data from file first.");
                                 Console.ReadKey(true);
                                 Lab2Menu(data);
                            }
                            else
                            {
                                BST.Node root = Lab2.OperationsOnTree((LinkedList<dList>)data);
                                Console.WriteLine("Three has been created.");
                                Console.ReadKey(true);
                                Lab2Menu(root);
                        
                            }
                    }
                    else
                    {
                        Console.WriteLine($"Loaded Wrong Object: {data.GetType()}. switch to Diffrent function");
                    }

                }
                break;

                case "D5":
                    if (data.GetType() == typeof(BST.Node))
                    {
                        Console.WriteLine("Give a file name in which you have a data base of words.");
                        string fileNameEng = Console.ReadLine();
                        Console.WriteLine("Give a file name in which you have randomized indexes");
                        string fileNameNum = Console.ReadLine();
                        Lab2.SearchBst(utility.Generate(fileNameEng, fileNameNum), (BST.Node)data);
                        Console.ReadLine();
                        Console.ReadKey(true);
                        Lab2Menu(data);
                    }
                    else
                    {
                        Console.WriteLine($"Loaded Wrong Object: {data.GetType()}. switch to Diffrent function");
                    }

                    break;

                case "D8":
                    {

                        Menu.MainMenu();
                    }
                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine("Niepoprawna akcja!");
                    Console.ReadKey(true);
                    Lab2Menu(data);
                    break;
            }

            Console.WriteLine();

        }
        #endregion
    }
}
