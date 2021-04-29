using System;

readonly struct RGBColor
{
  public readonly byte R;
  public readonly byte G;
  public readonly byte B;

  public RGBColor(byte r, byte g, byte b)
  {
    R = r;
    G = g;
    B = b;
  }
}


class MainApp
{
  static void Main(string[] args)
  {
    RGBColor Red = new RGBColor(255, 0, 0);
    Red.G = 100; //컴파일 에러 
  }
}

//실행 결과
//읽기 전용 필드에는 할당할 수 없습니다. 단, 필드가 정의된 형식의 생성자 또는 초기값 전용 setter나 변수 이니셜라이저에서는 예외입니다.
// Red.G = 100; //컴파일 에러 