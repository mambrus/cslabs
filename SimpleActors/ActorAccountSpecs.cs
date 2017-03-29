using System;
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
    [Test]
    public void FirstTestName()
    {
      ActorRef account = ActorFactory.Create(inbox => new AccountActor(inbox)).GetActor();

      AnonymousActor.New(inbox =>
      {
        account.Request(new QueryAccountBalance(), inbox)
          .Receive<AccountBalance>(message =>
          {
            Console.WriteLine("Balance is {0}", message.Balance);
          });
      });
    }
  }
}
