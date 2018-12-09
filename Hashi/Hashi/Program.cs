using System;

namespace Hashi
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var board = new[,]
            {
                {"1", "", "2"},
                {"|", "", "║"},
                {"3", "=", "4"}
            };

            var game = new Game();
            game.SetupBoard(board);
            game.SolveGame(new Solver());

            Console.WriteLine(game.GameStatus == GameStatus.Won ? "Winner" : "Loser");
        }
    }
}