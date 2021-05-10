using System;
using System.Collections.Generic;

class FriendList
{
  private List<string> list = new List<string>();

  public void Add(string name) => list.Add(name);
  public void Remove(string name) => list.Remove(name);
  public void PrintAll()
  {
    foreach (var s in list)
      Console.WriteLine(s);
  }

  public FriendList() => Console.WriteLine("FriendList()");
  ~FriendList() => Console.WriteLine("~FriendList()");

  // public int Capacity => list.Capacity; // 읽기 전용일때

  // 프로퍼티
  public int Capacity
  {
    get => list.Capacity;
    set => list.Capacity = value;
  }

  // public string this[int index] => list[index]; // 읽기 전용일때
  public string this[int index] // 인덱서 
  {
    get => list[index];
    set => list[index] = value;
  }
}

class MainApp
{
  static void Main(string[] args)
  {
    FriendList friendList = new FriendList();
    friendList.Add("Eeny");
    friendList.Add("Meeny");
    friendList.Add("Miny");
    friendList.Remove("Eeny");
    friendList.PrintAll();

    Console.WriteLine($"{friendList.Capacity}");
    friendList.Capacity = 10;
    Console.WriteLine($"{friendList.Capacity}");

    Console.WriteLine($"{friendList[0]}");
    friendList[0] = "Moe";
    friendList.PrintAll();
  }
}

/*실행 결과
FriendList()
Meeny
Miny
4
10
Meeny
Moe
Miny
*/