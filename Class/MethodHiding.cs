using System;

class Base
{
  public void MyMethod()
  {
    Console.WriteLine("Base.MyMethod()");
  }
}

class Derived : Base
{
  public new void MyMethod()
  {
    Console.WriteLine("Derived.MyMethod()");
  }
}


class MainApp
{
  static void Main(string[] args)
  {
    Base baseObj = new Base();
    baseObj.MyMethod();   //Base.MyMethod()

    Derived derivedObj = new Derived();
    derivedObj.MyMethod();  //Derived.MyMethod()

    Base baseOrDerived = new Derived();
    baseOrDerived.MyMethod(); //Base.MyMethod() 출력 다형성 형성 표현 못함
  }
}

/*실행 결과
  Base.MyMethod()
  Derived.MyMethod()
  Base.MyMethod()
*/