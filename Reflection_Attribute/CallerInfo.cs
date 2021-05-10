using System;
using System.Runtime.CompilerServices;

public static class Trace
{
  public static void WriteLine(string message,
      [CallerFilePath] string file = "",
      [CallerLineNumber] int line = 0,
      [CallerMemberName] string member = "")
  {
    Console.WriteLine(
      $"{file}(Line:{line}) {member}: {message}");
  }
}
class MainApp
{
  static void Main(string[] args)
  {
    Trace.WriteLine("즐거운 프로그래밍!!");
  }
}

/*실행 결과
D:\C#Practice\Study.cs(Line:19) Main: 즐거운 프로그래밍!!
*/