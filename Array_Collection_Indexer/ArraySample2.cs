using System;

class MainApp2
{
  static void Main(string[] args)
  {
    int[] scores = new int[5];
    scores[0] = 80;
    scores[1] = 74;
    scores[2] = 81;
    scores[^2] = 90;  //배열의 마지막 -1
    scores[^1] = 34;  //배열의 마지막

    foreach (int score in scores)
      Console.Write($"{score} ");

    int sum = 0;
    foreach (int score in scores)
      sum += score;

    int average = sum / scores.Length;

    Console.WriteLine($"Average Score : {average}");
  }
}

/*  실행 결과
    80 74 81 90 34 Average Score : 71
*/