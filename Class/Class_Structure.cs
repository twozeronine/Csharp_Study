using System;

struct Point3D
{
  public int X;
  public int Y;
  public int Z;

  public Point3D(int X, int Y, int Z)
  {
    this.X = X;
    this.Y = Y;
    this.Z = Z;
  }

  public override string ToString()
  {
    return string.Format($"{X}, {Y}, {Z}");
  }
}