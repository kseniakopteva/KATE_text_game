﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATE_text_game
{
    class Player
    {
        //string[] inventory;
        Location loc;
        int health = 10;

        public Player(Location loc) { this.loc = loc; }
        public Location Loc { get => loc; set => loc = value; }

    }
}
