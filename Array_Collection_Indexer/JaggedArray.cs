using System;

class MainApp
{
  static void Main(string[] args)
  {
    int[][] jagged = new int[3][];
    jagged[0] = new int[5] { 1, 2, 3, 4, 5 };
    jagged[1] = new int[] { 10, 20, 30 };
    jagged[2] = new int[] { 100, 200 };

    foreach (int[] arr in jagged)
    {
      Console.WriteLine($"Length : {arr.Length}");
      foreach (int e in arr)
      {
        Console.WriteLine($"{e}");
      }
      Console.WriteLine("");
    }

    int[][] jagged2 = new int[2][] { new int[] { 1000, 2000 }, new int[4] { 6, 7, 8, 9 } };

    foreach (int[] arr in jagged2)
    {
      Console.WriteLine($"Length : {arr.Length}, ");
      foreach (int e in arr)
      {
        Console.WriteLine($"{e}");
      }
      Console.WriteLine();
    }
  }
}

/*실행 결과 
Length : 5, 1 2 3 4 5 
Length : 3, 10 20 30
Length : 2, 100 200

Length : 2, 1000 2000
Length : 4, 6 7 8 9
*/