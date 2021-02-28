using System;
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
        public Location Loc { get => loc; }

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

            Location house = new Location("house", "a small wooden house", new string[] { "field" });
            Location field = new Location("field", "a field", new string[] { "house", "forest" });
            Location forest = new Location("forest", "a dense forest", new string[] { "field" });

            Location[] allLocations = new Location[] { field, house, forest };

            Item hat = new Item("HAT", "an old straw hat", "field");
            Item sword = new Item("SWORD", "a rusty sword", "house");

            Player player = new Player(field);

            int FindLoc(string searchWord)
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
            bool ExecuteLook(string where)
            {

                if (where == "around")
                    Console.WriteLine("You are in " + player.Loc.Desc);
                else
                {
                    int index = FindLoc(where);
                    if (index != -1)
                        Console.WriteLine("You see " + allLocations[index].Desc + ".");
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
                int inpWordNum;
                string[] inpTok = Input.Split(' ');

                if (inpTok.Length == 1)
                {
                    inpWordNum = 1;
                    //Console.WriteLine("There is only one word: " + inpTok[0]);
                }
                else if (inpTok.Length == 2)
                {
                    inpWordNum = 2;
                    //Console.WriteLine($"There are two words: {inpTok[0]} and {inpTok[1]}");
                }
                else
                {
                    inpWordNum = 3;
                    Console.WriteLine("There are too many words");
                    return true;
                }

                if (inpTok[0] == "look")
                {
                    if (inpWordNum == 1)
                        Console.WriteLine("Where should I look?");
                    else
                        ExecuteLook(inpTok[1]);
                }
                else if (inpTok[0] == "quit")
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
