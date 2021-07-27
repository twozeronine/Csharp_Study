# Abstract Factory Pattern

> 클라이언트에 연관된 객체들의 패밀리를 반환한다.
> 여러 팩토리들 마저도 추상화

-   팩토리 메서드 패턴과 차이점

    -   팩토리 메서드 패턴은 팩토리가 되는 클래스가 하나의 객체를 생성하고 리턴하는게 전부
    -   추상 팩토리 패턴은 관련 있는 여러 종류의 객체를 특정 그룹으로 묶어 한번에 생성

-   특정 라이브러리를 배포하는데 OS별로 지원하는 기능이 상이하다면 추상 팩토리 패턴으로 OS별 기능들을 통합적으로 변경할 수 있다.

## 장점

1. 관리의 용이성
    - 클래스 이름 대신 팩토리 메소드를 사용해 객체를 생성하므로 추후 실제 생성되는 객체가 바뀌거나 추가되어도 문제가 없다.
2. 보안성
    - 클래스의 대부분의 내용은 숨기고 싶을 때, 인터페이스나 abstract를 통해서만 객체에 접근하게 할 수 있다.
3. 리소스 재활용성
    - 반드시 객체를 새로 생성할 필요는 없고 상황에 따라 새로 생성될 수도, 기존의 것을 리턴할 수도 있다.
4. 상속 구조
    - 세밀한 팩토리 관리가 가능

> 1 ~ 3 장점은 팩토리 메서드 패턴과 같고 4번 상속 구조는 추상 팩토리 패턴만의 장점

## 예제 1 ) 추상 팩토리 패턴을 사용을 안하고 구현한다면 ?

```C#
RaceCapacity.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RaceCapacity
{
	public abstract void expand ();
}

public class SupplyDepot : RaceCapacity
{
	public override void expand()
	{
		Debug.Log ("Terran Capacity +8 !!!");
	}
}

public class Pylon : RaceCapacity
{
	public override void expand()
	{
		Debug.Log ("Protoss Capacity +8 !!!");
	}
}

```

```C#
UnitBuilding.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitBuilding
{
	public abstract void produce();
}

public class Barracks : UnitBuilding
{
	public override void produce ()
	{
		Debug.Log ("Terran Unit 생산 !!!");
	}
}

public class Gateway : UnitBuilding
{
	public override void produce()
	{
		Debug.Log ("Protoss Unit 생산 !!!");
	}
}
```

```C#
Factory.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Race
{
	Terran,
	Protoss,
	Zerg
}

public class CapacityFactory
{
	public static RaceCapacity makeBuilding(Race type)
	{
        RaceCapacity capacity = null;

        switch (type)
        {
            case Race.Terran:
                capacity = new SupplyDepot();
                break;
            case Race.Protoss:
                capacity = new Pylon();
                break;
        }

        return capacity;
    }
}

public class UnitBuildingFactory
{
	public static UnitBuilding makeBuilding(Race type)
	{
        UnitBuilding building = null;

        switch (type)
        {
            case Race.Terran:
                building = new Barracks();
                break;
            case Race.Protoss:
                building = new Gateway();
                break;
        }

        return building;
	}
}
```

```C#
FactoryUse.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryUse : MonoBehaviour {

    void Start () {

        // Race.Terran -> Race.Protoss 타입의 변경만으로 해당 객체 생성
        RaceCapacity capacity = CapacityFactory.makeBuilding(Race.Protoss);
        UnitBuilding building = UnitBuildingFactory.makeBuilding(Race.Protoss);

        capacity.expand();
        building.produce();

    }
}

```

### **문제점**

1. 각 종족마다 건물을 훨씬 다양하다면 각각의 건물마다 팩토리 클래스가 존재할 것이기에 건물 수만큼 인수를 바꿔야 한다.
2. 또한 새로운 Zerg를 지원해야 하는 경우, 즉 종족을 추가하는 경우 각각의 팩토리 클래스의 switch 문 마다 case Zerg: 문을 추가해줘야 한다.

### **해결책 : 추상 팩토리 패턴을 사용**

예시 ) 엘리베이터는 A_Company라면 모든 부품이 A_company일 것이다. 이렇게 여러 종류의 객체를 생성할 때 객체들 사이의 관련성이 있는 경우라면 각 종류별로 별도의 Factory 클래스를 사용하는 대신 관련 객체들을 일관성 있게 생성하는 추상 팩토리 패턴을 적용하는 것이 편리하다.

## 예제 2 ) 추상 팩토리 패턴을 사용 !!

```C#
Factory.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Race
{
    Terran,
    Protoss,
    Zerg
}

public abstract class RaceFactory{
	public abstract RaceCapacity makeCapacityBuilding();
	public abstract UnitBuilding makeUnitBuilding();
}

public class TerranFactory : RaceFactory
{
	public override RaceCapacity makeCapacityBuilding()
	{
		return new SupplyDepot();
	}

	public override UnitBuilding makeUnitBuilding()
	{
		return new Barracks();
	}
}

public class ProtossFactory : RaceFactory
{
	public override RaceCapacity makeCapacityBuilding()
	{
		return new Pylon();
	}

	public override UnitBuilding makeUnitBuilding()
	{
		return new Gateway();
	}
}
```

```C#
FactoryUse.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryUse : MonoBehaviour {

	void Start () {

    RaceFactory factory = null;
		Race type = Race.Protoss;

		if (type == Race.Terran) {
			factory = new TerranFactory();
		} else if (type == Race.Protoss) {
			factory = new ProtossFactory();
		}

        RaceCapacity capacity = factory.makeCapacityBuilding();
        UnitBuilding building = factory.makeUnitBuilding();

        capacity.expand();
        building.produce();
	}
}

```

위와 같이 타입에 따라 하나의 factory 객체를 정해서 생성한다. 해당 factory에서는 해당 객체만 생성하게끔 가능하다.

## 예제 3 ) 추상 팩토리 패턴 & 팩토리 메서드 패턴 섞어서 사용하기

-   팩토리 자체를 생성하고 리턴하는 함수를 둔 클래스를 따로 둔다.
    -   즉, 팩토리를 생성하고 리턴하는건 오직 한 팩토리에서 관리
-   팩토리 메서드 패턴 적용 전 후 차이는 별로 없으나 종족별 Factory 객체를 생성하는 방식을 캡슐화 했다는 점이 다르다.

```C#
FactoryMethod.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryMethod : MonoBehaviour {

    public Race type = Race.Terran;

    public RaceFactory getFactory()  // 팩토리 메서드
	  {
		  RaceFactory factory = null;

		  switch (type)
		  {
		  case Race.Terran:
			  factory = new TerranFactory ();
			  break;
		  case Race.Protoss:
			  factory = new ProtossFactory();
			  break;
		  }
		  return factory;
	  }
}
```

```C#
FactoryMethodUse.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryMethodUse : MonoBehaviour {

	void Start () {
/*  예제 2의 이전 코드
        RaceFactory factory = null;
        Race type = Race.Terran;

        if (type == Race.Terran)
        {
            factory = new TerranFactory();
        }
        else if (type == Race.Protoss)
        {
            factory = new ProtossFactory();
        }
*/

        // FactoryMethod 클래스는 정적 클래스로 만들어 바로 사용해도 된다.
        FactoryMethod factoryMethod = new FactoryMethod();

        RaceFactory factory = factoryMethod.getFactory();

        // 하나의 팩토리 객체로 모든 건물을 다 만들 수 있다.
        RaceCapacity capacity = factory.makeCapacityBuilding();
        UnitBuilding building = factory.makeUnitBuilding();

        capacity.expand();
        building.produce();
    }
}
```

## 예제 4 ) 실제 유니티에서 적용해 보기

> 추상 팩토리 패턴과 팩토리 메서드 패턴을 함께 사용

-   실제 유니티 오브젝트에 적용하려면 프리팹들에 관련 스크립트를 붙이고, new가 아닌 Instantiate로 프리팹을 오브젝트화 하고, GetComponent로 사용할 팩토리를 가져온다.

```C#
UnitBuilding.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UnitBuilding : MonoBehaviour
{
    public abstract void produce();
}
```

```C#
RaceCapacity.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RaceCapacity : MonoBehaviour
{
    public abstract void expand();
}
```

```C#
Barracks.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barracks : UnitBuilding {

	public override void produce()
	{
        Debug.Log("Terran Unit 생산 !!!");
    }
}
```

```C#
SupplyDepot.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupplyDepot : UnitBuilding {

	public override void expand()
	{
        Debug.Log("Terran Capacity +8 !!!");
    }
}
```

```C#
Gateway.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gateway : UnitBuilding {

	public override void produce()
	{
        Debug.Log("Protoss Unit 생산 !!!");
  }
}
```

```C#
Pylon.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pylon : UnitBuilding {

	public override void expand()
	{
        Debug.Log("Protoss Capacity +8 !!!");
    }
}

```

```C#
Factory.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Race
{
    Terran,
    Protoss,
    Zerg
}

public abstract class RaceFactory : MonoBehaviour
{
    public abstract GameObject makeCapacityBuilding();
    public abstract GameObject makeUnitBuilding();
}
```

```C#
TerranFactory.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerranFactory : RaceFactory
{
    public GameObject supply;
    public GameObject barracks;

    public override GameObject makeCapacityBuilding()
    {
        //return new SupplyDepot();
        return Instantiate(supply, new Vector3(-1.0f, 1.0f, 0.0f), Quaternion.identity);
    }

    public override GameObject makeUnitBuilding()
    {
        //return new Barracks();
        return Instantiate(barracks, new Vector3(1.0f, 0.5f, 0.0f), Quaternion.identity);
    }
}
```

```C#
ProtossFactory.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtossFactory : RaceFactory
{
    public GameObject pylon;
    public GameObject gateway;

    public override GameObject makeCapacityBuilding()
    {
        //return new Pylon();
        return Instantiate(pylon, new Vector3(-1.0f, 1.0f, 0.0f), Quaternion.identity);
    }

    public override GameObject makeUnitBuilding()
    {
        //return new Gateway();
        return Instantiate(gateway, new Vector3(1.0f, 0.5f, 0.0f), Quaternion.identity);
    }
}
```

```C#
FactoryMethod.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryMethod : MonoBehaviour {

	public Race type = Race.Terran;

	public RaceFactory getFactory()
	{
        RaceFactory factory = null;

		switch (type)
		{
		case Race.Terran:
			//factory = new TerranFactory ();
			factory = GetComponent<TerranFactory>();
			break;
		case Race.Protoss:
			//factory = new ProtossFactory();
			factory = GetComponent<ProtossFactory>();
			break;
		}

		return factory;
	}
}

```

```C#
FactoryMethodUse.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryMethodUse : MonoBehaviour {

    RaceFactory factory = null;

	void Start ()
    {
		factory = GetComponent<FactoryMethod>().getFactory();

		GameObject capacity = factory.makeCapacityBuilding();
		GameObject building = factory.makeUnitBuilding();

        capacity.GetComponent<RaceCapacity>().expand();
		building.GetComponent<UnitBuilding>().produce();
    }
}
```
