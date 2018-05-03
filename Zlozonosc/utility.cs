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
        public static List<string> Generate(string fileNameEng, string fileNameNum)
        {
           
            List<string> myEngStrings = ReadFromFIle(fileNameEng);
            List<string> myNumStrings = ReadFromFIle(fileNameNum);
            List<int> myNumInts = new List<int>();
            try
            {
                myNumInts = myNumStrings.Select(s => int.Parse(s)).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);             
            }                     
            List<string> toFind = new List<string>();
            foreach (int s in myNumInts)
            {
                toFind.Add(myEngStrings[s]);
            }
            return toFind;
        }


        public static List<string> ReadFromFIle(string fileName)
        {
            string dataFilePath = Directory.GetCurrentDirectory() + "//" + fileName;
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
                    Console.WriteLine("Wczytano poprawnie dane z pliku!");
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            return data;
        }

    }
}
