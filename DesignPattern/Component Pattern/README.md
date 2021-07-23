# Component Pattern

## 상속 VS 컴포넌트

### 상속 : A is B

-   장점
    -   부모 클래스로부터 물려받은 부분은 다시 쓸 필요가 없기 떄문에 재사용 면에 있어서 효율적이다.
-   단점
    -   부모, 조상 클래스가 될 공통된 최소 필수 집합을 개발자가 미리 예상하기 힘들다.
        -   즉, 완벽하게 순수한 Base Class를 만드는 것은 힘듬
        -   자식 클래스가 필요로 하지 않는 기능도 물려줄 수 있는 등등 문제점이 많음
    -   컴포넌트들끼리 커플링이 심하다.
        -   A를 삭제하면 A를 상속 받고 있던 B,C에 치명적인 문제가 생김

### 컴포넌트 : A has B

> 빈 컨테이너에 필요할 때마다 원하는 기능을 갖다 붙여 포함시키는 방식
> 유니티가 컴포넌트 패턴으로 이루어져있다.

-   각자의 기능을 가지고 있는 스스로 동작하는 독립적인 부품
    -   애니메이션 관련, 물리기능 관련, 이동 시키기 관련 등 각자 기능을 담당하는 컴포넌트들이 독립적으로 구현됨.
        -   독립적인 클래스로 만들어 두고, 만들어 둔 것을 부품 붙이듯이 갖다 붙이면 됨.
    -   컴포넌트를 뗀다고 해서 오브젝트의 다른 컴포넌트에 영향이 가는 것은 없음
        -   컴포넌트들끼리 독립적이며 커플링이 없다
-   코드의 의존성을 줄이고 재활용성을 높인다.

## 컴포넌트란?

> 로직을 기능별로 컴포넌트화 하는 것. 기능들을 나누어 각각 독립적인 클래스로 분리.

-   한 개체가 여러 분야를 서로 커플링 없이 다룰 수 있게 해준다.
    -   컴포넌트만 수정하면 되서 요구사항에 대한 대처가 빨라 유지보수시 편하다.
-   캡슐화를 더 살려 준다.

## 코드

### 컴포넌트 패턴을 사용하지 않았을 때

동작 예시)

1. 오브젝트를 90도 회전
2. 오브젝트를 이동
3. 0.5초 기다리는 동작

위와 같은 세가지 일련의 과정을 가진 코루틴 함수가 있다고 해보자  
한 코드 내에서 회전도 하고 이동도 하고 있지만 만약에 회전을 다하고 0.3초 기다리고 이동은 0.5초 기다리도록 수정해야 한다면 코드 상당수를 수정해야 한다.

```C#
NonComponent.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum MOVE
{
    MOVE_RIGHT,
    MOVE_LEFT
}

public class SpaghettiAct : MonoBehaviour {

    GameObject player1;
    GameObject player2;
    MOVE move = MOVE.MOVE_RIGHT;

    void Start () {
        player1 = GameObject.Find("Player1") as GameObject;
        player2 = GameObject.Find("Player2") as GameObject;

        StartCoroutine("MixedAct");
    }

    // 0.5초마다 객체들을 회전하면서 (글로벌 방향으로) 이동시키기
    IEnumerator MixedAct()
    {
        while (true)
        {
            player1.transform.Rotate(90.0f * Vector3.up);
            player2.transform.Rotate(90.0f * Vector3.up);

            if (player1.transform.position.x < -4)
            {
                move = MOVE.MOVE_RIGHT;
            }
            else if (player1.transform.position.x > 4)
            {
                move = MOVE.MOVE_LEFT;
            }

            if (move == MOVE.MOVE_RIGHT)
            {
                player1.transform.Translate(1.0f * Vector3.right, Space.World);
                player2.transform.Translate(-1.0f * Vector3.right, Space.World);
            }
            else
            {
                player1.transform.Translate(-1.0f * Vector3.right, Space.World);
                player2.transform.Translate(1.0f * Vector3.right, Space.World);
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
}
```

### 컴포넌트 패턴을 사용했을 때

> 기능 별로 나누어 클래스로 묶어 독립적으로 분리해놓고 필요할 때 가져다 쓴다

-   이동과 회전 기능을 클래스로 따로 묶어 분리

Move.cs : 이동에 관한 것만 묶어 작성. 0.3초 기다리는 코루틴 함수  
Rotate.cs : 회전에 관한 것만 묶어 작성. 0.5초 기다리는 코루틴 함수

```C#
Move.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum MOVE2
{
    MOVE_RIGHT,
    MOVE_LEFT
}

public class MoveAct : MonoBehaviour {

    MOVE2 move = MOVE2.MOVE_RIGHT;

    void Start () {
        StartCoroutine("Move");
    }

    // 0.5초마다 (글로벌 방향으로) 이동시키기
    IEnumerator Move()
    {
        while (true)
        {
            if (transform.position.x < -4)
            {
                move = MOVE2.MOVE_RIGHT;
            }
            else if (transform.position.x > 4)
            {
                move = MOVE2.MOVE_LEFT;
            }

            if (move == MOVE2.MOVE_RIGHT)
            {
                transform.Translate(1.0f * Vector3.right, Space.World);
            }
            else
            {
                transform.Translate(-1.0f * Vector3.right, Space.World);
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
}


```

```C#
Rotate.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAct : MonoBehaviour {

	void Start () {
        StartCoroutine("Rotate");
    }

    // 0.5초마다 객체 회전시키기
    IEnumerator Rotate()
    {
        while (true)
        {
            transform.Rotate(90.0f * Vector3.up);

            yield return new WaitForSeconds(0.3f);
        }
    }
}

```
