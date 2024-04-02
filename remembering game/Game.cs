using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace remembering_game
{
    internal class Game
    {
        #region fields
        public List<Basic_player> Players { get; set; } = new List<Basic_player>();
        public Board Board { get; set; }
        #endregion
        #region methods
        public void Restart()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("who do you want to play with?");
            Console.Write("with friends press 1,with the computer press 2: ");
            if (int.Parse(Console.ReadLine()) == 1)
            {
                Console.Write("enter the number of the players: ");
                int countPlayers = int.Parse(Console.ReadLine());
                for (int i = 0; i < countPlayers; i++)
                {
                    Console.Write("enter your name: ");
                    Players.Add(new User_player(Console.ReadLine()));
                }
            }
            else
            {

                Console.Write("choose level (1-4): ");
                int level = int.Parse(Console.ReadLine());
                switch (level)
                {
                    case 1:
                        level = 4;
                        break;
                    case 2:
                        level = 10;
                        break;
                    case 3:
                        level = 20;
                        break;
                    case 4:
                        level = 100;
                        break;
                }
                Console.Write("enter your name: ");
                Players.Add(new User_player(Console.ReadLine()));
                Players.Add(new Computer_player());
                (Players[1] as Computer_player).Level = (Level)level;
            }
            Console.WriteLine("what type of the cards do you want?");
            Console.Write("letter- press 1, symbol- press 2, exersize- press 3: ");
            Board = new Board((Types)int.Parse(Console.ReadLine()));
            Console.Clear();
            Board.Drawing();
        }
        public void Game_process()
        {
            Basic_card[] two_cards = new Basic_card[2];
            while (Board.Is_exist_cards())
            {
                foreach (Basic_player player in Players)
                {
                    if (!Board.Is_exist_cards())
                        break;
                    if (player is Computer_player computer)
                    {
                        Console.Write("computer choose:");
                        two_cards = computer.Choose_cards(Board.Cards);
                        Thread.Sleep(500);
                        two_cards[0].Drawing();
                        two_cards[1].Drawing();
                        Thread.Sleep(500);
                    }
                    else
                    {
                        int index;
                        do
                        {
                            Console.SetCursorPosition(0, 0);
                            Console.Write($"{player.Name}- enter your first choice:   ");
                            Console.SetCursorPosition(player.Name.Length + 27, 0);
                            int.TryParse(Console.ReadLine(), out index);
                        } while (index<1||index>30|| !Board.Is_available_loc(index-1));
                        two_cards[0] = Board.Cards[index - 1];
                        two_cards[0].Discovered = true;
                        two_cards[0].Drawing();
                        do
                        {
                            Console.SetCursorPosition(0, 1);
                            Console.Write($"{player.Name}- enter your second choice:   ");
                            Console.SetCursorPosition(player.Name.Length + 28, 1);
                            int.TryParse(Console.ReadLine(), out index);
                        } while (index < 1 || index > 30 || !Board.Is_available_loc(index-1));
                        two_cards[1] = Board.Cards[index - 1];
                        two_cards[1].Drawing();
                    }
                    if (Players[1] is Computer_player computer_player)
                        computer_player.AddToMemory(two_cards);
                    if (two_cards[0].Equals(two_cards[1]))
                        Find_couple(two_cards, player);
                    else
                        Thread.Sleep(1500);
                    Board.Drawing();
                    two_cards[0].Discovered = false;
                    two_cards[1].Discovered = false;
                }
            }
            Winner();
        }
        public void Find_couple(Basic_card[] cards, Basic_player player)
        {
            player.Score += 10;
            cards[0].Belong = player.Name;
            cards[1].Belong = player.Name;
            for (int i = 0; i < 5; i++)
            {
                cards[0].Drawing();
                cards[1].Drawing();
                Thread.Sleep(100);
                cards[0].Drawing(ConsoleColor.Black);
                cards[1].Drawing(ConsoleColor.Black);
                Thread.Sleep(100);
            }
        }
        public void Winner()
        {
            int max_score = 0;
            foreach(Basic_player player in Players)
            {
                if (player.Score > max_score)
                {
                    max_score = player.Score;
                }
            }
            List<string> winnersNames = new List<string>();
            foreach (Basic_player player in Players)
            {
                if (player.Score == max_score)
                {
                    winnersNames.Add(player.Name);
                }
            }
            Random random = new Random();
            Console.Clear();
            for (int i = 0; i < 5; i++)
            {
                foreach (Basic_card card in Board.Cards)
                {
                    if (card.Belong == winnersNames[0])
                    {
                        card.Location = new Point(random.Next() % 120, random.Next() % 40);
                        card.Drawing();
                    }
                }
                Thread.Sleep(200);
                foreach (Basic_card card in Board.Cards)
                {
                    if (card.Belong == winnersNames[0])
                    {
                        card.Drawing(ConsoleColor.Black);
                    }
                }
                Thread.Sleep(200);
            }
            Console.Clear();
            Console.WriteLine("scores:");
            foreach(Basic_player player in Players)
            {
                Console.WriteLine($"{player.Name}: {player.Score}");
            }
            Thread.Sleep(2000);
            Console.Clear();

            Point[] points = new Point[] { new Point(7, 5), new Point(27, 9), new Point(50, 3),
                new Point(74, 7), new Point(115, 3), new Point(97, 13), new Point(14, 22), new Point(42, 20),
                new Point(62, 19), new Point(108, 23), new Point(3, 34), new Point(39, 36), new Point(69, 37),
                new Point(84, 30) ,new Point(114, 35)};

            while (!Console.KeyAvailable)
            {
                for (int i=0;i< points.Length;i++)
                {
                    try
                    {
                        Console.SetCursorPosition(points[i].X, points[i].Y);
                        Console.ForegroundColor = (ConsoleColor)random.Next(15);
                        Console.WriteLine(winnersNames[i%winnersNames.Count]);
                    }
                    catch
                    {
                    }
                }
                Thread.Sleep(100);
                for (int i = 0; i < points.Length; i++)
                {
                    try
                    {
                        Console.SetCursorPosition(points[i].X, points[i].Y);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(winnersNames[i % winnersNames.Count]);
                    }
                    catch
                    {
                    }
                }
                Thread.Sleep(100);
            }
        }
        #endregion
    }
}
