# Factory Method Pattern

> 생성하는 공장은 딱 하나. 그러나 어떻게 생성할지에 대한 여러 방식들을 공장의 자식 클래스들로 구현.

-   다양한 자식들을 생성하고 리턴하는 팩토리 클래스는 딱 하나만 두고,  
    어떤 방식으로 몇개 생성할지에 관한 로직은 팩토리 클래스를 상속하는 서브 팩토리 클래스들에게 맡기는 형태.

-   생성 형태는 여러가지가 있으므로 서브 팩토리 클래스들은 여러개가 있을 수 있다.
-   오브젝트 생산 공장 -> 팩토리 클래스 ( 부모 )
-   오브젝트의 여러가지 생산 방식들 -> 서브 팩토리 클래스 ( 자식들 )

> 부모인 팩토리 클래스로 서브 팩토리 클래스들을 참조하면, 팩토리 클래스 입장에선 뭘 어떻게 생성하는지 알 핋요 없이 그냥 생성만 해주면 된다. -> 다형성

-   유지 보수가 편리
    -   생성 방식들을 추가/수정할땐 서브 팩토리 클래스 내용을 수정하거나 추가하면 된다.
    -   팩토리 클래스를 수정할 필요는 없다.

![유니티 팩토리 메소드 패턴](https://user-images.githubusercontent.com/85855054/127077790-6821eab3-4082-4780-a363-1382f573d790.png)

## 예제 1 ) 팩토리에서 유닛 생성

```C#
Unit.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType
{
	Marine,
	Firebat
}

abstract class Unit
{
	protected UnitType type;
	protected string name;
	protected int hp;
	protected int exp;
    public abstract void Attack();
}
```

```C#
Firebat.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Firebat : Unit
{
	public Firebat()
	{
		type = UnitType.Firebat;
		name = "Firebat";
		hp = 120;
		exp = 15;

		Debug.Log (this.name + " : 생성!!");
	}

    public override void Attack()
    {
        Debug.Log(this.name + " : 공격!!");
    }
}
```

```C#
Marine.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Marine : Unit
{
	public Marine()
	{
		type = UnitType.Marine;
		name = "Marine";
		hp = 100;
		exp = 50;

		Debug.Log (this.name + " : 생성!!");
	}

    public override void Attack()
    {
        Debug.Log(this.name + " : 공격!!");
    }
}
```

```C#
UnitGenerator.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class UnitGenerator
{
    public List<Unit> units = new List<Unit>();

    public List<Unit> getUnits()
    {
        return units;
    }

    // Factory Method
    public abstract void CreateUnits();
}
```

```C#
PatternGenerator.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class PatternGenerator_A : UnitGenerator
{
    public override void CreateUnits()
    {
        units.Add(new Marine());
        units.Add(new Marine());
        units.Add(new Marine());
        units.Add(new Marine());
        units.Add(new Marine());
        units.Add(new Marine());
        units.Add(new Marine());
        units.Add(new Marine());
    }
}

class PatternGenerator_B : UnitGenerator
{
    public override void CreateUnits()
    {
        units.Add(new Firebat());
        units.Add(new Firebat());
        units.Add(new Firebat());
        units.Add(new Marine());
        units.Add(new Marine());
        units.Add(new Marine());
        units.Add(new Marine());
    }
}
```

### 팩토리 메서드 패턴의 사용

```C#
UnitFactoryMethod

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseFactoryMethod : MonoBehaviour {

	UnitGenerator[] unitGenerators = null;

	void Start () {
		unitGenerators = new UnitGenerator[2];
		unitGenerators[0] = new PatternGenerator_A();
		unitGenerators[1] = new PatternGenerator_B();
	}

	public void DoMakeTypeA()
	{
		unitGenerators[0].CreateUnits();

        List<Unit> units = unitGenerators[0].getUnits();
        foreach (Unit unit in units)
        {
            unit.Attack();
        }
    }

	public void DoMakeTypeB()
	{
		unitGenerators[1].CreateUnits();

        List<Unit> units = unitGenerators[1].getUnits();
        foreach (Unit unit in units)
        {
            unit.Attack();
        }
    }
}
```

## 예제 2 ) 데이터 베이스에서의 팩토리 메서드 패턴

> DataBase 종류마다 접속 방식이 다르다

-   접속 기능을 수행하는 함수는 가상(추상)함수여야 한다.
    -   Database 자식들마다 각자 알아서 오버라이딩 하도록한다.

> DataBase 종류마다 삽입과 선택 연산은 같다

-   부모인 Database에만 구현해두고 상속받게만 하면됨. 재정의 필요 없음.
    -   InsertData() 함수
    -   SelectData() 함수

### DataBase

```C#
Product.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Database
{
	public string name;
	public double rows;

	// 데이터베이스마다 접속 방식이 다르다.
	public abstract void ConnectDatabase ();

	// 표준 SQL문을 사용한다. (업무처리 방식이 같다.)
	public void InsertData ()
	{
		Debug.Log (name + " 에 데이터를 추가했습니다..");
	}

	public void SelectData ()
	{
		Debug.Log (name + " 에서 데이터를 " + rows + "게 조회했습니다.");
	}
}

public class MySQL : Database
{
	public MySQL()
	{
		name = "MySQL";
        rows = 20;
	}

	public override void ConnectDatabase ()
	{
		Debug.Log (name + " 에 접속했습니다..");
	}
}

public class Oracle : Database
{
	public Oracle()
	{
		name = "Oracle";
        rows = 10;
	}

	public override void ConnectDatabase ()
	{
		Debug.Log (name + " 에 접속했습니다..");
	}
}

public class Informix : Database
{
	public Informix()
	{
		name = "Informix";
        rows = 40;
	}

	public override void ConnectDatabase ()
	{
		Debug.Log (name + " 에 접속했습니다..");
	}
}

```

### 팩토리 메서드 패턴

```C#
DatabaseFactory.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DBType
{
    MySQL,
    Oracle,
    Informix
};

public abstract class DatabaseFactory : MonoBehaviour
{
    // Factory Method
    public abstract Database MakeDatabase();
}
```

```C#
DatabaseGenerator.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DatabaseGenerator : DatabaseFactory
{

    // 데이터베이스 변경시 여기서 타입을 변경한다.
    public DBType dbType = DBType.MySQL;

    public override Database MakeDatabase()
    {
        // 회사 사정에 의해 어떤 데이터베이스를 다시 사용할지 모른다.
        // 그래서 구축한 정보를 지우지 않고 재사용시를 대비한다.

        if (dbType == DBType.MySQL)
        {
            Debug.Log("MySQL use...");
            return new MySQL();
        }
        else if (dbType == DBType.Oracle)
        {
            Debug.Log("Oralce use...");
            return new Oracle();
        }
        else if (dbType == DBType.Informix)
        {
            Debug.Log("Informix use...");
            return new Informix();
        }
        else
        {
            return null;
        }
    }
}
```

### 팩토리 메서드 패턴의 사용

```C#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseFactoryMethod : MonoBehaviour {

	DatabaseFactory factory = null;
	Database db = null;

	void Start ()
	{
        factory = GetComponent<DatabaseGenerator>();

        // 어떤 데이터베이스가 사용될지 여기서는 모른다.
        // 팩토리 메서드에서 제공되는 데이터베이스를 그냥 사용한다.
        db = factory.MakeDatabase();

		// ConnectDatabase()는 추상 함수 이므로 데이터베이스 종류에 따라 다르게 실행된다.
		db.ConnectDatabase();

		// 부모인 DataBase에서 정의한 내용대로 실행된다. 즉 모든 데이터베이스가 공통적인 내용으로 실행된다.
		db.InsertData();
		db.SelectData();
	}
}

```

## 예제 3 ) 유니티에서 실제로 사용해보기

```C#
Boss.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BossType
{
	NormalBoss,
	EventBoss
}


abstract class Boss : MonoBehaviour
{
	protected BossType type;
	protected int hp;
	protected int exp;
    public abstract void Attack();
}
```

```C#
EventBoss.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class EventBoss : Boss
{
	void Start()
	{
		type = BossType.EventBoss;
		hp = 200;
		exp = 20;

        name = "Event Boss";
        Debug.Log (this.name + " : 출현!!");
	}

    public override void Attack()
    {
        Debug.Log(this.name + " : 공격!!");
    }
}
```

```C#
NormalBoss.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class NormalBoss : Boss
{
	void Start()
	{
		type = BossType.NormalBoss;
		hp = 200;
		exp = 15;

        name = "Normal Boss";
        Debug.Log (this.name + " : 출현!!");
	}

    public override void Attack()
    {
        Debug.Log(this.name + " : 공격!!");
    }
}
```

### 팩토리 메서드 패턴

```C#
BossFactory.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


abstract class BossFactory : MonoBehaviour
{
	// Factory Method
	public abstract void CreateBoss(Transform tran);
}
```

```C#
BossGenerator.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class BossGenerator : BossFactory
{
    // 설날 코스튬 보스몹 지정
    public BossType type = BossType.EventBoss;
    public GameObject _normalBoss;
    public GameObject _eventBoss;

    public override void CreateBoss(Transform tran)
	{
        if (type == BossType.NormalBoss)
        {
            GameObject boss = Instantiate(_normalBoss) as GameObject;
            boss.transform.position = tran.position;
            boss.transform.localRotation = tran.localRotation;
        }
        else if (type == BossType.EventBoss)
        {
            GameObject boss = Instantiate(_eventBoss) as GameObject;
            boss.transform.position = tran.position;
            boss.transform.localRotation = tran.localRotation;
        }
    }
}
```

```C#
UnitFactoryMethod

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseFactoryMethod : MonoBehaviour {

    BossGenerator factory = null;
    public Text desc;

	void Start () {
        //factory = new BossGenerator();
        factory = GetComponent<BossGenerator>();

        if (factory.type == BossType.NormalBoss)
        {
            desc.text = "Normal Boss";
        }
        else if (factory.type == BossType.EventBoss)
        {
            desc.text = "Event Boss";
        }

        // 로직에 따라 특정 위치 지정
        Transform tran = this.gameObject.transform;

        // 무엇이 만들어질지 여기서는 모른다.
        // 이벤트 기간에 맞춰 팩토리 클래스에서 타입이 변경되었다면
        // 해당 보스가 등장하게 된다.
        factory.CreateBoss(tran);
    }
}
```
