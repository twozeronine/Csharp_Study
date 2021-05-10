using System;
using System.Linq;


class MainApp
{
  static void Main(string[] args)
  {
    int[] numbers = { 9, 2, 6, 4, 5, 3, 7, 8, 1, 10 };

    var result = (from n in numbers
                  where n % 2 == 0
                  orderby n ascending
                  select n);
    foreach (int n in result)
    {
      Console.WriteLine($"짝수 : {n}");
    }
  }
}

/*실행 결과
짝수 : 2
짝수 : 4
짝수 : 6
짝수 : 8
짝수 : 10
*/