using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace remembering_game
{
    internal class Letter_card : Basic_card
    {
        public char Letter { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Letter_card && ((obj as Letter_card).Letter+'a'-'A' == this.Letter || (obj as Letter_card).Letter  == this.Letter + 'a' - 'A') && base.Equals(obj);
        }
    }
}
