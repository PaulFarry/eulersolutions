using Common;
using System.Diagnostics;
using System.Text;

namespace Problems
{
    class Problem28 : IProblem
    {
        public int Number => 28;

        private const int Size = 1001;
        /// <summary>
        /// This is far more involved than it needs to be, it actually stores the values in 
        /// the array so it can print out a pretty display of the values.
        /// </summary>
        /// <returns></returns>

        public string Execute()
        {
            var spiral = CreateSpiral(Size, Size);
            var answer = CalculateSum(spiral, Size, Size);
            return answer.ToString();
        }

        private int CalculateSum(int[,] mm, int width, int height)
        {
            var totalSum = -1; //Start -1 due to crossing centre point twice
            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    if (x == y)
                    {
                        var col = x;
                        var row = y;
                        totalSum += mm[row, col];
                        col = width - (x + 1);
                        row = y;
                        totalSum += mm[row, col];
                    }
                }
            }

            return totalSum;
        }

        private class Mover
        {
            private Move Right = new Move { Column = 1, Row = 0, Name = "Right" };
            private Move Left = new Move { Column = -1, Row = 0, Name = "Left" };
            private Move Down = new Move { Column = 0, Row = 1, Name = "Down" };
            private Move Up = new Move { Row = -1, Column = 0, Name = "Up" };

            public Mover(int Width, int Height)
            {
                XLimit = 1;
                YLimit = 1;
                CurrentMove = Right;
                TotalMoves = Width * Height;
                Column = Width / 2;
                Row = Height / 2;
                Right.NextMove = Down;
                Down.NextMove = Left;
                Left.NextMove = Up;
                Up.NextMove = Right;

                Result = new int[Width, Height];
            }

            public int[,] Result { get; private set; }
            private class Move
            {
                public int Column { get; set; }
                public int Row { get; set; }
                public Move NextMove { get; set; }
                public string Name { get; set; }
            }
            private Move CurrentMove;

            private int MovesCompleted;
            public int TotalMoves { get; set; }

            public int Column { get; set; }
            public int Row { get; set; }
            public int XCounter { get; set; }
            public int YCounter { get; set; }
            public int XLimit { get; set; }
            public int YLimit { get; set; }


            public bool MakeMove()
            {
                MovesCompleted++;
                if (MovesCompleted <= TotalMoves)
                {
                    Result[Row, Column] = MovesCompleted;
                    Column += CurrentMove.Column;
                    Row += CurrentMove.Row;

                    if (CurrentMove.Column != 0)
                    {
                        XCounter++;
                        if (XCounter >= XLimit)
                        {
                            XLimit++;
                            CurrentMove = CurrentMove.NextMove;
                            XCounter = 0;
                        }
                    }
                    else
                    {
                        YCounter++;
                        if (YCounter >= YLimit)
                        {
                            YLimit++;
                            CurrentMove = CurrentMove.NextMove;
                            YCounter = 0;
                        };
                    }
                    return (MovesCompleted < TotalMoves);
                }
                return false;
            }
        }

        private int[,] CreateSpiral(int width, int height)
        {
            var mm = new Mover(width, height);
            while (mm.MakeMove()) { }
            //DrawResult(width, height, mm);
            return mm.Result;
        }

        private static void DrawResult(int width, int height, Mover mm)
        {
            var output = new StringBuilder();
            var currentLine = new StringBuilder();

            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    if (currentLine.Length == 0)
                    {
                        currentLine.Append("|");
                    }
                    currentLine.Append($"{mm.Result[x, y]:D7} | ");
                }
                output.AppendLine(currentLine.ToString());
                currentLine.Clear();
            }
            Debug.Print(output.ToString());
        }
    }
}
