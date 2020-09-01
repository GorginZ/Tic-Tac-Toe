using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;



namespace Tic_Tac_Toe
{
  public class Game
  {
    public int Turns { get; set; }
    public Player CurrentPlayer
    {
      get
      {
        if (Turns % 2 > 0)
        {
          return PlayerTwo;
        }
        else
        {
          return PlayerOne;
        }
      }
    }


    public Player PlayerOne { get; }

    public Player PlayerTwo { get; }


    public Board Board { get; }

    public static int GetDimensions()
    {

      Console.WriteLine("How do you want to play? for 3x3 board put: 3 ");
      var stringDimensions = Console.ReadLine();
      bool isValid = ValidDimensions(stringDimensions);
      while (!isValid)
      {
        Console.WriteLine("enter a number b/w 3 and 10 for board dimensions, or enter for 3x3");
        stringDimensions = Console.ReadLine();
        isValid = ValidDimensions(stringDimensions);
      }
        int.TryParse(stringDimensions, out int dimensions);
        return dimensions;
    }


    public static bool ValidDimensions(string stringDimensions)
    {

      if (int.TryParse(stringDimensions, out int useDimensions) && useDimensions >= 3 && useDimensions < 10)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public Game(Player playerOne, Player playerTwo, int dimensions)
    {
      Turns = 0;
      Board = new Board(dimensions);
      PlayerOne = playerOne;
      PlayerTwo = playerTwo;

    }

    public static void Run()
    {
      var playerOne = new Player(Player.GetName(), "O");
      var context = new ValidationContext(playerOne);
      playerOne.Name = Validate(playerOne.Name, "Name", context);
      var playerTwo = new Player(Player.GetName(), "X");
      playerTwo.Name = Validate(playerTwo.Name, "Name", context);


      var dimensions = Game.GetDimensions();


      var testGame = new Game(playerOne, playerTwo, dimensions);

      // var gameContext = new ValidationContext(testGame);
      // dimensions = Validate(testGame.Dimensions, "Dimensions", gameContext);



      testGame.Board.PrintBoard();
      while (testGame.Turns < dimensions * dimensions)
      {
        var coordsResult = new List<ValidationResult>();
        var coordsXY = Coords.CoordsInput(testGame.CurrentPlayer.Name);
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