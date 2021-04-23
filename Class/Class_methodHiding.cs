using System;

class Base2
{
  public void MyMethod()
  {
    Console.WriteLine("Base.MyMethod()");
  }
}

class Derived2 : Base2
{
  public new void MyMethod()
  {
    Console.WriteLine("Derived.MyMethod()");
  }
}
