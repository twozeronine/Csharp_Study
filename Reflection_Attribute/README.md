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
