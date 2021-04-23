using System;

class ArmorSuite
{
  public virtual void Initialize()
  {
    Console.WriteLine("Armored");
  }
}
class IronMan : ArmorSuite
{
  public override void Initialize()
  {
    base.Initialize();
    Console.WriteLine("Repulsor Rays Armed");
  }
}
class WarMachine : ArmorSuite
{
  public override void Initialize()
  {
    base.Initialize();
    Console.WriteLine("Double-Barrel Cannos Armed");
    Console.WriteLine("Micro-Rocket Launcher Armed");
  }
}