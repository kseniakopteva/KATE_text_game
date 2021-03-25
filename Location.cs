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
        public List<Item> itemList;
        public Dictionary<string, Location> directions;
        public List<Location> availableLocations;

        public Location(string tag, string name)
        {
            this.tag = tag;
            this.name = name;
        }

        public void RemoveItem(Item item)
        {
            itemList.Remove(item);
        }

        public string Tag { get => tag; }
        public string Name { get => name; }
        public string Desc { get => desc; set => desc = value; }
    }
}
