using System;
using System.Collections;

class MainApp
{
  static void Main(string[] args)
  {
    Hashtable hashtable = new Hashtable();
    hashtable["하나"] = "one";
    hashtable["둘"] = "two";
    hashtable["셋"] = "three";
    hashtable["넷"] = "four";
    hashtable["다섯"] = "five";

    Console.WriteLine(hashtable["하나"]);
    Console.WriteLine(hashtable["둘"]);
    Console.WriteLine(hashtable["셋"]);
    Console.WriteLine(hashtable["넷"]);
    Console.WriteLine(hashtable["다섯"]);
  }
}

/*실행 결과
one
two
three
four
five
*/