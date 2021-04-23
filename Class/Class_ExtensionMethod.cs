using System;

namespace MyExtension
{
  public static class IntegerExtension
  {
    public static int Square(this int myInt)
    {
      return myInt * myInt;
    }

    public static int Power(this int myInt, int exponent)
    {
      int result = myInt;
      for (int i = 1; i < exponent; i++)
        result = result * myInt;

      return result;
    }

    public static string Append(this string myString, string addString) => myString + addString;
  }
}