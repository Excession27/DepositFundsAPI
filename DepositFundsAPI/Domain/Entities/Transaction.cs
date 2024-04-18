using System;
using System.Transactions;

namespace DepositFundsAPI.Domain.Entities
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public string ExternalTransactionId { get; set; }
        public string UserId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public DateTime CreatedAt { get; set; }
        
        public User User { get; set; }



        public Transaction(string externalTransactionId, string userId, decimal amount, string currency, DateTime createdAt)
        {
            ExternalTransactionId = externalTransactionId;
            UserId = userId;
            Amount = amount;
            Currency = currency;
            CreatedAt = createdAt;
        }
    }
}