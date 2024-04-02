using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace remembering_game
{
    public enum Types { letter=1, symbol, exercize };
    internal class Arr_cards
    {
        public static int Size { get; } = 30;
        public Basic_card[] Cards { get; set; } = new Basic_card[Size];

        public Basic_card[] ArrCards(Types type)
        {
            switch (type)
            {
                case Types.exercize:
                    FillExersize();
                    break;
                case Types.letter:
                    FillLetter();
                    break;
                case Types.symbol:
                    FillSymbol();
                    break;
            }
            Mix();
            return Cards;
        }

        public void FillExersize()
        {
            Cards[0] = new Math_aritmetic() { Type = typeMath.math_aritmetic, MathAritmetic = " 2+3 ", Solution = 5 };
            Cards[1] = new Math_aritmetic() { Type = typeMath.solution, MathAritmetic = "  5  ", Solution = 5 };
            Cards[2] = new Math_aritmetic() { Type = typeMath.math_aritmetic, MathAritmetic = " 2*3 ", Solution = 6 };
            Cards[3] = new Math_aritmetic() { Type = typeMath.solution, MathAritmetic = "  6  ", Solution = 6 };
            Cards[4] = new Math_aritmetic() { Type = typeMath.math_aritmetic, MathAritmetic = " 3+5 ", Solution = 8 };
            Cards[5] = new Math_aritmetic() { Type = typeMath.solution, MathAritmetic = "  8  ", Solution = 8 };
            Cards[6] = new Math_aritmetic() { Type = typeMath.math_aritmetic, MathAritmetic = "11-2 ", Solution = 9 };
            Cards[7] = new Math_aritmetic() { Type = typeMath.solution, MathAritmetic = "  9  ", Solution = 9 };
            Cards[8] = new Math_aritmetic() { Type = typeMath.math_aritmetic, MathAritmetic = " 5+5 ", Solution = 10 };
            Cards[9] = new Math_aritmetic() { Type = typeMath.solution, MathAritmetic = " 10  ", Solution = 10 };
            Cards[10] = new Math_aritmetic() { Type = typeMath.math_aritmetic, MathAritmetic = "10+1 ", Solution = 11 };
            Cards[11] = new Math_aritmetic() { Type = typeMath.solution, MathAritmetic = " 11  ", Solution = 11 };
            Cards[12] = new Math_aritmetic() { Type = typeMath.math_aritmetic, MathAritmetic = " 6*2 ", Solution = 12 };
            Cards[13] = new Math_aritmetic() { Type = typeMath.solution, MathAritmetic = " 12  ", Solution = 12 };
            Cards[14] = new Math_aritmetic() { Type = typeMath.math_aritmetic, MathAritmetic = "12/4 ", Solution = 3 };
            Cards[15] = new Math_aritmetic() { Type = typeMath.solution, MathAritmetic = "  3  ", Solution = 3 };
            Cards[16] = new Math_aritmetic() { Type = typeMath.math_aritmetic, MathAritmetic = "42/6 ", Solution = 7 };
            Cards[17] = new Math_aritmetic() { Type = typeMath.solution, MathAritmetic = "  7  ", Solution = 7 };
            Cards[18] = new Math_aritmetic() { Type = typeMath.math_aritmetic, MathAritmetic = " 3*5 ", Solution = 15 };
            Cards[19] = new Math_aritmetic() { Type = typeMath.solution, MathAritmetic = " 15  ", Solution = 15 };
            Cards[20] = new Math_aritmetic() { Type = typeMath.math_aritmetic, MathAritmetic = "2*10 ", Solution = 20 };
            Cards[21] = new Math_aritmetic() { Type = typeMath.solution, MathAritmetic = " 20  ", Solution = 20 };
            Cards[22] = new Math_aritmetic() { Type = typeMath.math_aritmetic, MathAritmetic = " 9+8 ", Solution = 17 };
            Cards[23] = new Math_aritmetic() { Type = typeMath.solution, MathAritmetic = " 17  ", Solution = 17 };
            Cards[24] = new Math_aritmetic() { Type = typeMath.math_aritmetic, MathAritmetic = "21-2 ", Solution = 19 };
            Cards[25] = new Math_aritmetic() { Type = typeMath.solution, MathAritmetic = " 19  ", Solution = 19 };
            Cards[26] = new Math_aritmetic() { Type = typeMath.math_aritmetic, MathAritmetic = "58-9 ", Solution = 49 };
            Cards[27] = new Math_aritmetic() { Type = typeMath.solution, MathAritmetic = " 49  ", Solution = 49 };
            Cards[28] = new Math_aritmetic() { Type = typeMath.math_aritmetic, MathAritmetic = "48*2 ", Solution = 96 };
            Cards[29] = new Math_aritmetic() { Type = typeMath.solution, MathAritmetic = " 96  ", Solution = 96 };
        }   

        public void FillLetter()
        {
            for (int i = 0; i < 15; i++)
            {
                Cards[i] = new Letter_card() { Letter = (char)(i + 'A') };
                Cards[29 - i] = new Letter_card() { Letter = (char)(i + 'a') };
            }
        }

        public void FillSymbol()
        {
            Cards[0] = new Symbol_card() { Color = ConsoleColor.Yellow, Symbol = (char)(1) };
            Cards[1] = new Symbol_card() { Color = ConsoleColor.Yellow, Symbol = (char)(1) };
            Cards[2] = new Symbol_card() { Color = ConsoleColor.Red, Symbol = (char)(2) };
            Cards[3] = new Symbol_card() { Color = ConsoleColor.Red, Symbol = (char)(2) };
            Cards[4] = new Symbol_card() { Color = ConsoleColor.Magenta, Symbol = (char)(3) };
            Cards[5] = new Symbol_card() { Color = ConsoleColor.Magenta, Symbol = (char)(3) };
            Cards[6] = new Symbol_card() { Color = ConsoleColor.Blue, Symbol = (char)(4) };
            Cards[7] = new Symbol_card() { Color = ConsoleColor.Blue, Symbol = (char)(4) };
            Cards[8] = new Symbol_card() { Color = ConsoleColor.Cyan, Symbol = (char)(5) };
            Cards[9] = new Symbol_card() { Color = ConsoleColor.Cyan, Symbol = (char)(5) };
            Cards[10] = new Symbol_card() { Color = ConsoleColor.DarkCyan, Symbol = (char)(6) };
            Cards[11] = new Symbol_card() { Color = ConsoleColor.DarkCyan, Symbol = (char)(6) };
            Cards[12] = new Symbol_card() { Color = ConsoleColor.DarkGray, Symbol = (char)(15) };
            Cards[13] = new Symbol_card() { Color = ConsoleColor.DarkGray, Symbol = (char)(15) };
            Cards[14] = new Symbol_card() { Color = ConsoleColor.DarkGreen, Symbol = (char)(16) };
            Cards[15] = new Symbol_card() { Color = ConsoleColor.DarkGreen, Symbol = (char)(16) };
            Cards[16] = new Symbol_card() { Color = ConsoleColor.DarkMagenta, Symbol = (char)(19) };
            Cards[17] = new Symbol_card() { Color = ConsoleColor.DarkMagenta, Symbol = (char)(19) };
            Cards[18] = new Symbol_card() { Color = ConsoleColor.DarkRed, Symbol = (char)(20) };
            Cards[19] = new Symbol_card() { Color = ConsoleColor.DarkRed, Symbol = (char)(20) };
            Cards[20] = new Symbol_card() { Color = ConsoleColor.DarkYellow, Symbol = (char)(22) };
            Cards[21] = new Symbol_card() { Color = ConsoleColor.DarkYellow, Symbol = (char)(22) };
            Cards[22] = new Symbol_card() { Color = ConsoleColor.Gray, Symbol = (char)(30) };
            Cards[23] = new Symbol_card() { Color = ConsoleColor.Gray, Symbol = (char)(30) };
            Cards[24] = new Symbol_card() { Color = ConsoleColor.Green, Symbol = (char)(34) };
            Cards[25] = new Symbol_card() { Color = ConsoleColor.Green, Symbol = (char)(34) };
            Cards[26] = new Symbol_card() { Color = ConsoleColor.Magenta, Symbol = (char)(36) };
            Cards[27] = new Symbol_card() { Color = ConsoleColor.Magenta, Symbol = (char)(36) };
            Cards[28] = new Symbol_card() { Color = ConsoleColor.Yellow, Symbol = (char)(64) };
            Cards[29] = new Symbol_card() { Color = ConsoleColor.Yellow, Symbol = (char)(64) };
        }

        public void Mix()
        {
            Random random= new Random();
            int x, y;
            Basic_card temp;
            for (int i = 0; i < 50; i++)
            {
                x=random.Next()%30;
                y=random.Next()%30;
                temp = Cards[x];
                Cards[x] = Cards[y];
                Cards[y] = temp;
            }
        }
    }
}