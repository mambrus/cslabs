using SimpleActors.Messages;

namespace SimpleActors.Model
{
  using Stact;

  public class AccountActor : Actor
  {
    public AccountActor(Inbox inbox)
    {
      inbox.Receive<Request<QueryAccountBalance>>(message => { });
    }

    public decimal Balance { get; }
    public decimal CreditLimit { get; }
  }
}
