using SimpleActors.Messages;

namespace SimpleActors.Model
{
  using Stact;
  using Messages;
  using System.Threading;

  public class AccountActor : Actor
  {
    private decimal _balance;
    private decimal _creditLimit;
    private decimal _availableCredit;

    public AccountActor(Inbox inbox, decimal creditLimit)
    {
      _creditLimit = creditLimit;
      _balance = 0.0m;
      _availableCredit = _creditLimit - _balance;

      AsyncBehaviour(inbox);      
    }

    private void AsyncBehaviour(Inbox inbox)
    {
      inbox.Loop(loop =>
      {
        loop.Receive<Request<QueryAccountBalance>>(message =>
        {
          message.Respond(new AccountBalance
          {
            Balance = _balance,
            AvailableCredit = _availableCredit,
            CreditLimit = _creditLimit,
          });
          loop.Continue();
        });

        loop.Receive<ChargeAccount>(message =>
        {
          _balance += message.Amount;
          _availableCredit = CalculateAvailableCredit();
          loop.Continue();
        });
      });
    }

    private decimal CalculateAvailableCredit()
    {
      // Simulate some remote SQL query that takes time
      Thread.Sleep(5000);

      return CreditLimit - Balance;
    }

    public decimal Balance
    {
      get { return _balance; }
    }

    public decimal CreditLimit
    {
      get { return _creditLimit; }
    }
  }
}
