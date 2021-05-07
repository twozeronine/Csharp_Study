using System;
using System.Collections.Generic;

class MainApp
{
  static void Main(string[] args)
  {
    Stack<int> stack = new Stack<int>();
    for (int i = 0; i < 5; i++)
      stack.Push(i);

    while (stack.Count > 0)
      Console.WriteLine(stack.Pop());
  }
}

/*실행 결과
4
3
2
1
0
*/