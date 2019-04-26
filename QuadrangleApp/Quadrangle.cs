using System;

namespace QuadrangleApp
{
  class Quadrangle
  {
    private Point[] vertices = { };
    private double[] sides = new double[4];
    private double[] angles = new double[4];
    private Quadrangle(Point[] vertices)
    {
      if (vertices.Length == 4)
      {
        this.vertices = vertices;
        setSides();
        setAngles();
      }
    }

    private void setSides()
    {
      if(vertices.Length == 4)
      {
        for (int i = 0; i < sides.Length; i++)
        {
          if(i == 3)
            sides[i] = vertices[i].dist(vertices[0]);
          sides[i] = vertices[i].dist(vertices[(i + 1) % vertices.Length]);
        }
      }
    }

    private void setAngles()
    {
      if (vertices.Length == 4)
      {
        for (int i = 0; i < angles.Length; i++)
        {
          //move vertice to (0,0) origin
          //subtract from vertice/origin
          var pointAfter = (i + 1) % angles.Length;
          var pointBefore = (i - 1) < 0 ? angles.Length - 1 : i - 1;
          var diffedPointOne = vertices[pointAfter].sub(vertices[i]);
          var diffedPointTwo = vertices[pointBefore].sub(vertices[i]);
          //normalize
          var vectorOne = diffedPointOne.norm();
          var vectorTwo = diffedPointTwo.norm();
          //cosTheta
          var cosTheta = vectorOne.dot(vectorTwo) / (vectorOne.mag() * vectorTwo.mag());
          angles[i] = Math.Acos(cosTheta);
        }
      }
    }

    public static Quadrangle create(Point[] vertices)
    {
      return new Quadrangle(vertices);
    }

    public bool isTrapezoid()
    {
      //At least one pair of opposite sides are parallel
      var trapPropOne = Math.Sin(angles[0]) * Math.Sin(angles[2]) == Math.Sin(angles[1]) * Math.Sin(angles[3]);
      var trapPropTwo = (Math.Cos(angles[0]) + Math.Cos(angles[1]) == 0 && Math.Cos(angles[2]) + Math.Cos(angles[3]) == 0)
                     || (Math.Cos(angles[0]) + Math.Cos(angles[3]) == 0 && Math.Cos(angles[1]) + Math.Cos(angles[2]) == 0);
      return trapPropOne || trapPropTwo;
    }

    public bool isRectangle()
    {
      var oppositeSidesEqual = sides[0] == sides[2] && sides[1] == sides[3];
      var sidesNotAllEqual = sides[0] != sides[1];
      var allAnglesEqual = angles[0] == angles[1] && angles[0] == angles[2] && angles[0] == angles[3];
      return oppositeSidesEqual && sidesNotAllEqual && allAnglesEqual;

    }

    public bool isSquare()
    {
      var allAnglesEqual = angles[0] == angles[1] && angles[0] == angles[2] && angles[0] == angles[3];
      var allSidesEqual = sides[0] == sides[1] && sides[0] == sides[2] && sides[0] == sides[3];
      return allAnglesEqual && allSidesEqual;
    }

    public bool isParallelogram()
    {
      var oppositeAnglesEqual = angles[0] == angles[2] && angles[1] == angles[3];
      var oppositeSidesEqual = sides[0] == sides[2] && sides[1] == sides[3];
      var anglesNotAllEqual = angles[0] != angles[1];
      var sidesNotAllEqual = sides[0] != sides[1];
      return oppositeAnglesEqual && oppositeSidesEqual && anglesNotAllEqual && sidesNotAllEqual;
    }

    public bool isRhombus()
    {
      var oppositeAnglesEqual = angles[0] == angles[2] && angles[1] == angles[3];
      var allSidesEqual = sides[0] == sides[1] && sides[0] == sides[2] && sides[0] == sides[3];
      var anglesNotAllEqual = angles[0] != angles[1];
      return oppositeAnglesEqual && anglesNotAllEqual && allSidesEqual;
    }

    public double area()
    {

    }

    public string toString()
    {
      var toPrint = new string[vertices.Length];
      for (int i = 0; i < vertices.Length; i++)
      {
        toPrint[i] = vertices[i].print();
      }
      return string.Join(", ", toPrint);
    }
  }
}
