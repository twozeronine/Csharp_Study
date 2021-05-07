using System;
using System.Collections.Generic;

class MainApp
{
  static void Main(string[] args)
  {
    Queue<int> queue = new Queue<int>();
    for (int i = 0; i < 5; i++)
      queue.Enqueue(i);

    while (queue.Count > 0)
      Console.WriteLine(queue.Dequeue());
  }
}

/*실행결과
0
1
2
3
4
*/