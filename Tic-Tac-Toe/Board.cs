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

    //winning cords 
    //diagonal a
    // 0,0 1,1 2,2

    //diagonal b
    //0,2 1,1 0,2

    //horizontal 0
    //0,0 0,1 0,2

    //horizontal 1
    // 1,0, 1,1 1,2

    //horizontal 2
    //2,0 2,1 2,2

    // vertical 0
    //0,0 1,0, 2,0

    //vertical 1
    //0,1 1,1 2,1

    //vertical 2
    //0,2 1,2 2,2

    // public bool Win(string symbol) {
    //   if (_board[0][0] == symbol && _board[1][1] == symbol && _board[2][2] == symbol) 
    //   {
    //     // Console.WriteLine($"The {symbol}s have won this one!");
    //    return true;}
    // else {
    //   return false;
    // }
    // }



    private bool Tripple(List<string> sequence, string symbol)
    {
     int count = 0;
         foreach (string element in sequence)
      {
        if (element.Equals(symbol))
          count++;
      }
      if (count == 3)
      {return true;}
      else {
        return false;
      }
      
     
    }


    public bool Win(string symbol)
    {
      var sequence = new List<string>();

      // diagonal \
      for (var x = 0; x < _board.Count; x++)
        if (_board[x][x] != ".")
        {
          sequence.Add(_board[x][x]);

        }

      foreach (string element in sequence)
      {
        Console.WriteLine(element);

      }
     return       Tripple(sequence, symbol);


    }




    public bool Move(Coords coords, string symbol)
    {
      if (_board[coords.X][coords.Y] == ".")
      {
        _board[coords.X][coords.Y] = symbol;
        return true;

      }
      else
      {

        Console.WriteLine("That's an occupied coordiante!");
        return false;
      }

    }

  }
}