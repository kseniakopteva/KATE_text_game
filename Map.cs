using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATE_text_game
{
    class Map : Item
    {
        List<string> mapImage;

        public List<string> MapImage { get => mapImage; set => mapImage = value; }

        public Map(string tag, string name, string desc) : base(tag, name, desc)
        {
            this.tag = tag;
            this.name = name;
            this.desc = desc;
        }

        public List<string> GetMap()
        {
            return mapImage;
        }

        int indexOfFirstString;
        public int IndexOfFirstString
        {
            get => indexOfFirstString;
            set => indexOfFirstString = value;
        }

        public void OpenMap(ConsoleKeyInfo input)
        {
            //ConsoleKeyInfo input;
            //input = Console.ReadKey();
            List<string> batch = new List<string> { };

            if (input.Key == ConsoleKey.DownArrow)
            {

                IndexOfFirstString++;
                for (int i = 0; i < Console.WindowHeight; i++)
                {
                    if (IndexOfFirstString >= mapImage.Count - Console.WindowHeight)
                    {
                        batch.Add(mapImage[mapImage.Count - Console.WindowHeight + i]);
                        IndexOfFirstString--;
                    }
                    else if (IndexOfFirstString + i > -1 && IndexOfFirstString + i < mapImage.Count)
                        batch.Add(mapImage[IndexOfFirstString + i]);
                }

                Console.Clear();
                foreach (string str in batch)
                    Console.Write(str);
            }
            else if (input.Key == ConsoleKey.UpArrow)
            {

                IndexOfFirstString--;
                for (int i = 0; i < Console.WindowHeight; i++)
                {
                    if (IndexOfFirstString == 0)
                    {
                        batch.Add(mapImage[i]);
                    }
                    else if (IndexOfFirstString > -1 && IndexOfFirstString + i < mapImage.Count)
                        batch.Add(mapImage[IndexOfFirstString + i]);
                    else if (IndexOfFirstString < 0)
                    {
                        batch.Add(mapImage[i]);
                        IndexOfFirstString++;
                    }

                }
                Console.Clear();

                foreach (string str in batch)
                    Console.Write(str);
            }

        }
    }
}
