using SimpleActors.Messages;

namespace SimpleActors.Model
{
  using Stact;
  using Messages;

  public class AccountActor : Actor
  {
    private decimal _balance;
    private decimal _creditLimit;
    private decimal _availableCredit;

    public AccountActor(Inbox inbox)
    {
      // Default credit-limit
      _creditLimit = 1000.0m;

      inbox.Receive<Request<QueryAccountBalance>>(message =>
      {
        message.Respond(new AccountBalance
        {
          Balance = _balance,
          AvailableCredit = _availableCredit,
        });
      });

      inbox.Receive<ChargeAccount>(message =>
      {
        _balance = message.Amount;
        _availableCredit = _creditLimit - _balance;
      });
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
