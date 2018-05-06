using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Zlozonosc
{
    static class utility
    {
        #region Generate words
        public static List<string> Generate(string fileNameEng, string fileNameNum)
        {
           
            List<string> myEngStrings = ReadFromFIle(fileNameEng);
            List<string> myNumStrings = ReadFromFIle(fileNameNum);
            List<int> myNumInts = new List<int>();
            myNumInts = StringToInts(myNumStrings);
               
            List<string> toFind = new List<string>();
            foreach (int s in myNumInts)
            {
                toFind.Add(myEngStrings[s]);
            }
            return toFind;
        }
        #endregion

        #region ReadDataFromFile
        public static List<string> ReadFromFIle(string fileName)
        {
            string dataFilePath = Directory.GetCurrentDirectory() + "\\" + fileName;
            List<string> data = new List<string>();
            try
            {          
                using(StreamReader myFile = new StreamReader(dataFilePath))
                {

                    string line = null;
                    int i = 0;
                    while ((line = myFile.ReadLine()) != null)
                    {
                        data.Add(line);
                    }
                    Console.WriteLine($"Wczytano poprawnie dane z pliku: {fileName}");
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            return data;
        }
        #endregion

        #region SaveToCsvOrTxt
        public static void SaveToFileCsvOrTxt(List<string> doZapisu)
        {
            string fileName = null;
            Console.WriteLine("Name a file to which you want save the data: ");
            fileName = Console.ReadLine();
            var stringBuilder = new StringBuilder();
            string dataFilePath = Directory.GetCurrentDirectory() + "/" + fileName;
            if (fileName.Contains(".txt"))
            {
                foreach (var element in doZapisu)
                {
                    stringBuilder.AppendLine(element);
                }
                File.WriteAllText(dataFilePath, stringBuilder.ToString());

            }
            else
            {
                if (fileName.Contains(".csv"))
                {
                    foreach (var arrayElement in doZapisu)
                    {
                        var newLine = String.Format("{0};{1}", arrayElement, Environment.NewLine);
                        stringBuilder.Append(newLine);
                        File.WriteAllText(dataFilePath, stringBuilder.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("Wrong file format, only txt and csv are supported.");
                    Console.WriteLine("Try again");
                    SaveToFileCsvOrTxt(doZapisu);
                }
            }
           
            
        }
        #endregion

        #region GenerateRandomInts
        private static int[] RandomInts()
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

        #region ConvertList string to Int

        public static List<int> StringToInts(List<string> toConvert)
        {
            List<int> afterConvert = new List<int>();
            try
            {
                afterConvert = toConvert.Select(s => Int32.Parse(s)).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return afterConvert;
        }
        #endregion

        #region ConvertList Int to String

        public static List<string> IntToString(List<int> toConvert)
        {
            List<string> afterConvert = new List<string>();
            try
            {
                afterConvert = toConvert.Select(s => s.ToString()).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return afterConvert;
        }
        #endregion

       
        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
