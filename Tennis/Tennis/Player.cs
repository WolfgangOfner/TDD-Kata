namespace Tennis
{
    public class Player
    {
        public int Score { get; private set; }

        public void WinPoint()
        {
            Score++;
        }
    }
}