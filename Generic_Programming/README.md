## [CopyingArray.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Generic_Programming/CopyingArray.cs)

Generic Method

일반화 메소드는 데이터 형식을 일반화한 메소드이다. 일반화할 형식이 들어갈 자리에 구체적인 형식의 이름 대신 <형식 매개변수>(보통은 type을 뜻하는 T를 입력한다 )를 입력하면 된다.

## [Generic.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Generic_Programming/Generic.cs)

Generic Class

일반화 클래스는 데이터 형식을 일반화한 클래스이다. 일반화 클래스도 형식 매개변수가 있는 것을 제외하면 보통의 클래스와 똑같다.

## [ConstraintsOnTypeParameters.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Generic_Programming/ConstraintsOnTypeParameters.cs)

형식 매개변수 제약시키기

형식 매개변수 T는 "모든" 데이터 형식을 대신할 수 있다. 하지만 종종 특정 조건을 갖춘 형식에만 대응하는 형식 매개변수가 필요할 때도 있다. 이때 형식 매개변수의 조건에 제약을 줄 수 있다.

| 제약                         | 설명                                                                                                              |
| :--------------------------- | :---------------------------------------------------------------------------------------------------------------- |
| where T : struct             | T는 값 형식이어야 함.                                                                                             |
| where T : class              | T는 참조 형식이어야 함.                                                                                           |
| where T : new()              | T는 반드시 매개변수가 없는 생성자가 있어야 함.                                                                    |
| where T : 기반\_클래스\_이름 | T는 명시한 기반 클래스의 파생 클래스여야 함.                                                                      |
| where T : 인터페이스\_이름   | T는 명시한 인터페이스를 반드시 구현해야 합니다. 인터페이스\_이름에는 여러 개의 인터페이스를 명시할 수도 있습니다. |
| where T : U                  | T는 또 다른 형식 매개변수 U로부터 상속받은 클래스여야 합니다.                                                     |

## Generic Collections

일반화 컬렉션. 컴파일할 때 컬렉션에서 사용할 형식이 결정되고, object형식 기반의 컬렉션과는 다르게 쓸데없는 형식 변환을 일으키지 않는다.

### [UsingGenericList.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Generic_Programming/UsingGenericList.cs)

Generic List

### [UsingGenericQueue.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Generic_Programming/UsingGenericQueue.cs)

Generic Queue

### [UsingGenericStack.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Generic_Programming/UsingGenericStack.cs)

Generic Stack

### [UsingGenericDictionary.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Generic_Programming/UsingGenericDictionary.cs)

Generic Dictionary

## [EnumeralbeGeneric.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Generic_Programming/EnumeralbeGeneric.cs)

foreach를 사용할 수 있는 일반화 클래스.

Generic class도 IEnumerable 인터페이스를 상속하여 foreach를 통해 순회할 수 있지만, 요소를 순회할 때마다 형식 변환을 수행하는 오버로드가 발생한다. 때문에 IEnumerable의 일반화 버전인 IEnumeralbe\<T> 인터페이스를 사용하여 형식 변환으로 인한 성능 저하 문제를 해결 할 수 있다.
