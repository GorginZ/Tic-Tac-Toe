using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text;

namespace Tic_Tac_Toe
{
  public class Coords
  {
    // [RegularExpression("/[0-9]{1,2}([,.][0-9]{1,2})?$/", ErrorMessage = "Your coordinatest must be within 0-2 range")]
    [MaxLength(3, ErrorMessage = "You need to enter two coordinates delimited by a commar eg 0,1")]
    [MinLength(3, ErrorMessage = "You need to enter two coordinates delimited by a commar eg 0,1")]
    [Required(ErrorMessage = "You must enter two coordinates, eg: 0,1")]
    public string XY { get; set; }


    [Required(ErrorMessage = "You must enter two coordinates")]
    public int X { get; set; }

    [Required(ErrorMessage = "You must enter two coordinates")]
    public int Y { get; set; }

    // private List<string> OccupiedCoords { get; set; }


    // public StringBuilder OccupiedCoords { get; set; }

    // public static Coords CoordsCheck(Coords coords)
    // {

    //   var occupiedCoords = new StringBuilder();
    //   coords.OccupiedCoords.Append(coords.XY);
    //   return new Coords { OccupiedCoords = occupiedCoords };
    // }




    //    public static Coords()
    // {
    //   Console.WriteLine("Enter your coordinates:");
    //   var input = Console.ReadLine();
    //   return new  Coords { OccupiedCoords.Add(input) };
    // }

    // public static Coords CoordsCheck(coordsXY) {
    //   if (OccupiedCoords.Contains(coordsXY))
    //   {

    //   }
    // }

    public static Coords CoordsInput()
    {
      Console.WriteLine("Enter your coordinates:");
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