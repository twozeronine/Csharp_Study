using System;

class MyClass
{
  [Obsolete("OldMethod는 폐기되었습니다. NewMethod()를 이용하세요.")]
  public void OldMethod() => Console.WriteLine("I'm old");

  public void NewMethod() => Console.WriteLine("I'm new");

}
class MainApp
{
  static void Main(string[] args)
  {
    MyClass obj = new MyClass();
    obj.OldMethod();
    obj.NewMethod();
  }
}

/*실행 결과
cs(16,5): warning CS0618: 'MyClass.OldMethod()'은(는) 사용되지 않습니다. 'OldMethod는 폐기되었습니다. NewMethod()를 이용하
세요.'
I'm old
I'm new

*/