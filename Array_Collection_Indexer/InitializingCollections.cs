using System;
using System.Collections;
using static System.Console;

class MainApp
{
  static void Main(string[] args)
  {
    int[] arr = { 123, 456, 678 };

    ArrayList list = new ArrayList(arr);
    foreach (object item in list)
      WriteLine($"ArrayList : {item}");
    WriteLine();

    Stack stack = new Stack(arr);
    foreach (object item in stack)
    {
      WriteLine($"Satck : {item}");
    }
    WriteLine();

    Queue queue = new Queue(arr);
    foreach (object item in queue)
    {
      WriteLine($"Queue : {item}");
    }
    WriteLine();


    ArrayList list2 = new ArrayList() { 11, 22, 33 }; //컬렉션 초기자를 이용한 컬렉션 초기화
    foreach (object item in list2)
      WriteLine($"ArrayList2 : {item}");
    WriteLine();
  }
}

/*실행 결과
ArrayList : 123
ArrayList : 456
ArrayList : 678

Satck : 678
Satck : 456
Satck : 123

Queue : 123
Queue : 456
Queue : 678

ArrayList2 : 11
ArrayList2 : 22
ArrayList2 : 33
*/