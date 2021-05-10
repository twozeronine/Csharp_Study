using System;
using System.Reflection;

class Profile
{
  private string name;
  private string phone;
  public Profile()
  {
    name = ""; phone = "";
  }

  public Profile(string name, string phone)
  {
    this.name = name;
    this.phone = phone;
  }

  public void Print() => Console.WriteLine($"{name}, {phone}");

  public string Name
  {
    get => name;
    set => name = value;
  }

  public string Phone
  {
    get => phone;
    set => phone = value;
  }
}

class MainApp
{
  static void Main(string[] args)
  {
    Type type = Type.GetType("Profile");
    MethodInfo methodInfo = type.GetMethod("Print");
    PropertyInfo nameProperty = type.GetProperty("Name");
    PropertyInfo phoneProperty = type.GetProperty("Phone");

    object profile = Activator.CreateInstance(type, "사이온", "123-4567");
    methodInfo.Invoke(profile, null);

    profile = Activator.CreateInstance(type);
    nameProperty.SetValue(profile, "아이번", null);
    phoneProperty.SetValue(profile, "997-1312", null);

    Console.WriteLine("{0}, {1}",
        nameProperty.GetValue(profile, null),
        phoneProperty.GetValue(profile, null));

    Console.WriteLine($"{(Profile)profile.Name} , {(Profile)profile.Phone}");
  }
}

/*실행 결과
사이온, 123-4567
아이번, 997-1312
*/