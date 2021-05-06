using System;
using System.Collections;

class MyList : IEnumerable, IEnumerator
{
  private int[] array;
  int position = -1;

  public MyList() { array = new int[3]; }

  public int this[int index]
  {
    get
    {
      return array[index];
    }
    set
    {
      if (index >= array.Length)
      {
        Array.Resize<int>(ref array, index + 1);
        Console.WriteLine($"Array Resized : {array.Length}");
      }
      array[index] = value;
    }
  }

  //IEnumerator 멤버
  //IEnumerator로부터 Currernt 프로퍼티는 현재 위치의 요소를 반환함.
  public object Current
  {
    get
    {
      return array[position];
    }
  }

  //IEnumerator 멤버
  //IEnumerator로부터 상속받은 MoveNext() 메소드. 다음 위치의 요소로 이동합니다.
  public bool MoveNext()
  {
    if (position == array.Length - 1)
    {
      Reset();
      return false;
    }
    position++;
    return (position < array.Length);
  }

  //IEnumerator 멤버
  //IEnumerator로부터 상속받은 Reset() 메소드. 요소의 위치를 첫 요소의 "앞"으로 옮깁니다.
  public void Reset()
  {
    position = -1;
  }

  //IEnumerable 멤버
  public IEnumerator GetEnumerator()
  {
    return this;
  }
}

class MainApp
{
  static void Main(string[] args)
  {
    MyList list = new MyList();
    for (int i = 0; i < 5; i++)
      list[i] = i;

    foreach (int e in list)
      Console.WriteLine(e);
  }
}

/*실행 결과
Array Resized : 4
Array Resized : 5
0
1
2
3
4
*/