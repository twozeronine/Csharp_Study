리플렉션

리플렉션은 객체를 X-Ray 사진처럼 객체의 형식(type) 정보를 들여다보는 기능이다. 이 기능을 이용하면 우리는 프로그램 실행 중에 객체의 형식 이름부터 프로퍼트 목록, 메소드 목록, 필드, 이벤트 목록까지 모두 열어볼 수 있다. 형식의 이름만 있다면 동적으로 인스턴스를 만들 수도 있고, 그 인스턴스의 메소드를 호출할 수도 있다.

## [GetType.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Reflection_Attribute/GetType.cs)

### Object.GetType() 메소드와 Type 클래스

Object는 모든 데이터 형식의 조상이다. 즉 모든 데이터 형식은 Object 형식이 갖고 있는 다음의 메소드를 물려 받아 갖고 있다.

- Equals()
- GetHashCode()
- GetType()
- ReferenceEquals()
- ToString()

GetType() 메소드는 Type 형식의 결과를 반환한다.

다음은 Type형식의 메소드다.

| 메소드                | 반환 형식         | 설명                                               |
| :-------------------- | :---------------- | :------------------------------------------------- |
| GetConstructors()     | ConstructorInfo[] | 해당 형식의 모든 생성자 목록을 반환합니다.         |
| GetEvents()           | EventInfo[]       | 해당 형식의 이벤트 목록을 반환합니다.              |
| GetFields()           | FieldInfo[]       | 해당 형식의 필드 목록을 반환합니다.                |
| GetGenericArguments() | Type[]            | 해당 형식의 형식 매개변수 목록을 반환합니다.       |
| GetInterfaces()       | Type[]            | 해당 형식이 상속하는 인터페이스 목록을 반환합니다. |
| GetMembers()          | MemberInfo[]      | 해당 형식의 멤버 목록을 반환합니다.                |
| GetMethods()          | MethodInfo[]      | 해당 형식의 메소드 목록을 반환합니다.              |
| GetNestedTypes()      | Type[]            | 해당 형식의 내장 형식 목록을 반환합니다.           |
| GetProperties()       | PropertyInfo[]    | 해당 형식의 프로퍼티 목록을 반환합니다.            |

> 훨씬더 많은 기능은 [MSDN Type클래스](https://docs.microsoft.com/ko-kr/dotnet/api/system.type?view=net-5.0)

## [DynamicInstance.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Reflection_Attribute/DynamicInstance.cs)

### 리플렉션을 이용해서 객체 생성하고 이용하기

리플렉션을 사용하여 특정 형식의 인스턴스를 만들고 데이터를 할당하며 메소드를 호출 할 수 있다. 리플렉션을 이용해서 동적으로 인스턴스를 만들기 위해서는 System.Activator 클래스의 도움이 필요하다. 인스턴스를 만들고자 하는 형식의 Type 객체를 매개변수에 넘기면, Activator.CreateInstance() 메소드는 입력받은 형식의 인스턴스를 생성하여 반환한다.

```C#
object a = Activator.CreateInstance(typeof(int));
```

일반화를 지원하는 버전의 CreateInstance() 메소드

```C#
List<int> list = Activator.CreateInstance<List<int>>();
```

## [EmitTest.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Reflection_Attribute/EmitTest.cs)

### 형식 내보내기

리플렉션을 이용하면 프로그램 실행 중에 원하는 형식의 정보를 읽어낼 수 있을 뿐 아니라, 그 형식의 인스턴스도 만들 수 있으며 심지어는 프로퍼티나 필드에 값을 할당하고 메소드를 호출할 수도 있습니다. 더 나아가 프로그램 실행중에 새로운 형식을 만들어낼 수 있는 기능도 제공합니다.

동적으로 새로운 형식을 만드는 작업은 System.Reflection.Emit 네임스페이스에 있는 클래스들을 통해 이루어집니다.

> [System.Reflection.Emit 네임스페이스](https://docs.microsoft.com/ko-kr/dotnet/api/system.reflection.emit?view=net-5.0)

이 클래스를 사용하는 요령은 다음 순서와 같다.

1. AssemblyBuilder를 이용해서 어셈블리를 만든다.
2. ModuleBuilder를 이용해서 1에서 생성한 어셈블리 안에 모듈을 만들어 넣는다.
3. 2에서 생성한 모듈 안에 TypeBuilder로 클래스(형식)을 만들어 넣는다.
4. 3에서 생성한 클래스 안에 메소드(MethodBuilder 이용)나 프로퍼티(PropertyBuilder 이용)을 만들어 넣는다.
5. 4에서 생성한 것이 메소드라면, ILGenerator를 이용해서 메소드 안에 CPU가 실행할 IL 명령들을 넣는다.

## [BasicAttribute.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Reflection_Attribute/BasicAttribute.cs)

### 애트리뷰트

> 메타데이터란 데이터의 데이터를 말한다. 가령 C# 코드도 데이터지만 이 코드에 대한 정보, 즉 애트리뷰트나 리플렉션을 통해 얻는 정보들도 C# 코드의 메타데이터라고 할 수 있다.

애트리뷰트는 코드에 개한 부가 정보를 기록하고 읽을 수 있는 기능이다. 주석과 다른 점은 주석은 사람이 읽고 쓰는 정보라면, 애트리뷰트는 사람이 작성하고 컴퓨터가 읽는다.

```C#
  [ 애트리뷰트_이름( 애트리뷰트_매개변수) ]
  public void MyMethod()
  {
    //..
  }
```

## [CallerInfo.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Reflection_Attribute/CallerInfo.cs)

### 호출자 정보 애트리뷰트

C# 5.0 버전 부터 호출자 정보 애트리뷰트가 도입됐다. 호출자 정보는 메소드의 매개변수에 사용되며 메소드의 호출자 이름, 호출자 메소드가 정의된 소스 파일 경로, 심지어 소스 파일 내의 행 번호까지 알 수 있다.

|         애트리뷰트         | 설명                                                                                                        |
| :------------------------: | :---------------------------------------------------------------------------------------------------------- |
| CallerMemeberNameAttribute | 현재 메소드를 호출한 메소드 또는 프로퍼티의 이름을 나타낸다.                                                |
|  CallerFilePathAttribute   | 현재 메소드가 호출된 소스 파일 경로를 나타낸다. 이때 경로는 소스 코드를 컴파일할 때의 전체 경로를 나타낸다. |
| CallerLineNumberAttribute  | 현재 메소드가 호출된 소스 파일 내의 행(Line ) 번호를 나타낸다.                                              |
