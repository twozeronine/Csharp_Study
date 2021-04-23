using System;

static class TupleApp2
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