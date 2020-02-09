using System;
using System.Linq;

namespace Lib.Board
{
    public class SudokuBoard : ISudokuBoard
    {
        private readonly int[,] _board;

        public SudokuBoard(int[,] board)
        {
            if (!IsValidBoard(board))
            {
                throw new ArgumentException(nameof(board));
            }

            _board = (int[,]) board.Clone();
        }

        public int Size { get; } = 9;

        public ISudokuBoard Clone()
        {
            return new SudokuBoard(_board);
        }

        public int this[int row, int column]
        {
            get => _board[row, column];
            set
            {
                if (!IsValidCell(value))
                {
                    throw new ArgumentOutOfRangeException($"{value}");
                }
                
                _board[row, column] = value;
            }
        }

        public override string ToString()
        {
            return string.Join(" ", _board.Cast<int>());
        }

        private bool IsValidBoard(int[,] board)
        {
            if (board == null)
            {
                return false;
            }

            var rows = board.GetLength(0);
            var columns = board.GetLength(1);
            if (rows != Size || rows != columns)
            {
                return false;
            }

            var cells = from int cell in board select cell;
            return cells.All(IsValidCell);
        }

        private static bool IsValidCell(int value)
        {
            return value >= 0 && value <= 9;
        }
    }
}
