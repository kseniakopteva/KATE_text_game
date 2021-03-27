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
            Item hat = new Item("hat", "A HAT", "an old straw hat");
            Item sword = new Item("sword", "A SWORD", "a rusty sword");
            Item sand = new Item("sand", "SAND", "a small handful of sand");

            #region Initializing locations

            Location field = new Location("field", "a field") { ItemList = new List<Item>() { hat, sword } },
                     house = new Location("house", "a house") { ItemList = new List<Item> { } },
                     forest = new Location("forest", "a forest") { ItemList = new List<Item> { } },
                     village = new Location("village", "a village") { ItemList = new List<Item> { } },
                     seaside = new Location("seaside", "a seaside") { ItemList = new List<Item> { sand } },
                     meadow = new Location("meadow", "a meadow") { ItemList = new List<Item> { } },
                     windmill = new Location("windmill", "a windmill") { ItemList = new List<Item> { } },
                     hill = new Location("hill", "a hill") { ItemList = new List<Item> { } },
                     cave = new Location("cave", "a cave") { ItemList = new List<Item> { } },
                     lighthouse = new Location("lighthouse", "a lighthouse") { ItemList = new List<Item> { } },
                     cropfield = new Location("cropfield", "a cropfield") { ItemList = new List<Item> { } };

            #region descriptions, avalaible locations, directions and ascii art

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

            field.AvailableLocations = new List<Location> { house, forest, hill, meadow, seaside };
            house.AvailableLocations = new List<Location> { field };
            forest.AvailableLocations = new List<Location> { field, cave };
            village.AvailableLocations = new List<Location> { cropfield, hill };
            seaside.AvailableLocations = new List<Location> { field, lighthouse };
            meadow.AvailableLocations = new List<Location> { windmill, field, seaside };
            windmill.AvailableLocations = new List<Location> { meadow };
            hill.AvailableLocations = new List<Location> { village, field, cropfield, forest };
            cave.AvailableLocations = new List<Location> { forest };
            lighthouse.AvailableLocations = new List<Location> { seaside };
            cropfield.AvailableLocations = new List<Location> { hill, village, meadow };

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

            field.AsciiArt = new string[] {
@"          ╬                                                                 /\  ",
@"         ═@═                          ______                         /\  /\ /\ /",
@"          ░                          /  \   \                     /\  /\/\/\/\/\",
@"          █   /\           //,,.//. /____\   \ ,,//..,,/////..,,/\ /\ /\ /\ /\ /",
@"\\ ,,////\░ /\/\ ____..--/         ║██████░░░░  ,         ////\/\      /\/\/\/\ ",
@" ,,.. ,,  ..                       ║██╔╗██░░░░ ,    ,,    ,,   ,,,/\      /\/\/\",
@"       °      °    \\\        ° °°°║██╚╝██░░░░ ,,//   ,,,||\\°°...°  °°     /\  ",
@" || ,,,  °,,   //  ° °        ...  ║██████░░░░  |^^ °° °...  , ,. .,         /\ ",
@"  ,, \\         \\  ^^^   ...  '''   ..  \\  ---  ,,,  ;;    °  °°  '''   ''    ",
@" °°,,,       °   °      °°     ,,,,, //        \\            ,,,     ,,      .. "};
            seaside.AsciiArt = new string[]
            {
@"                                 |                                        /\/\/\",
@"                                ╔╩╗                                    /\/\/\/\/",
@"                              ═╦░@░╦═                    /\   /\ /\/\  /\ /\ /\ ",
@"                               ╚███╝                     /\  /\/\   /\/\    /\ /",
@"                                ░░░__               -.// /\ /\/\/\/\   /\/\     ",
@"                                ███__/\        ..--// | //    //          ,//,, ",
@"________________________________░░░██__║_..--//^^=.='//    ==  /// //     /\    ",
@"____  ---         ---       ..__███/                       ///,,, ,,///  /\ /\  ",
@"    ^^^--______ ---   ___ ___--/  . .            .  . .. ... ..     ///,,/,/,,// ",
@"           ^^^^----^^^          . . .  ....   .                                 "};

            #endregion

            #endregion

            Player player = new Player(field);

            #region methods

            bool Confirm(ConsoleKey key)
            {
                // Prevent from ending if CTL+C is pressed.
                //Console.TreatControlCAsInput = true;

                ConsoleKeyInfo keyPressed = Console.ReadKey();

                if (keyPressed.Key == key)
                {
                    return true;
                }
                return false;
            }

            bool ExecuteQuitGame()
            {
                Console.WriteLine("Are you sure? Y/N");
                Console.Write("-->");
                if (Confirm(ConsoleKey.Y))
                {
                    Console.WriteLine();
                    return true;
                }
                return false;
            }
            bool ExecuteLook(string dest)
            {
                if (dest == "around" || dest == player.Loc.Tag)
                    Print(GetLocationDescription());
                else
                {
                    int index = player.Loc.AvailableLocations.FindIndex(item => item.Tag == dest);
                    if (index >= 0)
                    {
                        Console.WriteLine(player.Loc.AvailableLocations[index].Desc);
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
                    case "n":
                        dest = player.Loc.directions["north"].Tag;
                        break;
                    case "south":
                    case "s":
                        dest = player.Loc.directions["south"].Tag;
                        break;
                    case "west":
                    case "w":
                        dest = player.Loc.directions["west"].Tag;
                        break;
                    case "east":
                    case "e":
                        dest = player.Loc.directions["east"].Tag;
                        break;
                    case "out":
                    case "outside":
                        if (player.Loc.Tag == "windmill" || player.Loc.Tag == "house" || player.Loc.Tag == "lighthouse" || player.Loc.Tag == "cave")
                            dest = player.Loc.AvailableLocations.ElementAt(0).Tag;
                        break;
                    case "in":
                    case "inside":
                        if (player.Loc.Tag == "meadow")
                            dest = "windmill";
                        else if (player.Loc.Tag == "field")
                            dest = "house";
                        else if (player.Loc.Tag == "seaside")
                            dest = "lighthouse";
                        else if (player.Loc.Tag == "forest")
                            dest = "cave";
                        break;
                    default:
                        break;
                }

                int index = player.Loc.AvailableLocations.FindIndex(item => item.Tag == dest);
                if (index >= 0)
                {
                    // element exists, do what you need
                    player.Loc = player.Loc.AvailableLocations[index];
                    Console.Clear();

                    Console.WriteLine();
                    Console.WriteLine(GetLocationImage());
                    Print(GetLocationDescription());
                }
                else
                {
                    Console.WriteLine("You can't go there.");
                }
                return true;
            }

            string GetLocationDescription()
            {
                StringBuilder desc = new StringBuilder("");

                if (player.Loc == seaside || player.Loc == field || player.Loc == cropfield || player.Loc == meadow || player.Loc == hill)
                    desc.Append($"You are on {player.Loc.Name}. {player.Loc.Desc}");
                else
                    desc.Append($"You are in {player.Loc.Name}. {player.Loc.Desc}");

                if (player.Loc.ItemList.Count != 0)
                {
                    desc.Append(" " + GetAvailableItems());
                }

                desc.AppendLine();

                return desc.ToString();
            }
            string GetAvailableLocations()
            {
                StringBuilder locs = new StringBuilder();

                locs.AppendLine("You can go to: ");
                foreach (Location loc in player.Loc.AvailableLocations)
                {
                    string locationKey = player.Loc.directions.FirstOrDefault(location => location.Value == loc).Key;

                    if (player.Loc.directions.ContainsValue(loc))
                    {
                        locs.AppendLine($"> {loc.Name} on the {locationKey}");
                    }
                    else
                    {
                        locs.AppendLine("> " + loc.Name);
                    }
                }
                return locs.ToString();
            }
            string GetAvailableItems()
            {
                if (player.Loc.ItemList.Count != 0)
                {
                    // TODO: "There are ..., ..., ... AND ... on the ground."

                    StringBuilder items = new StringBuilder("");

                    if (player.Loc.ItemList.Count == 1)
                        items.Append($"There is {string.Join(", ", from item in player.Loc.ItemList select item.Name)} on the ground.");
                    else
                        items.Append($"There are {string.Join(", ", from item in player.Loc.ItemList select item.Name)} on the ground.");

                    return items.ToString();
                }
                return null;
            }

            #region output methods

            // prints text; both typing and wrapping words (easier to write)
            void PrintLine(string text) { WordWrap(text, 80, true); }
            void Print(string text) { WordWrap(text, 80, false); }

            // types out the string letter by letter
            void TypeOut(string text)
            {
                foreach (char letter in text)
                {
                    int time; // = 50
                    Random rnd = new Random();

                    if (new[] { '.', ';', '?', '!', ':' }.Contains(letter))
                        time = 400;
                    else if (',' == letter)
                        time = rnd.Next(50, 100);
                    else if (' ' == letter)
                        time = rnd.Next(30, 40);
                    else if (Char.IsLetter(letter) || Char.IsNumber(letter))
                        time = rnd.Next(50, 80);
                    else time = 0;

                    Console.Write(letter);
                    Thread.Sleep(time);
                }
            }
            // wraps the string
            void WordWrap(string inputString, int limit, bool isNewLineNecessary)
            {
                limit = 80;
                string[] words = inputString.Split(' ');

                StringBuilder newSentence = new StringBuilder();

                string line = "";
                foreach (string word in words)
                {
                    if ((line + word).Length > limit)
                    {
                        newSentence.AppendLine(line);
                        line = "";
                    }
                    else if ((line + word).Length + 1 == limit)
                    {
                        line += string.Format("{0}", word);
                        continue;
                    }

                    if (word.Contains("\n"))
                        line += string.Format("{0}", word);
                    else
                        line += string.Format("{0} ", word);
                }

                if (line.Length > 0)
                {
                    if (isNewLineNecessary)
                        newSentence.AppendLine(line);
                    else
                        newSentence.Append(line);
                }

                TypeOut(newSentence.ToString());
            }

            void WordWrapInABox(string inputString, int boxWidth, char borderChar, int paddingWidth, string alignment)
            {
                //int boxWidth = 40;
                //char borderChar = '/';
                //int paddingWidth = 2;

                int leftMarginWidth;

                switch (alignment)
                {
                    case "center":
                        leftMarginWidth = (Console.WindowWidth - boxWidth) / 2;
                        break;
                    case "right":
                        leftMarginWidth = Console.WindowWidth - boxWidth - 1;
                        break;
                    case "left":
                    default:
                        leftMarginWidth = 1;
                        break;
                }

                int borderCharWidth = 1;
                int boxWidthWithoutMargins = boxWidth - 2 * borderCharWidth;
                int boxWitdthWithoutOneMargin = boxWidth - paddingWidth - borderCharWidth;

                int limit = boxWidth - 2 * paddingWidth - 10;
                string[] words = inputString.Split(' ');

                StringBuilder newSentence = new StringBuilder();

                Console.WriteLine(new string(' ', leftMarginWidth) + new string(borderChar, boxWidth));
                for (int i = 0; i < paddingWidth - 1; i++)
                {
                    Console.WriteLine(new string(' ', leftMarginWidth) + borderChar + new string(' ', boxWidthWithoutMargins) + borderChar);

                    string line = "";

                    foreach (string word in words)
                    {
                        if ((line + word).Length > limit)
                        {
                            newSentence.AppendLine(new string(' ', leftMarginWidth) + borderChar + new string(' ', paddingWidth) + line + new string(' ', boxWidthWithoutMargins - borderCharWidth - borderCharWidth - line.Length) + borderChar);
                            line = "";
                        }
                        line += string.Format("{0} ", word);
                    }

                    if (line.Length > 0)
                    {
                        newSentence.AppendLine(new string(' ', leftMarginWidth) + borderChar + new string(' ', paddingWidth) + line + new string(' ', boxWidthWithoutMargins - borderCharWidth - borderCharWidth - line.Length) + borderChar);
                    }
                }

                for (int j = 0; j < paddingWidth - 1; j++)
                    newSentence.AppendLine(new string(' ', leftMarginWidth) + borderChar + new string(' ', boxWidthWithoutMargins) + borderChar);
                newSentence.AppendLine(new string(' ', leftMarginWidth) + new string(borderChar, boxWidth));

                Console.WriteLine(newSentence.ToString());

            }

            string GetLocationImage()
            {
                StringBuilder imageString = new StringBuilder();
                foreach (string str in player.Loc.AsciiArt)
                    imageString.Append(str);
                return imageString.ToString();
            }

            #endregion

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
                string[] inpTok = Input.ToLower().Split(' ');
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
                        Console.Write(GetAvailableLocations());
                    }
                    else
                        ExecuteGo(dest);
                }
                else if (action == "get" || action == "take")
                {
                    int index = player.Loc.ItemList.FindIndex(item => item.Tag == dest);
                    if (index >= 0)
                    {
                        // element exists, do what you need
                        Console.WriteLine("You got a " + player.Loc.ItemList[index].Name + "! It is " + player.Loc.ItemList[index].Desc + ".");
                        player.AddItem(player.Loc.ItemList[index]);
                    }
                    else
                        Console.WriteLine("You can't " + action + " this!");

                }
                else if (action == "drop")
                {
                    int index = player.inventory.FindIndex(item => item.Tag == dest);
                    if (index >= 0)
                    {
                        Console.WriteLine("You dropped " + player.inventory[index].Name + "!");
                        player.RemoveItem(player.inventory[index]);
                    }
                    else
                    {
                        Console.WriteLine("You can't drop it!");
                    }
                }
                else if (action == "examine" || action == "x")
                {
                    string itemDesc;

                    int index = player.inventory.FindIndex(item => item.Tag == dest);
                    if (index < 0)
                    {
                        index = player.Loc.ItemList.FindIndex(item => item.Tag == dest);
                        itemDesc = player.Loc.ItemList[index].Desc;
                    }
                    else
                    {
                        itemDesc = player.inventory[index].Desc;
                    }

                    if (index >= 0)
                    {
                        Console.WriteLine(char.ToUpper(itemDesc[0]) + itemDesc.Substring(1) + ".");
                    }
                }
                else if (action == "inventory" || action == "i")
                {
                    Console.Write(player.GetInventory());
                }
                else if (action == "quit" || action == "q")
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

            #endregion

            WordWrapInABox("Lorem ipsum dolor sit amet, consectetur adipiscing elit.", 40, 'X', 2, "center");

            Console.WriteLine(GetLocationImage());
            PrintLine("You wake up.");
            Print(GetLocationDescription());
            Console.Write(GetAvailableLocations());

            while (GetInput() && ParseAndExecute(input)) ;
            Console.WriteLine("Bye!");
            Thread.Sleep(600);
        }
    }
}
