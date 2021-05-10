1. ## [From.cs](https://github.com/twozeronine/Csharp_Study/blob/main/LINQ/From.cs)
2. ## [SimpleLinq.cs](https://github.com/twozeronine/Csharp_Study/blob/main/LINQ/SimpleLinq.cs)

LINQ의 기본: from, where, orderby ,select

메소드를 비롯하여 속성(인덱서), 생성자, 종료자는 공통된 특징으로 클래스의 멤버로서 본문이 중괄호{}로 만들어져 있다. 이러한 멤버의 본문을 식만으로 구현할 수 있는데, 이렇게 식으로 구현된 멤버를 영어로는 "Expression-Bodied Member"라고 한다.

### LINQ의 범위 변수와 foreach 문의 반복 변수의 차이점

foreach 문의 반복 변수는 데이터 원본으로부터 데이터를 담아내지만, 범위 변수는 실제로 데이터를 담지는 않습니다. 그래서 쿼리식 외부에서 선언된 변수에 범위 변수의 데이터를 복사해 넣는다든가 하는 일은 할 수 없다. 범위 변수는 오로지 LINQ 질의 안에서만 통용되며, 질의가 실행될 때 어떤 일이 일어날지를 묘사하기 위해 도입됐기 때문이다.

## [FromFrom.cs](https://github.com/twozeronine/Csharp_Study/blob/main/LINQ/FromFrom.cs)

여러 개의 데이터 원본에 질의하기

여러 개의 데이터 원본에 접근하려면 from문을 중첩해서 사용하면 된다.

## [GroupBy.cs](https://github.com/twozeronine/Csharp_Study/blob/main/LINQ/GroupBy.cs)

group by로 데이터 분류하기

group by 절을 통하여 데이터를 분류할 수 있다.  
group A by B into C // A에는 from 절에서 뽑아낸 범위 변수, B에는 분류 기준 , C에는 그룹 변수를 위치시키면 된다.

## [Join.cs](https://github.com/twozeronine/Csharp_Study/blob/main/LINQ/Join.cs)

두 데이터 원본을 연결하는 join

각 데이터 원본에서 특정 필드의 값을 비교하여 일치하는 데이터끼리 연결을 수행한다.

### 내부 조인

내부 조인은 교집합과 비슷하다. 내부 조인은 첫 번째 데이터 원본과 두 번째 데이터 원본의 특정 필드를 비교해서 일치하는 데이터를 반환한다.

```C#
from a in A
join b in B on a.XXXX equals b.YYYY
```

기준 데이터 a는 from 절에서 뽑아낸 범위 변수이고, 연결 대상 데이터 b는 join절에서 뽑아낸 변수이다. join절의 on 키워드는 조인 조건을 수반한다. 이때 on 절의 조인 조건은 "동등(Equality)"만 허용된다.

### 외부 조인

외부 조인은 기본적으로 내부 조인과 비슷하지만 조인 결과에 기준이 되는 데이터 원본이 모두 포함된다는 점이 다르다.

> LINQ는 원래 DBMS에서 사용하던 SQL을 본떠 프로그래밍 언어 안에 통합한 것이다. LINQ의 외부 조인은 SQL에서 본떠서 만든것인데, 왼쪽 조인, 오른쪽 조인, 완전 외부 조인 이렇게 3가지 방식중에서 왼쪽 조인만을 지원한다.

## [SimpleLinq2.cs](https://github.com/twozeronine/Csharp_Study/blob/main/LINQ/SimpleLinq2.cs)

LINQ 표준 연산자

마이크로소프트는 LINQ 쿼리식이 실행될 수 있도록 CLR을 개선하는 대신, C# 컴파일러와 VB 컴파일러를 업그레이드했다. 이들 컴파일러가 각각 LINQ 쿼리식을 CLR이 이해할 수 있는 코드로 번역해주도록 만들었다.

```C#
    var profiles = from     profile in arrProfile
                   where    profile.Height < 175
                   orderby  profile.Height
                   select   new { Name = profile.Name , Height = profile.Height };
```

> C# 컴파일러는 다음과 같은 코드로 번역한다.

```C#
    var profiles = arrProfile
                      .Where(  profile => profile.Height < 175 )
                      .OrderBy(profile => profile.Heigth )
                      .Select( profile =>
                              new
                              {
                                  Name   =  profile.Name,
                                  Height =  profile.Height
                              });
```
