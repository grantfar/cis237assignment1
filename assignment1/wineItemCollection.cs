﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    private class wineItemCollection
    {
        private wineItem[] collectionArray;
        public wineItemCollection(CSVProcessor refrence):this(refrence.WineArray, refrence.LongestDescriptionLength, refrence.LongestIdLength)
        { }
        
        public wineItemCollection(String[][] wineArray, int padDescription, int padID)
        {
            collectionArray = new wineItem[wineArray.Length];
            for (int i = 0; i < wineArray.Length; i++)
            {
                collectionArray[i] = new wineItem(wineArray[i][0], wineArray[i][1], wineArray[i][2], padDescription, padID);
            }
        }
        public wineItem findWine(String id)
        {
            wineItem returnWine = new wineItem(id);
            for (int i = 0; i < collectionArray.Length; i++)
            {
                if (collectionArray[i].Equals(returnWine))
                    return collectionArray[i];
            }
            return null;
        }
    }
}