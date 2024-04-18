using System.Transactions;

namespace DepositFundsAPI.Application.Models
{
    public class TransactionSearchCriteria
    {
        public string UserId { get; set; }
        public decimal? MinimumAmount { get; set; }
        public decimal? MaximumAmount { get; set; }
        public string Currency { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ExternalTransactionId { get; set; }
        public TransactionStatus? Status { get; set; }
    }
}
