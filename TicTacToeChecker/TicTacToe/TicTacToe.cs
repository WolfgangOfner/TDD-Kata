using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public class TicTacToe
    {
        private int _winner;

        public int SolveGame(int[,] board)
        {
            if (RowIsWon(board) || ColumnIsWon(board) || DiagonalIsWon(board))
            {
                return _winner;
            }

            return GameIsInProgress(board);
        }

        private bool DiagonalIsWon(int[,] board)
        {
            var result = false;

            var diagonal = GetDiagonal(board);

            for (var i = 0; i < 2; i++)
            {
                if (CheckIfGameIsWon(diagonal[i]))
                {
                    _winner = diagonal[i][0];
                    result = true;
                    break;
                }
            }

            return result;
        }

        private static List<List<int>> GetDiagonal(int[,] board)
        {
            var diagonal = new List<List<int>> {new List<int>(), new List<int>()};

            for (var i = 0; i < board.GetLength(0); i++)
            {
                diagonal[0].Add(board[i, i]);
            }

            for (int i = board.GetLength(0) - 1, j = 0; i >= 0; i--, j++)
            {
                diagonal[1].Add(board[i, j]);
            }

            return diagonal;
        }

        private bool ColumnIsWon(int[,] board)
        {
            var result = false;

            for (var i = 0; i < board.GetLength(1); i++)
            {
                var column = GetColumn(board, i);

                if (CheckIfGameIsWon(column))
                {
                    _winner = column[0];
                    result = true;
                    break;
                }
            }

            return result;
        }

        private static List<int> GetColumn(int[,] board, int j)
        {
            var col = new List<int>();

            for (var i = 0; i < board.GetLength(0); i++)
            {
                col.Add(board[i, j]);
            }

            return col;
        }

        private bool RowIsWon(int[,] board)
        {
            var result = false;

            for (var i = 0; i < board.GetLength(1); i++)
            {
                var row = GetRow(board, i);

                if (CheckIfGameIsWon(row))
                {
                    _winner = row[0];
                    result = true;
                    break;
                }
            }

            return result;
        }

        private static bool CheckIfGameIsWon(IReadOnlyCollection<int> row)
        {
            return row.All(x => x == row.First());
        }

        private static List<int> GetRow(int[,] board, int i)
        {
            var row = new List<int>();

            for (var j = 0; j < board.GetLength(1); j++)
            {
                row.Add(board[i, j]);
            }

            return row;
        }

        private static int GameIsInProgress(int[,] board)
        {
            var result = board.Cast<int>().Contains(0);
            
            return result ? -1 : 0;
        }
    }
}