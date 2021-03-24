﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATE_text_game
{
    class Item
    {
        string tag;
        string name;
        string desc;

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

        void LookAt()
        {
            Console.WriteLine(desc);
        }

        public override string ToString()
        {
            return name;
        }

        //public static explicit operator Item(string item)
        //{
        //    Item newItem = new Item(item, "", "");
        //    return newItem;
        //}
    }
}
