# Observer Pattern

> 한 객체의 상태가 바뀌면 그 객체에 의존하는 다른 객체들한테 연락이 가서 자동으로 내용이 갱신되는 방식

## Subject

Subject 객체가 값 변경이 일어나면 Observer 객체들에게 이를 알린다. 각각의 Observer 객체들의 update() 함수에서 이를 감지하고 이에 따른 동작들을 수행한다.

-   Subject가 Observer에 대해서 아는 것은 Observer 가 특정 인터페이스를 구현한다는 것 뿐
    -   예를 들어 Observer 객체들은 모두 update()함수를 가지며 이에서 변화를 감지한다.
-   Observer는 언제든지 새로 추가할 수 있다.
    -   Subject는 Observer 인터페이스를 구현하는 객체 목록에만 의존하기 때문.
-   새로운 형식의 Observer를 추가하려 해도 Subject를 전혀 변경할 필요가 없다.
    -   새로운 클래스에서 Observer 인터페이스만 구현해주면 된다.
-   Subject나 Observer가 바뀌더라도 서로에게 전혀 영향을 주지 않는다. 그래서 Subject와 Observer는 서로 독립적으로 재사용할 수 있다.

서브젝트에서 옵저버들을 리스트로 관리를 하고, 이 리스트를 순회하며 옵저버들의 함수를 실행시키는 식으로 작동한다. 예를 들어 버튼 이벤트가 발생하면 서브젝트 A 함수가 실행되고 이 A 함수는 옵저버 오브젝트들의 B 함수를 일괄적으로 실행시키는 식이다.

## 예제 1)

```C#
Observer

// 옵저버 추상클래스
// : 옵저버들이 구현해야 할 인터페이스 메서드
public abstract class Observer
{
    // 상태 update 메서드
    public abstract void OnNotify();
}
```

```C#
ConcreteObserver1

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 옵저버 구현클래스
public class ConcreteObserver1 : Observer
{
    // 대상타입의 클래스에서 이 메소드를 실행시킴
    public override void OnNotify()
    {
        Debug.Log("옵저버 클래스의 메서드 실행 #1");
    }
}
```

```C#
ConcreteObserver2

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 옵저버 구현클래스
public class ConcreteObserver2 : Observer
{
    // 대상타입의 클래스에서 이 메소드를 실행시킴
    public override void OnNotify()
    {
        Debug.Log("옵저버 클래스의 메서드 실행 #2");
    }
}
```

```C#
Subject

// 대상 인터페이스
// : 옵저버 관리, 활용에 관한 타입 정의
public interface ISubject
{
    void AddObserver(Observer o);
    void RemoveObserver(Observer o);
    void Notify();
}
```

> 모든 Subject 인터페이스 자식 클래스들은 위 함수들을 오버라이딩 해야 한다.

-   AddObserver
    -   메세지 뿌릴 옵저버 추가
-   RemoveObserver
    -   메세지 뿌릴 옵저버 삭제
-   Notify
    -   옵저버들에게 연락하는 함수

```C#
ConcreteSubject

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 대상 클래스
// : 대상 인터페이스를 구현한 클래스
public class ConcreteSubject : MonoBehaviour, ISubject
{
    List<Observer> observers = new List<Observer>();  // 옵저버를 관리하는 List

    // 관리할 옵저버를 등록
    public void AddObserver(Observer observer)
    {
        observers.Add(observer);
    }

    // 관리중인 옵저버를 삭제
    public void RemoveObserver(Observer observer)
    {
        if (observers.IndexOf(observer) > 0) observers.Remove(observer);
    }

    // 관리중인 옵저버에게 연락
    public void Notify()
    {
		foreach (Observer o in observers)
		{
			o.OnNotify();
		}
    }

    void Start()
    {
        Observer obj1 = new ConcreteObserver1();
        Observer obj2 = new ConcreteObserver2();

        AddObserver(obj1);
        AddObserver(obj2);
    }
}

```

-   옵저버들을 리스트로 관리
-   Notify() 함수를 통해 옵저버들의 OnNotify() 함수를 다 실행시킴
    -   유니티 버튼 이벤트에 이 Notify() 함수를 추가하여, 버튼이 눌리면 옵저버들의 OnNotify() 함수가 실행되도록 한다.

## 예제 2)

```C#
Observer

// 옵저버 추상클래스
// : 옵저버들이 구현해야 할 인터페이스 메서드
public abstract class Observer
{
    // 상태 update 메서드
    public abstract void OnNotify(int num);
}
```

-   이번엔 Subject로 부터 파라미터 데이터를 받는다.

```C#
ConcreteObserver1

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 옵저버 구현클래스
public class ConcreteObserver1 : Observer
{
    GameObject obj;

    // 생성자를 통해 객체 전달
    public ConcreteObserver1(GameObject obj)
    {
        this.obj = obj;
    }

    // 대상타입의 클래스에서 이 메소드를 실행시킴
    public override void OnNotify(int num)
    {
        int num2 = obj.gameObject.GetComponent<ConcreteSubject>().getNum();

        Debug.Log("옵저버 클래스의 메서드 실행 #1");
        Debug.Log("메서드의 파라미터 : " + num);
        Debug.Log("객체 변수를 통한 접근 : " + num2);
    }
}
```

-   obj로 부터 서브젝트 ConcreteSubject가 붙어있는 오브젝트를 받는다.
    -   ConcreteSubject의 함수와 데이터를 옵저버가 받기 위하여

```C#
ConcreteObserver2

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 옵저버 구현클래스
public class ConcreteObserver2 : Observer
{
    GameObject obj;

    // 생성자를 통해 객체 전달
    public ConcreteObserver2(GameObject obj)
    {
        this.obj = obj;
    }

    // 대상타입의 클래스에서 이 메소드를 실행시킴
    public override void OnNotify(int num)
    {
        int num2 = obj.gameObject.GetComponent<ConcreteSubject>().getNum();

        Debug.Log("옵저버 클래스의 메서드 실행 #2");
        Debug.Log("메서드의 파라미터 : " + num);
        Debug.Log("객체 변수를 통한 접근 : " + num2);
    }
}

```

-   obj로 부터 서브젝트 ConcreteSubject가 붙어있는 오브젝트를 받는다.
    -   ConcreteSubject의 함수와 데이터를 옵저버가 받기 위하여

```C#
Subject

// 대상 인터페이스
// : 옵저버 관리, 활용에 관한 타입 정의
public interface ISubject
{
    void AddObserver(Observer o);
    void RemoveObserver(Observer o);
    void Notify();
}

```

> 모든 Subject 인터페이스 자식 클래스들은 위 함수들을 오버라이딩 해야 한다.

-   AddObserver
    -   메세지 뿌릴 옵저버 추가
-   RemoveObserver
    -   메시지 뿌릴 옵저버 삭제
-   Notify
    -   옵저버들에게 연락하는 함수

```C#
ConcreteSubject

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 대상 클래스
// : 대상 인터페이스를 구현한 클래스
public class ConcreteSubject : MonoBehaviour, ISubject
{
    List<Observer> observers = new List<Observer>();  // 옵저버를 관리하는 List
    private int myNum;

    // 관리할 옵저버를 등록
    public void AddObserver(Observer observer)
    {
        observers.Add(observer);
    }

    // 관리중인 옵저버를 삭제
    public void RemoveObserver(Observer observer)
    {
        if (observers.IndexOf(observer) > 0) observers.Remove(observer);
    }

    // 관리중인 옵저버에게 연락
    public void Notify()
    {
		  foreach (Observer o in observers)
		  {
			  o.OnNotify(myNum);
		  }
    }

    void Start()
    {
        myNum = 10;

        Observer obj1 = new ConcreteObserver1(this.gameObject);
        Observer obj2 = new ConcreteObserver2(this.gameObject);

        AddObserver(obj1);
        AddObserver(obj2);
    }

    public int getNum()
    {
        return myNum;
    }
}
```

-   옵저버들에게 myNum 데이터를 알려준다. o.OnNotify(myNum);

-   옵저버들에게 자신의 오브젝트를 넘겨 this.gameObject, 이를 통해 ConcreteSubject의 getNum() 함수를 사용할 수 있게 해준다.

## 예제 3) delegate 사용

> 나머지 코드는 예제 2와 동일함

```C#
ConcreteSubject

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteSubject : MonoBehaviour
{
  //  List<Observer> observers = new List<Observer>();  // 옵저버를 관리하는 List

    private int myNum;

	  delegate void NotiHandler(int num);
	  NotiHandler _notiHandler;

    public void Notify()
    {
		    _notiHandler(myNum);
    }

    void Start()
    {
        myNum = 10;

        Observer obj1 = new ConcreteObserver1(this.gameObject);
        Observer obj2 = new ConcreteObserver2(this.gameObject);

		    _notiHandler += new NotiHandler(obj1.OnNotify);
		    _notiHandler += new NotiHandler(obj2.OnNotify);
    }

    public int getNum()
    {
        return myNum;
    }
}
```

-   int 파라미터 하나를 받는 void형 함수들만 등록할 수 있는 \_notiHandler 델리게이트 객체를 생성한다.
    -   ConcreteSubject의 Notify()는 이 델리게이트를 파라미터만 넘겨 실행시킬 뿐이다. 어떤 함수들이 등록되있는지 알 필요 없는 체로.
        -   이전에 개별적으로 리스트에 옵저버 객체들을 저장해두고 for문을 돌려 일일이 옵저버들의 OnNotify를 실행시켰던 것과 다름.
-   델리게이트에 그저 옵저버의 OnNotify 함수르를 등록시킬 뿐이다.

```C#
		  _notiHandler += new NotiHandler(obj1.OnNotify);
          _notiHandler += new NotiHandler(obj2.OnNotify);
```
