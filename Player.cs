using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATE_text_game
{
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
            loc.itemList.Remove(item);
        }
        public void RemoveItem(Item item)
        {
            inventory.Remove(item);
            loc.itemList.Add(item);
        }

        public void PrintInventory()
        {
            Console.WriteLine("My inventory contains: ");
            foreach (Item item in inventory)
            {
                Console.WriteLine("- " + item.Name);
            }
        }
    }
}
