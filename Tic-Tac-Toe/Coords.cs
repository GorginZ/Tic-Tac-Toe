using System;

namespace Tic_Tac_Toe
{
  public class Coords
  {
    public int X { get; set; }
    public int Y { get; set; }


    public static Coords TakeCoords()
    {
      var input = Console.ReadLine();
      var coords = input.Split(",");
      int indexOne = int.Parse(coords[0]);
      int indexTwo = int.Parse(coords[1]);

      return new Coords { X = indexOne, Y = indexTwo };
    }


  }
}