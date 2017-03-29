using SimpleActors.Messages;

namespace SimpleActors.Model
{
  using Stact;
  using Messages;

  public class AccountActor : Actor
  {
    decimal _balance;
    decimal _creditLimit;

    public AccountActor(Inbox inbox)
    {
      inbox.Receive<Request<QueryAccountBalance>>(message =>
      {
        message.Respond(new AccountBalance // <== Set BP here
        {
          Balance = _balance
        });
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
