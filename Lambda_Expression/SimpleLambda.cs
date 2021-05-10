using System;

class MainApp
{
  delegate int Calculate(int a, int b);
  static void Main(string[] args)
  {
    Calculate calc = (a, b) => a + b;
    Console.WriteLine($"{3} + {4} : {calc(3, 4)}");
  }
}

/*실행 결과
3 + 4 : 7
*/