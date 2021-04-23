using System;

class MyClass
{
  public int MyField1;
  public int MyField2;

  public MyClass DeepCopy()
  {
    MyClass newCopy = new MyClass();
    newCopy.MyField1 = this.MyField1;
    newCopy.MyField2 = this.MyField2;

    return newCopy;
  }

}