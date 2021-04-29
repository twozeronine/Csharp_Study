using System;

class MainApp
{
  static void Main(string[] args)
  {
    var a = new { name = "Lee", Age = 123 };
    Console.WriteLine($"Name:{a.name}, Age:{a.Age}");

    var b = new { Subject = "수학", Scores = new int[] { 90, 80, 70, 60 } };

    Console.Write($"Subject:{b.Subject}, Scores: ");
    foreach (var score in b.Scores)
    {
      Console.Write($"{score} ");
    }
    Console.WriteLine();
  }
}

/* 실행 결과
Name:Lee, Age:123
Subject:수학, Scores: 90 80 70 60 
*/