using System;

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



class MainApp
{
  static void Main(string[] args)
  {
    Console.WriteLine($"3^2 : {3.Square()}");
    Console.WriteLine($"3^4 : {3.Power(4)}");
    Console.WriteLine($"2^10 : {2.Power(10)}");
    Console.WriteLine("Hello".Append(",World!"));
  }
}

/*실행 결과
  3^2 : 9
  3^4 : 81
  2^10 : 1024
  Hello,World!
*/