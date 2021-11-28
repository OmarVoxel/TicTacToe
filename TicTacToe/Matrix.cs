using System.Linq;

namespace TicTacToe
{
    public class Matrix
    {
        private const char initValue = '.';
        private readonly int columns;
        private readonly int rows;
        private readonly char[,] value;
        private readonly char token;
        private Coordinate lastMove;
        
        public Matrix(int n, int m, char selectedToken)
        {
            (columns, rows, token) = (n, m, selectedToken);
            value = new char[columns, rows];

            Initialize();
        }


        private void Initialize()
        {
            for (int column = 0; column < columns; column++)
                for (int row = 0; row < rows; row++)
                    value[column, row] = initValue;
        }
        
        
        public void SetToken(Coordinate coords)
        {
            if (value[coords.Column, coords.Row] != initValue) return;
            value[coords.Column, coords.Row] = token;
            lastMove = coords;
        }
        
        // https://en.wikipedia.org/wiki/Magic_square
        private static readonly int[,] magicSquare = new int[3, 3]
        {
            { 2, 7, 6 },
            { 9, 5, 1 },
            { 4, 3, 8 }
        };

        private bool HasWinner(CoordinateCollection listCord)
            => listCord.Sum(magicSquare) == 15;
        
        public bool CheckRow()
        {
            var rowCordList = new CoordinateCollection();
            rowCordList.AddRange(Enumerable.Range(0, columns)
                .Where(column => value[column, lastMove.Row] == token)
                .Select(column => new Coordinate(column, lastMove.Row)));

            return HasWinner(rowCordList);
        }
        
        public bool CheckColumn()
        {
            var columnsCordList = new CoordinateCollection();
            columnsCordList.AddRange(Enumerable.Range(0, rows)
                .Where(row => value[lastMove.Column, row] == token)
                .Select(row => new Coordinate(lastMove.Column, row)));

            return HasWinner(columnsCordList);
        }
        
        public bool CheckBackSlashDiagonal()
        {
            CoordinateCollection backSlashCordsList = new CoordinateCollection();
            for (int i = 0; i < columns; i++)
                if (value[i, i] == token)
                    backSlashCordsList.Add(new Coordinate(i, i));

            return HasWinner(backSlashCordsList);
        }

        public bool CheckSlashDiagonal()
        {
            CoordinateCollection slashCordsList = new CoordinateCollection();
            for (int x = 0, y = rows - 1; x < columns; x++, y--)
                if (value[x, y] == token)
                    slashCordsList.Add(new Coordinate(x, y));

            return HasWinner(slashCordsList);
        }
    }
}   