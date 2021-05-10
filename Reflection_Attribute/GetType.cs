using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

class MainApp
{
  static void PrintInterfaces(Type type)
  {
    Console.WriteLine("-------- Interfaces --------");

    Type[] interfaces = type.GetInterfaces();
    foreach (Type i in interfaces)
      Console.WriteLine("Name:{0}", i.Name);

    Console.WriteLine();
  }
  static void PrintFields(Type type)
  {
    Console.WriteLine("-------- Fields --------");

    FieldInfo[] fields = type.GetFields(
      BindingFlags.NonPublic |
      BindingFlags.Public |
      BindingFlags.Static |
      BindingFlags.Instance
    );


    foreach (FieldInfo field in fields)
    {
      String accessLevel = "protected";
      if (field.IsPublic) accessLevel = "public";
      else if (field.IsPrivate) accessLevel = "private";

      Console.WriteLine("Access:{0}, Type:{1}, Name:{2}", accessLevel, field.FieldType.Name, field.Name);
    }

    Console.WriteLine();
  }
  static void PrintMethods(Type type)
  {
    Console.WriteLine("-------- Methods --------");

    MethodInfo[] methods = type.GetMethods();
    foreach (MethodInfo method in methods)
    {
      Console.Write("Type:{0}, Name:{1}, Parameter:", method.ReturnType.Name, method.Name);

      ParameterInfo[] args = method.GetParameters();
      for (int i = 0; i < args.Length; i++)
      {
        Console.Write("{0}", args[i].ParameterType.Name);
        if (i < args.Length - 1)
          Console.Write(", ");
      }
      Console.WriteLine();
    }
    Console.WriteLine();
  }
  static void PrintProperties(Type type)
  {
    Console.WriteLine("-------- Properties --------");

    PropertyInfo[] properties = type.GetProperties();
    foreach (PropertyInfo property in properties)
      Console.WriteLine("Type:{0}, Name:{1}", property.PropertyType.Name, property.Name);

    Console.WriteLine();
  }
  static void PrintConstructors(Type type)
  {
    Console.WriteLine("-------- Constructors --------");

    ConstructorInfo[] constructors = type.GetConstructors();
    foreach (ConstructorInfo constructor in constructors)
      Console.WriteLine("Type:{0}", constructor.Name);

    Console.WriteLine();
  }

  static void Main(string[] args)
  {
    int a = 0;
    Type type = a.GetType();

    PrintInterfaces(type);
    PrintFields(type);
    PrintProperties(type);
    PrintMethods(type);
    PrintConstructors(type);
  }
}

/*실행 결과

-------- Interfaces --------
Name:IComparable
Name:IConvertible
Name:IFormattable
Name:IComparable`1
Name:IEquatable`1
Name:ISpanFormattable

-------- Fields --------
Access:private, Type:Int32, Name:m_value
Access:public, Type:Int32, Name:MaxValue
Access:public, Type:Int32, Name:MinValue

-------- Properties --------

-------- Methods --------
Type:Int32, Name:CompareTo, Parameter:Object
Type:Int32, Name:CompareTo, Parameter:Int32
Type:Boolean, Name:Equals, Parameter:Object
Type:Boolean, Name:Equals, Parameter:Int32
Type:Int32, Name:GetHashCode, Parameter:
Type:String, Name:ToString, Parameter:
Type:String, Name:ToString, Parameter:String
Type:String, Name:ToString, Parameter:IFormatProvider
Type:String, Name:ToString, Parameter:String, IFormatProvider
Type:Boolean, Name:TryFormat, Parameter:Span`1, Int32&, ReadOnlySpan`1, IFormatProvider
Type:Int32, Name:Parse, Parameter:String
Type:Int32, Name:Parse, Parameter:String, NumberStyles
Type:Int32, Name:Parse, Parameter:String, NumberStyles, IFormatProvider
Type:Int32, Name:Parse, Parameter:ReadOnlySpan`1, NumberStyles, IFormatProvider
Type:Boolean, Name:TryParse, Parameter:ReadOnlySpan`1, Int32&
Type:Boolean, Name:TryParse, Parameter:String, NumberStyles, IFormatProvider, Int32&
Type:TypeCode, Name:GetTypeCode, Parameter:
Type:Type, Name:GetType, Parameter:

-------- Constructors --------

*/