﻿namespace SimpleActors
{
  using System;
  using NUnit.Framework;

  [TestFixture]
  class AccountSpecs
  {
    [Test]
    public void Charging_an_account_should_adjust_the_balence()
    {
      var account = new Account(100.0m);
      account.Charge(50.0m);

      Console.WriteLine("Available credit; {0}", account.AvailableCredit);
      Assert.AreEqual(50.0m, account.AvailableCredit);
    }

    [Test]
    public void Charging_and_paying_an_account_should_adjust_the_balence()
    {
      var account = new Account(100.0m);
      account.Charge(50.0m);
      account.ApplyPayment(25.0m);

      Console.WriteLine("Available credit; {0}", account.AvailableCredit);
      Assert.AreEqual(75.0m, account.AvailableCredit);
    }

    [Test]
    public void Applying_payment_async_messes_up_the_works()
    {
      var account = new Account(100.0m);
      account.Charge(50.0m);
      account.ApplyPaymentAsync(25.0m);

      Console.WriteLine("Available credit; {0}", account.AvailableCredit);
      Assert.AreEqual(75.0m, account.AvailableCredit);
    }

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

  }
}
