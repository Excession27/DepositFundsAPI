
using System.Transactions;

namespace DepositFundsAPI.Presentation.Models
{
    public class CreateTransactionRequest
    {
        public string ExternalTransactionId { get; set; }
        public string UserId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
