using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace remembering_game
{
    internal class Symbol_card:Basic_card
    {
        public char Symbol { get; set; }
        public ConsoleColor Color { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Symbol_card && (obj as Symbol_card).Symbol == this.Symbol && (obj as Symbol_card).Color == this.Color && base.Equals(obj);
        }
    }
}