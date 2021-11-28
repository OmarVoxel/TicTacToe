using System.Collections.Generic;
using TicTacToe;
using Xunit;

namespace TicTacToeTests
{
    public class Tests
    {
        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { new List<Coordinate> { new Coordinate(0,0), new Coordinate(1,1), new Coordinate(2,2) } },
                new object[] { new List<Coordinate> { new Coordinate(0,2), new Coordinate(1,2), new Coordinate(2,2) } },
                new object[] { new List<Coordinate> { new Coordinate(0,1), new Coordinate(1,1), new Coordinate(2,1) } },
                new object[] { new List<Coordinate> { new Coordinate(0,2), new Coordinate(1,1), new Coordinate(2,0) } },
            };

        [Theory]
        [MemberData(nameof(Data))]
        public void CheckIfPlayerWinWithTheseCords(List<Coordinate> cordsList)
        {
            Player player = new Player(
                new Token('O')
            );

            foreach(Coordinate cord in cordsList)
                player.PutTokenAt(cord);

            Assert.True(player.CheckIfPlayerWon());
        }
    }
}