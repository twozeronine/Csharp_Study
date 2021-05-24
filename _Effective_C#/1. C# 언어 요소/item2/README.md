# 1장 언어요소

## 아이템 2: const보다는 readonly가 좋다

C#은 컴파일타임 상수와 런타임 상수 두 유형의 상수를 가진다.

| const                                                  | readonly                                                               |
| :----------------------------------------------------- | :--------------------------------------------------------------------- |
| 컴파일 타임 상수                                       | 런타임 상수                                                            |
| 컴파일 타임에 변수가 값으로 대체됨                     | 컴파일 타임에 값으로 대체되는 것이 아닌, 상수에 대한 '참조'로 컴파일됨 |
| 메서드 내부에서도 선언이 가능                          | 메서드 내에서는 선언 불가능                                            |
| 내장된 숫자형, enum, 문자열, null에 대해서만 사용 가능 | 어떤 타입도 가능                                                       |
| readonly보다 약간 더 빠르다.                           | const보다 약간 더 느리다.                                              |

```C#
// 컴파일타임 상수:
public const int Millennium = 2000;

// 런타임 상수:
public static readonly int ThisYear = 2000;

// 컴파일되지 않는다. 대신 readonly를 사용해야 한다.
private const DateTime classCreation = new DateTime(2000,1,1,0,0,0);
```

- 런타임 상수는 상수의 값이 런타임에 평가된다. 컴파일타임 상수는 다른 어셈블리의 참조 여부와 상관없이 항상 숫자나 문자열 등을 직접 사용한 것과 완전히 동일한 IL코드를 생성한다.
  - 이러한 차이로 인해 유지 및 보수에 상당한 영양을 준다.

```C#

//Infrastructure라는 어셈블리 내에 정의한 필드.
public class UsefulValues
{
  public static readonly int StartValue = 5;
  public const int EndValue = 10;
}

//다른 어셈블리에서 이 값들을 사용함.
for (int i= UsefulValues.StartValue; i< UsefulValues.EndValue; i++ )
  Console.WriteLine("value is {0}", i);

//출력 결과
Value is 105
Value is 106
...
Value is 119

//Infrastructure 어셈블리를 수정.
public class UsefulValues
{
  public static readonly int StartValue = 105;
  public const int EndValue = 120;
}

// 응용프로그램 전체를 리빌드하지 않고 Infrastructure만 리빌드.
// 그리고 기대한 출력 값.
Value is 105
Value is 106
...
Value is 119

```

하지만 실제로 수행하면 아무런 결과도 출력되지 않는다. 종료 조건에서 사용한 EndValue 값은 여전히 수정하기 이전 값인 10을 계속해서 사용하기 때문이다. 왜냐하면 C# 컴파일러는 const를 사용하는 컴파일타임 상수에 대해서는 참조 코드를 생성하지 않고 값으로 대체해버리기 때문이다.

이처럼 컴파일 타임 상수의 값을 수정할 때는 신중해야 하며, 모든 코드를 재컴파일해야 한다. 그리하여 몇 가지 예외적인 상황을 제외한다면 대부분의 경우 const보다는 readonly를 사용하는 것이 좋다.
