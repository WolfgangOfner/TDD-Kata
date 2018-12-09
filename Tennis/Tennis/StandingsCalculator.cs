using System;

namespace Tennis
{
    public class StandingsCalculator : IStandingsCalculator
    {
        public string Calculate(int playerAScore, int playerBScore)
        {
            string result;

            if (CheckIfGameIsWon(playerAScore, playerBScore))
            {
                result = playerAScore > playerBScore ? "PlayerA won" : "PlayerB won";
            }
            else if (CheckIfScoreIsDeuce(playerAScore, playerBScore))
            {
                result = "deuce";
            }
            else if (CheckIfScoreIsAdvantage(playerAScore, playerBScore))
            {
                result = playerAScore > playerBScore ? "advantage PlayerA" : "advantage PlayerB";
            }
            else
            {
                result = TranslateScore(playerAScore);
                result += ":";
                result += TranslateScore(playerBScore);
            }

            return result;
        }

        private bool CheckIfGameIsWon(int playerAScore, int playerBScore)
        {
            var gameWon = false;
            var pointsDifference = playerAScore - playerBScore;

            if ((playerAScore > 3 || playerBScore > 3) && Math.Abs(pointsDifference) > 1)
            {
                gameWon = true;
            }

            return gameWon;
        }

        private bool CheckIfScoreIsAdvantage(int playerAScore, int playerBScore)
        {
            var isAdvantage = playerAScore >= 3 && playerBScore >= 3 && playerAScore != playerBScore;

            return isAdvantage;
        }

        private bool CheckIfScoreIsDeuce(int playerAScore, int playerBScore)
        {
            var isDeuce = playerAScore >= 3 && playerBScore >= 3 && playerAScore == playerBScore;

            return isDeuce;
        }

        private string TranslateScore(int playerScore)
        {
            var result = string.Empty;

            switch (playerScore)
            {
                case 0:
                    result = "love";
                    break;
                case 1:
                    result = "fifteen";
                    break;
                case 2:
                    result = "thirty";
                    break;
                case 3:
                    result = "fourty";
                    break;
            }

            return result;
        }
    }
}