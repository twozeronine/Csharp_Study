# Strategy Pattern

> 인터페이스 & 다형성과 관련있다.

- 여러 알고리즘을 하나의 추상적인 접근점(인터페이스)을 만들어 접근점에서 알고리즘이 서로 교환이 가능하도록 하는 패턴
  - 동일 목적 알고리즘의 선택 적용

인터페이스

- 기능에 대한 선언
  - 구현과의 분리
    - 기능들을 구현하진 않고 프로토타입만 명시한다.
- 여러가지 기능을 사용하기 위한 단일 통로
- 예시
  - 워드 문서에서 프린터, 폰트 사용
    - 프린트 버튼만 누르면 어떤 종류의 프린터든간에 알아서 각자 맞게 프린트함
    - 똑같은 문장을 써도 폰트에 따라 모양은 다르게 나타남
  - 정수 배열에 대해 사용하는 정렬 알고리즘
  - 게임 캐릭터의 무기 사용

> 인터페이스에 무기에 대한 추상적인 기능 이름들만 명시해주면 각 무기들은 이 인터페이스를 상속받아 각자 무기 특성에 맞게 알아서 기능들을 구현하면 된다.

> 또한 부모인 인터페이스 이름 하나로 한방에 그 아래 자식들을 관리할 수 있다. => 다형성

인터페이스 클래스 구현 in C#

```C#
public interface IPrint  {
  void doPrint();
}
```

- 클래스 이름 앞엔 대문자 I를 붙여주어야 한다.
- 멤버 변수를 가질 수 없다.
- 멤버 함수들은 전부 프로토타입만 명시해주며 구현은 할 수 없다.
  - 자식 클래스들은 인터페이스에 있는 모든 함수들은 무조건 다 오버라이딩 해야 한다.

# 예시) 무기를 교체하며 쏠 수 있는 배틀쉽을 만들어보기

## 나만의 무기인 IWeapon 인터페이스 선언

```C#
IWeapon.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon{
	void Shoot(GameObject obj);
}

```

IWeapon을 상속받으면 Shoot 함수를 오버라이드 하여 구현해야함.

## 무기 구현

```C#
Arrow.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour, IWeapon {

	void Start () {
	}

	public void Shoot(GameObject obj)
    {
		Vector3 initialPosition = new Vector3 (transform.position.x, transform.position.y, 0);
        GameObject bullet = Instantiate(obj) as GameObject;
        bullet.transform.position = initialPosition;
	}
}
```

```C#
Bullet.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IWeapon {

	void Start () {
	}

	public void Shoot(GameObject obj)
    {
		Vector3 initialPosition = new Vector3 (transform.position.x, transform.position.y, 0);
        GameObject bullet = Instantiate(obj) as GameObject;
        bullet.transform.position = initialPosition;
	}

}
```

```C#
Missile.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour, IWeapon {

	void Start () {
	}

	public void Shoot(GameObject obj) {
		Vector3 initialPosition = new Vector3 (transform.position.x, transform.position.y, 0);
        GameObject bullet = Instantiate(obj) as GameObject;
        bullet.transform.position = initialPosition;
	}

}

```

IWeapon을 상속받았기 때문에 Shoot이라는 메소드를 오버라이드하여 구현해야한다.  
Shoot 함수는 무기마다 다른 로직으로 구현이 가능하다. ( 화살은 곡선으로 이동, 미사일은 빠르게 )

## 무기를 관리할 WeaponManager 구현

```C#
WeaponManager.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType {
	Bullet,
	Missile,
	Arrow
}

public class WeaponManager : MonoBehaviour {

    public GameObject _arrow;
    public GameObject _bullet;
    public GameObject _missile;

    private GameObject myWeapon;

    // 접근점
    private IWeapon weapon;

	private void setWeaponType (WeaponType weaponType) {

		Component c = gameObject.GetComponent<IWeapon>() as Component;  // 현재 게임 오브젝트의 IWeapon 타입의 컴포넌트를 가져온다.

		if (c != null) {
			Destroy(c);
		}

        switch (weaponType)
        {
            case WeaponType.Bullet:
                weapon = gameObject.AddComponent<Bullet>();
                myWeapon = _bullet;
                break;

            case WeaponType.Missile:
                weapon = gameObject.AddComponent<Missile>();
                myWeapon = _missile;
                break;

            case WeaponType.Arrow:
                weapon = gameObject.AddComponent<Arrow>();
                myWeapon = _arrow;
                break;

            default:
                weapon = gameObject.AddComponent<Bullet>();
                myWeapon = _bullet;
                break;
        }
    }

    void Start(){
		setWeaponType(WeaponType.Bullet);
	}

	public void ChangeBullet () {
		setWeaponType(WeaponType.Bullet);
	}

	public void ChangeMissile () {
		setWeaponType(WeaponType.Missile);
	}

	public void ChangeArrow () {
		setWeaponType(WeaponType.Arrow);
	}

	public void Fire() {
		weapon.Shoot(myWeapon);
	}
}

```

Fire()에서 현재 WeaponType에 따라 다른 무기를 발사할수가 있다.  
왜냐하면 모든 무기는 IWeapon이라는 인터페이스를 상속받아서 Shoot이라는 함수를 구현하였다라는것을 보장받기 때문이다.
