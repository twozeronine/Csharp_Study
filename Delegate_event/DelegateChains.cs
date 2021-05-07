using System;

delegate void Notify(string message); // Notify 대리자 선언

class Notifier // Notify 대리자의 인스턴스 EventOccured를 가지는 클래스 Notifier 선언
{
  public Notify EventOccured;
}

class EventListener
{
  private string name;
  public EventListener(string name) => this.name = name;
  public void SomethingHapped(string message) => Console.WriteLine($"{name}.SomethingHappened : {message}");

}

class MainApp
{
  static void Main(string[] args)
  {
    Notifier notifier = new Notifier();
    EventListener listener1 = new EventListener("Listener1");
    EventListener listener2 = new EventListener("Listener2");
    EventListener listener3 = new EventListener("Listener3");

    notifier.EventOccured += listener1.SomethingHapped;
    notifier.EventOccured += listener2.SomethingHapped; // += 연산자를 이용한 체인 만들기
    notifier.EventOccured += listener3.SomethingHapped;
    notifier.EventOccured("You've got mail.");

    Console.WriteLine();

    notifier.EventOccured -= listener2.SomethingHapped; // -= 연산자를 이용한 체인 끊기
    notifier.EventOccured("Download complete.");

    Console.WriteLine();

    notifier.EventOccured = new Notify(listener2.SomethingHapped)
                          + new Notify(listener3.SomethingHapped);
    notifier.EventOccured("Nuclear launch detected.");

    Console.WriteLine();

    Notify notify1 = new Notify(listener1.SomethingHapped);
    Notify notify2 = new Notify(listener2.SomethingHapped);

    notifier.EventOccured =
    (Notify)Delegate.Combine(notify1, notify2); // Delegate.Combine() 메소드를 이용한 체인 만들기
    notifier.EventOccured("Fire!!");

    Console.WriteLine();

    notifier.EventOccured =
    (Notify)Delegate.Remove(notifier.EventOccured, notify2);
    notifier.EventOccured("RPG!");
  }
}

/*실행 결과

Listener1.SomethingHappened : You've got mail.
Listener2.SomethingHappened : You've got mail.
Listener3.SomethingHappened : You've got mail.

Listener1.SomethingHappened : Download complete.
Listener3.SomethingHappened : Download complete.

Listener2.SomethingHappened : Nuclear launch detected.
Listener3.SomethingHappened : Nuclear launch detected.

Listener1.SomethingHappened : Fire!!
Listener2.SomethingHappened : Fire!!

Listener1.SomethingHappened : RPG!

*/