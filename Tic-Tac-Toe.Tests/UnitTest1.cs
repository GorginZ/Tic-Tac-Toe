using System;
using Xunit;

namespace Tic_Tac_Toe.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void PrintBoard()
        { //arrange
          var board = new Board();
          var aBoard = board.PrintBoard();
          //act
          // var aBoard = board.GetBoard();
          //assert
          var expectedBoard = "..." + "\n"
                            + "..." + "\n" 
                            + "...";
                            
           Assert.Equal(expectedBoard, aBoard); 
          
        }
    }
}
