using System;
using System.Collections;

class MainApp
{
  static void Main(string[] args)
  {
    Queue queue = new Queue();
    queue.Enqueue(1);
    queue.Enqueue(2);
    queue.Enqueue(3);
    queue.Enqueue(4);
    queue.Enqueue(5);

    while (queue.Count > 0)
      Console.WriteLine(queue.Dequeue());
  }
}

/*실행결과
1
2
3
4
5
*/