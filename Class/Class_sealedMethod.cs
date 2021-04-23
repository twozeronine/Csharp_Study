using System;

class Base3
{
  public virtual void SealMe()
  {

  }
}

class Derived3 : Base3
{
  public sealed override void SealMe()
  {

  }
}

class WantToOverride : Derived3
{
  // public override void SealMe()
  // {
  // }
  //error CS0239: 'WantToOverride.SealMe()': 상속된 'Derived3.SealMe()' 멤버는 봉인되어 있으므로 재정의할 수 없습니다.
}