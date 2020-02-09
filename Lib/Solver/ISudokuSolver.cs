using Lib.Board;

namespace Lib.Solver
{
    public interface ISudokuSolver
    {
        bool TrySolve(ISudokuBoard source, out ISudokuBoard destination);
    }
}
