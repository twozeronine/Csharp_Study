## [ArraySample.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Array_Collection_Indexer/ArraySample.cs)

배열

같은 형식의 데이터를 담는 상자와 같은 역할.

## [ArraySample2.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Array_Collection_Indexer/ArraySample2.cs)

배열 System.Index 형식과 ^연산자

C# 8.0부터 추가된 기능 System.Index 형식과 ^연산자.  
배열의 마지막 요소에 접근할 때 간편하게 할 수 있다.

```c#
1.  System.Index last = ^1;
2.  scores[last] = 34; // scores[scores.Legth-1] = 34; 와 동일
3.  scores[^1] = 34; // 위와 동일
```

## [InitializingArray.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Array_Collection_Indexer/InitializingArray.cs)

배열을 초기화 하는 방법

배열 객체를 초기화하는 { } 블록 컬렉션 초기자(Collection Initializer)를 사용하여 초기화 할 수 있다.

```c#
    // 배열을 초기화 하는 3가지 방법
1.  string[] array1 =new string[3] {"안녕","Hello","Hallo"};
2.  string[] array2 =new string[] {"안녕","Hello","Hallo"}; // 컴파일러가 첫번째와 동일하게 초기화한 실행파일을 만듬.
3.  string[] array3 = {"안녕","Hello","Hallo"};
```

## [DerivedFromArray.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Array_Collection_Indexer/DerivedFromArray.cs)

System.Array

C#에서 모든 것은 객체다. .NET 의 CTS (Common Type System)에서 배열은 System.Array 클래스에 대응한다.  
따라서 System.Array의 특성과 메소드를 파악하면 많은 일들을 할 수 있다.

## [MoreOnArray.cs](https://github.com/twozeronine/Csharp_Study/blob/main/Array_Collection_Indexer/MoreOnArray.cs)

[Array클래스](https://docs.microsoft.com/ko-kr/dotnet/api/system.array?view=net-5.0)

|      분류       | 이름                | 설명                                                                                                |
| :-------------: | :------------------ | :-------------------------------------------------------------------------------------------------- |
|                 | Sort()              | 배열을 정렬한다.                                                                                    |
|                 | BinarySearch\<T>( ) | 이진 탐색을 수행한다.                                                                               |
|                 | IndexOf( )          | 배열에서 찾고자 하는 특정 데이터의 인덱스를 반환.                                                   |
|                 | TrueForAll\<T>( )   | 배열의 모든 요소가 지정한 조건에 부합하는지의 여부를 반환                                           |
|   정적 메소드   | FindIndex\<T>( )    | 배열에서 지정한 조건에 부합하는 첫 번째 요소의 인덱스를 반환.                                       |
|                 |                     | IndexOf() 메소드가 특정 값을 찾는데 비해, FindIndex<T>() 메소드는 지정한 조건에 바탕하여 값을 찾음. |
|                 | Resize\<T>( )       | 배열의 크기를 재조정함.                                                                             |
|                 | Clear( )            | 배열의 모든 요소를 초기화함. 숫자 형식 기반이면 0 , 논리 false, 참조 null                           |
|                 | ForEach\<T>( )      | 배열의 모든 요소에 대해 동일한 작업을 수행                                                          |
|                 | Copy\<T>( )         | 배열의 일부를 다른 배열에 복사함.                                                                   |
| 인스턴스 메소드 | GetLength( )        | 배열에서 지정한 차원의 길이를 반환함.                                                               |
|    프로퍼티     | Legth( )            | 배열의 길이를 반환함.                                                                               |
|                 | Rank( )             | 배열의 차원을 반환함.                                                                               |

## [Slice](https://github.com/twozeronine/Csharp_Study/blob/main/Array_Collection_Indexer/Slice.cs)

배열 분할하기

C#8.0에서 지원하는 System.Index 형식과 함께 도입된 System.Range를 사용하면 Array.Copy()메소드를 대체하여 쓸 수 있다.

```c#
1.  System.Range r1 = 0..3;
2.  int[] sliced = scores[r1];
3.  int[] sliced2 =scores[0..3];
```

## [2DArray](https://github.com/twozeronine/Csharp_Study/blob/main/Array_Collection_Indexer/2DArray.cs)

2차원 배열

## [3DArray](https://github.com/twozeronine/Csharp_Study/blob/main/Array_Collection_Indexer/3DArray.cs)

다차원 배열

다차원 배열을 선언할 때 꼭 배열의 각 차원의 크기를 지정해주자. 그래야 컴파일러가 초기화 코드와 선언문에 있는 배열의 차원 크기를 비교해서 이상이 없는지 검사 할 수 있다.

## [JaggedArray](https://github.com/twozeronine/Csharp_Study/blob/main/Array_Collection_Indexer/JaggedArray.cs)

가변 배열

배열을 요소로 갖는 배열. 가변 배열이라는 말보단 "들쭉날쭉한" 형태의 배열이라고 기억하자.

# Collection

## [UsingList](https://github.com/twozeronine/Csharp_Study/blob/main/Array_Collection_Indexer/UsingList.cs)

ArrayList 배열과 가장 닮은 컬렉션. Add(), RemoveAt(), Insert() 등의 메소드가 있다.

### ArrayList가 다양한 형식의 객체를 담을 수 있는 이유

ArrayList가 다양한 형식의 객체를 담을 수 있는 이유는 다음의 메소드의 선언을 보면 알 수 있다.

```C#
1. public virtual int Add( Object value)
2. public virtual void Insert( int index, Object value)
```

object 형식의 매개변수를 받고 있다.모든 형식은 object를 상속하므로 obejct 형식으로 간주되어 Add()메소드에 int 형식의 데이터를 넣더라도 정수 형식 그대로 입력되는 것이 아니라 object형식으로 박싱되어 입력된다.  
반대로 ArrayList의 요소에 접근해서 사용할 때는 원래의 데이터 형식으로 언박싱이 이루어진다. 박싱과 언박싱은 적지 않은 오버헤드를 요구하는 작업이다. 그래서 해결 방법으로 Generic Collection을 사용한다.

## [UsingQueue](https://github.com/twozeronine/Csharp_Study/blob/main/Array_Collection_Indexer/UsingQueue.cs)

Queue

FIFO(First In First Out)형태의 자료구조. 프린터가 여러 문서를 출력할 때, 인터넷 동영상 스트리밍 서비스에서 콘텐츠를 버퍼링할 때 등 많은 곳에 쓰인다.

## [UsingStack](https://github.com/twozeronine/Csharp_Study/blob/main/Array_Collection_Indexer/UsingStack.cs)

Stack

LIFO(Last In First Out)형태의 자료구조.

## [UsingHashtable](https://github.com/twozeronine/Csharp_Study/blob/main/Array_Collection_Indexer/UsingHashtable.cs)

Hashtable

Key와 Value의 쌍으로 이루어진 데이터를 다룰 때 사용한다. Hashtable은 배열에서 인덱스를 이용해서 배열 요소에 접근하는 것에 준하는 탐색 속도를 자랑한다. ArrayList에서 원하는 데이터를 찾으려면 컬렉션을 정렬해 이진 탐색을 수행하거나 순차적으로 리스트를 탐색해나가지만, Hashtable은 키를 이용해서 단번에 데이터가 저장된 컬렉션 내의 주소를 계산해낸다. 이 작업을 Hashing이라고 함.

## [InitializingCollections](https://github.com/twozeronine/Csharp_Study/blob/main/Array_Collection_Indexer/InitializingCollections.cs)

컬렉션을 초기화하는 방법

ArrayList , Queue , Stack은 배열의 도움을 받아 간단하게 초기화를 수행 할 수 있다. 그중에 ArrayList는 배열의 도움 없이 직접 컬렉션 초기자를 이용해서 초기화할 수 있다.
