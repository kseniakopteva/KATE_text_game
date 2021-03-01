using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KATE_text_game
{
    class Player
    {
        string[] inventory;
        Location loc;
        int health = 10;

        public Player(Location loc) { this.loc = loc; }
        public Location Loc { get => loc; set => loc = value; }

    }

    class Item
    {
        string name;
        string desc;
        string loc;

        public Item(string name, string desc, string loc)
        {
            this.name = name;
            this.desc = desc;
        }
        public string Name
        {
            get => name;
        }
        public string Desc { get => desc; }

        void LookAt()
        {
            Console.WriteLine(desc);
        }
    }

    class Location
    {
        string name;
        string desc;
        string[] locsAvbl;

        public Location(string name, string desc, string[] locsAvbl)
        {
            this.name = name;
            this.desc = desc;
            this.locsAvbl = locsAvbl;
        }

        public string Name { get => name; }
        public string Desc { get => desc; }
        public string[] LocsAvbl { get => locsAvbl; set => locsAvbl = value; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            // house, N - forest with lighthouse, E - forest with cave, S - hill with village, W - flowerfield with windmill

            Location field = new Location("field", "a field", new string[] { "house", "forest", "hill", "meadow", "seaside" }),
                     house = new Location("house", "a small wooden house", new string[] { "field" }),
                     forest = new Location("forest", "a dense forest", new string[] { "field", "cave" }),
                     village = new Location("village", "a cute village", new string[] { "cropfield", "hill" }),
                     seaside = new Location("seaside", "a seaside with a few trees and a rocky beach", new string[] { "field", "lighthouse" }),
                     meadow = new Location("meadow", "a flowery meadow", new string[] { "windmill", "field" }),
                     windmill = new Location("windmill", "a windmill", new string[] { "meadow" }),
                     hill = new Location("hill", "a grass hill", new string[] { "village", "field", "cropfield" }),
                     cave = new Location("cave", "a dark cave", new string[] { "forest" }),
                     lighthouse = new Location("lighthouse", "a sky-high black and white lighthouse", new string[] { "seaside" }),
                     cropfield = new Location("cropfield", "a cropfield with wheat", new string[] { "hill", "village" });

            Location[] allLocations = new Location[] { field, house, forest, village, seaside, meadow, windmill, hill, cave, lighthouse, cropfield };

            Item hat = new Item("HAT", "an old straw hat", "field");
            Item sword = new Item("SWORD", "a rusty sword", "house");

            Player player = new Player(field);

            // finds a location in the array allLocations by only a string
            int FindLocInAllLocs(string searchWord)
            {
                int index = 0;

                // check whether the word is available

                if (player.Loc.LocsAvbl.Contains(searchWord))
                {
                    // find it in all locations

                    for (; index < allLocations.Length; index++)
                    {
                        if (searchWord == allLocations[index].Name)
                        {
                            return index;
                        }
                    }
                }

                // somehow find it description
                //allLocations[index].Desc;

                return -1;
            }

            bool ExecuteQuitGame()
            {
                Console.WriteLine("Are you sure? Y/N");

                ConsoleKeyInfo keyPressed;

                // Prevent example from ending if CTL+C is pressed.
                Console.TreatControlCAsInput = true;

                Console.Write("-->");
                keyPressed = Console.ReadKey();

                if (keyPressed.Key == ConsoleKey.Y)
                {
                    Console.Write("\n");
                    return true;
                }
                return false;
            }
            bool ExecuteLook(string dest)
            {
                if (dest == "around" || dest == player.Loc.Name)
                    Console.WriteLine("You are in " + player.Loc.Desc + ".");
                else
                {
                    int index = FindLocInAllLocs(dest);
                    if (index != -1)
                        Console.WriteLine("You see " + allLocations[index].Desc + ".");
                    else
                        Console.WriteLine("ERROR");
                }

                return true;
            }
            bool ExecuteGo(string dest)
            {
                int index = FindLocInAllLocs(dest);
                if (index != -1)
                {
                    Console.WriteLine("You go in " + allLocations[index].Desc + ".");
                    player.Loc = allLocations[index];
                }
                return true;
            }

            string input = "placeholder";
            bool GetInput()
            {
                Console.Write("-->");
                input = Console.ReadLine();
                if (input != null)
                    return true;
                else return false;
            }

            bool ParseAndExecute(string Input)
            {
                string[] inpTok = Input.Split(' ');
                string action = inpTok[0];

                if (inpTok.Length > 2)
                {
                    Console.WriteLine("There are too many words.");
                    return true;
                }

                string dest = inpTok[1];

                if (action == "look")
                {
                    if (inpTok.Length == 1)
                        Console.WriteLine($"Where should I {action}?");
                    else
                        ExecuteLook(dest);
                }
                else if (action == "go")
                {
                    if (inpTok.Length == 1)
                        Console.WriteLine($"Where should I {action}?");
                    else
                        ExecuteGo(dest);
                }
                else if (action == "quit")
                {
                    if (ExecuteQuitGame())
                        return false;
                }
                else
                {
                    Console.WriteLine("I don't understand what you are saying.");
                }

                return true;
            }


            Console.WriteLine("You wake up.");
            Console.WriteLine("You are in " + player.Loc.Desc + ".");
            Console.WriteLine("You can go to: ");
            for (int i = 0; i < player.Loc.LocsAvbl.Length; i++)
            {
                Console.Write("- ");
                Console.WriteLine(player.Loc.LocsAvbl[i]);
            }

            while (GetInput() && ParseAndExecute(input)) ;
            Console.WriteLine("Bye!");
            Thread.Sleep(600);

        }
    }
}
