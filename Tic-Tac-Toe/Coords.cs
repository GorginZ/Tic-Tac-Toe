using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe
{
  public class Coords
  { 
    //this now only checks that the format is right, I also need to make sure the RANGE isn't exceeding the size of indexes
    [RegularExpression("[0-9],[0-9]", ErrorMessage = "You must enter in this format X,Y ")]
    [MaxLength(3, ErrorMessage = "You need to enter two coordinates delimited by a commar eg 0,1")]
    [MinLength(3, ErrorMessage = "You need to enter two coordinates delimited by a commar eg 0,1")]
    [Required(ErrorMessage = "You must enter two coordinates, eg: 0,1")]
    public string XY { get; set; }


    [Required(ErrorMessage = "You must enter two coordinates")]
    public int X { get; set; }

    [Required(ErrorMessage = "You must enter two coordinates")]
    public int Y { get; set; }

    public static Coords CoordsInput(string currentPlayer)
    {
      Console.WriteLine($"Enter your coordinates {currentPlayer}:");
      var input = Console.ReadLine();
      return new Coords { XY = input };
    }

    public static Coords TakeCoords(string coordsStringXY)
    {
      var coords = coordsStringXY.Split(",");
      int indexOne = int.Parse(coords[0]);
      int indexTwo = int.Parse(coords[1]);

      //append
      return new Coords { X = indexOne, Y = indexTwo };
    }

  }
}