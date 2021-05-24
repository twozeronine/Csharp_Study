# 1장 언어요소

## 아이템 1: 지역변수를 선언할 때는 var를 사용하는 것이 낫다.

C# 언어에서는 지역변수의 타입을 암시적으로 선언할 수 있게 익명 타입(anonymous type)을 지원한다.

- 지역변수에 대한 타입 추론이 C#의 고유 특성이라 할 수 있는 정적 타이핑을 훼손하는 것은 아니다.

  - 이를 이해하려면 지역변수에 대한 타입 추론과 동적 타이핑이 서로 다른 것임을 알아야한다.
  - C#에서 특정 변수를 var로 선언하면 할당 연산자 오른쪽의 타입을 확인하여 왼쪽 변수의 타입을 결정하게 된다.

|           |                              동적 타이핑                              |                        정적 타이핑                         |
| :-------- | :-------------------------------------------------------------------: | :--------------------------------------------------------: |
| 특징      |                        자료형을 런타임 시 결정                        |                자료형을 컴파일 당시에 결정                 |
| 단점      | 런타임 진행 시 예상치 못한 에러가 발생할 수 있고 이를 발견하기 어려움 | 컴파일 진행시 자료형에 맞지 않은 값이 전달되면 컴파일 에러 |
| 주요 언어 |                           C, C++, Java, C#                            |                  Python, Ruby, javascript                  |

- 코드를 읽을 때도 var를 사용하여 암시적으로 변수를 선언한 코드가 더 잘 읽힌다.

  - 변수의 의미에 좀 더 집중할 수 있다.

```C#
// 메서드 이름만으로 반환 타입을 짐작하기 어렵다.
var result = someObject.DoSomeWork( anotherParameter );

// 변수명을 바꿔 그 의미를 더 명확하게 드러낼 수 있다.
// Product 타입임을 미루어 짐작 가능.
var HightestSellingProduct = someObject.DoSomeWork( anotherParameter );
```

- 정확한 반환 타입을 알지 못한 채 올바르지 않은 타입을 명시적으로 지정하게 되면 득보다 실이 많다.

  - 예를 들어 IQueryable\<T> 컬렉션을 IEnumerable\<T>로 명시하여 강제 형변환하게 되면 IQueryProvider가 제공하는 장점을 모두 잃게 된다.

```C#
public IEnumerable<string> FindCustomersStartingWith1(string start)
{

  IEnumerable<string> q =
        from c in db.Customers // db에서 쿼리가 수행되면 LINQ쿼리는 실제로 IQueryable<string> 타입을 반환.
        select c.ContactName;
  var q2 = q.Where(s => s.StartWith(start)); // Enumerable.Where가 호출됨.
  return q2;
}
```

위 코드에서 개발자가 q를 IEnumerabl\<string>으로 선언하여 IQueryable\<string>과 관련된 장점을 모두 잃게됨.

```C#
public IEnumerable<string> FindCustomersStartingWith1(string start)
{

  var q =
        from c in db.Customers
        select c.ContactName;
  var q2 = q.Where(s => s.StartWith(start));
  return q2;
}
```

위 코드에서 첫 번째 LINQ 쿼리 문장이 수행되면 데이터베이스가 있는 원격지로 아무런 SQL 쿼리도 전달하지 않는다.  
두 번째 LINQ 쿼리 문장을 수행하면 앞서 첫 번째 LINQ 쿼리에 where 절을 추가하여 완성된 SQL 쿼리 구문을 작성하게 된다. 이번에는 호출자가 쿼리의 결과를 이용하여 그 값을 순회하는 시점까지 SQL 쿼리의 수행이 연기된다. 결과를 필터링하는 where절까지 포함된 SQL 쿼리가 원격지로 전달되므로 돌아오는 결과에는 조건문에 따라 필터링된 연락처의 이름만 포함된다.  
결과적으로 네트워크 트레픽을 적게 쓰고 효율적인 쿼리를 수행한다.

---

### 주의할 점

- 개발자가 코드를 읽을 때 변수의 타입을 쉽사리 짐작할 수 없는 경우에는 명시적으로 타입을 기술하는 편이 낫다.
  - 짐작한 타입과 컴파일러가 실제로 추론한 타입이 달라서 문제가 되는 경우도 있다.

```C#
var f =GetMagicNumber(); // total은 GetMagicNumber() 메서드의 반환 타입에 의해 결정된다.
var total = 100 * f / 6;
Console.WriteLine($"Declared Type: {total.GetType().Name}, Value: {total}");

// 이럴때는 total의 타입을 명시적으로 선언해주자.
double total = 100 * GetMagicNumber() / 6 ;

```
