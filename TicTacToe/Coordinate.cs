using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{
    public struct Coordinate
    {
        public readonly int Column;
        public readonly int Row;

        public Coordinate(int x, int y)
            => (Column, Row) = (x, y);
    }
    
    public class CoordinateCollection
    {
        private readonly List<Coordinate> collection = new();
        
        public void AddRange(IEnumerable<Coordinate> cords)
            => collection.AddRange(cords);
        
        public void Add(Coordinate cords)
            => collection.Add(cords);
        
        public int Sum(int[,] magicSquare)
            => collection.Sum(cord => magicSquare[cord.Column, cord.Row]);
    }
}