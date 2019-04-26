using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadrangleApp
{
  class Program
  {
    static void Main(string[] args)
    {
      Point[] pointsOne = { Point.create(0, 1), Point.create(2, 0), Point.create(0, -1), Point.create(-2, 0) };
      Point[] pointsTwo = { Point.create(0, 1), Point.create(1, 0), Point.create(0, -1), Point.create(-1, 0) };
      Point[] pointsThree = { Point.create(0, 1), Point.create(0, 3), Point.create(5, 0), Point.create(-1, 0) };
      var pointSets = new[]{ pointsOne, pointsTwo, pointsThree };
      foreach (var pointSet in pointSets)
      {
        var quadrangle = Quadrangle.create(pointSet);
        Console.WriteLine(quadrangle.toString());
        if (quadrangle.isTrapezoid())
          Console.WriteLine("Is Trapezoid");
        if (quadrangle.isRectangle())
          Console.WriteLine("Is Rectangle");
        if (quadrangle.isSquare())
          Console.WriteLine("Is Square");
        if (quadrangle.isParallelogram())
          Console.WriteLine("Is Parallelogram");
        if (quadrangle.isRhombus())
          Console.WriteLine("Is Rhombus");
      }
      Console.ReadKey();
    }
  }
}
