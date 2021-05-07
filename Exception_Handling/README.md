## [KillingProgram.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Exception_Handling/KillingProgram.cs)

예외에 대하여

프로그래머가 생각하는 시나리오에서 벗어나는 사건을 예외(Exceptio)라고 한다. 그리고 예외가 프로그램의 오류나 다운으로 이어지지 않도록 적절하게 처리하는 것을 예외 처리(Exception Handling)라고 한다.

## [TryCatch.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Exception_Handling/TryCatch.cs)

try~catch로 예외 받기

try절의 코드 블록에서 예외가 일어나지 않을 경우에 실행되어야 할 코드들이 들어가고, catch절에는 예외가 발생했을 때의 처리 코드가 들어간다.

### System.Exception 클래스

모든 예외의 조상. C#에서 모든 예외 클래스는 반드시 이 클래스로부터 상속받아야 한다. 고로 여러 가지 예외 형식을 사용할 것 없이 System.Exception 클래스를 사용해도 된다고 생각할 수 있지만 예외 상황에 따라 섬세한 예외 처리를 해줘야한다.

## [Throw.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Exception_Handling/Throw.cs)

## [ThrowExpression.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Exception_Handling/ThrowExpression.cs)

예외 던지기

throw문을 사용하여 예외를 던질 수 있다. C# 7.0부터는 식으로도 사용할 수 있도록 개선되었다.

## [Throw.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Exception_Handling/Throw.cs)
