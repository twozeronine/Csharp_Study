using System;

class CTransaction
{
  public string From { get; init; }
  public string To { get; init; }
  public int Amount { get; init; }

  public override string ToString()
  {
    return $"{From,-10} -> {To,-10} : ${Amount}";
  }
}

record RTransaction3
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
    CTransaction trA = new CTransaction { From = "Alice", To = "Bob", Amount = 100 };
    CTransaction trB = new CTransaction { From = "Alice", To = "Bob", Amount = 100 };

    Console.WriteLine(trA);
    Console.WriteLine(trB);
    Console.WriteLine($"trA equals to trB : {trA.Equals(trB)}");

    RTransaction3 tr1 = new RTransaction3 { From = "Alice", To = "Bob", Amount = 100 };
    RTransaction3 tr2 = new RTransaction3 { From = "Alice", To = "Bob", Amount = 100 };

    Console.WriteLine(tr1);
    Console.WriteLine(tr2);
    Console.WriteLine($"tr1 equals to tr2 : {tr1.Equals(tr2)}");
  }
}

/* 실행결과
Alice      -> Bob        : $100
Alice      -> Bob        : $100
trA equals to trB : False
Alice      -> Bob        : $100
Alice      -> Bob        : $100
tr1 equals to tr2 : True
Equals( )의 기본 구현은 내용 비교가 아닌 참조를 비교하므로 두 CTransaction 객체의 비교 결과는 False이다.
*/