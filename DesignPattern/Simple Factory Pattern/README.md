# Factory Pattern

-   Factory : 객체 생성을 처리하는 클래스
-   Factory Pattern : 객체를 생성하고자 할 때 사용하는 패턴

종류

1. Simple Factory Pattern
    - 팩토리 패턴의 가장 기본.
    - OOP에서 늘상 사용되기 때문에 패턴이라고 하기에는 그렇지만 팩토리 메서드와 추상 팩토리 패턴의 가장 기본이 되기 때문에 확실히 짚고 넘어가야 한다.
2. Factory Method Pattern
3. Abstract Factory Pattern

하나의 클래스로 여러가지 타입의 객체(자식)을 찍어내어 리턴하는 함수를 가진 하나의 공장(부모 클래스)를 만든다. 다형성

여러개의 자식 오브젝트들을 하나의 함수로 쉽게 한방에 생성하기 위해 사용하는 패턴

-   객체 생성을 한군데에서만 관리할 수 있다는 장점이 있다.
    -   여러 자식 타입들에게서 중복되는 내용을 제거할 수 있음.

## 예제 1 ) 스타크래프트 배럭 만들기

```C#
Unit.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit
{
	public abstract void move ();
}

public class Marine : Unit {

    public Marine()
    {
        Debug.Log("Marine 생성 !!!");
    }

    public override void move ()
	{
		Debug.Log ("Marine 이동 !!!");
	}
}

public class Firebat : Unit {

    public Firebat()
    {
        Debug.Log("Firebat 생성 !!!");
    }

    public override void move ()
	{
		Debug.Log ("Firebat 이동 !!!");
	}
}

public class Medic : Unit {

    public Medic()
    {
        Debug.Log("Medic 생성 !!!");
    }

    public override void move()
    {
        Debug.Log("Medic 이동 !!!");
    }
}

```

```C#
Factory.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType
{
	Marine,
	Firebat,
	Medic
}

public class UnitFactory
{
	public static Unit createUnit(UnitType type)
	{
		Unit unit = null;

		switch (type) {
            case UnitType.Marine:
                unit = new Marine();
                break;
            case UnitType.Firebat:
                unit = new Firebat();
                break;
            case UnitType.Medic:
                unit = new Medic();
                break;
        }
        return unit;
	}
}
```

부모인 Unit 타입의 unit에 3 개의 자식 타입들을 참조하여 unit을 리턴하는 static 함수다. 즉, 인수로 들어온 유닛을 생성하고 리턴해주는 공장과도 같은 역할을 한다.

```C#
FactoryUse.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryUse : MonoBehaviour {

	void Start () {

		Unit unit1 = UnitFactory.createUnit(UnitType.Marine);
        Unit unit2 = UnitFactory.createUnit(UnitType.Firebat);
        Unit unit3 = UnitFactory.createUnit(UnitType.Medic);

        unit1.move();
        unit2.move();
        unit3.move();
    }
}


```

-   static 함수이므로 클래스 이름으로 바로 접근
    -   UnitFactory.createUnit(UnitType.Marine)
-   부모 타입으로 자식을 참조
    -   Unit unit2 = UnitFactory.createUnit(UnitType.Firebat)
-   create으로부터 리턴받은 자식 객체로 move()를 호출한다.
    -   move() 함수는 추상 함수이므로 자식들이 반드시 오버라이딩 해야 하며 부모인 Unit 타입으로 자식 객체를 참조해도 자식이 오버라이딩한 move()가 호출된다.

## 예제 2 ) 유니티에서 실제로 사용해보기

```C#
Unit.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
	public abstract void Move ();
}
```

```C#
Marine.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marine : Unit {

    void Start()
    {
        Debug.Log("Marine 생성 !!!");
    }

    public override void Move()
    {
        Debug.Log("Marine 이동 !!!");
    }
}
```

```C#
Firebat.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firebat : Unit {

    void Start()
    {
        Debug.Log("Firebat 생성 !!!");
    }

    public override void Move()
    {
        Debug.Log("Firebat 이동 !!!");
    }
}


```

```C#
Factory.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType
{
	Marine,
	Firebat
}

public class Factory : MonoBehaviour
{
    public GameObject marine = null;
    public GameObject firebat = null;

    public GameObject createUnit(UnitType type)
	{
        //Unit unit = null;
        GameObject unit = null;

        float x = (float)Random.Range(0, 6);
        float z = (float)Random.Range(0, 6);

        switch (type) {
            case UnitType.Marine:
                //unit = new Marine();
                unit = Instantiate(marine, new Vector3(x, 1.0f, z), Quaternion.identity);
                break;
            case UnitType.Firebat:
                //unit = new Firebat();
                unit = Instantiate(firebat, new Vector3(x, 0.5f, z), Quaternion.identity);
                break;
        }

        return unit;
	}
}

```

-   marine, firebat에 각각 프리팹을 연결해준다.
-   부모인 Unit 타입의 unit에 자식들 타입들을 참조하여 unit을 리턴하는 함수다. 즉, 인수로 들어온 유닛을 생성하고 리턴해주는 공장과도 같은 역할을 한다.
    -   각 자식들의 프리팹을 x,z 랜덤한 위치에 Instantiate 하고 리턴한다.

```C#
FactoryUse.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryUse : MonoBehaviour {

    Factory factory = null;
    GameObject unit1 = null;
    GameObject unit2 = null;
    GameObject unit3 = null;

    void Start () {
        factory = GetComponent<Factory>();

        unit1 = factory.createUnit(UnitType.Marine);
        unit2 = factory.createUnit(UnitType.Firebat);
        unit3 = factory.createUnit(UnitType.Firebat);

        StartCoroutine("UnitAction");
    }

    IEnumerator UnitAction()
    {
        yield return new WaitForSeconds(0.2f);

        // 추상클래스 Unit을 이용하여 Marine, Firebat의 구분없이
        // 접근하여 사용할 수 있다.
        unit1.GetComponent<Unit>().Move();
        unit2.GetComponent<Unit>().Move();
    }
}

```

-   부모 타입으로 자식을 참조
    -   Unit unit2 = UnitFactory.createUnit(UnitType.Firebat)
-   createUnit으로부터 리턴받은 자식 객체로 move()를 호출한다.
    -   move() 함수는 추상 함수이므로 자식들이 반드시 오버라이딩 해야 하며 부모인 Unit 타입으로 자식 객체를 참조해도 자식이 오버라이딩 한 move()가 호출된다.
    -   각각 파이어뱃, 마린의 move()가 호출됨
