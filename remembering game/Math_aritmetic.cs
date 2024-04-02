using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace remembering_game
{
    public enum typeMath { math_aritmetic, solution };
    internal class Math_aritmetic : Basic_card
    {
        public string MathAritmetic { get; set; }
        public int Solution { get; set; }
        public typeMath Type { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Math_aritmetic && (obj as Math_aritmetic).Solution == this.Solution && (obj as Math_aritmetic).Type != this.Type && base.Equals(obj);
        }
        
    }
}