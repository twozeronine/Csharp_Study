using System;
using System.Collections;

class MyEnumerator
{
  int[] numbers = { 1, 2, 3, 4 };
  public IEnumerator GetEnumerator()
  {
    yield return numbers[0];
    yield return numbers[1];
    yield return numbers[2];
    yield break;
    yield return numbers[3]; // yield break는 GetEnumerator()메소드를 종료시킵니다.
                             //(13,5): warning CS0162: 접근할 수 없는 코드가 있습니다.
  }
}

class MainApp
{
  static void Main(string[] args)
  {
    var obj = new MyEnumerator();
    foreach (int i in obj)
    {
      Console.WriteLine(i);
    }
  }
}


/*

1
2
3

*/