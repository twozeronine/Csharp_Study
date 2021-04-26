using System;

// Interface.cs 의 인터페이스 ILogger를 상속함
interface IFormattableLogger : ILogger
{
  void WriteLog(string format, params object[] args);
}

// IFormattableLogger를 상속함.
class ConsoleLogger2 : IFormattableLogger
{
  public void WriteLog(string message)
  {
    Console.WriteLine("{0} {1}", DateTime.Now.ToLocalTime(), message);
  }

  public void WriteLog(string format, params Object[] args)
  {
    String message = String.Format(format, args);
    Console.WriteLine("{0} {1}", DateTime.Now.ToLocalTime(), message);
  }
}

// class MainApp
// {
//   static void Main(string[] args)
//   {
//     IFormattableLogger logger = new ConsoleLogger2();
//     logger.WriteLog("The world is not flat");
//     logger.WriteLog("{0} + {1} = {2}", "1", 1, 2);
//   }
// }