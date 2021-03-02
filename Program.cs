﻿using System;
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
        string tag;
        string name;
        string desc;
        string[] locsAvbl;

        string north,
            south,
            west,
            east;

        public Location(string tag, string name, string[] locsAvbl, string north, string south, string west, string east)
        {
            this.tag = tag;
            this.name = name;
            this.locsAvbl = locsAvbl;

            this.north = north;
            this.south = south;
            this.west = west;
            this.east = east;
        }

        public string Name { get => name; }
        public string Desc { get => desc; set => desc = value; }
        public string[] LocsAvbl { get => locsAvbl; set => locsAvbl = value; }
        public string Tag { get => tag; }
        public string North { get => north; }
        public string South { get => south; }
        public string West { get => west; }
        public string East { get => east; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            // house, N - forest with lighthouse, E - forest with cave, S - hill with village, W - flowerfield with windmill

            Location field = new Location("field", "a field", new string[] { "house", "forest", "hill", "meadow", "seaside" }, "seaside", "hill", "meadow", "forest"),
                     house = new Location("house", "a house", new string[] { "field" }, "", "", "", ""),
                     forest = new Location("forest", "a forest", new string[] { "field", "cave" }, "forest", "forest", "field", "cave"),
                     village = new Location("village", "a village", new string[] { "cropfield", "hill" }, "hill", "", "cropfield", ""),
                     seaside = new Location("seaside", "a seaside", new string[] { "field", "lighthouse" }, "lighthouse", "field", "", ""),
                     meadow = new Location("meadow", "a meadow", new string[] { "windmill", "field", "seaside" }, "seaside", "cropfield", "", "field"),
                     windmill = new Location("windmill", "a windmill", new string[] { "meadow" }, "", "", "", ""),
                     hill = new Location("hill", "a hill", new string[] { "village", "field", "cropfield", "forest" }, "field", "village", "cropfield", "forest"),
                     cave = new Location("cave", "a cave", new string[] { "forest" }, "", "", "forest", ""),
                     lighthouse = new Location("lighthouse", "a lighthouse", new string[] { "seaside" }, "", "", "", ""),
                     cropfield = new Location("cropfield", "a cropfield", new string[] { "hill", "village", "meadow" }, "meadow", "", "", "village");

            field.Desc = "It's a field with tall grass and yarrow. There is a small house nearby.";
            house.Desc = "It's a small wooden house made out of thin wood planks. There are few lattice windows and a table with a note. There is a chest next to one of the walls.";
            forest.Desc = "It's a dense forest with barely any light. There is a cave in the raised ground.";
            village.Desc = "It's a small village with quite a few people.";
            seaside.Desc = "It's a seaside with a few trees and a rocky beach. You hear the sea waves crushing on the shore. It is windy out here. You see a sky-high black and white lighthouse.";
            meadow.Desc = "It's a colourful flower meadow. There is a windmill.";
            windmill.Desc = "It's an old but tidy windmill. You can see it is still being used. The sunbeams shine through the gaps in the wallboards.";
            hill.Desc = "It's a grass hill. You can see the field, a cropfield, and the village from here. What a view.";
            cave.Desc = "It's a dark cave.";
            lighthouse.Desc = "It's a small room. You see light coming from above. There's nothing much here.";
            cropfield.Desc = "It's a cropfield with wheat.";

            Location[] allLocations = new Location[] { field, house, forest, village, seaside, meadow, windmill, hill, cave, lighthouse, cropfield };

            //Item hat = new Item("HAT", "an old straw hat", "field");
            //Item sword = new Item("SWORD", "a rusty sword", "house");

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
                        if (searchWord == allLocations[index].Tag)
                        {
                            return index;
                        }
                    }
                }
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
                if (dest == "around" || dest == player.Loc.Tag)
                    PrintLocDesc();
                else
                {
                    int index = FindLocInAllLocs(dest);
                    if (index != -1)
                        Console.WriteLine(allLocations[index].Desc);
                    else
                        Console.WriteLine("ERROR");
                }

                return true;
            }
            bool ExecuteGo(string dest)
            {
                switch (dest)
                {
                    case "north":
                        dest = player.Loc.North;
                        break;
                    case "south":
                        dest = player.Loc.South;
                        break;
                    case "west":
                        dest = player.Loc.West;
                        break;
                    case "east":
                        dest = player.Loc.East;
                        break;
                    default:
                        break;
                }

                int index = FindLocInAllLocs(dest);
                if (index != -1)
                {
                    player.Loc = allLocations[index];
                    Console.Clear();
                    PrintLocDesc();
                }
                else
                {
                    Console.WriteLine("You can't go there.");
                }
                return true;
            }

            void PrintLocDesc()
            {
                Console.WriteLine($"You are in {player.Loc.Name}. {player.Loc.Desc}");
            }

            void PrintAvblDir()
            {
                string dest;
                for (int i = 0; i < player.Loc.LocsAvbl.Length; i++)
                {
                    bool isThereNoDir = true;

                    if (player.Loc.North == player.Loc.LocsAvbl[i])
                        dest = "North";
                    else if (player.Loc.South == player.Loc.LocsAvbl[i])
                        dest = "South";
                    else if (player.Loc.West == player.Loc.LocsAvbl[i])
                        dest = "West";
                    else if (player.Loc.East == player.Loc.LocsAvbl[i])
                        dest = "East";
                    else
                    {
                        dest = "";
                        isThereNoDir = false;
                        //dest = player.Loc.Tag;
                    }

                    int index = FindLocInAllLocs(player.Loc.LocsAvbl[i]);
                    if (isThereNoDir)
                        Console.WriteLine($" - {allLocations[index].Name} in the {dest}");
                    else
                        Console.WriteLine($" - {allLocations[index].Name}");
                }
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

                string dest = "";
                if (inpTok.Length == 2)
                {
                    dest = inpTok[1];
                }

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
                    {
                        Console.WriteLine($"Where should I {action}?");
                        Console.WriteLine("You can go to: ");
                        PrintAvblDir();
                    }
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
            PrintLocDesc();
            Console.WriteLine("There is: ");
            PrintAvblDir();

            while (GetInput() && ParseAndExecute(input)) ;
            Console.WriteLine("Bye!");
            Thread.Sleep(600);

        }
    }
}
