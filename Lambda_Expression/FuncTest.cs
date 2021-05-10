using System;

class MainApp
{
  static void Main(string[] args)
  {
    Func<int> func1 = () => 10;
    Console.WriteLine($"func1() : {func1()}");

    Func<int, int> func2 = (x) => x * 2;
    Console.WriteLine($"func2(4) : {func2(4)}");

    //public delegate TResult Func<in T1, in T2, out TResult>(T1 arg1, T2 arg2)
    Func<double, double, double> func3 = (x, y) => x / y; // 입력 매개변수는 double 형식 둘 , 반환 형식은 double
    Console.WriteLine($"func3(22,7) : {func3(22, 7)}");
  }
}

/*실행 결과
func1() : 10
func2(4) : 8
func3(22,7) : 3.142857142857143
*/