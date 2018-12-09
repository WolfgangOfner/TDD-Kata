using System;

namespace Hashi.Test
{
    public static class Helper
    {
        private static string[,] _board = null;

        public static string[,] GetBoardWithBrokenBridge(int boardNumber)
        {
            switch (boardNumber)
            {
                case 1:
                    GetBoardWithCrossedBridge();
                    break;
                case 2:
                    GetBoardWithNoEndOfHorizontalSingleBridge();
                    break;
                case 3:
                    GetBoardWithNoEndOfHorizontalSingleBridge();
                    break;
                case 4:
                    GetBoardWithEndOfVerticalSingleBridgeAtTheEndOfTheBoard();
                    break;
                case 5:
                    GetBoardWithEndOfHorizontalSingleBridgeAtTheEndOfTheBoard();
                    break;
                case 6:
                    GetBoardWithNoStartOfVerticalSingleBridge();
                    break;
                case 7:
                    GetBoardWithNoStartOfHorizontalSingleBridge();
                    break;
                case 8:
                    GetBoardWithStartOfVerticalSingleBridgeAtTheBeginningOfTheBoard();
                    break;
                case 9:
                    GetBoardWithStartOfHorizontalSingleBridgeAtTheBeginningOfTheBoard();
                    break;
                case 10:
                    GetBoardWithNoEndOfVerticalSingleBridge();
                    break;
                default:
                    throw new InvalidOperationException();
            }

            return _board;
        }

        public static string[,] GetBoardWithHorizontalOrVerticalBridge(bool vertical)
        {
            if (vertical)
            {
                GetBoardWithVerticalBridge();
            }
            else
            {
                GetBoardWithHorizontalBridge();
            }

            return _board;
        }

        public static string[,] GetBoardWithRightSolution(int boardNumber)
        {
            switch (boardNumber)
            {
                case 1:
                    GetWorkingBoard();
                    break;
                case 2:
                    GetBigWorkingBoard();
                    break;
                default:
                    throw new InvalidOperationException();
            }

            return _board;
        }

        public static string[,] GetBoardWithWrongSolution(int boardNumber)
        {
            switch (boardNumber)
            {
                case 1:
                    GetBoardWithAllElements();
                    break;
                case 2:
                    GetBoardWithNotAllIslandsConnected();
                    break;
                default:
                    throw new InvalidOperationException();
            }

            return _board;
        }

        private static void GetWorkingBoard()
        {
            _board = new[,]
            {
                {"1", "", "2"},
                {"|", "", "║"},
                {"3", "=", "4"}
            };
        }

        private static void GetBigWorkingBoard()
        {
            _board = new[,]
            {
                {"2", "-", "3","-", "-", "4","-", "-", "-","-", "2", " "," "},
                {"|", " ", "|"," ", " ", "║"," ", " ", " "," ", "|", " ","2"},
                {"|", " ", "|"," ", " ", "║"," ", " ", " "," ", "|", " ","║"},
                {"1", " ", "1"," ", " ", "║"," ", " ", "1","-", "3", " ","3"},
                {" ", " ", " "," ", " ", "║"," ", " ", " "," ", "|", " ","|"},
                {"2", "=", "=","=", "=", "8","=", "=", "=","=", "5", "-","2"},
                {" ", " ", " "," ", " ", "║"," ", " ", " "," ", "|", " ",""},
                {" ", " ", " "," ", " ", "║"," ", " ", " "," ", "|", " "," "},
                {"3", "-", "-","3", " ", "║"," ", " ", " "," ", "|", " ","1"},
                {"║", " ", " ","║", " ", "║"," ", " ", " "," ", "|", " ","|"},
                {"║", " ", " ","2", " ", "║"," ", " ", " "," ", "3", "=","4"},
                {"║", " ", " "," ", " ", "║"," ", " ", " "," ", " ", " ","|"},
                {"3", "-", "-","-", "-", "3"," ", "1", "-","-", "-", "-","2"},
            };
        }

        private static void GetBoardWithAllElements()
        {
            _board = new[,]
            {
                {"1", "-", "2"},
                {"|", "", "║"},
                {"3", "=", "4"}
            };
        }

        private static void GetBoardWithNotAllIslandsConnected()
        {
            _board = new[,]
            {
                {"1", "", "2"},
                {"|", "", ""},
                {"3", "=", "4"}
            };
        }

        private static void GetBoardWithCrossedBridge()
        {
           _board = new[,]
            {
                {"", "", "1", "", ""},
                {"", "", "|", "", ""},
                {"1", "-", "|", "-", "1"},
                {"", "", "|", "", ""},
                {"", "", "1", "", ""}
            };
        }

        private static void GetBoardWithNoEndOfVerticalSingleBridge()
        {
            _board = new[,]
            {
                {"1", "-", "2"},
                {"|", "", "║"},
                {"", "", "4"}
            };
        }

        private static void GetBoardWithNoEndOfHorizontalSingleBridge()
        {
            _board = new[,]
            {
                {"2", "-", "1"},
                {"|", "", ""},
                {"2", "-", ""}
            };
        }

        private static void GetBoardWithEndOfVerticalSingleBridgeAtTheEndOfTheBoard()
        {
            _board = new[,]
            {
                {"2", "-", "2"},
                {"|", "", ""},
                {"|", "", ""}
            };
        }

        private static void GetBoardWithEndOfHorizontalSingleBridgeAtTheEndOfTheBoard()
        {
            _board = new[,]
            {
                {"2", "-", "-"},
                {"|", "", ""},
                {"1", "", ""}
            };
        }

        private static void GetBoardWithNoStartOfVerticalSingleBridge()
        {
            _board = new[,]
            {
                {"", "", ""},
                {"", "|", ""},
                {"", "1", ""}
            };
        }

        private static void GetBoardWithNoStartOfHorizontalSingleBridge()
        {
            _board = new[,]
            {
                {"", "", ""},
                {"", "-", "1"},
                {"", "", ""}
            };
        }

        private static void GetBoardWithStartOfVerticalSingleBridgeAtTheBeginningOfTheBoard()
        {
            _board = new[,]
            {
                {"", "|", ""},
                {"", "1", ""},
                {"", "", ""}
            };
        }

        private static void GetBoardWithStartOfHorizontalSingleBridgeAtTheBeginningOfTheBoard()
        {
            _board = new[,]
            {
                {"", "", ""},
                {"-", "1", ""},
                {"", "", ""}
            };
        }

        private static void GetBoardWithHorizontalBridge()
        {
            _board = new[,]
            {
                {"", "", ""},
                {"1", "-", "1"},
                {"", "", ""}
            };
        }

        private static void GetBoardWithVerticalBridge()
        {
            _board = new[,]
            {
                {"1", "", ""},
                {"|", "", ""},
                {"1", "", ""}
            };
        }
    }
}