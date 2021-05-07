using System;

class MainApp
{
  static void Main(string[] args)
  {
    int[] arr = { 1, 2, 3 };

    for (int i = 0; i < 5; i++)
      Console.WriteLine(arr[i]); // i가 "배열의 크기 -1"을 넘어서면 예외를 일으키고 종료된다. 이후에 코드는 더 이상 실행되지 않음.
  }
}

/*실행 결과
1
2
3
Unhandled exception. System.IndexOutOfRangeException: Index was outside the bounds of the array.
   at MainApp.Main(String[] args) in Main.cs:line 10
   */

//에러 메세지는 CLR이 출력한것이다.
//이 문제에 대한 상세 정보를 IndexOutOfRangeException의 객체에 담은 후 Main() 메소드에 던지는데, 
//이 예제의 Main()메소드는 이 예외를 처리할 방도가 없기 때문에 다시 CLR에 던진다.