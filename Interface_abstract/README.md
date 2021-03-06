## [Interface.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Interface_abstract/Interface.cs)

인터페이스

접근 제한 한정자는 모두 public으로 선언된다.  
메소드, 이벤트, 인덱서, 프로퍼티만 가질수있다.
인스턴스를 못 만들지만, 파생 클래스의 객체의 위치를 담는 참조는 가능하다.

## [DerivedInterface.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Interface_abstract/DerivedInterface.cs)

인터페이스를 상속하는 인터페이스

클래스, 구조체, 인터페이스 모두 인터페이스를 상속할 수 있다.

> [인터페이스를 가진 구조체 설계시 주의점](https://www.csharpstudy.com/Mistake/Article/10)

### 인터페이스 상속을 사용하는 경우

1. 새로운 기능을 추가한 인터페이스를 만들고 싶을 때 상속하려는 인터페이스가 소스 코드가 아닌 어셈블리로 제공되는 경우 어셈블리 안에 있는 인터페이스를 수정할 수 없기 때문에 상속하는 방법을 사용한다.
2. 이미 인터페이스를 상속하는 기존 클래스들이 존재할때 해당 인터페이스에 새로운 기능을 추가하면 기존 클래스들에서 구현해 주어야함.이때 기존의 소스 코드에 영향을 주지 않고 새로운 기능을 추가하고 싶을때 인터페이스를 상속.

## [MultiInterfaceInheritance.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Interface_abstract/MultiInterfaceInheritance.cs)

다중 상속 인터페이스

인터페이스는 다중 상속이 가능하다.
클래스는 여러 클래스를 한꺼번에 상속할 수 없음, "죽음의 다이아몬드"라는 문제 때문인데 이 문제를 해결하기 위한 방법으로 인터페이스 사용.

> [죽음의 다이아몬드](https://ansohxxn.github.io/c%20sharp/ch9-2/)

## [DefaultImplementation.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Interface_abstract/DefaultImplementation.cs)

인터페이스 기본 구현 메소드

인터페이스의 파생 클래스가 수없이 많이 생겼을때, 이와 같은 인터페이스 (레거시 코드)를 새 메소드를 추가하여 업그레이드 해야 할때
기본적인 구현체를 가진 기본 구현 메소드를 사용하여 파생 클래스에서의 컴파일 에러를 막을 때 사용한다.

## [AbstractClass.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Interface_abstract/AbstractClass.cs)

추상 클래스

일반 클래스처럼 구현과 더불어 추상 메소드를 가지고 있음.
추상 클래스는 또 다른 추상 클래스를 상속할 수 있음. 하지만 파생 클래스에서의 다중 상속은 불가능함.

|             | 인터페이스                       | 추상클래스                                                |
| :---------: | :------------------------------- | :-------------------------------------------------------- |
| 접근 지정자 | 기본적으로 public                | 기본 적으로 private이지만 , 추상 메소드는 private 불가능. |
|    구현     | 구현이 아닌 서명만 가질 수 있다. | 구현을 제공할 수 있다.                                    |
| 인스턴스화  | 불가능                           | 불가능                                                    |
|    필드     | 불가능                           | 필드와 상수 정의 가능                                     |
|   메소드    | 추상메소드만 있음.               | 비추상메소드 있을 수 있음.                                |
