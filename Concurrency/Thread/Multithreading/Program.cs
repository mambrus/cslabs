using System;
using System.Security.Principal;
using System.Threading;

namespace Multithreading
{

  class Worker
  {
    private ThreadStart childref;
    private Thread childThread;

    public Worker(Action startfunc)
    {
      childref = new ThreadStart(startfunc);
      childThread = new Thread(childref);
      childThread.Start();
    }
  }

  class Program
  {
    public static void Start()
    {
      try
      {
        Console.WriteLine("Child thread starts");

        // do some work, like counting to 10
        for (int counter = 0; counter <= 10; counter++)
        {
          Thread.Sleep(500);
          Console.WriteLine(counter);
        }

        Console.WriteLine("Child Thread Completed");
      }

      catch (ThreadAbortException e)
      {
        Console.WriteLine("Thread Abort Exception");
      }
      finally
      {
        Console.WriteLine("Couldn't catch the Thread Exception");
      }
    }

    static void Main(string[] args)
    {
      ThreadStart childref = new ThreadStart(Start);
      Console.WriteLine("In Main: Creating the Child thread");
      Thread childThread = new Thread(childref);
      childThread.Start();

      //stop the main thread for some time
      Thread.Sleep(2000);

      //now abort the child
      Console.WriteLine("In Main: Aborting the Child thread");
      childThread.Abort();

      Console.WriteLine("In Main: Spawn 50 Workers:");
      for (int i = 0; i < 50; i++)
      {
        new Worker(() =>
        {
          Console.WriteLine("Hello");
          Thread.Sleep(1000);
        });
      }
      Console.WriteLine("Wait 2s, then press key to exit");
      Thread.Sleep(2000);
      Console.WriteLine("Press key to exit");
      Console.ReadKey();
    }
  }
}