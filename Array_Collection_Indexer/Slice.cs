using System;

class MainApp
{
  static void PrintArray(System.Array array)
  {
    foreach (var e in array)
    {
      Console.Write(e);
    }
    Console.WriteLine();
  }

  static void Main(string[] args)
  {
    char[] array = new char['Z' - 'A' + 1]; // 'Z' ASCII 90 , 'A' ASCII 65 , 90-65+1 = 26 
    for (int i = 0; i < array.Length; i++)
    {
      array[i] = (char)('A' + i);
    }
    PrintArray(array[..]); // 0번째부터 마지막까지
    PrintArray(array[5..]); // 5번째부터 마지막까지

    Range range_5_10 = 5..10;
    PrintArray(array[range_5_10]); // 5번째부터 9(10-1)번째까지

    // Range를 생성할 때 리터럴과 Index 객체를 함께 사용할 수 있음.
    Index last = ^0;
    Range range_5_last = 5..last;
    PrintArray(array[range_5_last]); // 5번째부터 끝(^)까지

    PrintArray(array[^4..^1]); // 끝에서 4번째부터 끝(^)에서 2번째까지
  }
}

/*
    ABCDEFGHIJKLMNOPQRSTUVWXYZ
    FGHIJKLMNOPQRSTUVWXYZ
    FGHIJ
    FGHIJKLMNOPQRSTUVWXYZ
    WXY
*/