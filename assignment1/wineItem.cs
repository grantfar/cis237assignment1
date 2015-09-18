using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class wineItem
    {
        protected String wineId;
        private String wineDescriptionString;
        private String winePackString;
        private int longestIdLength;
        private int longestDescriptionLength;

        public wineItem(String id, String description, String pack): this(id,description,pack,0,0)
        {
        }
        public wineItem(String id, String description, String pack, int padDescription, int padID)
        {
            wineId = id;
            wineDescriptionString = description;
            winePackString = pack;
            longestIdLength = padID;
            longestDescriptionLength = padDescription;
        }
        public wineItem(String id)
        {
            wineId = id;
        }
        public String WineId
        {
            get
            {
                return wineId;
            }
        }

        public String WineDescription
        {
            get
            {
                return wineDescriptionString;
            }
        }

        public String WinePack
        {
            get
            {
                return winePackString;
            }
        }
        public override string ToString()
        {
            return "ID: " + wineId.PadRight(longestIdLength + 2) + "Description: " + wineDescriptionString.PadRight(longestDescriptionLength + 2) + "Pack: " + winePackString;
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
