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
