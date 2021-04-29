using System;
interface ILogger
{
  void WriteLog(string message);
}

interface IFormattableLogger : ILogger
{
  void WriteLog(string format, params object[] args);
}

// IFormattableLogger를 상속함.
class ConsoleLogger : IFormattableLogger
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

class MainApp
{
  static void Main(string[] args)
  {
    IFormattableLogger logger = new ConsoleLogger();
    logger.WriteLog("The world is not flat");
    logger.WriteLog("{0} + {1} = {2}", "1", 1, 2);
  }
}

/*실행 결과
  2021-04-29 오후 6:06:30 The world is not flat
  2021-04-29 오후 6:06:30 1 + 1 = 2
*/