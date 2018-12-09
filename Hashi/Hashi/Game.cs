using System.Collections.Generic;

namespace Hashi
{
    public class Game
    {
        public Game()
        {
            Bridges = new List<Bridge>();
            GameStatus = GameStatus.Running;
        }

        public IGameObject[,] Board { get; private set; }

        public GameStatus GameStatus { get; private set; }

        public List<Bridge> Bridges { get; private set; }

        public void SolveGame(ISolver solver)
        {
            GameStatus = solver.SolveGame(this);
        }

        public void SetupBoard(string[,] inputBoard)
        {
            CreateBoard(inputBoard);

            try
            {
                CreateBridges();
            }
            catch (HashiException)
            {
                GameStatus = GameStatus.Lost;
            }
        }

        private void CreateBoard(string[,] inputBoard)
        {
            Board = new IGameObject[inputBoard.GetLength(0), inputBoard.GetLength(1)];

            for (var i = 0; i < inputBoard.GetLength(0); i++)
            {
                for (var j = 0; j < inputBoard.GetLength(1); j++)
                {
                    if (int.TryParse(inputBoard[i, j], out var neededConnections))
                    {
                        Board[i, j] = new Island(neededConnections, i, j);
                    }
                    else if (string.IsNullOrEmpty(inputBoard[i, j].Trim()))
                    {
                        Board[i, j] = new EmptyField(i, j);
                    }
                    else if (inputBoard[i, j].Equals("-"))
                    {
                        Board[i, j] = new BridgePart(i, j, true, false);
                    }
                    else if (inputBoard[i, j].Equals("|"))
                    {
                        Board[i, j] = new BridgePart(i, j);
                    }
                    else if (inputBoard[i, j].Equals("="))
                    {
                        Board[i, j] = new BridgePart(i, j, false, false);
                    }
                    else if (inputBoard[i, j].Equals("║"))
                    {
                        Board[i, j] = new BridgePart(i, j, false);
                    }
                }
            }
        }

        private void CreateBridges()
        {
            var bridgeBuilder = new BridgeBuilder();

            Bridges = bridgeBuilder.CreateBridges(Board);
        }
    }
}