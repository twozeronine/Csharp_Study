# State Pattern

## 예제 1 ) 상태 패턴을 사용하지 않고 상태 플래그 변수를 사용하기

> 슈퍼마리오 같은 횡스크롤 게임을 만든다면 서있기 / 점프 / 엎드리기 / 엎드려 기모으기 / 이동과 같은 동작을 만들것이다. 이단 점프는 허용 안 한 다고 가정.

```C#
// 스페이스바 누르면 점프하기

void Update()
{
    if (Input.GetKeyDown(KeyCode.Space))
    {
        StartCoroutine("HandleJump");  // 점프를 처리하는 코루틴 함수
    }
}

```

```C#
// 이단 점프를 허용 안한다고 가정하므로 이단 점프를 막기 위해 다음와 같이 추가

 void Update()
 {
    if (Input.GetKeyDown(KeyCode.Space))
    {
        if (!is.Jumping)
        {
            isJumping = true;
            StartCoroutine("HandleJump");  // 점프를 처리하는 코루틴 함수
        }
    }
 }

```

```C#
// 이제 케릭터가 땅에 있을 때 아래쪽 버튼을 누르면 엎드리고, 버튼을 떼면 다시 일어서는 기능을 추가

void Update()
 {
    if (Input.GetKeyDown(KeyCode.Space))
    {
        if (!is.Jumping)
        {
            isJumping = true;
            StartCoroutine("HandleJump");  // 점프를 처리하는 코루틴 함수
        }
    }
    else if (Input.GetKeyDown(KeyCode.DownArrow))  // ↓ 키를 누르면
    {
        if (!is.Jumping)  // 점프 상태가 아닐 때만 엎드릴 수 있어야 함
        {
            StartCoroutine("HandleDown");  // 엎드리기를 처리하는 코루틴 함수
        }
    }
    else if (Input.GetKeyUp(KeyCode.DownArrow))  // ↓ 키를 떼면
    {
        StartCoroutine("HandleStand");  // 일어나기를 처리하는 코루틴 함수
    }
 }


```

기존 로직에서 상태 변경을 더 하게 된다면 상태 변경을 체크할 플래그 변수가 늘어나며 복잡성이 굉장히 높아지게 된다.

## 상태패턴 정의 및 적용하기

> 상태를 별도의 클래스로 캡슐화한 다음 현재 상태를 나타내는 객체에게 행동을 위임한다.

-   내부 상태가 바뀜에 따라서 행동이 달리지게 된다.
-   동적으로 행동을 교체할 수 있다.
-   전략 패턴과 구조는 거의 동일하나 쓰임의 용도가 다르다.

### 핵심 정리

-   상태 패턴을 사용하면 내부 상태를 바탕으로 여러가지 서로 다른 행동을 사용할 수 있다.
-   상태 패턴을 사용하면 FSM을 쓸 때와는 달리 각 상태를 클래스를 이용하여 표현하게 된다.
-   상태를 사용하는 Context 객체에서는 현재 상태에게 행동을 위임한다.
-   각 상태를 클래스로 캡슐화함으로써 나중에 변경시켜야 하는 내용을 국지화시킬 수 있다.
-   상태 패턴과 전략 패턴의 용도 차이점
    -   전략 패턴
        -   행동 또는 알고리즘을 Context 클래스를 만들 때 설정한다.
    -   상태 패턴
        -   Context의 내부 상태가 바뀜에 따라 알아서 행동을 바꿀 수 있도록 할 수 있다.
-   상태 전환은 State 클래스에 의해서 제어할 수 도 있고 Context 클래스에 의해서 제어할 수도 있다.
-   State 클래스를 여러 Context 객체의 인스턴스에서 공유하도록 디자인 할 수도 있다.

```C#
State.cs

// 상태 인터페이스 클래스
public interface State
{
    void Action();
};

// 추상 클래스로 구현해도 됨


```

```C#
Move.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : State
{
    public void Action()  // 오버라이딩
    {
        Debug.Log("이동 !!!");
    }
}
```

```C#
Attack.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : State
{
    public void Action() // 오버라이딩
    {
        Debug.Log("공격 !!!");
    }
}

```

```C#
Monster.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster
{
    private State state;

    // Constructor
    public Monster(State state) // 어떤 상태가 들어올지 모르지만 일단 상태 입력을 받고
    {
        this.state = state;
    }

    public void setState(State state) // setter 상태를 set
    {
        this.state = state;
    }

    public void act()  // getter 상대를 get. ⭐상태에 따른 행동을 알아서 한다.⭐
    {
        state.Action();
    }
}
```

```C#
StateManager.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour {

	void Start () {
        Monster monster = new Monster(new Move()); // 상태를 만들고 상태에 따른 행동을 위임
        monster.act();

        monster.setState(new Attack()); // 상태를 Attack로 바꿔줌
        monster.act();

        monster.setState(new Move());  // 상태를 Move로 바꿔줌
        monster.act();
    }
}
```

## 예제 2)

```C#
void Update()
    {
		switch (state) {
		case MyState.STATE_STANDING:
			if (Input.GetKeyDown(KeyCode.Space))
			{
				state = MyState.STATE_JUMPING;
				StartCoroutine("HandleJump");
			}
            else if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				chargeTime = 0;

				state = MyState.STATE_DUCKING;
				StartCoroutine("HandleDown");
			}
			break;
		case MyState.STATE_JUMPING:
			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				state = MyState.STATE_DIVING;
				StartCoroutine("HandleAttack");
			}
			break;
		case MyState.STATE_DUCKING:
			if (Input.GetKeyUp(KeyCode.DownArrow))
			{
				state = MyState.STATE_STANDING;
				StartCoroutine("HandleStand");
			}

			chargeTime ++;
			if ( chargeTime > MAX_CHARGE ) {
				// 스킬 발동;
				state = MyState.STATE_STANDING;
				StartCoroutine("HandleSkill");
			}

			break;
		default:
			break;
		}
    }

```

> 상태 패턴으로 구현

STATE_DUCKING 상태일 때 기모으기를 해서 스킬을 발동시키려면 chargeTime을 증가시켜야 하는데 MyState.STATE_STANDING 서 있을 때 미리 초기화 하여 chargeTime = 0 하는 작업이 필요하다. A 상태에서 B 상태가 발동될 수 있을 때, B 상태에 필요한 작업을 미리 해놔야 한다는게 상태 패턴의 단점이다.

## 예제 3 )

```C#
public abstract class State : MonoBehaviour
{
    public abstract void DoAction(MyState state);
};

```

-   State ( 인터페이스이며 DoAction 함수를 오버라이딩 하라고 강제 )
    -   ConcreteStateAttack ( DoAction 오버라이딩 -> 내려찍는 공격)
    -   ConcreteStateDown ( DoAction 오버라이딩 -> 엎드리고 기모으기)
    -   ConcreteStateJump ( DoAction 오버라이딩 -> 점프)
    -   ConcreteStateSkill ( DoAction 오버라이딩 -> 기 모은 후 공격)
    -   ConcreteStateStand ( DoAction 오버라이딩 -> 서 있기)

```C#
public enum MyState
{
    STATE_STANDING,
    STATE_JUMPING,
    STATE_DUCKING,
    STATE_DIVING,
    STATE_SKILL
}

public class MyAction8 : MonoBehaviour {

    private MyState state;

	// Concrete클래스들의 접근점(인터페이스)
	private State myState;

	// 상태 클래스 교환...
	public void setActionType (MyState state) {

        // 현재 상태 저장
        this.state = state;

        // 다양한 상태 중에 어떤 것을 가져와야 할 지 모르므로
        // 인터페이스를 대표로 해서 가져온다.
		Component c = gameObject.GetComponent<State>() as Component;

		if (c != null) {
			Destroy(c);
		}

        switch (state)
        {
            case MyState.STATE_STANDING:
                myState = gameObject.AddComponent<ConcreteStateStand>();
                myState.DoAction(state);
                break;
            case MyState.STATE_JUMPING:
                myState = gameObject.AddComponent<ConcreteStateJump>();
                myState.DoAction(state);
                break;
            case MyState.STATE_DUCKING:
                myState = gameObject.AddComponent<ConcreteStateDown>();
                myState.DoAction(state);
                break;
            case MyState.STATE_DIVING:
                myState = gameObject.AddComponent<ConcreteStateAttack>();
                myState.DoAction(state);
                break;
            case MyState.STATE_SKILL:
                myState = gameObject.AddComponent<ConcreteStateSkill>();
                myState.DoAction(state);
                break;
            default:
                break;
        }
    }

    void Start ()
	{
        setActionType(MyState.STATE_STANDING);
	}

    void Update()
    {
        switch (state)
        {
            case MyState.STATE_STANDING:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    setActionType(MyState.STATE_JUMPING);
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    setActionType(MyState.STATE_DUCKING);
                }
                break;
            case MyState.STATE_JUMPING:
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    setActionType(MyState.STATE_DIVING);
                }
                break;
            case MyState.STATE_DUCKING:
                if (Input.GetKeyUp(KeyCode.DownArrow))
                {
                    setActionType(MyState.STATE_STANDING);
                }
                break;
            default:
                break;
        }
    }
}


```
