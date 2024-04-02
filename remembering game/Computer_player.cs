using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace remembering_game
{
    public enum Level { low=4,average=10,high=20,max=100};
    internal class Computer_player : Basic_player
    {
        public Level Level { get; set; }
        public List<Basic_card> Memory {private get; set; }= new List<Basic_card>();
        public Computer_player():base("computer")
        {

        }
        public void AddToMemory(Basic_card[] cards)
        {
            Memory.AddRange(cards);
        }
        public Basic_card[] Choose_cards(Basic_card[]cards)
        {
            Basic_card[] res = new Basic_card[2];
            for (int i = Memory.Count-1; i >= 0&&i> Memory.Count-(int)Level; i--)
            {
                for (int j = i-1; j>=0&&j > Memory.Count - (int)Level; j--)
                {
                    if (Memory[i].Equals(Memory[j]) && Memory[i].Belong == "available" && Memory[j].Belong == "available")
                    {
                        res[0] = Memory[i];
                        res[1] = Memory[j];
                        return res;
                    }
                }
            }
            Random random= new Random();
            int x =random.Next(cards.Length);
            while (cards[x].Belong!="available")
                x = random.Next(cards.Length); 
            res[0]= cards[x];
            for (int i = Memory.Count - 1; i >= 0 && i > Memory.Count - (int)Level; i--)
            {
                if (Memory[i].Equals(cards[x]) && Memory[i].Belong == "available")
                {
                    res[1] = Memory[i];
                    return res;
                }
            }
            int y = random.Next(cards.Length);
            while (cards[y].Belong != "available"||y==x)
                y = random.Next(cards.Length);
            res[1] = cards[y];
            return res;
        }
    }
}