using System;

delegate int MyDelegate(int a, int b);
class Calculator
{
  public int Plus(int a, int b) => a + b; // 대리자는 인스턴스 메소드도 참조할 수 있고
  public static int Minus(int a, int b) => a - b; //대리자는 정적 메소드도 참조할 수 있습니다.
}
class MainApp
{
  static void Main(string[] args)
  {
    Calculator Calc = new Calculator();
    MyDelegate Callback;

    Callback = new MyDelegate(Calc.Plus);
    Console.WriteLine(Callback(3, 4)); // 메소드를 호출하듯 대리자를 사용하면, 참조하고 있는 메소드가 실행됩니다.

    Callback = new MyDelegate(Calculator.Minus);
    Console.WriteLine(Callback(7, 5));
  }
}

/*실행 결과

7
2

*/