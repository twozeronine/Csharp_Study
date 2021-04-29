## [Propety.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Property/Property.cs)

프로퍼티

C#에서는 은닉성 유지를 위해 Get/Set 메소드를 구현 하지않고 프로퍼티를 사용하여 구현한다.

## AutoImplementedProperty.cs

자동 구현 프로퍼티

C# 3.0에서 도입된 기능, C# 7.0부터는 자동 구현 프로퍼티를 선언함과 동시에 초기화를 수행할 수 있다.

## ConstructorWithProperty.cs

프로퍼티와 생성자

객체를 생성할 때 초기화 하고 싶은 프로퍼티만 넣어서 초기화 할 수 있다.

## InitOnly.cs

Init-only 자동 구현 프로퍼티

기존에 프로퍼티를 읽기 전용으로 선언하고 초기화하는 방법이 불편했기 때문에 C# 9.0에서 초기화 전용 자동 구현 프로퍼티를 간편하게 선언할 수 있다.

## Record.cs

레코드 형식

C# 9.0에서 도입된 기능으로 불변 객체에서 빈번하게 이뤄지는 두 가지 연산 ( 기존 불변 객체를 복사해 새로운 객체 만들기, 상태를 확인하기 위해 객체 내용 비교하기 )를 편리하게 수행할 수 있도록 함.

## WithExp.cs

with를 이용한 레코드 복사

C# 컴파일러는 레코드 형식을 위한 복사 생성자를 자동으로 작성함. 사용할 때 with 식을 이용하여 사용함.

## RecordComp.cs

레코드 객체 비교하기

레코드는 참조 형식이지만 값 형식처럼 Equals() 메소드를 구현하지 않아도 비교가 가능하다.
