using System.Collections.Generic;
using FluentAssertions;
using Lib.Board;
using Lib.Solver;
using NUnit.Framework;

namespace UnitTests
{
    public class SudokuSolverTests
    {
        [TestCaseSource(nameof(GetBoards))]
        public void Should_Solve_Valid_Board(int[,] board)
        {
            // arrange
            var source = new SudokuBoard(board);
            var solver = new SudokuSolver();

            // act
            var ok = solver.TrySolve(source, out var destination);

            // assert
            ok.Should().BeTrue();
            destination.Should().NotBeNull();
        }

        private static IEnumerable<int[,]> GetBoards()
        {
            var board1 = new[,]
            {
                {0, 0, 6, 2, 9, 0, 3, 4, 0},
                {0, 0, 0, 0, 8, 6, 0, 9, 2},
                {0, 0, 0, 0, 7, 0, 0, 0, 1},
                {1, 0, 0, 0, 0, 8, 0, 7, 0},
                {0, 0, 8, 0, 2, 0, 1, 0, 0},
                {0, 9, 0, 1, 0, 0, 0, 0, 8},
                {7, 0, 0, 0, 3, 0, 0, 0, 0},
                {5, 1, 0, 8, 4, 0, 0, 0, 0},
                {0, 6, 4, 0, 0, 0, 0, 0, 0},
            };

            var board2 = new[,]
            {
                {0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0},
            };

            return new List<int[,]>
            {
                board1,
                board2
            };
        }
    }
}