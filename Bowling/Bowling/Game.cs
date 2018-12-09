using System.Collections.Generic;

namespace Bowling
{
    public class Game
    {
        private readonly List<int> _rollResult;

        public Game()
        {
            _rollResult = new List<int>();
        }

        public int Score { get; private set; }

        public void Roll(int pins)
        {
            Score += pins;
            _rollResult.Add(pins);
        }

        public int CalculateScore()
        {
            var score = 0;
            var roll = 0;

            for (var frame = 0; frame < 10; frame++)
            {
                if (IsStrike(roll))
                {
                    score += _rollResult[roll] + _rollResult[roll + 1] + _rollResult[roll + 2];
                    roll++;
                }
                else if (IsSpare(roll))
                {
                    score += 10 + _rollResult[roll + 2];
                    roll += 2;
                }

                else
                {
                    score += _rollResult[roll] + _rollResult[roll + 1];
                    roll += 2;
                }
            }

            return score;
        }

        private bool IsSpare(int roll)
        {
            return _rollResult[roll] + _rollResult[roll + 1] == 10;
        }

        private bool IsStrike(int roll)
        {
            return _rollResult[roll] == 10;
        }
    }
}