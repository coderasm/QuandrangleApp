namespace QuadrangleApp
{
  class Quadrangle
  {
    private Point[] vertices = { };
    private Quadrangle(Point[] vertices)
    {
      if (vertices.Length == 4)
        this.vertices = vertices;
    }

    public Quadrangle create(Point[] vertices)
    {
      return new Quadrangle(vertices);
    }

    public bool isTrapezoid()
    {

    }

    public bool isRectangle()
    {

    }

    public bool isSquare()
    {

    }

    public bool isParallelogram()
    {

    }
  }
}
