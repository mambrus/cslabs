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

      account.Send(new QueryAccountBalance());
    }
  }
}
