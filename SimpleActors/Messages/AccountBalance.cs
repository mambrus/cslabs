
namespace SimpleActors.Messages
{
  class AccountBalance
  {
    public decimal Balance { set; get; } = 0.0m;
    public decimal AvailableCredit {set; get; } = 0.0m;
    public decimal CreditLimit { set; get; } = 0.0m;
  }
}
