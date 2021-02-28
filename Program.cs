using System;
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
            bool QuitGame()
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
                    else if (inpWordNum == 2)
                        Console.WriteLine("I am looking " + inpTok[1]);
                }
                else if (inpTok[0] == "quit")
                {
                    if (QuitGame())
                        return false;
                }
                else
                {
                    Console.WriteLine("I don't understand what you are saying.");
                }

                return true;
            }

            Console.WriteLine("You wake up.");
            while (GetInput() && ParseAndExecute(input)) ;
            Console.WriteLine("Bye!");
            Thread.Sleep(600);

        }
    }
}
