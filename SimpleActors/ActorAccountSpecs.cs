using SimpleActors.Model;

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
      var account = ActorFactory.Create(x => new AccountActor()).GetActor();

      //account.
    }
  }
}
