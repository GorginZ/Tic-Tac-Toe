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
          //act
          var aBoard = board.BuildBoard();
          //assert
          var expectedBoard = "..." + "\n"
                            + "..." + "\n" 
                            + "...";
                            
           Assert.Equal(expectedBoard, $"{aBoard[0][0]}{aBoard[0][1]}{aBoard[0][2]}\n{aBoard[1][0]}{aBoard[1][1]}{aBoard[1][2]}\n{aBoard[2][0]}{aBoard[2][1]}{aBoard[2][2]}"); 
          
        }

        [Fact]
        public void SetName()
        { //arrange
          var testPlayer = new Player();
          //act
          //how ot test this one when the consolereadline is in the function in the class?
          testPlayer.Name = testPlayer.GetName();
          //assert
          var expectedName = "Name";
                            
           Assert.Equal(expectedName, $"{testPlayer.Name}"); 
          
        }  
//          [Fact]
//         public void Game()
//         { //arrange
//           var testGame = new Game();
//           //act
//           //how ot test this one when the consolereadline is in the function in the class?
// testGame.Status = testGame.GameStatus();          //assert
//           var expectedStatus = "draw";
                            
//            Assert.Equal(expectedName, $"{testPlayer.Name}"); 
          
//         }  
//  [Fact]
//         public void ValidateName()
//         { //arrange
//           var testPlayer = new Player();
//           //act
//           var testPlayer.Validate(null);
//           //assert
//           var expectedName = "Name";
                            
//            Assert.Equal(expectedName, testPlayer.Name); 
          
//         }  

    }
}
