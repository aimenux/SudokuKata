using System;
using FluentAssertions;
using Lib.Board;
using NUnit.Framework;

namespace UnitTests
{
    public class SudokuBoardTests
    {
        [Test]
        public void When_Board_Size_Is_Invalid_Then_Should_Throw_Argument_Exception()
        {
            // arrange
            var board = new[,]
            {
                {1, 2}, {2, 3}
            };

            // act
            SudokuBoard sudokuBoard = null;
            Action createSudokuBoard = () =>
            {
                sudokuBoard = new SudokuBoard(board);
            };

            // assert
            createSudokuBoard.Should().Throw<ArgumentException>();
            sudokuBoard.Should().BeNull();
        }

        [Test]
        public void When_Board_Items_Are_Invalid_Then_Should_Throw_Argument_Exception()
        {
            // arrange
            var board = new[,]
            {
                {-1, 2, 3, 4, 5, 6, 7, 8, 9},
                {-1, 2, 3, 4, 5, 6, 7, 8, 9},
                {-1, 2, 3, 4, 5, 6, 7, 8, 9},
                {-1, 2, 3, 4, 5, 6, 7, 8, 9},
                {-1, 2, 3, 4, 5, 6, 7, 8, 9},
                {-1, 2, 3, 4, 5, 6, 7, 8, 9},
                {-1, 2, 3, 4, 5, 6, 7, 8, 9},
                {-1, 2, 3, 4, 5, 6, 7, 8, 9},
                {-1, 2, 3, 4, 5, 6, 7, 8, 9},
            };

            // act
            SudokuBoard sudokuBoard = null;
            Action createSudokuBoard = () =>
            {
                sudokuBoard = new SudokuBoard(board);
            };

            // assert
            createSudokuBoard.Should().Throw<ArgumentException>();
            sudokuBoard.Should().BeNull();
        }

        
        [Test]
        public void When_Board_Is_Valid_Then_Should_Create_Instance()
        {
            // arrange
            var board = new[,]
            {
                {1, 2, 3, 4, 5, 6, 7, 8, 9},
                {1, 2, 3, 4, 5, 6, 7, 8, 9},
                {1, 2, 3, 4, 5, 6, 7, 8, 9},
                {1, 2, 3, 4, 5, 6, 7, 8, 9},
                {1, 2, 3, 4, 5, 6, 7, 8, 9},
                {1, 2, 3, 4, 5, 6, 7, 8, 9},
                {1, 2, 3, 4, 5, 6, 7, 8, 9},
                {1, 2, 3, 4, 5, 6, 7, 8, 9},
                {1, 2, 3, 4, 5, 6, 7, 8, 9},
            };

            // act
            SudokuBoard sudokuBoard = null;
            Action createSudokuBoard = () =>
            {
                sudokuBoard = new SudokuBoard(board);
            };

            // assert
            createSudokuBoard.Should().NotThrow<Exception>();
            sudokuBoard.Should().NotBeNull();
        }

        [TestCase(0,0,1)]
        [TestCase(1,1,2)]
        [TestCase(2,2,3)]
        [TestCase(3,3,4)]
        [TestCase(4,4,5)]
        public void When_Board_Is_Valid_Then_Should_Get_Any_Cell(int row, int column, int value)
        {
            // arrange
            var board = new[,]
            {
                {1, 2, 3, 4, 5, 6, 7, 8, 9},
                {1, 2, 3, 4, 5, 6, 7, 8, 9},
                {1, 2, 3, 4, 5, 6, 7, 8, 9},
                {1, 2, 3, 4, 5, 6, 7, 8, 9},
                {1, 2, 3, 4, 5, 6, 7, 8, 9},
                {1, 2, 3, 4, 5, 6, 7, 8, 9},
                {1, 2, 3, 4, 5, 6, 7, 8, 9},
                {1, 2, 3, 4, 5, 6, 7, 8, 9},
                {1, 2, 3, 4, 5, 6, 7, 8, 9},
            };
            var sudokuBoard = new SudokuBoard(board);

            // act
            var cell = sudokuBoard[row, column];

            // assert
            cell.Should().Be(value);
        }

        [TestCase(0,0,0)]
        [TestCase(1,1,0)]
        [TestCase(2,2,0)]
        [TestCase(3,3,0)]
        [TestCase(4,4,0)]
        public void When_Board_Is_Valid_Then_Should_Set_Any_Cell(int row, int column, int value)
        {
            // arrange
            var board = new[,]
            {
                {1, 2, 3, 4, 5, 6, 7, 8, 9},
                {1, 2, 3, 4, 5, 6, 7, 8, 9},
                {1, 2, 3, 4, 5, 6, 7, 8, 9},
                {1, 2, 3, 4, 5, 6, 7, 8, 9},
                {1, 2, 3, 4, 5, 6, 7, 8, 9},
                {1, 2, 3, 4, 5, 6, 7, 8, 9},
                {1, 2, 3, 4, 5, 6, 7, 8, 9},
                {1, 2, 3, 4, 5, 6, 7, 8, 9},
                {1, 2, 3, 4, 5, 6, 7, 8, 9},
            };
            var sudokuBoard = new SudokuBoard(board);

            // act
            sudokuBoard[row, column] = value;

            // assert
            sudokuBoard[row, column].Should().Be(value);
        }
    }
}