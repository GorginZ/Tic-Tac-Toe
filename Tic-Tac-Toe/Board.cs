using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;
using System.Text;

namespace Tic_Tac_Toe
{
  public class Board
  {

    private List<List<string>> _board = new List<List<String>>();

    public Board(int dimensions)
    {
      _board = BuildBoard(dimensions);
    }

    public List<List<string>> GetBoard()
    {
      return _board;
    }

    //build board of specified dimensions b/w 3 to 10

    public List<List<string>> BuildBoard(int dimensions)
    {
      List<List<String>> board = new List<List<String>>();

      for (var x = 0; x < dimensions; x++)
      {
        board.Add(new List<string>());
        for (var y = 0; y < dimensions; y++)
        {
          board[x].Add(".");

        }
      }
      return board;
    }

    public void PrintBoard()
    {
      foreach (List<string> row in _board)
      {
        // Console.WriteLine($"{row[0]} {row[1]} {row[2]}");
        Console.WriteLine(String.Join(" ", row));
      }
    }
    // obz way to check for wins but have abaondoned this. not sure if what i implemented is actually more efficient. IF I used enums or a dictionary (not sure if this is possible) I could use the magic square logic more efficiently I think. I think this ends up being more 'expensive' because I have to keep creating more lists instead of just looking. If I had a dictionary or enums I would be able to remove this extra layer I think?

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


    //too fiddley with list.TrueForAll, tripple was going to be my predicate function but because I need it to see two things, the symbol and teh element, I'm pretty sure TrueForAll wasn't a good choice for my use.
    private bool Tripple(List<string> sequence, string symbol)
    {
      int count = 0;
      foreach (string element in sequence)
      {
        if (element.Equals(symbol))
          count++;
      }
      return count == sequence.Count;
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

      //only want to check for wins if the sequence is as long as the dimensions 

      if (sequence.Count == _board.Count && Tripple(sequence, symbol) == true)
      {
        return true;
      }
      else
      {
        sequence.Clear();
      }




      // diagonal /


      for (int x = 0, y = _board.Count - 1;
          x < _board.Count;
          x++, y--)
      {
        sequence.Add(_board[x][y]);
      }

      if (sequence.Count == _board.Count && Tripple(sequence, symbol) == true)
      {
        return true;
      }
      else
      {
        sequence.Clear();
      }


      // rows  

      for (var x = 0; x < _board.Count; x++)
      {
        for (var y = 0; y < _board.Count; y++)
        {
          sequence.Add(_board[x][y]);
        }

        if (sequence.Count == _board.Count && Tripple(sequence, symbol) == true)
        {
          return true;
        }
        else
        {
          sequence.Clear();
        }

      }
      // cols |
      for (var x = 0; x < _board.Count; x++)
      {
        for (var y = 0; y < _board.Count; y++)
        {
          sequence.Add(_board[y][x]);
        }

        if (sequence.Count == _board.Count && Tripple(sequence, symbol) == true)
        {
          return true;
        }
        else
        {
          sequence.Clear();
        }

      }


      //otherwise return false
      return false;

    }


  
    //check coord in range
    //is this a crummy and totally wrong use of try catch? I suspect as much.
    public bool Move(Coords coords, string symbol)
    {
      try
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

      catch (System.ArgumentOutOfRangeException)
      {
        Console.WriteLine("those coordinates are outside the bounds of this universe");
        return false;

      }
    }
  }
}