using System;

// class MainApp
// {
//   private static bool CheckPassed(int score) => score >= 60;
//   private static void Print(int value) => Console.Write($"{value} ");

//   static void Main(string[] args)
//   {
//     int[] scores = new int[] { 80, 74, 81, 90, 34 };

//     foreach (int score in scores)
//       Console.Write($"{score} ");
//     Console.WriteLine();

//     Array.Sort(scores);
//     // Array.ForEach<int>(scores, (scores) => Console.WriteLine($"{scores}"));
//     Array.ForEach<int>(scores, new Action<int>(Print));

//     Console.WriteLine();

//     // .Rank {get;} 프로퍼티 몇차원 배열인지 알려줌.
//     Console.WriteLine($"Number of dimensions : {scores.Rank}");

//     // 이진 탐색
//     Console.WriteLine($"Binary Search : 81 is at " + $"{Array.BinarySearch<int>(scores, 81)}");
//     // 선형 탐색
//     Console.WriteLine($"Linear Search : 90 is at " + $"{Array.IndexOf(scores, 90)}");
//     // TrueForAll 메소드는 배열과 함께 조건을 검사하는 메소드를 매개변수로 받음.
//     Console.WriteLine($"Everyone passed ? : " + $"{Array.TrueForAll<int>(scores, CheckPassed)}");
//     // FindIndex 메소드는 특정 조건에 부합하는 메소드를 매개변수로 받음. 람다식으로 구현.
//     int index = Array.FindIndex<int>(scores, (score) => score < 60);
//     scores[index] = 61;
//     // TrueForAll 메소드는 배열과 함께 조건을 검사하는 메소드를 매개변수로 받음. 람다식으로 구현.
//     Console.WriteLine($"Everyone passed ? : " + $"{Array.TrueForAll<int>(scores, (score) => score >= 60)}");

//     // 인자로 받는 n차원 배열의 길이를 반환함.
//     Console.WriteLine("Old length of scores : " + $"{scores.GetLength(0)}");

//     // 5였던 배열의 용량을 10으로 재조정.
//     Array.Resize<int>(ref scores, 10);
//     Console.WriteLine("New length of scores : " + $"{scores.Length}");

//     // Action 대리자.
//     Array.ForEach<int>(scores, new Action<int>(Print));
//     Console.WriteLine();

//     Array.Clear(scores, 3, 7);
//     Array.ForEach<int>(scores, new Action<int>(Print));
//     Console.WriteLine();

//     int[] sliced = new int[3];
//     // scores 배열의 0번째부터 3개요소를 scliced 배열의 0번째 ~2번째 요소에 차례대로 복사.
//     Array.Copy(scores, 0, sliced, 0, 3);
//     Array.ForEach<int>(sliced, new Action<int>(Print));
//     Console.WriteLine();
//   }
// }

/* 실행 결과 
    80 74 81 90 34 
    34 74 80 81 90
    Number of dimensions : 1
    Binary Search : 81 is at 3
    Linear Search : 90 is at 4
    Everyone passed ? : False
    Everyone passed ? : True
    Old length of scores : 5
    New length of scores : 10
    61 74 80 81 90 0 0 0 0 0
    61 74 80 0 0 0 0 0 0 0
    61 74 80
*/