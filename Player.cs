using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATE_text_game
{
    [Serializable]
    class Player
    {
        Location loc;
        int health = 10;

        // TODO: make private
        public List<Item> inventory = new List<Item>() { };

        public Player(Location loc) { this.loc = loc; }
        public Location Loc { get => loc; set => loc = value; }

        public void AddItem(Item item)
        {
            inventory.Add(item);
            loc.ItemList.Remove(item);
        }
        public void RemoveItem(Item item)
        {
            inventory.Remove(item);
            loc.ItemList.Add(item);
        }

        public string GetInventory()
        {
            StringBuilder str = new StringBuilder();

            if (inventory.Count != 0)
            {
                str.AppendLine("My inventory contains: ");
                foreach (Item item in inventory)
                {
                    str.AppendLine("- " + item.Name);
                }
            }
            else
                str.AppendLine("You don't have anything in your inventory.");

            return str.ToString();
        }

        List<Location> visitedLocations = new List<Location> { };
        public List<Location> VisitedLocations { get => visitedLocations; set => visitedLocations = value; }

    }
}
