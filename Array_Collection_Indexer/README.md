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
