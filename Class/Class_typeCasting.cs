using System;

class Mammal
{
  public void Nurse()
  {
    Console.WriteLine("Nurse()");
  }
}

class Dog : Mammal
{
  public void Bark()
  {
    Console.WriteLine("Bark()");
  }
}

class Cat : Mammal
{
  public void Meow()
  {
    Console.WriteLine("Meow()");
  }
}