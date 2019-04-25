using System;

namespace QuadrangleApp
{
  class Point
  {
    private double x = 0;
    private double y = 0;
    private Point(double x, double y)
    {
      this.x = x;
      this.y = y;
    }

    public Point create(double x, double y)
    {
      return new Point(x, y);
    }

    public void setPoint(double x, double y)
    {
      this.x = x;
      this.y = y;
    }

    public double dist(Point p)  // compute the distance of point p to the current point
    {
      double distance;
      distance = Math.Sqrt((x - p.x) * (x - p.x) + (y - p.y) * (y - p.y));
      return distance;
    }
    public void print()
    {
      Console.Write("Point: ({0}, {1})", x, y);
    }
  }
}
