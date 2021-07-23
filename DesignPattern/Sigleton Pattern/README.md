# 싱글톤 패턴이란 ?

> 오직 한개의 클래스 인스턴스(static)만 갖도록 보장하고, 이데 대한 전역적인 접근점을 제공한다.

-   일종의 전역 변수. 모든 곳에서 접근하여 공유할 수 있는 단 하나의 인스턴스.

## 싱글톤 단점

> 전역 변수이므로 전역변수가 가지는 모든 장단점을 다 가지고 있다.

-   모든 곳에서 접근이 가능하므로 싱글톤 객체의 변경 시점, 변경주체, 호출 시점을 모두가 알기가 어렵다.
-   여러 클래스와 커플링이 된다.
    -   하나의 코드를 수정했을때, 싱글톤과 연결된 다양한 곳들에서 문제 발생
-   멀티 쓰레드 환경에서 문제 발생
    -   모든 곳에서 접근이 가능하므로 race condition 발생.
        -   이를 막기 위해 싱글톤은 mutex lock, unlock을 반복적으로 걸기 때문에 코드의 성능은 떨어지게 된다.

## 유니티 안에서의 싱글톤 패턴 객체

여러 오브젝트들이 데이터를 사용하는 오브젝트를 단 한개를 만들어 두고 이를 공유한다.

-   같은 Scene 안에서의 데이터 공유시에 사용됨
-   서로 다른 scene들간의 데이터 공유시에 사용됨
    -   DontDestroyOnLoad 메소드를 호출하여 Scene 변경시에도 싱글톤 객체의 Destroy를 막아주는 형태로 구현한다.

## 예제 1: 한 Scene 내에서 사용

> 공 오브젝트가 중력에 의해 떨어져 바닥에 부딪치면 소리가 나게 구현해보자.

-   공 오브젝트에 Rigidbody, Coliider 컴포넌트가 붙어있는 상태.
    -   바닥에 부딪치면 OnCollisionEnter 이벤트 발생
-   Audio Source 컴포넌트를 통해 소리 파일을 실행시켜야 한다.

### 싱글톤 사용하기 전

-   공 오브젝트에 붙여준다.
-   자기 자신(공 오브젝트)가 바닥에 부딪쳐 OnCollisionEnter 이벤트 발생시키면 오디오를 플레이 한 후 자기 자신을 파괴하도록 하였다.

```C#
WhenDestoyPlay.cs

using UnityEngine;
using System.Collections;

public class WhenDestroyPlay : MonoBehaviour {

	void OnCollisionEnter(Collision collision)
	{
		GetComponent<AudioSource>().Play();  // 오디오를 플레이한 후

		Destroy(this.gameObject);  // 자기 자신 파괴
	}
}

```

오디오가 재생되기도 전에 오브젝트가 파괴되어 오디오를 재생할 수 없게된다.

`Destoy(this.gameObject, myAudio.Clip.length)`
위와같이 이런식으로 해결할 수 있지만 바닥에 부딪치고 소리 재생이 끝날때까지 오브젝트가 제거되지않아 어색함이있다.

### 싱글톤을 사용

이 전체 시스템을 관리할 게임 매니저가 필요하다.
이 게임매니저 오브젝트의 오디오 매니저 스크립트를 싱글톤으로 지정한 후 공 오브젝트와 이를 공유

```C#
using UnityEngine;
using System.Collections;

public class MyAudioPlay : MonoBehaviour {

	public AudioClip clip;

	void OnCollisionEnter(Collision collision)
	{
		AudioManager.Instance().Play(clip);

		Destroy(this.gameObject);
	}
}

```

-   싱글톤인 AudioManager의 static 함수 Instance()를 호출하여 싱글톤 Audio Manager를 리턴 받는다.
    -   static 함수이기 때문에 클래스 이름인 AudioManager로 호출 가능.
-   공이 파괴되기 전, 공에 붙어 있는 Audio Source 컴포넌트의 clip을 싱글톤인 AudioSource가 재생시켜주도록 자기 자신의 clip을 넘겨준다.

```C#

AudioManager.cs
using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
	static AudioManager _instance = null;  // 싱글톤 객체
	public static AudioManager Instance()  // static 함수. 공유하고자 하는 외부에서 사용할 것.
	{
		return _instance;  // 자기 자신 리턴
	}

	void Start ()
	{
		if (_instance == null)  // 게임 시작되면 자기 자신을 넣음
			_instance = this;
	}

	public void Play(AudioClip clip)
	{
		GetComponent<AudioSource>().PlayOneShot(clip);  // 재생
    }
}
```

AudioManager.cs는 싱글톤 객체.

게임이 시작되면 자기 자신을 static변수 \_instance에 넣는다.
