using System;

interface ILogger2
{
  void WriteLog(string message);

  void WriteError(string error) // 새로운 메소드 추가
  {
    WriteLog($"Error: {error}");
  }
}

class ConsoleLogger3 : ILogger2
{
  public void WriteLog(string message)
  {
    Console.WriteLine($"{DateTime.Now.ToLocalTime()},{message}");
  }
}

class MainApp
{
  static void Main(string[] args)
  {
    ILogger2 logger = new ConsoleLogger3();
    logger.WriteLog("System Up");
    logger.WriteError("System Fail");

    ConsoleLogger3 clogger = new ConsoleLogger3();
    clogger.WriteLog("System Up"); // OK
    // clogger.WriteError("System Fail"); // 컴파일 에러
  }
}