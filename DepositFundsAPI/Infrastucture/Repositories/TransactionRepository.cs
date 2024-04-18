using DepositFundsAPI.Application.Interfaces;
using DepositFundsAPI.Domain.Entities;
using DepositFundsAPI.Infrastucture.Data;
using Microsoft.EntityFrameworkCore;

namespace DepositFundsAPI.Infrastucture.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _context;

        public TransactionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return transaction.TransactionId;
        }

    }
}
