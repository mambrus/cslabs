using System.Diagnostics;
using Bank;

namespace NUnitQuickStart
{
  using System;

  class Program
  {
    #region HARD-CODED TEST

    [Conditional("DEBUG")]
    static void DoSomething(Account account)
    {
      Console.WriteLine("But OK, DEBUG is set so here's a hard-coded test.");

      Console.WriteLine("Creating and making initial deposit...");
      account.Deposit(199m);

      Console.WriteLine("Account balance is: " + account.Balance);
    }

    #endregion

    static void Main(string[] args)
    {
      Console.WriteLine("You're not supposed to run this. Use NUnit executive instead..");
      DoSomething(new Account());
      Console.ReadKey();
    }
  }
}