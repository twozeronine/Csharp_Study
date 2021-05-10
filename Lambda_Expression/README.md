## [SimpleLambda.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Lambda_Expression/SimpleLambda.cs)

람다식

람다식은 익명 메소드를 만들기 위해 사용한다. 다만, 람다식으로 만드는 익명 메소드는 무명 함수라는 이름으로 부른다. C# 2.0에 익명 메소드가 이미 있지만 람다식은 C# 3.0에 도입됐다.

## [StatementLambda.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Lambda_Expression/StatementLambda.cs)

문 형식의 람다식

반환 형식이 없는 무명 함수를 람다식을 이용해서 만들수있다.

## [FuncTest.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Lambda_Expression/FuncTest.cs)

## [ActionTest.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Lambda_Expression/ActionTest.cs)

Func와 Action으로 더 간편하게 무명 함수 만들기

매번 별개의 대리자를 선언하고 익명 메소드나 무명 함수를 만든다면 번거롭기 때문에 마이크로소프트는 .NET에 Func와 Action 대리자를 미리 선언해뒀다. Func는 반환 형식이 존재하고 Action은 반환 형식이 없다는 차이점이 있다.

## [UsingExpressionTree.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Lambda_Expression/UsingExpressionTree.cs)

## [ExpressionTreeViaLambda.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Lambda_Expression/ExpressionTreeViaLambda.cs)

식 트리

식 트리 자료구조는 컴파일러나 인터프리터를 제작하는 데도 응용된다. 완전한 C# 컴파일러는 아니지만, C#은 프로그래머가 C# 코드 안에서 직접 식 트리를 조립하고 컴파일해서 사용할 수 있는 기능을 제공한다. 다시 말해. 프로그램 실행 중에 동적으로 무명함수를 만들어 사용할 수 있게 해준다.

식 트리를 다루는 데 필요한 클래스들은 System.Linq.Expressions 네임스페이스 안에 준비되어 있다.  
[System.Linq.Expressions 네임스페이스](https://docs.microsoft.com/ko-kr/dotnet/api/system.linq.expressions?view=net-5.0)

Expression 클래스 자신은 abstract로 선언되어 자신의 인스턴스는 만들 수 없지만, 파생 클래스의 인스턴스를 생성하는 정적 팩토리 메소드를 제공한다.

식 트리는 코드를 데이터로서 보관이 가능하다. 파일에 저장할 수도 있으며 네트워크를 통해 전달할 수도 있다. 심지어 식트리 데이터를 데이터베이스 서버에 보내서 실행시킬 수도 있다. 데이터베이스 처리를 위한 식 트리는 LINQ에서 사용된다.
