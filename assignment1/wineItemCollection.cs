using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    /// <summary>
    ///  A Class used to hold and search through the wine database
    /// </summary>

    class wineItemCollection
    {
        private List<wineItem> collectionList;
        public wineItemCollection(CSVProcessor refrence)
            : this(refrence.WineArray)
        { }

        public wineItemCollection(String[][] wineArray)
        {
            collectionList = new List<wineItem>();
            for (int i = 0; i < wineArray.Length; i++)
            {
                collectionList.Add(new wineItem(wineArray[i][0], wineArray[i][1], wineArray[i][2]));
            }
        }
        public wineItem findWine(String id)
        {
            wineItem returnWine = new wineItem(id);
            for (int i = 0; i < collectionList.Count; i++)
            {
                if (collectionList[i].Equals(returnWine))
                    return collectionList[i];
            }
            return null;
        }
        /// <summary>
        /// removes the wine item matching the input wine item from the list
        /// </summary>
        /// <param name="removealItem"></param>
        public void removeWine(wineItem removealItem)
        {
            collectionList.Remove(removealItem);
        }
        public void AddWine(wineItem addedWine)
        {
            collectionList.Add(addedWine);
        }
        /// <summary>
        /// outputs all the wine items in the array
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            String returnString = "";
            foreach (wineItem w in collectionList)
                returnString += w.ToString() + Environment.NewLine;
            return returnString;
        }
    }
}
