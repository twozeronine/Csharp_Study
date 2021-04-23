using System;

class Employee
{
  private string Name;
  private string Position;

  public void SetName(string Name)
  {
    this.Name = Name;
  }

  public string GetName()
  {
    return Name;
  }

  public void SetPosition(string Position)
  {
    this.Position = Position;
  }

  public string GetPosition()
  {
    return this.Position;
  }
}
