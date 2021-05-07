using System;

class StructArray<T> where T : struct
{
  public T[] Array { get; set; }
  public StructArray(int size) { Array = new T[size]; }
}

class RefArray<T> where T : class
{
  public T[] Array { get; set; }
  public RefArray(int size) { Array = new T[size]; }
}

class Base { }
class Dervied : Base { }
class BaseArray<U> where U : Base
{
  public U[] Array { get; set; }
  public BaseArray(int size) { Array = new U[size]; }

  public void CopyArray<T>(T[] Source) where T : U
  {
    Source.CopyTo(Array, 0);
  }
}

interface IGeneric { }
class DerivedInterface : IGeneric { }
class IArray<T> where T : IGeneric
{
  public T[] Array { get; set; }
  public IArray(int size) { Array = new T[size]; }
}


class MainApp
{
  public static T CreateInstance<T>() where T : new() { return new T(); }

  static void Main(string[] args)
  {
    StructArray<int> a = new StructArray<int>(3);
    a.Array[0] = 0;
    a.Array[1] = 1;
    a.Array[2] = 2;

    for (int i = 0; i < a.Array.Length; i++)
      Console.WriteLine(a.Array[i]);
    Console.WriteLine();

    RefArray<StructArray<double>> b = new RefArray<StructArray<double>>(3);
    b.Array[0] = new StructArray<double>(5);
    b.Array[1] = new StructArray<double>(10);
    b.Array[2] = new StructArray<double>(1005);

    for (int i = 0; i < b.Array.Length; i++)
      Console.WriteLine(b.Array[i].Array.Length);
    Console.WriteLine();

    BaseArray<Base> c = new BaseArray<Base>(3);
    c.Array[0] = new Base();
    c.Array[1] = new Dervied();
    c.Array[2] = CreateInstance<Base>();

    for (int i = 0; i < c.Array.Length; i++)
      Console.WriteLine(c.Array[i].GetType());
    Console.WriteLine();

    BaseArray<Dervied> d = new BaseArray<Dervied>(3);
    d.Array[0] = new Dervied(); // Base 형식은 여기에 할당할 수 없다.
    d.Array[1] = CreateInstance<Dervied>();
    d.Array[2] = CreateInstance<Dervied>();

    for (int i = 0; i < d.Array.Length; i++)
      Console.WriteLine(d.Array[i].GetType());
    Console.WriteLine();

    BaseArray<Dervied> e = new BaseArray<Dervied>(3);
    e.CopyArray<Dervied>(d.Array);

    for (int i = 0; i < e.Array.Length; i++)
      Console.WriteLine(e.Array[i].GetType());
    Console.WriteLine();

    IArray<DerivedInterface> f = new IArray<DerivedInterface>(3);
    f.Array[0] = new DerivedInterface();
    f.Array[1] = CreateInstance<DerivedInterface>();
    f.Array[2] = CreateInstance<DerivedInterface>();

    for (int i = 0; i < f.Array.Length; i++)
      Console.WriteLine(f.Array[i].GetType());
  }
}

/*실행 결과

0
1
2

5
10
1005

Base
Dervied
Base

Dervied
Dervied
Dervied

Dervied
Dervied
Dervied

DerivedInterface
DerivedInterface
DerivedInterface

*/