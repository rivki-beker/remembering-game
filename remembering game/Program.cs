using remembering_game;
for (int i = 0; i < 16; i++)
{
    Console.BackgroundColor=(ConsoleColor)i;
    Console.WriteLine((ConsoleColor)i);
}
Game game = new Game();
game.Restart();
game.Game_process();