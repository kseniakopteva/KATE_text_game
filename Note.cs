using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KATE_text_game
{
    class Note : Item
    {
        string noteText;

        public Note(string tag, string desc, string text) : base(tag, "A NOTE", desc)
        {
            this.tag = tag;
            this.desc = desc;
            noteText = text;
        }

        public string GetNoteText()
        {
            return noteText;
        }
    }
}
