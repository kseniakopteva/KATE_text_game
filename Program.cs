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
                string[] inputTokens = Input.Split(' ');
                if (inputTokens[0] == "look")
                {
                    Console.WriteLine("I am looking.");
                }
                else if (inputTokens[0] == "quit")
                {
                    if (QuitGame())
                        return false;
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
