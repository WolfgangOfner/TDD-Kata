namespace Hashi
{
    public class Bridge
    {
        public Bridge(int startX, int startY, int endX, int endY, bool isSingle, bool isVertical)
        {
            StartX = startX;
            StartY = startY;
            EndX = endX;
            EndY = endY;
            IsSingle = isSingle;
            IsVertical = isVertical;
        }

        public int StartX { get; set; }

        public int StartY { get; set; }

        public int EndX { get; set; }

        public int EndY { get; set; }

        public bool IsSingle { get; set; }

        public bool IsVertical { get; set; }
    }
}