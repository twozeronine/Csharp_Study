# Builder Pattern

> 객체를 생성할 때, 그 객체를 구성하는 부분 부분을 단계별로 먼저 생성하고 이를 조합함으로써 객체 전체를 생성한다.

-   복잡한 유형의 오브젝트를 작성할 때 도움된다.
-   생성할 객체의 종류를 손쉽게 추가, 확장이 가능한 설계.
-   플레이어 캐릭터 별개의 옷, 무기 등등을 조합하고 장착하는 등등 여러가지 경우에 상요될 수 있다.

## 빌더 패턴 VS 추상 팩토리 패턴

-   Builder
    -   복잡한 객체의 단계별 생성에 중점을 두고 있는 패턴
    -   마지막 단계에서 생성한 제품을 리턴한다.
-   Abstract Factory
    -   제품의 유사군들이 존재하는 경우 유연한 설계에 중점을 두는 패턴
    -   (단계마다) 만드는 즉시 제품을 리턴한다.
        -   테란, 프로토스 공장을 만들어둔 후 만드는 즉시 리턴

## 예제 1 ) 탈 것 만들기

```C#
Vehicle.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Our final product
class Vehicle
{
    public VehicleType vehicleType;
    private List<string> _parts = new List<string>();

    // Constructor method
    public Vehicle(VehicleType vehicleType)
    {
        this.vehicleType = vehicleType;
    }

    public void AddPart(string desc)
    {
        _parts.Add(desc);
    }

    public string GetPartsList()
    {
        string partsList = vehicleType.ToString() + " parts:\n\t";
        foreach (string part in _parts)
        {
            partsList += part + " ";
        }

        return partsList;
    }
}

```

```C#
InterfaceBuilder.cs

using UnityEngine;
using System.Collections.Generic;

// 'abstract Builder' class
interface IVehicleBuilder
{
    Vehicle getVehicle();

    void BuildFrame(); // 프레임 만들기
    void BuildEngine(); // 엔진 만들기
    void BuildWheels(); // 바퀴 만들기
}

public enum VehicleType
{
    Car,
    MotorCycle
}

```

```C#
CarBuilder.cs

using UnityEngine;

class CarBuilder : IVehicleBuilder
{
    private Vehicle _vehicle;

    public Vehicle getVehicle()
    {
        return _vehicle;
    }

    public CarBuilder()
    {
        // 빌더가 만들어질 때 아무것도 없는 차도 하나 만든다. (부품이 붙기 전)
        _vehicle = new Vehicle(VehicleType.Car);
    }

    public void BuildFrame() // Car의 프레임 만들기
    {
        _vehicle.AddPart("강철");
    }

    public void BuildEngine() // Car의 엔진 만들기
    {
        _vehicle.AddPart("100마력");
    }

    public void BuildWheels()  // Car의 바퀴 만들기
    {
        _vehicle.AddPart("앞.왼쪽 바퀴");
        _vehicle.AddPart("앞.오른쪽 바퀴");
        _vehicle.AddPart("뒤.왼쪽 바퀴");
        _vehicle.AddPart("뒤.오른쪽 바퀴");
    }
}
```

```C#
MonotCycleBuilder.cs

using UnityEngine;

class MotorCycleBuilder : IVehicleBuilder
{
    private Vehicle _vehicle;

    public Vehicle getVehicle()
    {
        return _vehicle;
    }

    public MotorCycleBuilder()
    {
        // 빌더가 만들어질 때 아무것도 없는 모터싸이클도 하나 만든다.(부품이 붙기 전)
        _vehicle = new Vehicle(VehicleType.MotorCycle);
    }

    public void BuildFrame()  // MotorCycle의 프레임 만들기
    {
        _vehicle.AddPart("알루미늄");
    }

    public void BuildEngine() // MotorCycle의 엔진 만들기
    {
        _vehicle.AddPart("50마력");
    }

    public void BuildWheels() // MotorCycle의 바퀴 만들기
    {
        _vehicle.AddPart("앞 바퀴");
        _vehicle.AddPart("뒤 바퀴");
    }
}


```

```C#
Engineer.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Engineer
{
    public void Construct(IVehicleBuilder vehicleBuilder)
    {
        vehicleBuilder.BuildFrame();
        vehicleBuilder.BuildEngine();
        vehicleBuilder.BuildWheels();
    }
}

```

```C#
BuilderUse.cs

using UnityEngine;

public class BuilderUse : MonoBehaviour
{
    void Start()
    {
        // Instantiate the director and builders
        Engineer engineer = new Engineer();  // 엔지니어 만들기
        CarBuilder carBuilder = new CarBuilder(); // 빈 Car 만들기
        MotorCycleBuilder motorCycleBuilder = new MotorCycleBuilder();  // 빈 MotorCycle 만들기

        // 빌더를 통해 구성해야 할 제품을 입력받아 제품을 구성한다.
        // 부품들을 붙인다.
        engineer.Construct(carBuilder);
        engineer.Construct(motorCycleBuilder);

        // 최종 생산된 완성된 제품을 반환받는다.
        Vehicle car = carBuilder.getVehicle();
        Debug.Log(car.GetPartsList());
        Vehicle motorCycle = motorCycleBuilder.getVehicle();
        Debug.Log(motorCycle.GetPartsList());
    }
}
```

## 예제 2 ) 유니티에서 객체 생성해 보기

```C#
Vehicle.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Our final product
public class Vehicle : MonoBehaviour
{
    private VehicleType vehicleType;

    public void setVehicleType(VehicleType vehicleType)
    {
        this.vehicleType = vehicleType;
    }

    public void AddPart(GameObject part, Vector3 localPosition)
    {
        GameObject obj = Instantiate(part) as GameObject;
        obj.transform.localPosition = localPosition;
        obj.transform.SetParent(this.transform);
    }

    public string GetPartsList()
    {
        string partsList = vehicleType.ToString() + " parts:\n\t";

        Transform[] trs = GetComponentsInChildren<Transform>();
        for (int i = 1; i < trs.Length; i++)
        {
            partsList += trs[i].gameObject.name + " ";
        }

        return partsList;
    }
}
```

-   유니티에서 사용하는 것이니 MonoBehaviour를 상속 받고 new가 아닌 Instantiate로 생성

```C#
InterfaceBuilder.cs

using UnityEngine;
using System.Collections.Generic;

// 'abstract Builder' class
interface IVehicleBuilder
{
    Vehicle getVehicle();

    void BuildFrame();
    void BuildEngine();
    void BuildWheels();
}

public enum VehicleType
{
    Car,
    MotorCycle
}

```

```C#
CarBuilder.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class CarBuilder : MonoBehaviour, IVehicleBuilder
{
    public GameObject ParentOfVehicle;
    public GameObject frame;
    public GameObject engine;
    public GameObject wheel1;
    public GameObject wheel2;
    public GameObject wheel3;
    public GameObject wheel4;

    private Vehicle _vehicle;

    public Vehicle getVehicle()
    {
        return _vehicle;
    }

    public void makeVehicle()
    {
        //_vehicle = new Vehicle(VehicleType.Car);
        GameObject obj = Instantiate(ParentOfVehicle) as GameObject;
        _vehicle = obj.GetComponent<Vehicle>();
        _vehicle.setVehicleType(VehicleType.Car);
    }

    public void BuildFrame()
    {
        _vehicle.AddPart(frame, Vector3.zero);
    }

    public void BuildEngine()
    {
        _vehicle.AddPart(engine, new Vector3(0, 0.5f, 0));
    }

    public void BuildWheels()
    {
        _vehicle.AddPart(wheel1, new Vector3(0.75f, -0.5f, 0.5f));
        _vehicle.AddPart(wheel2, new Vector3(-0.75f, -0.5f, 0.5f));
        _vehicle.AddPart(wheel3, new Vector3(-0.75f, -0.5f, -0.5f));
        _vehicle.AddPart(wheel4, new Vector3(0.75f, -0.5f, -0.5f));
    }
}
```

```C#
MotorCycleBuilder.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class MotorCycleBuilder : MonoBehaviour, IVehicleBuilder
{
    public GameObject ParentOfVehicle;
    public GameObject frame;
    public GameObject engine;
    public GameObject wheel1;
    public GameObject wheel2;

    private Vehicle _vehicle;

    public Vehicle getVehicle()
    {
        return _vehicle;
    }

    public void makeVehicle()
    {
        //_vehicle = new Vehicle(VehicleType.MotorCycle);
        GameObject obj = Instantiate(ParentOfVehicle) as GameObject;
        _vehicle = obj.GetComponent<Vehicle>();
        _vehicle.setVehicleType(VehicleType.MotorCycle);
    }

    public void BuildFrame()
    {
        _vehicle.AddPart(frame, Vector3.zero);
    }

    public void BuildEngine()
    {
        _vehicle.AddPart(engine, new Vector3(0, 0.5f, 0));
    }

    public void BuildWheels()
    {
        _vehicle.AddPart(wheel1, new Vector3(1.5f, 0, 0));
        _vehicle.AddPart(wheel2, new Vector3(-1.5f, 0, 0));
    }
}

```

```C#
Engineer.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Our 'Director' class.
class Engineer
{
    public void Construct(IVehicleBuilder vehicleBuilder)
    {
        vehicleBuilder.BuildFrame();
        vehicleBuilder.BuildEngine();
        vehicleBuilder.BuildWheels();
    }
}

```

```C#
BuilderUse.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderUse : MonoBehaviour
{
    void Start()
    {
        // Instantiate the director and builders
        Engineer engineer = new Engineer();
        //CarBuilder carBuilder = new CarBuilder();
        CarBuilder carBuilder = GetComponent<CarBuilder>();
        carBuilder.makeVehicle();
        //MotorCycleBuilder motorCycleBuilder = new MotorCycleBuilder();
        MotorCycleBuilder motorCycleBuilder = GetComponent<MotorCycleBuilder>();
        motorCycleBuilder.makeVehicle();

        // 빌더를 통해 구성해야 할 제품을 입력받아 제품을 구성한다.
        engineer.Construct(carBuilder);
        engineer.Construct(motorCycleBuilder);

        // 최종 생산된 제품을 반환받는다.
        Vehicle car = carBuilder.getVehicle();
        Debug.Log(car.GetPartsList());

        Vehicle motorCycle = motorCycleBuilder.getVehicle();
        Debug.Log(motorCycle.GetPartsList());

        // 최종 생산된 제품의 위치를 지정한다.
        car.transform.position = new Vector3(-3f, 0, 0);
        motorCycle.transform.position = new Vector3(3f, 0, 0);
    }

}
```
