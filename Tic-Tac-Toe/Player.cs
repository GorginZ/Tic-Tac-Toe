using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace Tic_Tac_Toe
{
  public class Player
  {
    [Required(ErrorMessage = "You must enter your name to enter the hall of fame")]
    public string Name { get; set; }
    // public int Score { get; set; }


    public string GetName()
    {
      Console.WriteLine("Tic-Tac-Toer, please enter your name");
      var input = Console.ReadLine();
      return input;
    
    }
  }

}