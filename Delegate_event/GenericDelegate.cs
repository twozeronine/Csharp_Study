using System;

delegate int Compare<T>(T a, T b);
class MainApp
{
  //오름차순 비교
  static int AscendCompare<T>(T a, T b) where T : IComparable<T>
  {
    /*IComparable<T>이 나온 이유 : System.Int32(int),System.Double(double)을 비롯한 모든 수치 형식과
    System.String(string)은 모두 IComparable을 상속해서 CompareTo() 메소드를 구현하고 있다.
    이들 모두의 CompareTo() 메소드는 매개변수가 자신보다 크면 -1, 같으면 0, 작으면 1을 반환한다.
    그리고 형식 매개변수 T 는 연산자 > 와 == 등으로 비교 할수없다. 왜냐하면 무슨 값이 들어오는지 알 수 없기 때문에
    그 값을 한정 시키기 위해 where T : IComparable을 통하여 CompareTo() 메소드를 쓸수있는 값들만 일반화 시키게끔 하였다.
    */
    return a.CompareTo(b); // 매개변수가 자신보다 큰경우 1, 같으면 0, 작은 경우 -1을 반환.
  }
  //내림차순 비교
  static int DescendCompare<T>(T a, T b) where T : IComparable<T>
  {
    return b.CompareTo(a);
  }

  static void BubbleSort<T>(T[] DataSet, Compare<T> compare)
  {
    int i = 0, j = 0;
    T temp;

    for (i = 0; i < DataSet.Length - 1; i++)
    {
      for (j = 0; j < DataSet.Length - (i + 1); j++)
      {
        if (compare(DataSet[j], DataSet[j + 1]) > 0)
        {
          temp = DataSet[j + 1];
          DataSet[j + 1] = DataSet[j];
          DataSet[j] = temp;
        }
      }
    }
  }
  static void Main(string[] args)
  {
    int[] array = { 3, 7, 4, 2, 10 };

    Console.WriteLine("Sorting int ascending...");
    BubbleSort<int>(array, new Compare<int>(AscendCompare));

    for (int i = 0; i < array.Length; i++)
      Console.Write($"{array[i]} ");

    Console.WriteLine("\nSorting int descendCompare...");
    BubbleSort<int>(array, new Compare<int>(DescendCompare));

    for (int i = 0; i < array.Length; i++)
      Console.Write($"{array[i]} ");

    Console.WriteLine();

    string[] array2 = { "abc", "def", "ghi", "jkl", "mno" };

    Console.WriteLine("\nSorting string ascendCompare...");
    BubbleSort<string>(array2, new Compare<string>(AscendCompare));

    for (int i = 0; i < array2.Length; i++)
      Console.Write($"{array2[i]} ");

    Console.WriteLine("\nSorting string descending...");
    BubbleSort<string>(array2, new Compare<string>(DescendCompare));

    for (int i = 0; i < array2.Length; i++)
      Console.Write($"{array2[i]} ");

    Console.WriteLine();
  }
}

/*실행 결과

Sorting int ascending...
2 3 4 7 10 
Sorting int descendCompare...
10 7 4 3 2

Sorting string ascendCompare...
abc def ghi jkl mno
Sorting string descending...
mno jkl ghi def abc

*/