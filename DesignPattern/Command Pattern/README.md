# Command Pattern

> 명령 패턴은 함수 호출 자체를 실체화, 즉 객체로 감싼것이다.

-   요청 자체를 캡슐화 하는 것.
    -   이를 통해 요청이 서로 다른 사용자를 매개 변수로 만들고, 요청을 대기시키거나 로깅하며, 되돌릴 수 있는 연산을 지원한다.
-   함수 호출을 객체로 만들었기 때문에 디커플링으로 코드가 유연하다.
-   게임 프로그래밍에서의 사용 예
    -   입력 키 변경
    -   실행 취소, 재실행

## 커맨드 패턴이 적용 안된 예제

> 총알 오브젝트에 붙는다.

```C#
csCannon

using UnityEngine;
using System.Collections;

public class csCannon : MonoBehaviour
{
	float power = 900.0f;
	Vector3 velocity;

	void Start()
	{
		velocity = transform.forward * power;

		GetComponent<Rigidbody>().AddForce(velocity); // 생성 되자마자 900 크기의 속도로 발사 됨
		StartCoroutine ("DeleteCannon"); // 0.5초 뒤 총알 파괴
	}

	IEnumerator DeleteCannon() {
		yield return new WaitForSeconds (0.5f);
		Destroy(this.gameObject);
	}
}
```

```C#
csPlayerNormal

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csPlayerNormal : MonoBehaviour {

	public GameObject shield; // 쉴드 오브젝트(비활성화 상태가 디폴트다)
	public GameObject cannon; // 총알 프리팹
	public Transform firePos; // 총알이 생성될 위치가 될 빈 오브젝트

	void Update () {

		if (Input.GetKeyDown ("a")) {
			Attack ();
		} else if (Input.GetKeyDown ("b")) {
			Defense ();
		}
	}

	void Attack() // 공격. 총쏘기
	{
		Debug.Log("Attack");
		Instantiate (cannon, firePos.position, firePos.rotation); // 📜csCannon 의 Start()가 실행되며 총알 생성되고 날라가고 0.5초뒤 파괴
	}

	void Defense() // 방어.
	{
		Debug.Log("Defense");
		shield.SetActive(true); // 쉴드를 활성화
		StartCoroutine (Defense(0.5f)); // 0.5초 뒤 쉴드 비활성화
	}

	IEnumerator Defense(float tm) {
		yield return new WaitForSeconds (tm);
		shield.SetActive(false);
	}

}

```

문제점

```C#
void Update()
{
    if(Input.GetKeyDown("a"))
    {
        Attack();
    }
    else if (Input.GetKeyDown("b"))
    {
        Defense();
    }
}
```

공격을 E키로 하고 싶다면? 사용자가 Key를 바꾸고 싶다면? 사용자가 직접 update() 문 코드를 바꾸지 않는 이상 사용자 정의 키를 사용할 수 없다. 커맨드 패턴을 사용하면 key를 바꿀 수 있다.

## 커맨드 패턴이 적용된 예제

> 명령 자체를 클래스로 만든다

```C#
csCannon

public class csCannon : MonoBehaviour
{
	float power = 900.0f;
	Vector3 velocity;

	void Start()
	{
		velocity = transform.forward * power;

		GetComponent<Rigidbody>().AddForce( velocity );
		StartCoroutine ("DeleteCannon");
	}

	IEnumerator DeleteCannon() {
		yield return new WaitForSeconds (0.5f);
		Destroy(this.gameObject);
	}
}
```

```C#
CommandKey

// 인터페이스 : Execute() 메소드만 있는 추상클래스
public abstract class CommandKey {
	public GameObject shield;
	public GameObject cannon;
	public Transform firePos;

	public MonoBehaviour mono;

	public virtual void Execute() {}
}

```

```C#
CommandAttack

// Concrete Command 객체 : 직접적으로 동작하는 객체
public class CommandAttack : CommandKey {

	public CommandAttack(MonoBehaviour _mono, GameObject _shield,
		                 GameObject _cannon, Transform _firePos)
	{
		this.shield = _shield;
		this.cannon = _cannon;
		this.firePos = _firePos;
		this.mono = _mono;
	}

	public override void Execute()
	{
		Attack();
	}

	void Attack()
	{
		Debug.Log("Attack");
		GameObject.Instantiate(cannon, firePos.position, firePos.rotation);
	}
}
```

-   CommandAttack의 Excute() 오버라이딩
    -   Attack() 호출

```C#
CommandDefense

// Concrete Command 객체 : 직접적으로 동작하는 객체
public class CommandDefense : CommandKey {

	public CommandDefense(MonoBehaviour _mono, GameObject _shield,
		                  GameObject _cannon, Transform _firePos)
	{
		this.shield = _shield;
		this.cannon = _cannon;
		this.firePos = _firePos;
		this.mono = _mono;
	}

	public override void Execute()
	{
		Defense();
	}

	void Defense()
	{
		Debug.Log("Defense");
		shield.SetActive(true);
		mono.StartCoroutine(Defense(0.5f));
	}

	IEnumerator Defense(float second) {
		yield return new WaitForSeconds (second);
		this.shield.SetActive(false);
	}
}
```

-   CommandDefense Excute() 오버라이딩
    -   Defense() 호출

```C#
csPlayerCommand

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class csPlayerCommand : MonoBehaviour {

	public GameObject shield;
	public GameObject cannon;
	public Transform firePos;
	bool bCmd;
	Text txt1;
	Text txt2;

	CommandKey btnA, btnB;

	void Start () {
		bCmd = true;
		txt1 = GameObject.Find ("Text1").GetComponent<Text>();
		txt2 = GameObject.Find ("Text2").GetComponent<Text>();

		SetCommand();
	}

	// SetCommand() 메소드를 통해 버튼을 누르면 어떤 동작을 수행할지를 각 버튼에 등록
	public void SetCommand()
	{
		if (bCmd == true) {
			btnA = new CommandAttack(this, shield, cannon, firePos);
			btnB = new CommandDefense(this, shield, cannon, firePos);

			bCmd = false;
			txt1.text = "A - Attack";
			txt2.text = "B - Defense";
		} else {
			btnA = new CommandDefense(this, shield, cannon, firePos);
			btnB = new CommandAttack(this, shield, cannon, firePos);

			bCmd = true;
			txt1.text = "A - Defense";
			txt2.text = "B - Attack";
		}
	}

	// 버튼을 누르면 단지 버튼의 Execute()만 호출
	void Update () {

		if (Input.GetKeyDown ("a")) {
			btnA.Execute ();
		} else if (Input.GetKeyDown ("b")) {
			btnB.Execute ();
		}
	}

}

```

-   부모 타입 CommandKey 변수로 CommandDefense, CommandAttack 두 명령 객체를 업캐스팅 한다. => 다형성
    -   단지 Excute() 하나만으로 어떤 타입의 객체를 참조하느냐에 따라 다르게 실행된다.
        -   btnA, btnB는 SetCommand 함수에서 버튼 눌리는 것에 따라 다른 명령 객체 CommandDefense, CommandAttack을 참조하게 된다.
        -   따라서 버튼이 눌림에 따라 A키를 눌렀을 때 btnA.Excute() 에서 공격을 할 수도 있고 방어를 할 수도 있고 경우에 따라 다르게 코딩할 수 있게 되었음.

## 예제 2 )

```C#
CommandKey

// 인터페이스 : Execute() 메소드만 있는 추상클래스
public abstract class CommandKey {
	public virtual void Execute(GameObject obj) {}
}

```

```C#
CommandAttack

// Concrete Command 객체 : 직접적으로 동작하는 객체
public class CommandAttack : CommandKey {

	// 객체를 파라미터로 받아 어떤 객체라도 메서드를 호출하여 사용할 수 있도록 함
	public override void Execute(GameObject obj)
	{
		// 객체와 메서드는 decoupling 관계
		Attack(obj);
	}

	void Attack(GameObject obj)
	{
		Debug.Log(obj.name + " Attack");
		obj.transform.Translate (Vector3.forward);
	}
}
```

-   CommandAttack의 Excute() 오버라이딩
    -   Attack() 호출

```C#
CommandDefense

// Concrete Command 객체 : 직접적으로 동작하는 객체
public class CommandDefense : CommandKey {

	public override void Execute(GameObject obj)
	{
		Defense(obj);
	}

	void Defense(GameObject obj)
	{
		Debug.Log(obj.name + " Defense");
		obj.transform.Translate (Vector3.back);
	}
}

```

-   CommandDefense Excute() 오버라이딩
    -   Defense() 호출

```C#
csPlayerCommand

public class csPlayerCommand : MonoBehaviour {

	CommandKey btnA, btnB;

	void Start () {
		SetCommand();
	}

	void SetCommand()
	{
		btnA = new CommandAttack();
		btnB = new CommandDefense();
	}

	public void BtnCommandA()
	{
		btnA.Execute(gameObject); // 이 스크립트가 붙은 오브젝트를 공격하게 함
	}
	public void BtnCommandB()
	{
		btnB.Execute(gameObject); // 이 스크립트가 붙은 오브젝트를 방어하게 함
	}

}
```

## 예제 3

```C#
CommandKey

// 인터페이스 : Execute() 메소드만 있는 추상클래스
public abstract class CommandKey {
	public virtual void Execute(Transform tr, Vector3 newPos) {}
	public virtual void Undo(Transform tr) {}
}
```

-   Undo 추가!
    -   이전 Transform 위치 기록

```C#
CommandMoveRight

// Concrete Command 객체 : 직접적으로 동작하는 객체
public class CommandMoveRight : CommandKey {

	Vector3 prevPos;

	public override void Execute(Transform tr, Vector3 newPos)
	{
		prevPos = tr.position;
		tr.Translate(newPos);
	}

	public override void Undo(Transform tr)
	{
		tr.position = prevPos;
	}
}
```

-   CommandAttack의 Excute() 오버라이딩
    -   Attack() 호출

```C#
CommandMoveForward

// Concrete Command 객체 : 직접적으로 동작하는 객체
public class CommandMoveForward : CommandKey {

	Vector3 prevPos;

	public override void Execute(Transform tr, Vector3 newPos)
	{
		prevPos = tr.position;
		tr.Translate(newPos);
	}

	public override void Undo(Transform tr)
	{
		tr.position = prevPos;
	}
}

```

-   CommandDefense Excute() 오버라이딩
    -   Defense() 호출

```C#
csPlayerCommand

public class csPlayerCommand : MonoBehaviour
{
	Stack<CommandKey> stack = new Stack<CommandKey>();

    public void MoveForward()
    {
        CommandKey command = new CommandMoveForward();
        stack.Push(command);
        command.Execute(transform, new Vector3(0f, 0f, 1f));
    }

    public void MoveRight()
    {
        CommandKey command = new CommandMoveRight();
        stack.Push(command);
        command.Execute(transform, new Vector3(1f, 0f, 0f));
    }

    public void MoveUndo()
    {
        if (stack.Count > 0)
        {
            CommandKey command = stack.Pop();
            command.Undo(transform);
        }
    }

}

```
