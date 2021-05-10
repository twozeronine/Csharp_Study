1. ## [From.cs](https://github.com/twozeronine/Csharp_Study/blob/main/LINQ/From.cs)
2. ## [SimpleLinq.cs](https://github.com/twozeronine/Csharp_Study/blob/main/LINQ/SimpleLinq.cs)

LINQ의 기본: from, where, orderby ,select

메소드를 비롯하여 속성(인덱서), 생성자, 종료자는 공통된 특징으로 클래스의 멤버로서 본문이 중괄호{}로 만들어져 있다. 이러한 멤버의 본문을 식만으로 구현할 수 있는데, 이렇게 식으로 구현된 멤버를 영어로는 "Expression-Bodied Member"라고 한다.

### LINQ의 범위 변수와 foreach 문의 반복 변수의 차이점

foreach 문의 반복 변수는 데이터 원본으로부터 데이터를 담아내지만, 범위 변수는 실제로 데이터를 담지는 않습니다. 그래서 쿼리식 외부에서 선언된 변수에 범위 변수의 데이터를 복사해 넣는다든가 하는 일은 할 수 없다. 범위 변수는 오로지 LINQ 질의 안에서만 통용되며, 질의가 실행될 때 어떤 일이 일어날지를 묘사하기 위해 도입됐기 때문이다.

## [FromFrom.cs](https://github.com/twozeronine/Csharp_Study/blob/main/LINQ/FromFrom.cs)

여러 개의 데이터 원본에 질의하기

여러 개의 데이터 원본에 접근하려면 from문을 중첩해서 사용하면 된다.

## [FromFrom.cs](https://github.com/twozeronine/Csharp_Study/blob/main/LINQ/FromFrom.cs)

group by로 데이터 분류하기

group by 절을 통하여 데이터를 분류할 수 있다.  
group A by B into C // A에는 from 절에서 뽑아낸 범위 변수, B에는 분류 기준 , C에는 그룹 변수를 위치시키면 된다.
