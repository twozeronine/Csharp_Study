# Adapter Pattern

> 이미 제공되어 있는 것과 필요한 것의 차이를 없애주는 디자인 패턴

-   한 클래스의 인터페이스를 클라이언트에서 사용하고자 하는 다른 인터페이스로 변환한다.
-   어댑터를 이용하면 인터페이스 호환성 문제 때문에 같이 쓸 수 없는 클래스들을 연결해서 쓸 수 있다.

> Adapter 패턴은 Wrapper 패턴으로 불리기도 한다.

일반 상품을 예쁜 포장지로 싸서 선물용 상품으로 만드는 것처럼, 무엇인가를 한번 포장해서 다른 용도로 사용할 수 있게 교환해주는 것이 wrapper이며 adapter 이다.

## Adapter 패턴의 종류

1. 클래스에 의한 Adapter 패턴 ( 상속을 사용한 Adapter )
2. 인스턴스에 의한 Adapter 패턴 ( 위임을 사용한 Adapter )

## Adapter를 사용하는 경우

-   이미 존재하고 있는, 버그 적은 클래스를 부품으로서 재사용
-   Adapter 패턴은 기존의 클래스를 개조해서 필요한 클래스를 만든다.
    -   이 패턴으로 필요한 메소드를 빠르게 만들 수 있다.
    -   만약 버그가 발생해도 기존의 클래스에는 버그가 없으므로 Adapter 역할의 클래스를 중점적으로 조사하면 되고, 프로그램 검사도 상당히 쉬워진다.
-   이미 만들어진 클래스를 새로운 인터페이스에 맞게 개조시킬때는 당연히 Adapter 패턴을 사용해야 한다.
    -   Adapter 패턴은 기존의 클래스를 전혀 수정하지 않고 목적한 인터페이스에 맞추려는 것이다.
    -   또한 Adapter 패턴에서는 기존 클래스의 소스프로그램이 반드시 필요한 것은 아니다. 기존 클래스의 사양(interface)만 알면 새로운 클래스를 만들 수 있다.

### 예제 1)

```C#
Duck

// 오리 인터페이스
public interface Duck
{
    void quack();  // 꽥 울기
    void fly();    // 날기
}

```

```C#
MallardDuck

// 청둥오리
public class MallardDuck : Duck
{
    public void quack()
    {
        Debug.Log("오리 : 울기(꽥꽥)");
    }

    public void fly()
    {
        Debug.Log("오리 : 날기");
    }
}

```

```C#
Turkey

// 칠면조 인터페이스
public interface Turkey
{
    void gobble();  // 울기
    void fly();  // 날기
}

```

```C#
WildTurkey

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 야생칠면조
public class WildTurkey : Turkey
{
    public void gobble()
    {
        Debug.Log("칠면조 : 울기(고르륵고르륵)");
    }

    public void fly()
    {
        Debug.Log("칠면조 : 날기");

    }

}

```

```C#
TurkeyAdapter

// Duck 객체가 모자라서 Turkey 객체를 대신 사용해야 하는 상황
// 인터페이스가 다르기 때문에 Turkey객체를 바로 사용할 수는 없다.
public class TurkeyAdapter : Duck
{
    Turkey turkey;

    public TurkeyAdapter(Turkey turkey)
    {
        this.turkey = turkey;
    }

    public void quack()
    {
        turkey.gobble();
    }

    public void fly()
    {
        turkey.fly();
    }
}
```

> Turkey를 Duck으로 바꿔주는 어댑터

-   Turkey 객체로 Duck의 인터페이스를 사용하기 위해서
    -   Duck 인터페이스 상속
    -   Duck 인터페이스 함수들을 오버라이딩 하되, 함수들 안에서 turkey.gobble(), turkey.fly() 이렇게 Turkey의 함수들을 호출해주면 된다.

```C#
Client

public class Client : MonoBehaviour {

	void Start () {

        MallardDuck duck = new MallardDuck();
        WildTurkey turkey = new WildTurkey();
        Duck turkeyAdapter = new TurkeyAdapter(turkey);

        Debug.Log("오리 사용...");
        testDuck(duck);

        Debug.Log("오리 부족. 칠면조로 대체...");
        testDuck(turkeyAdapter);
    }

    void testDuck(Duck duck)
    {
        // 동일한 방법으로 사용
        duck.quack();
        duck.fly();
    }
}

```

-   Duck turkeyAdapter = new TurkeyAdapter(turkey)
    -   칠면조 어댑터는 Duck 타입
    -   즉, 칠면조 객체로 오리의 인터페이스를 사용할 것
-   testDuck(turkeyAdapter); 이렇게 사용이 가능

### 예제 2

현재 PayX 결제 시스템을 사용하고 있는데, PayY 결제 시스템으로 변경하고 싶은 상황. 현재까지 PayX를 사용한 수많은 클래스와 데이터들을 변경하고 싶지않고,
현재 서비스 되고 있는 많은 부분을 변경하는 것은 위험하다. PayX는 안정적인 상태로 쓰고 있었는데 PayY로 갑자기 변경해서 전부 다 변경해버리면 버그나 다른 위험이 발생할 수 도 있다.

```C#
PayX

// PayX 회사로부터 받은 인터페이스
public interface PayX {

	string getCreditCardNum();

	void setCreditCardNum (string creditCardNum);
}
```

```C#
PayY

// PayY 회사로부터 받은 인터페이스
public interface PayY {

	string getCustomerCardNum();

	void setCustomerCardNum (string customerCardNum);
}
```

갈아 타고 싶은 PayY 결제시스템의 인터페이스, PayX와 사용하는 함수가 다르다.

```C#
PayImpl ( 수정전 )

// 우리 회사에서 PayX 인터페이스 구현
public class PayImpl : PayX {

    private string creditCardNum;

 	public string getCreditCardNum () {
 		Debug.Log ("PayX (Get)");
 		return creditCardNum;
 	}

 	public void setCreditCardNum (string creditCardNum) {
 		Debug.Log ("PayX (Set)");
 		this.creditCardNum = creditCardNum;
 	}
 }


```

이렇게 PayX 인터페이스를 오버라이딩하여 PayX를 사용하고 있는 상태였었다.

```C#
수정 후. 어댑터 패턴 사용하여 갈아타기: 다중 상속

// 우리 회사에서 PayY 인터페이스 구현
public class PayImpl : PayY, PayX {

    // for PayY
    private string customerCardNum;

	public string getCustomerCardNum() {
		Debug.Log ("PayY (Get)");
		return customerCardNum;
	}

	public void setCustomerCardNum (string customerCardNum) {
		Debug.Log ("PayY (Set)");
		this.customerCardNum = customerCardNum;
	}

	// ------------------------------------------------------

	// for PayX Method
    public string getCreditCardNum()
    {
        return getCustomerCardNum();
    }

    public void setCreditCardNum(string creditCardNum)
    {
        setCustomerCardNum(creditCardNum);
    }
}

```

PayY 인터페이스 오버라이딩시 아예 PayX와 PayX 를 둘 다 다중상속 해서 둘 다 오버라이딩한다. 그리고 PayX의 함수 오버라이딩시 내용을 PayY의 함수를 호출하도록 함수의 내용을 바꿔주면 된다.

-   PayX의 getCreditCardNum() 함수를 호출하면 PayY의 getCustomerCardNum() 함수를 호출하도록
-   PayX의 setCreditCardNum() 함수를 호출하면 PayY의 setCustomerCardNum() 함수를 호출하도록

이 PayImpl가 바로 어댑터가 된다.

```C#
MyPay

public class MyPay : MonoBehaviour {

	void Start () {

        // for PayX : 원래 이렇게 사용중 ...

        PayImpl myPay = new PayImpl();
        myPay.setCreditCardNum("12345");
        string myCardNum = myPay.getCreditCardNum();
        // Debug.Log("PayX : " + myCardNum);

        // for PayY : PayX 와 같은 메서드명을 사용
        //            그러므로 코드를 바꿀 필요가 없다.
        Debug.Log("PayY : " + myCardNum);
    }

}
```

코드는 바꿀 필요가 전혀 없다.(변화로 인해 위험할 일이 없다 ) 그러나 내부적으로 setCreditCardNum는 곧 PayY의 setCustomerCardNum 함수를 부르도록 PayImpl 스크립트만 수정했을 뿐이다.
