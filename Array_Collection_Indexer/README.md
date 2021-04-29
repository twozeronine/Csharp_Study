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

|      분류       | 이름              | 설명                                                                                                |
| :-------------: | :---------------- | :-------------------------------------------------------------------------------------------------- |
|                 | Sort()            | 배열을 정렬한다.                                                                                    |
|                 | BinarySearch<T>() | 이진 탐색을 수행한다.                                                                               |
|                 | IndexOf()         | 배열에서 찾고자 하는 특정 데이터의 인덱스를 반환.                                                   |
|                 | TrueForAll<T>()   | 배열의 모든 요소가 지정한 조건에 부합하는지의 여부를 반환                                           |
|   정적 메소드   | FindIndex<T>()    | 배열에서 지정한 조건에 부합하는 첫 번째 요소의 인덱스를 반환.                                       |
|                 |                   | IndexOf() 메소드가 특정 값을 찾는데 비해, FindIndex<T>() 메소드는 지정한 조건에 바탕하여 값을 찾음. |
|                 | Resize<T>()       | 배열의 크기를 재조정함.                                                                             |
|                 | Clear()           | 배열의 모든 요소를 초기화함. 숫자 형식 기반이면 0 , 논리 false, 참조 null                           |
|                 | ForEach<T>()      | 배열의 모든 요소에 대해 동일한 작업을 수행                                                          |
|                 | Copy<T>()         | 배열의 일부를 다른 배열에 복사함.                                                                   |
| 인스턴스 메소드 | GetLength()       | 배열에서 지정한 차원의 길이를 반환함.                                                               |
|    프로퍼티     | Legth()           | 배열의 길이를 반환함.                                                                               |
|                 | Rank()            | 배열의 차원을 반환함.                                                                               |
