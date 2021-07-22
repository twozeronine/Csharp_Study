## C# 클래스의 특성

> 모든 디자인 패턴의 시작 하위 클래스(자식) 객체를 상위 클래스(부모) 객채에 대입할 수 있다.

```C#
Super obj = new Sub();
```

-   부모 객체에 자식 객체를 대입할 수 있다.
    -   이때 obj는 Sub 타입의 객체를 참조하고 있긴 하지만 Super가 물려준 멤버들만 호출할 수있다.
        -   Sub 만의 멤버들은 호출할 수 없다.

> 상위 클래스 객체를 하위 클래스 객체에 대입할 수 없다.

```C#
Super obj1 = new Super();
Sub obj2 = obj1; // 컴파일 에러 발생
```

-   부모 객체를 자식 객체에 대입할 수 없다.
    -   Sub만 가지고 있는 멤버들은 Super타입의 객체인 obj1에 없기 때문이다.

## [가상 함수](https://github.com/twozeronine/Csharp_Study/blob/main/DesignPattern/Class/CSharpEx.cs)

> C#도 C++과 마찬가지로 부모 타입의 포인터로 자식 객체를 참조하면 재정의했던게 있더라도 부모 타입의 멤버를 호출한다.  
> C#은 Java와 다르게 멤버 호출시 참조하는 객체가 아닌 참조하는 변수의 타입을 본다.

-   따라서 부모 타입 포인터로 자식 객체를 참조했을 때 각 자식의 오버라이딩된 멤버 함수를 호출하게 하려면 그 멤버 함수를 가상 함수로 정의해야 한다. virtual

```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class SuperA
{
    public abstract void Execute();
}

class SubA : SuperA
{
    public override void Execute()
    {
        Debug.Log("A");
    }
}


class SuperB
{
    public void Execute_1()
    {
        Debug.Log("B-1");
    }

    public virtual void Execute_2()
    {
        Debug.Log("B-2");
    }
}

class SubB : SuperB
{
    public void Execute_1()
    {
        Debug.Log("C-1");
    }

    public override void Execute_2()
    {
        Debug.Log("C-2");
    }

    public void Execute_3()
    {
        base.Execute_1();  // B-1 출력
        Debug.Log("C-3");
    }
}


public class CSharpEx : MonoBehaviour
{
    void Start()
    {
        SuperA super1 = new SubA();
        super1.Execute();  //  "A"출력. 'SubA' 가 오버라이딩 한 Execute()실행

        SuperB super2 = new SuperB();
        super2.Execute1();  //  "B-1"출력. 'SuperB'의 Execute1()실행
        super2.Execute2();  //  "B-2"출력. 'SuperB'의 Execute2()실행

        SuperB super3 = new SubB();
        super3.Execute1();  //  "B-1"출력. 'SuperB'의 Execute1()실행
        super3.Execute2();  //  "C-2"출력. 'SubB' 가 오버라이딩 한 Execute2()실행

        SubB sub1 = new SubB();
        sub1.Execute1();  //  "C-1"출력. 'SubB' 가 오버라이딩 한 Execute1()실행
        sub2.Execute2();  //  "C-2"출력. 'SubB' 가 오버라이딩 한 Execute2()실행
        sub3.Execute3();  //  "B-1", "C-3"출력. 'SubB' 가 오버라이딩 한 Execute3()실행
    }
}

/*출력
A
B-1
B-2
B-1
C-2
C-1
C-2
B-1
C-3
*/

```

`SuperA super1 = new SubA();`

-   부모의 abstract 함수는 자식이 반드시 오버라이딩 해야 하며, 부모 타입으로 자식 객체를 참조하더라도 자식의 오버라이딩 된 함수를 호출한다.

`SuperB super2 = new SuperB();`

-   타입이 SuperB, SuperB로 통일하니 SuperB 본연의 멤버들 호출

`SuperB super3 = new SubB();`

-   super3.Execute1();
    -   Execute1은 가상함수가 아니므로 super3은 SuperB타입이니 SuperB의 Execute1() 호출.
-   super3.Execute2();
    -   Execute2은 가상함수이므로 자식인 SubB가 오버라이딩 한 Execute2() 호출

`SubB sub1 = new SubB();`

-   타입이 SubB,SubB로 동일하니 SubB 본연의 멤버들 호출
