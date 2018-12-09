namespace Tennis
{
    public interface IStandingsCalculator
    {
        string Calculate(int playerAScore, int playerBScore);
    }
}