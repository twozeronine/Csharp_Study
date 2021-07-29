# Flyweight Pattern

![flyweight](https://user-images.githubusercontent.com/85855054/127412459-dc18f173-de9b-45ee-80a5-3d8a37d2244e.png)

![flyweight2](https://user-images.githubusercontent.com/85855054/127412460-61b3c6bb-0f56-4b1a-a2cf-c2d9ac9f1c67.png)

> 한개의 고유 상태를 다른 객체들에게 공유하게 만들어 메모리 사용량을 줄인다.

> 내용이 같은 객체가 이미 있으면 새로 객체를 또 만들지 않고 그 내용 같은 기존 객체를 공유한다.

-   게임 내에서 같은 메시와 텍스처를 여러번 메모리에 올릴 필요가 없기 때문에
-   TreeModel 객체는 하나만 존재하며 각 나무 인스턴스들은 이 TreeModel 객체 하나를 공유하며 참조할 뿐이다.
-   Tree 클래스에서는 인스턴스별로 다른 상태값만 남겨둔다.
-   플라이웨이트 패턴에서의 객체 데이터 종류
    1.  모든 객체의 데이터 값이 같은 부분들만 모아둔 데이터, 즉 공유할 수 있는 데이터.
    2.  나머지 데이터는 인스턴스별로 값이 다른 외부 상태에 해당.
-   생성된 객체를 공유하는 것이라서 C++ 포인터 개념과도 같다.

## 구현

-   인스턴스를 요청 받았을 때 이전에 같은걸 만들어 놓은게 있는지 확인해보고 있다면 그걸 리턴해야 공유 기능이 유지된다.
    -   이러려면 이런 코드를 인터페이스 밑으로 숨겨두어야 한다.
        -   팩토리 메서드 패턴
-   이미 생성해놓은 객체를 찾을 수 있도록 Pool을 관리해야 한다.

## 예제 1 )

```C#
Unit.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Unit {   // 인터페이스

    string getName();
}

public class Marine : Unit
{
    string name;
    int hp;

    public Marine(string name)
    {
        this.name = name;
    }

    public string getName()   // 오버라이딩
    {
        return name;
    }

```

```C#
UnitFactory.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFactory : MonoBehaviour {

    static Dictionary<string, Marine> dic = new Dictionary<string, Marine>();  // 이미 생성해놓은 Marine 객체가 있는지 관리해야 해서

    public static Marine getPerson(string name)
    {
        if (!dic.ContainsKey(name))   // 해당 이름의 생성해 놓은 객체가 없을 때만 생성
        {
            Marine tmp = new Marine(name);
            dic.Add(name, tmp);  // Dictionary 에 추가
        }
        return dic[name];  // 만들어둔거 리턴
    }
}

```

```C#
FlyweightUse.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyweightUse : MonoBehaviour {

	void Start () {
        Marine p1 = UnitFactory.getPerson("홍길동");
        Marine p2 = UnitFactory.getPerson("전우치");
        Marine p3 = UnitFactory.getPerson("홍길동");

        Debug.Log(p1 == p2);  // 둘이 다르다.
        Debug.Log(p1 == p3);  // 둘이 동일하다.

        Debug.Log("name : " + p1.getName());
    }

}
```

## 예제 2 ) 유니티에 적용해보기

-   유니티 오브젝트들은 MonoBehaivour를 상속 받는다.
    -   MonoBehaviour를 상속 받는 오브젝트들은 new를 통해 생성하면 안된다.

```C#
Unit.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Unit {   // 인터페이스

    string getName();
    void setName(string name);
}
```

```C#
Marine.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marine : MonoBehaviour, Unit
{
    public string name;
    public int hp;

    public void setName(string name)
    {
        this.name = name;
    }

    public string getName()
    {
        return name;
    }

    void Start()
    {

    }
}
```

```C#
UnitFactory.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitFactory : MonoBehaviour {

    Dictionary<string, GameObject> dic = new Dictionary<string, GameObject>();
    public GameObject marine;

    public GameObject getMarine(string name)
    {
        if (!dic.ContainsKey(name))
        {
            float x = (float)Random.Range(-10, 11);
            float z = (float)Random.Range(-10, 11);
            Vector3 pos = new Vector3(x, 1.0f, z);

            //Marine obj = new Marine(name);
            GameObject obj = Instantiate(marine, pos, Quaternion.identity);
            obj.GetComponent<Marine>().setName(name);
            dic.Add(name, obj);
        }
        return dic[name];
    }
}
```

```C#
FlyweightUse.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyweightUse : MonoBehaviour {

	void Start () {
        UnitFactory factory = GetComponent<UnitFactory>();

        for (int i=0; i< 10; i++)
        {
            factory.getMarine("홍길동" + i);
        }

        GameObject p1 = factory.getMarine("홍길동");
        GameObject p2 = factory.getMarine("전우치");
        GameObject p3 = factory.getMarine("홍길동");

        if (p1 == p3)
        {
            Debug.Log("name : " + p1.GetComponent<Marine>().getName());
        }
    }
}
```
