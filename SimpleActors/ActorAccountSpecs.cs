using System;
using System.Threading;
using Magnum.Extensions;
using SimpleActors.Messages;
using SimpleActors.Model;
using Stact.Internal;

namespace SimpleActors
{
  using NUnit.Framework;
  using Stact;


  [TestFixture]
  class ActorAccountSpecs
  {
    #region FirstTestName

    [Test]
    public void Newly_created_account_should_have_correct_balence_and_credit()
    {
      ActorRef account = ActorFactory.Create(inbox => new AccountActor(inbox, 100.0m)).GetActor();
      Future<bool> result = new Future<bool>();

      decimal balance = 0xDEADBEEF;
      decimal availableCredit = 0xDEADBEEF;
      decimal creditLimit = 0xDEADBEEF;
      AnonymousActor.New(inbox =>
      {
        account.Request(new QueryAccountBalance(), inbox)
          .Receive<AccountBalance>(message =>
          {
            balance = message.Balance;
            availableCredit = message.AvailableCredit;
            creditLimit = message.CreditLimit;

            Console.WriteLine("Balance={0}, Credit={1}, Limit={2}",
              balance, availableCredit, creditLimit);
            result.Complete(true);
          });
      });

      result.WaitUntilCompleted(5.Seconds());
      Assert.True(balance == 0 && availableCredit == 100.0m && creditLimit == 100.0m);
    }

    #endregion

    #region Charging_an_account_async_should_still_adjust_the_balence

    [Test]
    public void Charging_an_account_async_should_still_adjust_the_balence()
    {
      ActorRef account = ActorFactory.Create(inbox => new AccountActor(inbox, 100.0m)).GetActor();

      decimal balance = 0xDEADBEEF;
      decimal availableCredit = 0xDEADBEEF;
      decimal creditLimit = 0xDEADBEEF;

      #region  Charge 3 times with 10.0 async

      AnonymousActor.New(inbox =>
      {
        account.Send(new ChargeAccount()
        {
          Amount = 10
        });
      });
      
      AnonymousActor.New(inbox =>
      {
        account.Send(new ChargeAccount()
        {
          Amount = 10
        });
      });

      AnonymousActor.New(inbox =>
      {
        account.Send(new ChargeAccount()
        {
          Amount = 10
        });
      });

      #endregion

      #region Loop until available credit is correct but fail if more than 50 times

      for (int i = 0; availableCredit != 70.0m && i < 100; i++)
      {
        Future<bool> result = new Future<bool>();

        //Fire of listeners serially and with some time apart
        AnonymousActor.New(inbox =>
        {
          account.Request(new QueryAccountBalance(), inbox)
            .Receive<AccountBalance>(message =>
            {
              balance = message.Balance;
              availableCredit = message.AvailableCredit;
              creditLimit = message.CreditLimit;

              Console.WriteLine("Balance={0}, Credit={1}, Limit={2}",
                balance,
                availableCredit,
                creditLimit);

              Thread.Sleep(1000);
              result.Complete(true);
            });
        });
        result.WaitUntilCompleted(5.Seconds());
        Console.WriteLine("Listener {0} completed", i);
        Thread.Sleep(1000);

        Assert.True(i < 50);
      }

      #endregion

      Assert.True(balance == 30 && availableCredit == 70.0m && creditLimit == 100.0m);
    }

    #endregion

    #region Setup & Teardown
    [SetUp]
    public void Setup()
    {
      Console.WriteLine("Start: {0}", DateTime.UtcNow);
    }

    [TearDown]
    public void Teardown()
    {
      Console.WriteLine("Stop: {0}", DateTime.UtcNow);
    }
    #endregion
  }
}
