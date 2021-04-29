using System;

static class TupleApp
{
  public static double GetDiscountRate(object client)
  {
    return client switch
    {
      ("학생", int age) when age < 18 => 0.2, //학생 & 18세 미만
      ("학생", _) => 0.1, // 학생 & 18세 이상
      ("일반", int age) when age < 18 => 0.1, // 일반 & 18세 미만
      ("일반", _) => 0.05, //일반 & 18세 이상
      _ => 0,
    };
  }
}


class MainApp
{
  static void Main(string[] args)
  {
    var alice = (job: "학생", age: 17);
    var bob = (job: "학생", age: 23);
    var charlie = (job: "일반", age: 15);
    var dave = (job: "일반", age: 21);

    Console.WriteLine($"alice :{TupleApp.GetDiscountRate(alice)}");
    Console.WriteLine($"bob :{TupleApp.GetDiscountRate(bob)}");
    Console.WriteLine($"charlie :{TupleApp.GetDiscountRate(charlie)}");
    Console.WriteLine($"dave :{TupleApp.GetDiscountRate(dave)}");
  }
}


/*실행 결과
  alice :0.2
  bob :0.1
  charlie :0.1
  dave :0.05
*/