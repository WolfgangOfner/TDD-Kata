namespace Tennis
{
    public class Game
    {
        private readonly IStandingsCalculator _standingsCalculator;
        private readonly Player _playerA;
        private readonly Player _playerB;

        public Game(IStandingsCalculator standingsCalculator, Player playerA, Player playerB)
        {
            _standingsCalculator = standingsCalculator;
            _playerA = playerA;
            _playerB = playerB;
        }

        public string Score => _standingsCalculator.Calculate(_playerA.Score, _playerB.Score);

        public void PlayPoint(Player playerWinsPoint)
        {
            playerWinsPoint.WinPoint();
        }
    }
}