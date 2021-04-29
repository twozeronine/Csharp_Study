using System;

// class MainApp
// {
//   static void PrintArray(int[,] array)
//   {
//     for (int i = 0; i < array.GetLength(0); i++)
//     {
//       for (int j = 0; j < array.GetLength(1); j++)
//       {
//         Console.Write($"[{i}, {j}] : {array[i, j]}");
//       }
//       Console.WriteLine();
//     }
//     Console.WriteLine();
//   }
//   static void Main(string[] args)
//   {
//     // 2차원 배열을 초기화하는 3가지 방법
//     int[,] arr = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
//     int[,] arr2 = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
//     int[,] arr3 = { { 1, 2, 3 }, { 4, 5, 6 } };

//     FPrintArray(arr);
//     FPrintArray(arr2);
//     FPrintArray(arr3);
//   }
// }

/*실행결과
  [0, 0] : 1[0, 1] : 2[0, 2] : 3
  [1, 0] : 4[1, 1] : 5[1, 2] : 6

  [0, 0] : 1[0, 1] : 2[0, 2] : 3
  [1, 0] : 4[1, 1] : 5[1, 2] : 6

  [0, 0] : 1[0, 1] : 2[0, 2] : 3
  [1, 0] : 4[1, 1] : 5[1, 2] : 6
*/