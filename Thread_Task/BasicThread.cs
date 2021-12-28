using System;
using System.Threading;

namespace BasicThread
{
    class MainApp
    {
        static void DoSomething()
        {
            for (int i = 0; i < 5; i++)
            {
                System.Console.WriteLine($"DoSomething : {i}");
                Thread.Sleep(10); // Sleep() 메소드를 만나면 인수(10) 만큼 CPU 사용을 멈춘다. 이때 인수 단위는 밀리초...
            }
        }

        static void Main(string[] args)
        {
            Thread t1 = new Thread(new ThreadStart(DoSomething));

            System.Console.WriteLine("Starting thread...");
            t1.Start();

            for (int i = 0; i < 5; i++) // t1 스레드의 DoSomething() 메소드가 실행되는 동시에 메인 스레드의 이 반복문도 실행됨.
            {
                System.Console.WriteLine($"Main : {i}");
                Thread.Sleep(10);
            }

            System.Console.WriteLine("Waing until thread stops...");
            t1.Join();

            System.Console.WriteLine("Finished");
        }
    }

    /*
    실행결과
    아래의 실행 결과는 언제든지 변동될 수 있음.

    Starting thread...
    Main : 0
    Dosomething : 0
    Main : 1
    Dosomething : 1
    Main : 2
    Dosomething : 2
    Dosomething : 3
    Main : 3
    Dosomething : 4
    Main : 4
    Wating until thread stops...
    Finished
    */
}