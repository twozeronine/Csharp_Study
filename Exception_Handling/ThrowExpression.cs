using System;

class MainApp
{

  static void Main(string[] args)
  {
    try
    {
      int? a = null;
      int b = a ?? throw new ArgumentNullException();
    }
    catch (ArgumentNullException e)
    {
      Console.WriteLine($"예외가 발생했습니다! : {e.Message}");
    }

    try
    {
      int[] array = new[] { 1, 2, 3 };
      int index = 4;
      //index가 0보다 크고 3보다 작으면 index값을 넣고 그렇지 않으면 예외 던지기
      int value = array[
        index >= 0 && index < 3 ? index : throw new IndexOutOfRangeException()
      ];
    }
    catch (IndexOutOfRangeException e)
    {
      Console.WriteLine($"예외가 발생했습니다! : {e.Message}");
    }

  }
}

/*실행 결과
예외가 발생했습니다! : Value cannot be null.
예외가 발생했습니다! : Index was outside the bounds of the array.
   */