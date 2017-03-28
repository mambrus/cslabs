namespace SimpleActors
{
  using System;
  using NUnit.Framework;

  [TestFixture]
  class AccountSpecs
  {
    private Account _account;

    [SetUp]
    public void Init()
    {
      _account = new Account(100m);
    }

    [Test]
    public void Chargeing_an_account_should_adjust_the_balence()
    {
      Assert.AreEqual(0m, _account.Balance);
      _account.Charge(10m);
      Assert.AreEqual(110m, _account.AvailableCredit);
    }
  }
}
