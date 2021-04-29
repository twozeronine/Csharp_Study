using System;
interface IRunnable
{
  void Run();
}

interface IFlyable
{
  void Fly();
}

class FlyingCar : IRunnable, IFlyable
{
  public void Run()
  {
    Console.WriteLine("Run Run!");
  }

  public void Fly()
  {
    Console.WriteLine("Fly Fly");
  }
}

#region Containment (포함) 기법을 사용하여 클래스 다중 상속 흉내 내보기

class Plane : IFlyable
{
  public void Fly()
  {
    Console.WriteLine("Fly Fly");
  }
}
class Car : IRunnable
{
  public void Run()
  {
    Console.WriteLine("Run Run");
  }
}

class FlyingCar2 : IRunnable, IFlyable
{
  Car car = new Car();
  Plane plane = new Plane();
  public void Run()
  {
    car.Run();
  }
  public void Fly()
  {
    plane.Fly();
  }
}

#endregion



class MainApp
{
  static void Main(string[] args)
  {
    FlyingCar car = new FlyingCar();
    car.Run();
    car.Fly();

    IRunnable runnable = car as IRunnable;
    runnable.Run();

    IFlyable flyable = car as IFlyable;
    flyable.Fly();

    // 포함 기법을 사용한 클래스 다중 상속 흉내내보기
    FlyingCar2 car2 = new FlyingCar2();
    car2.Fly();
    car2.Run();
  }
}

/*실행 결과
  Run Run!
  Fly Fly
  Run Run!
  Fly Fly
  Fly Fly
  Run Run
*/