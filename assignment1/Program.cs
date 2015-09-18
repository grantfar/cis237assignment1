using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            string csvPathString = "";
            //tests to see if path given is valid
            while (!System.IO.File.Exists(csvPathString))
            {
                System.Console.WriteLine("Please enter wine list file path");
                csvPathString = System.Console.ReadLine();
            }
            CSVProcessor onlyRunOneCSVProcessor = new CSVProcessor(csvPathString);
            wineItemCollection theWineCollection = new wineItemCollection(onlyRunOneCSVProcessor);
            controlClass controlTheProgram = new controlClass(theWineCollection, onlyRunOneCSVProcessor);
            while(true)
            {
                controlTheProgram.PrintPrompt();
            }
        }

    }
}
