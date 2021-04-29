using System;
using System.IO;

interface ILogger
{
  void WriteLog(string message);
}

// interface ILogger를 상속받은 클래스는 WriteLog( ) 메소드를 구현해야함.
// 로그를 콘솔로 출력해주는 클래스
class ConsoleLogger : ILogger
{
  public void WriteLog(string message)
  {
    Console.WriteLine(
      "{0} {1}",
      DateTime.Now.ToLocalTime(), message);
  }
}

// 로그를 파일로 출력해주는 클래스
class FileLogger : ILogger
{
  private StreamWriter writer;

  public FileLogger(string path)
  {
    writer = File.CreateText(path);
    writer.AutoFlush = true;
  }

  public void WriteLog(string message)
  {
    writer.WriteLine("{0} {1}", DateTime.Now.ToShortTimeString(), message);
  }
}

class ClimateMonitor
{
  private ILogger logger;
  public ClimateMonitor(ILogger logger)
  {
    this.logger = logger;
  }

  public void start()
  {
    while (true)
    {
      Console.Write("온도를 입력해주세요.: ");
      string temperature = Console.ReadLine();
      if (temperature == "") break;
      logger.WriteLog("현재 온도 : " + temperature);
    }
  }
}

class MainApp
{
  static void Main(string[] args)
  {
    ClimateMonitor monitor1 = new ClimateMonitor(new FileLogger("MyLog.txt"));
    ClimateMonitor monitor2 = new ClimateMonitor(new ConsoleLogger());
    //monitor1.start();
    monitor2.start();
  }
}

/*실행 결과
  온도를 입력해주세요.: 30
  2021-04-29 오후 6:05:20 현재 온도 : 30
  온도를 입력해주세요.: 20
  2021-04-29 오후 6:05:21 현재 온도 : 20
  온도를 입력해주세요.:
*/