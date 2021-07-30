# ObjectPool Pattern

-   장점) 메모리를 신경쓰지 않고 마음껏 객체를 생성, 삭제할 수 있다.
-   단점) 객체 아무것도 사용하지 않아도 메모리를 차지하고 있는 상태가 됨.
-   객체 풀 클래스에 들어가는 객체는 현재 자신이 사용중인지 아닌지 알 수 있는 방법을 제공해야 한다.
    1. 풀은 초기화될 때 사용할 객체들을 미리 생성하여 배열에 넣어두고 사용 안함 상태로 초기화 한다.
    2. 새로운 객체가 필요하면 풀에 요청한다.
    3. 풀은 사용 가능한 객체를 찾아 사용 중으로 초기화 한 뒤 리턴한다.
    4. 객체를 더 이상 사용하지 않는 다면 사용 안함 상태로 되돌린다.

## 오브젝트풀 패턴을 사용해야 할 때

-   객체를 빈번하게 생성/삭제 해야할 때
-   객체들의 크기가 비슷할 때
-   객체를 힙에 생성하기엔 느리거나 메모리 단편화가 우려될 때
-   DB 연결이나 네트워크 연결같이 객체 생성시 비용이 비쌀 경우 미리 생성해두고 재사용할 필요가 있을 때

## 경량 패턴(Flyweight Pattern)과의 비교

> 둘 다 재사용 가능한 객체 집합을 관리함

-   경량 패턴
-   같은 인스턴스를 여러 객체에서 공유함으로써 재사용한다.
    -   같은 객체를 동시에 여러 문맥에서 사용함으로써 메모리 중복 사용을 피하는게 의도
-   오브젝트풀 패턴
    -   객체를 재사용하긴 하지만 여러 곳에서 동시에 재사용하지는 않는다.
        -   이전 사용자가 다 쓴 다음 객체 메모리를 회수해가는 것을 의미할 뿐 공유하는 개념은 아니다. 객체는 한번에 한곳에서만 사용 됨.

```C#
Enemy.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.SetActive(false);
        }
    }
}
```

-   OnMouseOver() 함수
    -   마우스 좌클릭 입력이 들어오면
    -   이 스크립트가 붙어있는 게임 오브젝트, 즉 자기 자신을 비활성화 시킨다.

```C#
EnemyManager.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public GameObject enemy;   // 프리팹을 여기에 넣어주기
    public int poolSize = 10;       // Object Pool Size
    GameObject[] enemyPool;   // 게임 오브젝트 배열

    void Start()  // 배열에 오브젝트들 생성하여 담기
    {
        enemyPool = new GameObject[poolSize];  // 배열 생성
        for (int i = 0; i < poolSize; ++i)
        {
            enemyPool[i] = Instantiate(enemy) as GameObject;
            enemyPool[i].name = "Enemy_" + i;
            enemyPool[i].SetActive(false);  // `사용 안함` 상태
        }

        StartCoroutine("SpawnManager");
    }

    IEnumerator SpawnManager()
    {
        while (true)
        {
            // 2초 마다 배열 안에 있는 객체들이 차례대로 생성될 것
            yield return new WaitForSeconds(2.0f);

            for (int i = 0; i < poolSize; i++)
            {
                if (enemyPool[i].activeSelf == true)  // ⭐ 이미 setActive(true)인 상태인 오브젝트면 넘어감!!
                    continue;

                float x = Random.Range(-5, 6);
                float z = Random.Range(-5, 6);

                enemyPool[i].transform.position = new Vector3(x, 0.5f, z);  // 랜덤한 위치
                enemyPool[i].SetActive(true); // `사용 함` 상태

                break;
            }
        }
    }
}
```
