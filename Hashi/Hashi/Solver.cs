using System.Collections.Generic;
using System.Linq;

namespace Hashi
{
    public class Solver : ISolver
    {
        private Game _game;
        
        public GameStatus SolveGame(Game game)
        {
            _game = game;

            return _game.GameStatus != GameStatus.Lost &&
                   (CheckIfGameHasRightAmountOfBridges() && CheckIfAllIslandsAreConnected())
                ? GameStatus.Won
                : GameStatus.Lost;
        }
        
        private bool CheckIfGameHasRightAmountOfBridges()
        {
            var neededConnections = GetNumberOfNeededBridges();
            var bridgesCount = GetNumberOfNeededSetBridges();

            return neededConnections == bridgesCount;
        }

        private bool CheckIfAllIslandsAreConnected()
        {
            var islands = GetAllIslands();
            var visitedIslandIds = islands[0]?.IterateThroughAllIslands(islands[0], new List<int>());

            return islands.Count == visitedIslandIds?.Count;
        }

        private int GetNumberOfNeededSetBridges()
        {
            return _game.Bridges.Select(x => x.IsSingle ? 1 : 2).Sum() * 2;
        }

        private int GetNumberOfNeededBridges()
        {
            var neededConnections = 0;

            foreach (var gameObject in _game.Board)
            {
                if (gameObject is Island island)
                {
                    neededConnections += island.NeededConnection;
                }
            }

            return neededConnections;
        }

        private List<Island> GetAllIslands()
        {
            var islands = new List<Island>();

            foreach (var gameObject in _game.Board)
            {
                if (gameObject is Island island)
                {
                    islands.Add(island);
                }
            }

            return islands;
        }
    }
}