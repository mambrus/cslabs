using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleActors
{
  class Account
  {
    public decimal AvailableCredit { get; private set; }
    public decimal Balance { get; private set; }
    public decimal CreditLimit { get; private set; }

    public Account(decimal creditLimit)
    {
      CreditLimit = creditLimit;
      Balance = 0.0m;
      AvailableCredit = CreditLimit - Balance;
    }

    public void Charge(decimal amount)
    {
      Balance -= amount;
      AvailableCredit = CalculateAvailableCredit();
    }
    public void ApplyPayment(decimal amount)
    {
      Balance -= amount;
      AvailableCredit = CalculateAvailableCredit();
    }

    public void ApplyPaymentAsync(decimal amount)
    {
      Balance -= amount;
      new Task(() =>
        { AvailableCredit = CalculateAvailableCredit(); }).Start();
    }

    private decimal CalculateAvailableCredit()
    {
      return CreditLimit - Balance;
    }
  }
}
