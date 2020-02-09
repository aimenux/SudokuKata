using Lib.Board;

namespace Lib.Solver
{
    public class SudokuSolver : ISudokuSolver
    {
        public bool TrySolve(ISudokuBoard source, out ISudokuBoard destination)
        {
            var sudokuBoard = source.Clone();
            destination = Solve(sudokuBoard);
            return destination != null;
        }

        private static ISudokuBoard Solve(ISudokuBoard sudokuBoard)
        {
            var position = GetUnassignedPosition(sudokuBoard);
            if (position == null)
            {
                return sudokuBoard;
            }

            var (row, column) = position.Value;

            for (var choice = 1; choice <= 9; choice++)
            {
                if (!IsValidChoiceForPosition(sudokuBoard, (row, column), choice))
                {
                    continue;
                }

                sudokuBoard[row, column] = choice;

                var result = Solve(sudokuBoard);
                if (result != null)
                {
                    return result;
                }

                sudokuBoard[row, column] = 0;
            }

            return null;
        }

        private static (int,int)? GetUnassignedPosition(ISudokuBoard sudokuBoard)
        {
            for (var row = 0; row < sudokuBoard.Size; row++)
            {
                for (var column = 0; column < sudokuBoard.Size; column++)
                {
                    if (sudokuBoard[row, column] == 0)
                    {
                        return (row, column);
                    }
                }
            }

            return null;
        }

        private static bool IsValidChoiceForPosition(ISudokuBoard sudokuBoard, (int,int) position, int choice)
        {
            var (row, column) = position;

            for (var index = 0; index < sudokuBoard.Size; index++)
            {
                if (sudokuBoard[row, index] == choice || sudokuBoard[index, column] == choice)
                {
                    return false;
                }
            }

            var rowLower = 3 * (row / 3);
            var columnLower = 3 * (column / 3);

            for (var rowIndex = rowLower; rowIndex < rowLower + 3; rowIndex++)
            {
                for (var columnIndex = columnLower; columnIndex < columnLower + 3; columnIndex++)
                {
                    if (sudokuBoard[rowIndex, columnIndex] == choice)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}