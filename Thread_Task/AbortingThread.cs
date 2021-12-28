using System;
using System.Threading;

namespace AbortingThread
{
    class SideTask
    {
        int count;

        public SideTask(int count) => this.count = count;

        public void KeepAlive()
        {
            try
            {
                while (count > 0)
                {
                    System.Console.WriteLine($"{count--} left");
                    Thread.Sleep(10);
                }
                System.Console.WriteLine("Count : 0");
            }
            catch (ThreadAbortException e)
            {
                System.Console.WriteLine(e);
                Thread.ResetAbort();
            }
            finally
            {
                System.Console.WriteLine("Clearing resource...");
            }
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            SideTask task = new SideTask(100);
            Thread t1 = new Thread(new ThreadStart(task.KeepAlive));
            t1.IsBackground = false;

            System.Console.WriteLine("Starting thread...");
            t1.Start();

            Thread.Sleep(100);

            System.Console.WriteLine("Aborting thread...");
            t1.Abort();

            System.Console.WriteLine("Wating until thread stops...");
            t1.Join();

            System.Console.WriteLine("Finished");
        }
    }
}
