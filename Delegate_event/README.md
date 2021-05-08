## [Delegate.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Delegate_event/Delegate.cs)

대리자 delegate란?

C#에서는 콜백을 맡아 실행하는 일을 '대리자'가 담당함. 대리자는 메소드에 대한 참조임. 대리자에 메소드의 주소를 할당한 후 대리자를 호출하면 이 대리자가 메소드를 호출한다.

## [UsingCallBack.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Delegate_event/UsingCallBack.cs)

대리자는 왜, 그리고 언제 사용하는가에 대하여

프로그래밍을 하다 보면 "값"이 아닌 "코드" 자체를 매개변수에 넘기고 싶을 때가 많다. 예를 들어서 배열을 정렬하는 메소드를 만든다고 할때 오름차순으로 정렬할지 내림차순으로 정렬할지, 이 메소드가 정렬을 수행할 때 사용하는 비교 루틴을 매개변수에 넣을 수 있다면 이런 문제가 해결된다. 그게 바로 대리자 Delegate의 쓰임새이다.

## [GenericDelegate.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Delegate_event/GenericDelegate.cs)

일반화 대리자

> 일반화 메소드에서 값을 비교하기 위해 쓰이는 CompareTo()메소드, 소스코드에 IComparable\<T>에 대한 설명을 추가하였으니 꼭 확인해보자 !!  
> IComparable\<T>을 상속받는 [int](https://docs.microsoft.com/ko-kr/dotnet/api/system.int32?view=net-5.0), [Double](https://docs.microsoft.com/ko-kr/dotnet/api/system.double?view=net-5.0), [String](https://docs.microsoft.com/ko-kr/dotnet/api/system.string?view=net-5.0)과 같은 형식들은 모두 내부적으로 CompareTo() 메소드를 구현했기 때문에 사용 가능하다.

대리자는 보통의 메소드뿐 아니라 일반화 메소드도 참조할 수 있다. 물론 이 경우에는 대리자도 일반화 메소드를 참조할 수 있도록 형식 매개변수를 이용하여 선언해야함.

## [DelegateChains.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Delegate_event/DelegateChains.cs)

대리자 체인

대리자에는 재미있는 속성으로 대리자 하나가 여러 개의 메소드를 동시에 참조할 수 있다. 결합해놓은 대지라를 호출하면 데리자 체인을 따라 차례대로 연결된 메소드들이 호출된다.

## [AnonymousMethod.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Delegate_event/AnonymousMethod.cs)

익명 메소드

익명 메소드란 이름이 없는 메소드를 말합니다. 익명 메소드는 특정 상황에서 유용하게 사용할 수 있습니다.
