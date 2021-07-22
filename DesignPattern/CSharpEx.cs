using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class SuperA
{
    public abstract void Execute();
}

class SubA : SuperA
{
    public override void Execute()
    {
        Debug.Log("A");
    }
}


class SuperB
{
    public void Execute_1()
    {
        Debug.Log("B-1");
    }

    public virtual void Execute_2()
    {
        Debug.Log("B-2");
    }
}

class SubB : SuperB
{
    public void Execute_1()
    {
        Debug.Log("C-1");
    }

    public override void Execute_2()
    {
        Debug.Log("C-2");
    }

    public void Execute_3()
    {
        base.Execute_1();  // B-1 출력
        Debug.Log("C-3");
    }
}


public class CSharpEx : MonoBehaviour
{
    void Start()
    {
        SuperA super1 = new SubA();
        super1.Execute();  //  "A"출력. 'SubA' 가 오버라이딩 한 Execute()실행

        SuperB super2 = new SuperB();
        super2.Execute1();  //  "B-1"출력. 'SuperB'의 Execute1()실행
        super2.Execute2();  //  "B-2"출력. 'SuperB'의 Execute2()실행

        SuperB super3 = new SubB();
        super3.Execute1();  //  "B-1"출력. 'SuperB'의 Execute1()실행
        super3.Execute2();  //  "C-2"출력. 'SubB' 가 오버라이딩 한 Execute2()실행

        SubB sub1 = new SubB();
        sub1.Execute1();  //  "C-1"출력. 'SubB' 가 오버라이딩 한 Execute1()실행
        sub2.Execute2();  //  "C-2"출력. 'SubB' 가 오버라이딩 한 Execute2()실행
        sub3.Execute3();  //  "B-1", "C-3"출력. 'SubB' 가 오버라이딩 한 Execute3()실행
    }
}