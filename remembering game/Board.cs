using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace remembering_game
{
    internal class Board
    {
        #region fields
        public Basic_card[] Cards;

        #endregion
        #region methods

        public Board(Types type)
        {
            Cards = new Arr_cards().ArrCards(type);
        }
        public void Drawing()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Black;
            for (int i = 0; i < 21; i++)
            {
                Console.SetCursorPosition(40, 4 + i);
                Console.Write("  ");
                Console.SetCursorPosition(86, 4 + i);
                Console.Write("  ");
            }
            for (int i = 0; i < 48; i++)
            {
                Console.SetCursorPosition(40 + i, 3);
                Console.Write(" ");
                Console.SetCursorPosition(40 + i, 25);
                Console.Write(" ");
            }
            int x, y;
            Console.BackgroundColor = ConsoleColor.White;
            for (int i = 0; i < Cards.Length; i++)
            {
                if (Cards[i].Belong == "available")
                {
                    x = 44 + i % 6 * 7;
                    y = 5 + i / 6 * 4;
                    Console.SetCursorPosition(x, y);
                    Console.Write("     ");
                    Console.SetCursorPosition(x, y + 1);
                    Console.Write($"  {i + 1} ");
                    if (i < 9)
                        Console.Write(" ");
                    Console.SetCursorPosition(x, y + 2);
                    Console.Write("     ");
                    Cards[i].Location = new Point(x, y);
                }
            }
            Console.BackgroundColor= ConsoleColor.Black;
            Console.ForegroundColor= ConsoleColor.White;
            Console.SetCursorPosition(0, 0);
        }

        public bool Is_available_loc(int i)
        {
            return Cards[i].Belong == "available" && !Cards[i].Discovered;
        }
        public bool Is_exist_cards()
        {
            for (int i = 0; i < Cards.Length; i++)
            {
                if (Cards[i].Belong == "available")
                    return true;
            }
            return false;
        }
        #endregion
    }
}
