using System;

struct ACSetting
{
  public double currentInCelsius; // 현재 온도 (C);
  public double target; // 희망 온도
  // public readonly double GetFahrenheit()
  // {
  //   //화씨(F) 계산 결과를 target에 저장
  //   //error CS1604: 읽기 전용인 'target'에는 할당할 수 없습니다.
  //   // target = currentInCelsius * 1.6 + 32;
  //   return target; // target 반환
  // }
  public readonly double GetFahrenheit() => currentInCelsius * 1.6 + 32;
}