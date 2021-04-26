using System;

class BirthdayInfo3
{
  public string Name { get; set; }
  public DateTime Birthday { get; set; }
  public int Age
  {
    get
    {
      return new DateTime(DateTime.Now.Subtract(Birthday).Ticks).Year;
    }
  }
}

// class MainApp
// {
//   static void Main(string[] args)
//   {
//     BirthdayInfo3 birth = new BirthdayInfo3()
//     {
//       Name = "서현",
//       Birthday = new DateTime(1991, 6, 28)
//     };

//     Console.WriteLine($"Name:{birth.Name}");
//     Console.WriteLine($"Birthday:{birth.Birthday.ToShortDateString()}");
//     Console.WriteLine($"Age:{birth.Age}");
//   }
// }