﻿using System;

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

    public static Point create(double x, double y)
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

    public Point sub(Point p)
    {
      return create(x - p.x, y - p.y);
    }

    public Point norm()
    {
      var mag = this.mag();
      return create(x / mag, y / mag);
    }

    public double dot(Point p)
    {
      return x * p.x + y * p.y;
    }

    public double mag()
    {
      return dist(create(0, 0));
    }

    public string print()
    {
      return $"({x}, {y})";
    }
  }
}
