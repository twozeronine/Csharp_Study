using System;

class BirthdayInfo2
{
  public string Name { get; set; } = "Unknown";
  public DateTime Birthday { get; set; } = new DateTime(1, 1, 1);
  public int Age
  {
    get
    {
      return new DateTime(DateTime.Now.Subtract(Birthday).Ticks).Year;
    }
  }
}

class MainApp
{
  static void Main(string[] args)
  {
    BirthdayInfo2 birth = new BirthdayInfo2();
    Console.WriteLine($"Name : {birth.Name}");
    Console.WriteLine($"Birthday : {birth.Birthday.ToShortDateString()}");
    Console.WriteLine($"Age : {birth.Age}");

    birth.Name = "서현";
    birth.Birthday = new DateTime(1991, 6, 28);

    Console.WriteLine($"Name : {birth.Name}");
    Console.WriteLine($"Birthday :{birth.Birthday.ToShortDateString()}");
    Console.WriteLine($"Age : {birth.Age}");
  }
}

/*실행 결과
  Name : Unknown
  Birthday : 0001-01-01
  Age : 2021
  Name : 서현
  Birthday :1991-06-28
  Age : 30
*/