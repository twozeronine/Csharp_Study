using System;

delegate int Compare(int a, int b);
class MainApp
{
  //오름차순 비교
  static int AscendCompare(int a, int b)
  {
    if (a > b) return 1;
    else if (a == b) return 0;
    else return -1;
  }
  //내림차순 비교
  static int DescendCompare(int a, int b)
  {
    if (a < b) return 1;
    else if (a == b) return 0;
    else return -1;
  }

  static void BubbleSort(int[] DataSet, Compare compare)
  {
    int i = 0, j = 0, temp = 0;

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

    Console.WriteLine("Sorting ascending...");
    BubbleSort(array, new Compare(AscendCompare));

    for (int i = 0; i < array.Length; i++)
      Console.Write($"{array[i]} ");

    int[] array2 = { 7, 2, 8, 10, 11 };
    Console.WriteLine("\nSorting descending...");
    BubbleSort(array2, new Compare(DescendCompare));

    for (int i = 0; i < array2.Length; i++)
      Console.Write($"{array2[i]} ");

    Console.WriteLine();
  }
}

/*실행 결과

Sorting ascending...
2 3 4 7 10 
Sorting descending...
11 10 8 7 2

*/