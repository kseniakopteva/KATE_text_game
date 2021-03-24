using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATE_text_game
{
    class Item
    {
        string name;
        string desc;
        string loc;

        public Item(string name, string desc, string loc)
        {
            this.name = name;
            this.desc = desc;
            this.loc = loc;
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
}
