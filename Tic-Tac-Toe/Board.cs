using System.Collections.Generic;
using System;
using System.Text;

namespace Tic_Tac_Toe
{
  public class Board
  {

    private List<List<string>> _board = new List<List<String>>();

    public Board()
    {
      _board = BuildBoard();
    }

    public List<List<string>> GetBoard()
    {
      return _board;
    }

    public List<List<string>> BuildBoard()
    {

      List<string> row0 = new List<string> { ".", ".", "." };
      List<string> row1 = new List<string> { ".", ".", "." };
      List<string> row2 = new List<string> { ".", ".", "." };

      List<List<String>> board = new List<List<String>>();
      board.Add(row0);
      board.Add(row1);
      board.Add(row2);

      return board;

    }

    public void PrintBoard()
    {
      foreach (List<string> row in _board)
      {
        Console.WriteLine($"{row[0]} {row[1]} {row[2]}");
      }
    }

    //receives Symbol from SetSymbol in program
    //if I want to test it? does this need to return something?
    public void Move(Coords coords, string symbol)
    {
     
      _board[coords.X][coords.Y] = symbol;
  
  }
  }
}