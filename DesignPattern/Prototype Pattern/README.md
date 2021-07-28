# Prototype Pattern

> 오브젝트를 새로 생성할시 기존 오브젝트의 복사본으로 생성하여 내용만 조금 수정해준다.

-   Prototype을 상속 받아 clone() 메소드를 구현하는 ConcretePrototype으로 구성되어 있다.
-   원형을 하나 가지고 있고, 원형의 Prototype을 상속 받아 clone() 메소드를 구현한 상태라면 Client에서 원할 때 원형으로 클론을 만들어 사용할 수 있다.

## 사용하는 이유

-   프로토타입 패턴은 비슷한 오브젝트를 지속적으로 생성해야 할 때 유용하게 사용할 수 있다.

    -   아예 새로운 오브젝트를 지속적으로 생성 new하는건 부담스러운 일이기 때문.
    -   그보다 싼 비용인 본래의 오브젝트의 복사본을 만들어 내어 ( 서로 다른 인스턴스 ), 각 객체에 따라 데이터 수정을 해주는 방식으로 오브젝트를 생성한다.

-   동적 클래스 확장
    -   약간의 설정으로 비슷하지만 다른 클래스로의 확장이 가능한 경우, 세부 클래스를 미리 명세하지 않고 런타임 때 원형을 복제해서 그 복사본을 수정함으로써 동적으로 오브젝트를 생성함.

## 예제 1 )

Unit.cs

```C#

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 'IPrototype' interface
public interface IUnit
{
    // Method for cloning
    IUnit Clone();
}

// 'ConcretePrototype1' class implements IPrototype interface
public class Marine : IUnit
{
    public int Hp { get; set; }
    public int AttackPower { get; set; }

    // Implement shallow cloning method
    public IUnit Clone()
    {
        // Shallow Copy
        return this.MemberwiseClone() as IUnit;

        // Deep Copy
        // Implement Memberwise clone method for every reference type object
        // return ..
    }
}

public class Firebat : IUnit
{
    public int Age { get; set; }
    public int AttackPower { get; set; }

    // Implement shallow cloning method
    public IUnit Clone()
    {
        // Shallow Copy
        return this.MemberwiseClone() as IUnit;
    }
}
```

### MemberwiseClone() 함수 in C#

> 해당 객체를 얕은 복사로 단순 복사본 객체를 생성하고 리턴한다.

-   객체 복사를 위해 C# Object 클래스에서 지원하는 함수
    `this.MemberwiseClone() as IUnit;` - IUnit 타입으로 this(Friebat, Marine 객체)의 사본을 생성한다.
-   깊은 복사를 하려면 이 함수 말고 따로 개발자가 직접 깊은 복사 내용을 구현해야 한다

```C#
UnitManager.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour {

	void Start () {
        Marine marine = new Marine();
        marine.Hp = 25;
        marine.AttackPower = 5;

        // clone Marine object with Clone method
        // If you will not set the new value for any field the it will take the default value
        // from original object
        Marine marineClone = (Marine)marine.Clone();
        marineClone.Hp = 30;  // 값만 수정해준다.
        marineClone.AttackPower = 6;  // 값만 수정해준다.

        Debug.Log("Marine Details");
        Debug.LogFormat("Age: {0} / AttackPower: {1}",marine.Hp, marine.AttackPower);

        Debug.Log("Cloned Marine Details");
        Debug.LogFormat("Age: {0} / AttackPower: {1}", marineClone.Hp, marineClone.AttackPower);

        // you can perform the same operation for Firebat
    }
}

```

-   마린 최초의 생성은 new를 사용하여 생성한다
-   두번째 마린부터는 새로 생성하지 않고 기존 마린으로부터 복사본을 만든 후 내용만 수정해준다.
-   원본인 marine과 복사본인 marineClone은 별개의 객체이다

## 예제 2) 유니티에서의 프로토타입 패턴 적용

-   유니티에서 프리팹은 이미 프로토 타입을 따르고있다.
    -   원형인 프리팹을 복사해서 오브젝트로 찍어내는 것이기 때문
    -   프리팹이 Instatiate되어 생성된 오브젝트들은 모두 프리팹의 복사본이다.

```C#
Marine.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marine : MonoBehaviour
{
    void Start()
    {
        float r = Random.Range(0.0f, 1.0f);
        float g = Random.Range(0.0f, 1.0f);
        float b = Random.Range(0.0f, 1.0f);

        Renderer rend = GetComponent<Renderer>();
        rend.material.color = new Color(r, g, b, 0f);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");
        Destroy(this.gameObject);
    }
}

```

-   게임이 시작되면 위 Marine.cs 스크립트가 붙는 오브젝트의 색상이 랜덤하게 설정됨
-   Marine.cs 스크립트가 붙는 오브젝트가 어떤 물체와 충돌하면 오브젝트를 파괴한다.

```C#
UnitManager.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour {

    public GameObject unit;
    public Transform tr;

	void Start () {
    }

    public void CreateUnit()
    {
        GameObject obj = Instantiate(unit);
        obj.transform.position = tr.position;
    }
}

```
