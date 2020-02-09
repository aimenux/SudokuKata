namespace Lib.Board
{
    public interface ISudokuBoard
    {
        int Size { get; }
        ISudokuBoard Clone();
        int this[int row, int column] { get; set; }
    }
}