using System;

readonly struct RGBColor
{
  public readonly byte R;
  public readonly byte G;
  public readonly byte B;

  public RGBColor(byte r, byte g, byte b)
  {
    R = r;
    G = g;
    B = b;
  }
}