using System;

class MainApp
{
  static void DoSomething(int arg)
  {
    if (arg < 10)
      Console.WriteLine($"arg : {arg}");
    else
      throw new Exception("arg가 10보다 큽니다.");
  }
  static void Main(string[] args)
  {
    try
    {
      DoSomething(1);
      DoSomething(3);
      DoSomething(5);
      DoSomething(9);
      DoSomething(11);
      DoSomething(13); //위에 행에서 예외가 발생하여 현행의 코드는 실행되지 않음.
    }
    catch (Exception e)
    {
      Console.WriteLine($"예외가 발생했습니다! : {e.Message}");
    }
  }
}

/*실행 결과
arg : 1
arg : 3
arg : 5
arg : 9
예외가 발생했습니다! : arg가 10보다 큽니다.
   */