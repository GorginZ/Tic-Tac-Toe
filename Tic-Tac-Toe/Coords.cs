using System;
using System.ComponentModel.DataAnnotations;


namespace Tic_Tac_Toe
{
  public class Coords
  {
     [Required(ErrorMessage = "You must enter two coordinates")]
    public int X { get; set; }

     [Required(ErrorMessage = "You must enter two coordinates")]
    public int Y { get; set; }


  

    public static Coords TakeCoords()
    { Console.WriteLine("Enter your coordinates:");
      var input = Console.ReadLine();
      var coords = input.Split(",");
      int indexOne = int.Parse(coords[0]);
      int indexTwo = int.Parse(coords[1]);

      


      return new Coords { X = indexOne, Y = indexTwo };
    }


  }
}