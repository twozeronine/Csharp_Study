using System;
using System.Linq.Expressions;

class MainApp
{
  static void Main(string[] args)
  {
    Expression<Func<int, int, int>> expression = (a, b) => 1 * 2 + (a - b);
    Func<int, int, int> func = expression.Compile();

    // x = 7 , y =8 
    Console.WriteLine($"1*2+({7}-{8}) = {func(7, 8)}");
  }
}

/*실행 결과
1*2+(7-8) = 1

람다식을 이용하면 더 간편하게 식 트리를 만들 수 있다. 다만 이 경우에는 "동적으로" 식 트리를 만들기는 어려워진다.
Expression 형식은 불변 이기 때문에 인스턴스가 한번 만들어진 후에는 변경할 수가 없기 때문이다.
*/
