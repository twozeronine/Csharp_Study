using System;

record RTransaction
{
  public string From { get; init; }
  public string To { get; init; }
  public int Amount { get; init; }

  // 후에 main에서 이 객체를 Console.WriteLine으로 출력할 때 객체를 Tostring()하는데 이때 사용될 Tostring()을 확장 메소드 기능으로 기존 기능을 바꿈.
  public override string ToString()
  {
    return $"{From,-10} -> {To,-10} : ${Amount}";
  }
}

// class MainApp
// {
//   static void Main(string[] args)
//   {
//     RTransaction tr1 = new RTransaction { From = "Alice", To = "Bob", Amount = 100 };
//     RTransaction tr2 = new RTransaction { From = "Alice", To = "Charlie", Amount = 100 };
//     RTransaction copytr1 = new RTransaction { From = "Alice", To = "Bob", Amount = 100 };
//     RTransaction copytr2 = tr1;
//     Console.WriteLine(tr1);
//     Console.WriteLine(tr2);
//     Console.WriteLine(tr1.Equals(copytr1));
//     Console.WriteLine(tr1.Equals(copytr2));
//   }
// }