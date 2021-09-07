# 1장 언어요소

## 아이템 3: 캐스트보다는 is,as가 좋다

C#은 정적 타이핑을 수행하는 언어다. 따라서 컴파일러가 이를 걸러주기 때문에 런타임에 타입 검사를 자주 수행할 필요가 없다.

하지만 간혹 런타임에 반드시 타입을 확인해야 하는 경우도 있다.

C#에서 형변환을 수행하는 방법에는 두가지가 있다.

1. as 연산자를 사용하는 방법
2. 컴파일러의 캐스트 연산자 구문을 사용하는 방법

형변환을 수행하는 경우 캐스팅을 사용하기보다 as 연산자를 사용하는 것이 좋다.

as를 사용하는 편이 더 안전하고 런타임에 효율적으로 동작한다.

### 예제 1) 임의의 객체를 MyType으로 형변환.

```C#
object o = Factory.GetObject();

// 첫 번째 버전 :
MyType t = o as MyType;

if ( t != null )
{
    // MyType 타입의 t 객체 사용
}
else
{
    // 오류 보고
}
```

```C#
object o = Factory.GetObject();

// 두 번째 버전 :
try
{
    MyType t;
    t = (MyType)o;
    // MyType 타입의 t 객체 사용
}
catch (InvalidCastException)
{
    // 오류 보고
}
```

위 두가지의 예시코드는 모두 형변환에 실패한다.
캐스팅을 사용하면 사용자 정의 형변환 연산이 사용되어 두번째 버전의 캐스팅은 성공해야한다. 하지만 컴파일러는 런타임에 객체가 어떤 타입일지는 예측하지 못한다.

컴파일러는 단순히 컴파일 타임에 객체가 어떤 타입으로 선언됐는지만 추적하기 때문에 두번째 버전 또한 실패하게 된다.

### 가능한 한 as를 사용하는 편이 좋으나, as를 사용할 수 없는 경우에 대해서 알아보자

```C#
object o = Factory.GetValue();
int i = o as int ; // 컴파일되지 않음
```

int는 값 타입이고 null이 될 수 없다. 이럴때는 as 연산자를 그대로 이용하되 nullable 타입으로 형변환을 수행한 후 그 값이 null인지를 확인하는 편이 낫다.

```C#
object o = Factory.GetValue();
var i =0 as int ?;
if( i != null )
    Console.WriteLine(i.Value);
```
