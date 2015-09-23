using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace assignment1
{
    /// <summary>
    /// A Class for handling the csv file
    /// </summary>
    class CSVProcessor
    {
        private System.IO.StreamReader wineReader;
        private String[][] wineArray;
        private string pathString;
        public CSVProcessor(String csvPathString)
        {
            pathString = csvPathString;
            wineArrayCreator();

        }
        //initial read in. only called by the constructer
        private void wineArrayCreator()
        {
            String[] tempWineArray;
            List<String> wineList = new List<string>();
            wineReader = new System.IO.StreamReader(pathString);
            while (!wineReader.EndOfStream)
            {
                wineList.Add(wineReader.ReadLine());
            }
            wineReader.Close();
            wineArray = new String[wineList.Count][];
            for (int i = 0; i < wineList.Count; i++)
            {
                tempWineArray = wineList[i].Split(',');
                wineArray[i] = tempWineArray;
            }
        }

        //adds a wine to the csv list
        public void AddWine(wineItem addedWine)
        {
            StreamWriter wineWriter = File.AppendText(pathString);
            wineWriter.WriteLine(addedWine.WineId + "," + addedWine.WineDescription + "," + addedWine.WinePack);
            wineWriter.Close();
        }
        //removes the wine from the csv file
        public void RemoveWine(wineItem removedWine)
        {
            List<String> newWineList = new List<String>();
            StreamReader wineReader = new StreamReader(pathString);
            String readLineString;
            //reads in all wines besides the specified wine
            while(!wineReader.EndOfStream)
            {
                readLineString = wineReader.ReadLine();
                if(!readLineString.Split(',')[0].Equals(removedWine.WineId))
                {
                    newWineList.Add(readLineString);
                }
            }
            wineReader.Close();
            //writes the read in lines to the csv after eracing it
            StreamWriter newFileWriter = new StreamWriter(File.Open(pathString, FileMode.Create));
            foreach (string s in newWineList)
                newFileWriter.WriteLine(s);
            newFileWriter.Close();
        }
        public String[][] WineArray
        {
            get
            {
                return wineArray;
            }
        }
    }
}
