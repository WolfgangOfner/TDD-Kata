using System.Collections.Generic;

namespace Hashi
{
    public class BridgeBuilder
    {
        public List<Bridge> CreateBridges(IGameObject[,] gameBoard)
        {
            var bridges = CreateHorizontalBridges(gameBoard);
            bridges = CreateVerticalBridges(gameBoard, bridges);

            return bridges;
        }

        private static List<Bridge> CreateHorizontalBridges(IGameObject[,] board)
        {
            var bridges = new List<Bridge>();
            var onBridge = false;
            var startX = 0;
            var startY = 0;
            Island startIsland = null;

            for (var i = 0; i < board.GetLength(0); i++)
            {
                for (var j = 0; j < board.GetLength(1); j++)
                {
                    if ((i == 0 || i == board.GetLength(0)) && (j == 0 || j == board.GetLength(1)))
                    {
                        continue;
                    }

                    if (onBridge && j + 1 == board.GetLength(1))
                    {
                        throw new HashiException("A bridge can't end at the end of the board");
                    }

                    if (IsHorizontal(board[i, j]))
                    {
                        if (j == 0)
                        {
                            throw new HashiException("A bridge can't start at the end of the board");
                        }

                        if (!onBridge && board[i, j - 1] is Island)
                        {
                            onBridge = true;
                            startX = i;
                            startY = j;
                            ((Island) board[i, j - 1]).Connections += IsSingle(board[i, j]) ? 1 : 2;
                            startIsland = (Island) board[i, j - 1];
                        }

                        if (onBridge && board[i, j + 1] is Island)
                        {
                            onBridge = false;
                            bridges.Add(new Bridge(startX, startY, i, j, IsSingle(board[i, j]), false));
                            ((Island) board[i, j + 1]).Connections += IsSingle(board[i, j]) ? 1 : 2;

                            ((Island) board[i, j + 1]).Neighbours.Add(startIsland);
                            startIsland.Neighbours.Add((Island) board[i, j + 1]);
                        }
                        else if (onBridge && board[i, j + 1] is BridgePart bridgePart)
                        {
                            if (bridgePart.IsVertical != ((BridgePart) board[i, j]).IsVertical ||
                                bridgePart.IsSingle != ((BridgePart) board[i, j]).IsSingle)
                            {
                                throw new HashiException("Bridge crossing detected");
                            }
                        }
                        else
                        {
                            throw new HashiException("Bridge is not attached to an island at the end");
                        }
                    }
                }
            }

            return bridges;
        }

        private static List<Bridge> CreateVerticalBridges(IGameObject[,] board, List<Bridge> bridges)
        {
            var onBridge = false;
            var startX = 0;
            var startY = 0;
            Island startIsland = null;

            for (var j = 0; j < board.GetLength(1); j++)
            {
                for (var i = 0; i < board.GetLength(0); i++)
                {
                    if ((i == 0 || i == board.GetLength(0)) && (j == 0 || j == board.GetLength(1)))
                    {
                        continue;
                    }

                    if (onBridge && i + 1 == board.GetLength(0))
                    {
                        throw new HashiException("A bridge can't end at the end of the board");
                    }

                    if (IsVertical(board[i, j]))
                    {
                        if (i == 0)
                        {
                            throw new HashiException("A bridge can't start at the end of the board");
                        }

                        if (!onBridge && board[i - 1, j] is Island)
                        {
                            onBridge = true;
                            startX = i;
                            startY = j;
                            ((Island) board[i - 1, j]).Connections += IsSingle(board[i, j]) ? 1 : 2;

                            startIsland = (Island) board[i - 1, j];
                        }

                        if (onBridge && board[i + 1, j] is Island)
                        {
                            onBridge = false;
                            bridges.Add(new Bridge(startX, startY, i, j, IsSingle(board[i, j]), true));
                            ((Island) board[i + 1, j]).Connections += IsSingle(board[i, j]) ? 1 : 2;

                            ((Island) board[i + 1, j]).Neighbours.Add(startIsland);
                            startIsland.Neighbours.Add((Island) board[i + 1, j]);
                        }
                        else if (onBridge && board[i + 1, j] is BridgePart bridgePart)
                        {
                            if (bridgePart.IsVertical != ((BridgePart) board[i, j]).IsVertical ||
                                bridgePart.IsSingle != ((BridgePart) board[i, j]).IsSingle)
                            {
                                throw new HashiException("Bridge crossing detected");
                            }
                        }
                        else
                        {
                            throw new HashiException("Bridge is not attached to an island at the end");
                        }
                    }
                }
            }

            return bridges;
        }

        private static bool IsSingle(IGameObject gameObject)
        {
            return ((BridgePart) gameObject).IsSingle;
        }

        private static bool IsVertical(IGameObject gameObject)
        {
            return gameObject is BridgePart part && part.IsVertical;
        }

        private static bool IsHorizontal(IGameObject gameObject)
        {
            return gameObject is BridgePart part && !part.IsVertical;
        }
    }
}