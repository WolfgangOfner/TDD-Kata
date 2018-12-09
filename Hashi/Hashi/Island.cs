using System.Collections.Generic;

namespace Hashi
{
    public class Island : IGameObject
    {
        private static int _id = 1;

        public Island(int neededConnections, int x, int y)
        {
            NeededConnection = neededConnections;
            X = x;
            Y = y;
            Id = _id++;
            Neighbours = new List<Island>();
        }

        public int Id { get; private set; }

        public int NeededConnection { get; private set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int Connections { get; set; }
        
        public List<Island> Neighbours { get; set; }

        public List<int> IterateThroughAllIslands(Island island, List<int> visitedIslandIds)
        {
            if (visitedIslandIds.Contains(island.Id))
            {
                return visitedIslandIds;
            }

            visitedIslandIds.Add(island.Id);

            foreach (var item in island.Neighbours)
            {
                IterateThroughAllIslands(item, visitedIslandIds);
            }

            return visitedIslandIds;
        }
    }
}