using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace remembering_game
{
    abstract class Basic_card
    {
        #region fields
        public bool Discovered { get; set; }
        public Point Location { get; set; }
        public string Belong { get; set; } = "available";
        #endregion
        #region methods        
        public override bool Equals(object? obj)
        {
            return this.Location.X != (obj as Basic_card).Location.X || this.Location.Y != (obj as Basic_card).Location.Y;
        }
        public void Drawing()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            try
            {
                Console.SetCursorPosition(Location.X, Location.Y + 1);
                if (this is Symbol_card symbol)
                {
                    Console.BackgroundColor = symbol.Color;
                    Console.Write($"  {symbol.Symbol}  ");
                }
                else if (this is Math_aritmetic math)
                    Console.Write(math.MathAritmetic);
                else
                    Console.Write($"  {(this as Letter_card).Letter}  ");
                Console.SetCursorPosition(Location.X, Location.Y);
                Console.Write("     ");
                Console.SetCursorPosition(Location.X, Location.Y + 2);
                Console.Write("     ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0, 0);
            }
            catch
            {
            }
        }
        public void Drawing(ConsoleColor color)
        {
            int x = Location.X;
            int y = Location.Y;
            Console.BackgroundColor = color;
            try
            {
                Console.SetCursorPosition(x, y);
                Console.Write("     ");
                Console.SetCursorPosition(x, y + 1);
                Console.Write("     ");
                Console.SetCursorPosition(x, y + 2);
                Console.Write("     ");
                Console.SetCursorPosition(0, 0);
            }
            catch
            {

            }
        }
        #endregion

    }
}
