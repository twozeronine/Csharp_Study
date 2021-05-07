using System;

class MainApp
{
  static int Divide(int dividend, int divisor)
  {
    try
    {
      Console.WriteLine("Divide() 시작");
      return dividend / divisor;
    }
    catch (DivideByZeroException e)
    {
      Console.WriteLine("Divide() 예외 발생");
      throw e;
    }
    finally
    {
      Console.WriteLine("Divide() 끝");
    }
  }
  static void Main(string[] args)
  {
    try
    {
      Console.Write("제수를 입력하세요. :");
      String temp = Console.ReadLine();
      int dividend = Convert.ToInt32(temp);

      Console.Write("피제수를 입력하세요. :");
      temp = Console.ReadLine();
      int divisor = Convert.ToInt32(temp);

      Console.WriteLine("{0}/{1} = {2}", dividend, divisor, Divide(dividend, divisor));
    }
    catch (FormatException e)
    {
      Console.WriteLine($"예외가 발생했습니다! : {e.Message}");
    }
    catch (DivideByZeroException e)
    {
      Console.WriteLine($"예외가 발생했습니다! : {e.Message}");
    }
    finally
    {
      Console.WriteLine("프로그램을 종료합니다.");
    }
  }
}

/*실행 결과

제수를 입력하세요. :40
피제수를 입력하세요. :십일
예외가 발생했습니다! : Input string was not in a correct format.
프로그램을 종료합니다.

PS > dotnet run
제수를 입력하세요. :7
피제수를 입력하세요. :0
Divide() 시작
Divide() 예외 발생
Divide() 끝
예외가 발생했습니다! : Attempted to divide by zero.
프로그램을 종료합니다.
   */