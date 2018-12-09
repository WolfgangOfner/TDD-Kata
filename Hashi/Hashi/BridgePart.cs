namespace Hashi
{
    public class BridgePart : IGameObject
    {
        public BridgePart(int x, int y, bool isSingle = true, bool isVertival = true)
        {
            X = x;
            Y = y;
            IsSingle = isSingle;
            IsVertical = isVertival;

        }
        public int X { get; set; }

        public int Y { get; set; }

        public bool IsSingle { get; set; }

        public bool IsVertical { get; set; }
    }
}