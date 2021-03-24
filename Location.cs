using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATE_text_game
{
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
}
