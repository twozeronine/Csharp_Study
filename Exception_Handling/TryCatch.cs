using System;

class MainApp
{
  static void Main(string[] args)
  {
    int[] arr = { 1, 2, 3 };

    try
    {
      for (int i = 0; i < 5; i++)
        Console.WriteLine(arr[i]); // i가 3이되면 IndexOutOfRangeException 객체가 던져지고, catch 블록이 이를 받아낸다.

    }
    catch (IndexOutOfRangeException e)
    {
      Console.WriteLine($"예외가 발생했습니다! : {e.Message}");
    }

    Console.WriteLine("종료");
  }
}

/*실행 결과
1
2
3
예외가 발생했습니다! : Index was outside the bounds of the array.
종료
   */