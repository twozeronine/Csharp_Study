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



class MainApp
{
  static void Main(string[] args)
  {
    Console.WriteLine("Creating ArmorSuite...");
    ArmorSuite armorSuite = new ArmorSuite();
    armorSuite.Initialize();

    Console.WriteLine("\nCreating IronMan...");
    ArmorSuite ironMan = new IronMan();
    ironMan.Initialize();

    Console.WriteLine("Creating WarMachine...");
    ArmorSuite warMachine = new WarMachine();
    warMachine.Initialize();
  }
}

/*실행 결과
Creating ArmorSuite...
Armored

Creating IronMan...
Armored
Repulsor Rays Armed

Creating WarMachine...
Armored
Double-Barrel Cannos Armed
Micro-Rocket Launcher Armed
*/