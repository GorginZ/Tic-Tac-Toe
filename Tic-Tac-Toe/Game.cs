using System.Collections.Generic;
using System;

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


    public Game(Player playerOne, Player playerTwo)
    {
      Turns = 0;
      Board = new Board();
      PlayerOne = playerOne;
      PlayerTwo = playerTwo;
    }

  }
}