﻿using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KATE_text_game
{
    class Program
    {
        static void Main(string[] args)
        {
            Item hat = new Item("HAT", "an old straw hat");
            Item sword = new Item("SWORD", "a rusty sword");
            Item sand = new Item("SAND", "a small handful of sand");

            #region Initializing locations

            Location field = new Location("field", "a field") { itemList = new List<Item>() { hat, sword } },
                     house = new Location("house", "a house"),
                     forest = new Location("forest", "a forest"),
                     village = new Location("village", "a village"),
                     seaside = new Location("seaside", "a seaside") { itemList = new List<Item> { sand } },
                     meadow = new Location("meadow", "a meadow"),
                     windmill = new Location("windmill", "a windmill"),
                     hill = new Location("hill", "a hill"),
                     cave = new Location("cave", "a cave"),
                     lighthouse = new Location("lighthouse", "a lighthouse"),
                     cropfield = new Location("cropfield", "a cropfield");

            #region descriptions, avalaible locations and directions

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

            field.availableLocations = new List<Location> { house, forest, hill, meadow, seaside };
            house.availableLocations = new List<Location> { field };
            forest.availableLocations = new List<Location> { field, cave };
            village.availableLocations = new List<Location> { cropfield, hill };
            seaside.availableLocations = new List<Location> { field, lighthouse };
            meadow.availableLocations = new List<Location> { windmill, field, seaside };
            windmill.availableLocations = new List<Location> { meadow };
            hill.availableLocations = new List<Location> { village, field, cropfield, forest };
            cave.availableLocations = new List<Location> { forest };
            lighthouse.availableLocations = new List<Location> { seaside };
            cropfield.availableLocations = new List<Location> { hill, village, meadow };

            field.directions = new Dictionary<string, Location> {
                { "north", seaside },
                { "south", hill },
                { "west", meadow },
                { "east", forest }
            };
            house.directions = new Dictionary<string, Location>
            {
                { "north", null },
                { "south", null },
                { "west", null },
                { "east", null }
            };
            forest.directions = new Dictionary<string, Location>
            {
                { "north", forest },
                { "south", forest },
                { "west", field },
                { "east", cave }
            };
            village.directions = new Dictionary<string, Location>
            {
                { "north", hill },
                { "south", null },
                { "west", cropfield },
                { "east", null }
            };
            seaside.directions = new Dictionary<string, Location>
            {
                { "north", lighthouse },
                { "south", field },
                { "west", null },
                { "east", null }
            };
            meadow.directions = new Dictionary<string, Location>
            {
                { "north", seaside },
                { "south", cropfield },
                { "west", null },
                { "east", field }
            };
            windmill.directions = new Dictionary<string, Location>
            {
                { "north", null },
                { "south", null },
                { "west", null },
                { "east", null }
            };
            hill.directions = new Dictionary<string, Location>
            {
                { "north", field },
                { "south", village },
                { "west", cropfield },
                { "east", forest }
            };
            cave.directions = new Dictionary<string, Location>
            {
                { "north", null },
                { "south", null },
                { "west", forest },
                { "east", null }
            };
            lighthouse.directions = new Dictionary<string, Location>
            {
                { "north", null },
                { "south", null },
                { "west", null },
                { "east", null }
            };
            cropfield.directions = new Dictionary<string, Location>
            {
                { "north", meadow },
                { "south", null },
                { "west", null },
                { "east", village }
            };

            #endregion

            #endregion

            Player player = new Player(field);

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
            // TODO: "look north"
            bool ExecuteLook(string dest)
            {
                if (dest == "around" || dest == player.Loc.Tag)
                    PrintLocDesc();
                else
                {
                    int index = player.Loc.availableLocations.FindIndex(item => item.Tag == dest);
                    if (index >= 0)
                    {
                        Console.WriteLine(player.Loc.availableLocations[index].Desc);
                    }
                    else
                        Console.WriteLine("ERROR");
                }

                return true;
            }
            bool ExecuteGo(string dest)
            {
                // go north
                switch (dest)
                {
                    case "north":
                        dest = player.Loc.directions["north"].Tag;
                        break;
                    case "south":
                        dest = player.Loc.directions["south"].Tag;
                        break;
                    case "west":
                        dest = player.Loc.directions["west"].Tag;
                        break;
                    case "east":
                        dest = player.Loc.directions["east"].Tag;
                        break;
                    case "out":
                    case "outside":
                        if (player.Loc.Tag == "windmill" || player.Loc.Tag == "house" || player.Loc.Tag == "lighthouse" || player.Loc.Tag == "cave")
                            dest = player.Loc.availableLocations.ElementAt(0).Tag;
                        break;
                    default:
                        break;
                }

                int index = player.Loc.availableLocations.FindIndex(item => item.Tag == dest);
                if (index >= 0)
                {
                    // element exists, do what you need
                    player.Loc = player.Loc.availableLocations[index];
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
                foreach (KeyValuePair<string, Location> loc in player.Loc.directions)
                {
                    if (loc.Value != null)
                        Console.WriteLine($" - {loc.Value.Name} in the {loc.Key}");
                    else
                    {
                        Console.WriteLine("Oops! Something went wrong");
                    }
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
                else if (action == "get")
                {
                    int index = player.Loc.itemList.FindIndex(item => item.Name == dest.ToUpper());
                    if (index >= 0)
                    {
                        // element exists, do what you need
                        player.AddItem(player.Loc.itemList[index]);
                        Console.WriteLine("You got a " + player.Loc.itemList[index].Name + "!");
                    }
                    else
                        Console.WriteLine("You can't!");

                }
                else if (action == "check")
                {
                    player.PrintInventory();
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
