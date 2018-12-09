namespace Hashi
{
    public class EmptyField : IGameObject
    {
        public EmptyField(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }
    }
}