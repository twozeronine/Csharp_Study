using System;

class Transaction
{
  public string From { get; init; }
  public string To { get; init; }
  public int Amount { get; init; }

  public override string ToString()
  {
    return $"{From,-10} -> {To,-10} : ${Amount}";
  }
}

class MainApp
{
  static void Main(string[] args)
  {
    Transaction tr1 = new Transaction { From = "Alice", To = "Bob", Amount = 100 };
    Transaction tr2 = new Transaction { From = "Bob", To = "Charlie", Amount = 50 };
    Transaction tr3 = new Transaction { From = "Charlie", To = "Alice", Amount = 50 };

    Console.WriteLine(tr1);
    Console.WriteLine(tr2);
    Console.WriteLine(tr3);
  }
}

/*실행 결과
  Alice      -> Bob        : $100
  Bob        -> Charlie    : $50
  Charlie    -> Alice      : $50
*/