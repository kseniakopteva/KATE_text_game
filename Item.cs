using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATE_text_game
{
    [Serializable]
    class Item
    {
        protected string tag;
        protected string name;
        protected string desc;

        public Item(string tag, string name, string desc)
        {
            this.tag = tag;
            this.name = name;
            this.desc = desc;
        }
        public string Tag
        {
            get => tag;
        }
        public string Name
        {
            get => name;
        }
        public string Desc { get => desc; }
    }
}
