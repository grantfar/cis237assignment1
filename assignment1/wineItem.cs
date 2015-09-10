using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    private class wineItem
    {
        protected String wineId;
        private String wineDescriptionString;
        private String winePackString;
        private int longestIdLength;
        private int longestDescriptionLength;

        public wineItem(String id, String description, String pack, int padDescription, int padID)
        {
            wineId = id;
            wineDescriptionString = description;
            winePackString = pack;
        }
        public wineItem(String id)
        {
            wineId = id;
        }
        public override string ToString()
        {
            return "ID: " + wineId.PadRight(longestIdLength + 5) + "Description:" + wineDescriptionString.PadRight(longestDescriptionLength + 5) + "Pack:" + winePackString;
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType().Equals(this.GetType()))
            {
                wineItem comp = (wineItem)obj;
                return comp.wineId.Equals(wineId);
            }
            return false;
        }
    }
}
