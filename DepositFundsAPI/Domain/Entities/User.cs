namespace DepositFundsAPI.Domain.Entities
{
    public class User
    {
        public string UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Funds { get; set; }

        public List<Transaction> Transactions { get; set; }
    }
}
