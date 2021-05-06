using System;
using System.Collections;

class MyList
{
  private int[] array;


  // 생성자
  public MyList()
  {
    array = new int[3];
  }

  // 인덱서
  public int this[int dz]
  {
    get { return array[dz]; }
    set
    {
      if (dz >= array.Length)
      {
        Array.Resize<int>(ref array, dz + 1);
        Console.WriteLine($"Array Resized : {array.Length}");
      }
      array[dz] = value;
    }
  }

  public int Length
  {
    get { return array.Length; }
  }
}

class MainApp
{
  static void Main(string[] args)
  {
    MyList list = new MyList();
    for (int i = 0; i < 5; i++)
      list[i] = i; // 배열을 다루듯 인덱스를 통해 데이터를 입력함.

    for (int i = 0; i < list.Length; i++)
      Console.WriteLine(list[i]); // 데이터를 얻어올 때도 인덱스를 이용함.
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