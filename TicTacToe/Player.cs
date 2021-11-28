namespace TicTacToe
{
    public struct Token
    {
        public readonly char Selected;

        public Token(char token)
            => Selected = token;
    }
    
    public class Player
    {
        private readonly Matrix _matrix;
        
        public Player(Token token)
            => _matrix = new Matrix(3, 3, token.Selected);
        
        public void PutTokenAt(Coordinate coordinate)
            => _matrix.SetToken(coordinate);

        public bool CheckIfPlayerWon()
            => _matrix.CheckRow() ||
               _matrix.CheckColumn() ||
               _matrix.CheckSlashDiagonal() ||
               _matrix.CheckBackSlashDiagonal();
    }
}