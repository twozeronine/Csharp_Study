using System;
using System.Collections;

class MainApp
{
  static void Main(string[] args)
  {
    Stack stack = new Stack();
    stack.Push(1);
    stack.Push(2);
    stack.Push(3);
    stack.Push(4);
    stack.Push(5);

    while (stack.Count > 0)
      Console.WriteLine(stack.Pop());
  }
}

/*실행 결과
5
4
3
2
1
*/