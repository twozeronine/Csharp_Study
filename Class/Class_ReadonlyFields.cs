using System;

class Configuration
{
  // readonly를 이용해서 읽기 전용 필드를 선언합니다.
  private readonly int min;
  private readonly int max;

  public Configuration(int v1, int v2)
  {
    //읽기 전용 필드는 생성자 안에서만 초기화 가능
    min = v1;
    max = v2;
  }

  public void ChangeMax(int newMax)
  {
    //생성자가 아닌 다른 곳에서 값을 수정하려하면 컴파일 에러가 발생합니다!
    //error CS0191: 읽기 전용 필드에는 할당할 수 없습니다. 단, 필드가 정의된 형식의 생성자 또는 초기값 전용 setter나 변수 이니셜라이저에서는 예외입니다.
    max = newMax;
  }
}


class MainApp
{
  static void Main(string[] args)
  {
    Configuration c = new Configuration(100, 10);
  }
}
