#목차

- [깊은 복사](#class_deepcopy.cs)
- [this](#class_this.cs)
- [상속](#class_inheritance.cs)
- [typecasting](#class_typeCasting.cs)
- [오버라이딩과 다형성](#class_overriding.cs)
- [메소드 숨기기](#class_methodhiding.cs)
- [readonlyfields](#class_readonlyfields.cs)
- [중첩 클래스](#class_nestedclass.cs)
- [분할 클래스](#class_partialclass.cs)
- [확장 메소드](#class_extensionmethod.cs)
- [구조체](#class_structure.cs)
- [readonlystruct](#class_readonlystruct.cs)
- [readonlymethod](#class_readonlymethod.cs)
- [tuple](#class_tuple.cs)
- [postionalpatternopy](#Class_PostionalPattern.cs)
- [핵심 키워드](#class에서-사용되는-키워드)

## Class_deepCopy.cs

객체 깊은복사하기

클래스는 참조 형식으로 힙 메모리 영역에 객체를 할당함.
따라서 클래스로 만든 객체를 복사하기 위해서 깊은 복사 코드를 직접 만들어야함.

## Class_this.cs

this

객체 내에서 자신을 지칭할 때 사용하는 키워드.  
객체 내부에서 자신의 필드나 메소드에 접근할 때 사용한다.

## Class_Inheritance.cs

상속

sealed 한정자로 상속을 막을수있다.
파생 클래스 생성자에서 base()로 기반 클래스의 생성자 호출 가능하다.
파생 클래스와 기반 클래스 사이의 생성자와 소멸자는 호출 순서가 있다.

## Class_typeCasting.cs

기반 클래스와 파생 클래스 사이의 형식 변환

연산자 is 와 as로 형식 변환

| 연산자 |                                                     설명                                                      |
| :----: | :-----------------------------------------------------------------------------------------------------------: |
|   is   |                               객체가 해당 형식에 해당하는지 검사 bool 값 반환.                                |
|   as   | 형식 변환 연산자와 같은 역할, 형식 변환 연산자가 반환에 실패하면 예외를 던지지만 as는 객체 참조를 null로 만듬 |

## Class_overriding.cs

오버라이딩

상속받은 메소드를 다른 기능으로 재정의함.
객체지향 프로그래밍에서 다형성을 실현하게 해줌.
다형성은 객체가 여러 형태를 가질 수 있음을 의미함.
오버라이딩을 할 메소드를 virtual 키워드로 한정해야함.

## Class_methodHiding.cs

메소드 숨기기

new 키워드를 사용.
단순히 기반 클래스의 메소드를 숨기는것이기 때문에 완전한 다형성을 표현하지 못함.

## Class_ReadonlyFields.cs

클래스나 구조체에서 const와 비슷한 읽기 전용 값 readonly 상수 선언하기 생성자에서만 초기화 가능하다.

## Class_NestedClass.cs

중첩클래스

1. 클래스 외부에 공개하고 싶지 않은 형식을 만들고자 할 때
2. 현재 클래스의 빌부분처럼 표현할 수 있는 클래스를 만들고자 할 때

## Class_PartialClass.cs

분할클래스

클래스의 구현이 길어질 경우 여러 파일에 나눠서 구현할 수 있게 함.

## Class_ExtensionMethod.cs

확장메소드

기존 클래스의 기능을 확장하는 기법

## Class_Structure.cs

구조체

구조체와 클래스 차이점

| 특징          | 클래스                         | 구조체                           |
| :------------ | :----------------------------- | :------------------------------- |
| 키워드        | class                          | struct                           |
| 형식          | 참조 형식(힙에 할당)           | 값 형식(스택에 할당)             |
| 복사          | 얕은 복사(Shallow Copy)        | 깊은 복사(Deep Copy)             |
| 인스턴스 생성 | new 연산자와 생성자 필요       | 선언만으로도 생성                |
| 생성자        | 매개변수 없는 생성자 선언 가능 | 매개변수 없는 생성자 선언 불가능 |
| 상속          | 가능                           | 값 형식이므로 상속 불가능        |

### 구조체 특징

구조체의 인스턴스는 스택에 할당되고 인스턴스가 선언된 블록이 끝나는 지점의 메모리에서 사라짐.  
따라서 가비지 콜렉터 최적화에 도움.  
구조체는 매개변수가 없는 생성자는 선언할 수 없음.

## Class_ReadonlyStruct.cs

읽기 전용 구조체

구조체의 모든 필드가 readonly로 선언됨.  
불변성을 지키는 코드를 작성할때 사용할수있다.

## Class_ReadonlyMethod.cs

읽기 전용 메소드

구조체에서만 선언할수 있다.  
메소드에서 필드의 상태를 바꾸지 말아야할때 사용.

## Class_Tuple.cs

튜플

필드를 담을 수 있는 구조체.  
하지만 구조체와는 달리 튜플은 형식 이름이 없음.  
즉석에서 사용할 복합 데이터 형식을 선언할 때 적합함.
튜플 분해 가능.

## Class_PostionalPattern.cs

위치 패턴 매칭

튜플에는 분해자가 구현되어있어 분해가 가능함.
튜플 분해를 사용하여 switch 식에 적용할 수 있음.

## Class에서 사용되는 키워드

클래스

- 객체를 만들기 위한 설계도 혹은 틀

객체

- 클래스의 타입으로 선언된 실체

인스턴스

- 설계도를 바탕으로 메모리에 할당된 구체적인 실체

this,base

- this: 클래스의 현재 인스턴스를 가르킴.
- base: 파생 클래스 내에서 기반 클래스의 멤버에 엑세스 하는데 사용, 다른언어에서의 super
