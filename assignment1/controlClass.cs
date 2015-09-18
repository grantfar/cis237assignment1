using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class controlClass
    {
        CSVProcessor processCSV;
        wineItemCollection collectedWineItems;
        public controlClass(wineItemCollection collection, CSVProcessor processor)
        {
            processCSV = processor;
            collectedWineItems = collection;
        }

        public void PrintPrompt()
        {
            Console.WriteLine("\nEnter command or type \"help\" to see a list of commands");
            processAnswer(Console.ReadLine());
        }
        private void processAnswer(String promptAnswer)
        {
            String promptSwitch = promptAnswer;
            String promptStatements = "";
            if (promptSwitch.Contains(" "))
            {
                promptSwitch = promptSwitch.Substring(0, promptAnswer.IndexOf(' '));
                promptStatements = promptAnswer.Substring(promptAnswer.IndexOf(' ')+1);
            }

            switch(promptSwitch.ToLower())
            {
                case "help":
                    Console.WriteLine("display (id/all)".PadRight(43) + "|Displays the wine with the id/displays all wines\n" +
                        "display-multi (ids)".PadRight(43) + "|displays multible wines (inter ids seperated by commas\n" +
                        "add (wine ID, wine description, wine pack)".PadRight(43) + "|adds a wine to the wine list\n");
                    break;
                case "display":
                    displayWine(promptStatements.Trim());
                    break;
                case "display-multi":
                    displayMultiWines(promptStatements.Split(','));
                    break;
                case "add":
                    addWineItem(promptStatements.Split(','));
                    break;
                default:
                    Console.WriteLine("invalid Command: \"" + promptAnswer + "\"\n");
                    break;
            }
        }
        private void displayWine(String wineID)
        {
            if (wineID == "all")
                Console.WriteLine(collectedWineItems.ToString());
            else
            {
                wineItem wineMatchingID = collectedWineItems.findWine(wineID);
                if (wineMatchingID != null)
                    Console.WriteLine(wineMatchingID.ToString());
                else
                    Console.WriteLine("No wine with id: " + wineID + " is found");
            }
        }
        private void displayMultiWines(String[] wineIDs)
        {
            foreach(String s in wineIDs)
                displayWine(s.Trim());
        }
        private void addWineItem(String[] peramitersStrings)
        {
            if (peramitersStrings.Length == 3)
            {
                if (collectedWineItems.findWine(peramitersStrings[0]) != null)
                {
                    wineItem addWine = new wineItem(peramitersStrings[0], peramitersStrings[1], peramitersStrings[2], processCSV.LongestIdLength, processCSV.LongestDescriptionLength);
                    collectedWineItems.AddWine(addWine);
                    processCSV.AddWine(addWine);
                }
                else
                {
                    Console.WriteLine("Error: " + peramitersStrings[0] + " matches a wine ID already in the database");
                }
            }
            else if (peramitersStrings.Length > 3)
                Console.WriteLine("Error: to many parameters");
            else
                Console.WriteLine("Error: to few parameters");
        }
    }
}
