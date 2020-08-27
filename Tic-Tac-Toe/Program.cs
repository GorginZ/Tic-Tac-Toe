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
      //constructor later remember.
      var playerTwo = new Player(Player.GetName(), "X");
      playerTwo.Name = Validate(playerTwo.Name, "Name", context);


      Console.WriteLine($"\n\n{playerOne.Name} VS {playerTwo.Name}\n\n{playerOne.Name} Enter your coordinate eg: 0,0\n");

      var testGame = new Game(playerOne, playerTwo);
      testGame.Board.PrintBoard();

      while (testGame.Turns < 9)
      {
        testGame.Board.Move(Coords.TakeCoords(),testGame.CurrentPlayer.Symbol);
        testGame.Board.PrintBoard();
        testGame.Turns++;

        Console.WriteLine(testGame.Turns.ToString());
      }
      Console.WriteLine("GAME OVER");
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
