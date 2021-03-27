using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATE_text_game
{
    class Location
    {
        string tag;
        string name;
        string desc;

        // TODO: change public to private
        public Dictionary<string, Location> directions;
        List<Item> itemList;
        List<Location> availableLocations;

        string[] asciiArt;

        public string[] AsciiArt
        {
            get { return asciiArt; }
            set { asciiArt = value; }
        }

        public List<Location> AvailableLocations
        {
            set => availableLocations = value;
            get => availableLocations;
        }

        public List<Item> ItemList
        {
            set => itemList = value;
            get => itemList;
        }

        public Location(string tag, string name)
        {
            this.tag = tag;
            this.name = name;
        }

        public string Tag { get => tag; }
        public string Name { get => name; }
        public string Desc { get => desc; set => desc = value; }
    }
}
