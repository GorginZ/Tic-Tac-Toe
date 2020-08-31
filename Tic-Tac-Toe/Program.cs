using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Tic_Tac_Toe
{
  class Program
  {
    static void Main(string[] args)
    {
      var playerOne = new Player(Player.GetName(), "O");
      var context = new ValidationContext(playerOne);
      playerOne.Name = Validate(playerOne.Name, "Name", context);
      var playerTwo = new Player(Player.GetName(), "X");
      playerTwo.Name = Validate(playerTwo.Name, "Name", context);

      Console.WriteLine("How do you want to play? enter dimensions");
      //change to enums selection list
      var dimensions = int.Parse(Console.ReadLine());


      var testGame = new Game(playerOne, playerTwo, dimensions);
            Console.WriteLine($"\n\n{playerOne.Name} VS {playerTwo.Name}\n\n{playerOne.Name} Enter your coordinate eg: 0,0\n");

      testGame.Board.PrintBoard();
//while needs to be changed to be whatever board dimension possible turns are
      while (testGame.Turns < (dimensions * dimensions))
      {
        var coordsResult = new List<ValidationResult>();
        var coordsXY = Coords.CoordsInput();
        var coordsContext = new ValidationContext(coordsXY);

        coordsXY.XY = Validate(coordsXY.XY, "XY", coordsContext);
        var validTurn = testGame.Board.Move(Coords.TakeCoords(coordsXY.XY), testGame.CurrentPlayer.Symbol);
        if (validTurn == true)
        {
          testGame.Board.PrintBoard();
          var checkWin = testGame.Board.Win(testGame.CurrentPlayer.Symbol);
          if (checkWin == true)
          {
            Console.WriteLine($"The {testGame.CurrentPlayer.Symbol}'s have won!");
            break;

          }

          testGame.Turns++;




        }
      }
      Console.WriteLine("What a game");
    }


    public static string Validate(string value, string propertyName, ValidationContext context)
    {
      context.MemberName = propertyName;

      var result = new List<ValidationResult>();
      var isValidProp = Validator.TryValidateProperty(value, context, result);

      while (!isValidProp)
      {
        foreach (var validation in result)
        {
          Console.WriteLine(validation.ErrorMessage);
        }

        Console.WriteLine("Please enter a valid entry for this field");

        value = Console.ReadLine();
        result = new List<ValidationResult>();
        isValidProp = Validator.TryValidateProperty(value, context, result);
      }
      Console.WriteLine($"OK..{value}");

      return value;
    }
  }
}
