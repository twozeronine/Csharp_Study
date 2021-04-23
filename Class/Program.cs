using System;
using MyExtension;

namespace Class
{
  class Program
  {
    static void Main(string[] args)
    {
      /////////////////////
      ////Class_this.cs
      /////////////////////
      // Employee pooh = new Employee();
      // pooh.SetName("Pooh");
      // pooh.SetPosition("Waiter");
      // Console.WriteLine($"{pooh.GetName()} {pooh.GetPosition()}");

      // Employee tigger = new Employee();
      // tigger.SetName("Tigger");
      // tigger.SetPosition("Cleaner");
      // Console.WriteLine($"{tigger.GetName()} {tigger.GetPosition()}");

      /////////////////////
      // //Class_Inheritance.cs
      /////////////////////
      // Base a = new Base("a");
      // a.BaseMethod();

      // Derived b = new Derived("b");
      // b.BaseMethod();
      // b.DerivedMethod();


      // //Class_typeCasting.cs
      // Mammal mammal = new Dog();
      // Dog dog;

      // if (mammal is Dog)
      // {
      //   dog = (Dog)mammal;
      //   dog.Bark();
      // }

      // Mammal mammal2 = new Cat();

      // Cat cat = mammal2 as Cat;
      // if (cat != null)
      // {
      //   cat.Meow();
      // }

      // Cat cat2 = mammal as Cat;
      // if (cat2 != null)
      //   cat2.Meow();
      // else
      //   Console.WriteLine("cat2 is not a Cat");

      /////////////////////
      ////Class_overriding.cs
      /////////////////////
      // Console.WriteLine("Creating ArmorSuite...");
      // ArmorSuite armorSuite = new ArmorSuite();
      // armorSuite.Initialize();

      // Console.WriteLine("\nCreating IronMan...");
      // ArmorSuite ironMan = new IronMan();
      // ironMan.Initialize();

      // Console.WriteLine("Creating WarMachine...");
      // ArmorSuite warMachine = new WarMachine();
      // warMachine.Initialize();

      /////////////////////
      ////Class_deepCopy.cs
      /////////////////////
      // Console.WriteLine("Shallow Copy");
      // {
      //   MyClass source = new MyClass();
      //   source.MyField1 = 10;
      //   source.MyField2 = 20;

      //   MyClass target = source;
      //   target.MyField2 = 30;

      //   Console.WriteLine($"{source.MyField1} {source.MyField2}");
      //   Console.WriteLine($"{target.MyField1} {target.MyField2}");
      // }

      // Console.WriteLine("Deep Copy");

      // {
      //   MyClass source = new MyClass();
      //   source.MyField1 = 10;
      //   source.MyField2 = 20;

      //   MyClass target = source.DeepCopy();
      //   target.MyField2 = 30;

      //   Console.WriteLine($"{source.MyField1} {source.MyField2}");
      //   Console.WriteLine($"{target.MyField1} {target.MyField2}");
      // }

      /////////////////////
      ////Class_methodHiding.cs
      /////////////////////
      // Base2 baseObj = new Base2();
      // baseObj.MyMethod();   //Base.MyMethod()

      // Derived2 derivedObj = new Derived2();
      // derivedObj.MyMethod();  //Derived.MyMethod()

      // Base2 baseOrDerived = new Derived2();
      // baseOrDerived.MyMethod(); //Base.MyMethod() 출력 다형성 형성 표현 못함

      /////////////////////
      ////Class_NestedClass.cs
      /////////////////////
      // Configuration2 config2 = new Configuration2();
      // config2.SetConfig("Version", "V 5.0");
      // config2.SetConfig("Size", "655,324 KB");

      // Console.WriteLine(config2.GetConfig("Version"));
      // Console.WriteLine(config2.GetConfig("Size"));

      // config2.SetConfig("Version", "V 5.0.1");
      // Console.WriteLine(config2.GetConfig("Version"));

      /////////////////////
      ////Class_PartialClass.cs
      /////////////////////
      // MyPartialClass obj = new MyPartialClass();
      // obj.Method1();
      // obj.Method2();
      // obj.Method3();
      // obj.Method4();

      /////////////////////
      ////Class_ExtensionMethod.cs
      /////////////////////
      // Console.WriteLine($"3^2 : {3.Square()}");
      // Console.WriteLine($"3^4 : {3.Power(4)}");
      // Console.WriteLine($"2^10 : {2.Power(10)}");
      // Console.WriteLine("Hello".Append(",World!"));

      /////////////////////
      ////Class_Struct.cs
      /////////////////////
      // Point3D p3d1;
      // p3d1.X = 10;
      // p3d1.Y = 20;
      // p3d1.Z = 40;

      // Console.WriteLine(p3d1.ToString());

      // Point3D p3d2 = new Point3D(100, 200, 300);
      // Point3D p3d3 = p3d2;
      // p3d3.Z = 400;

      // Console.WriteLine(p3d2.ToString());
      // Console.WriteLine(p3d3.ToString());

      /////////////////////
      ////Class_ReadonlyStruct.cs
      /////////////////////
      // RGBColor Red = new RGBColor(255, 0, 0);
      // //읽기 전용 필드에는 할당할 수 없습니다. 단, 필드가 정의된 형식의 생성자 또는 초기값 전용 setter나 변수 이니셜라이저에서는 예외입니다.
      // // Red.G = 100; //컴파일 에러 


      /////////////////////
      ////Class_ReadonlyMethod.cs
      /////////////////////
      // ACSetting acs;
      // acs.currentInCelsius = 25;
      // acs.target = 25;

      // Console.WriteLine($"{acs.GetFahrenheit()}");
      // Console.WriteLine($"{acs.target}");



      /////////////////////
      ////Class_Tuple.cs
      /////////////////////
      //TupleApp.TupleExample();


      /////////////////////
      ////Class_PositionalPattern.cs
      /////////////////////

      var alice = (job: "학생", age: 17);
      var bob = (job: "학생", age: 23);
      var charlie = (job: "일반", age: 15);
      var dave = (job: "일반", age: 21);

      Console.WriteLine($"alice :{TupleApp2.GetDiscountRate(alice)}");
      Console.WriteLine($"bob :{TupleApp2.GetDiscountRate(bob)}");
      Console.WriteLine($"charlie :{TupleApp2.GetDiscountRate(charlie)}");
      Console.WriteLine($"dave :{TupleApp2.GetDiscountRate(dave)}");
    }
  }
}
