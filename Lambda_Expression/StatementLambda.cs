using System;

class MainApp
{
  delegate string Concatenate(string[] args);
  static void Main(string[] args)
  {
    Concatenate concat = (arr) =>
    {
      string result = "";
      foreach (string s in arr)
        result += s;
      return result;
    };

    Console.WriteLine(concat(args));
  }
}

/*실행 결과
PS > dotnet run 아버지가 방에 들어가신다.
아버지가방에들어가신다.
PS > dotnet run 아 기다리고 기다리던 방학.   
아기다리고기다리던방학.
*/