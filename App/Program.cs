using System;
using Lib.Board;
using Lib.Solver;

namespace App
{
    public static class Program
    {
        public static void Main()
        {
            var board = new[,]
            {
                {0, 0, 0, 2, 0, 0, 3, 4, 0},
                {0, 0, 0, 0, 8, 6, 0, 9, 2},
                {0, 0, 0, 0, 7, 0, 0, 0, 1},
                {1, 0, 0, 0, 0, 8, 0, 7, 0},
                {0, 0, 8, 0, 2, 0, 1, 0, 0},
                {0, 9, 0, 1, 0, 0, 0, 0, 8},
                {7, 0, 0, 0, 3, 0, 0, 0, 0},
                {5, 1, 0, 8, 4, 0, 0, 0, 0},
                {0, 6, 4, 0, 0, 0, 0, 0, 0},
            };

            var problem = new SudokuBoard(board);
            var sudokuSolver = new SudokuSolver();

            var isSolvable = sudokuSolver.TrySolve(problem, out var solution);

            Console.WriteLine(isSolvable
                ? $"Found solution: {solution}"
                : $"Unfound solution for problem: {problem}");

            Console.WriteLine("Press any key to exit program!");
            Console.ReadKey();
        }
    }
}
