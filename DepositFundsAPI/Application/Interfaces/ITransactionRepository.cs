using DepositFundsAPI.Application.Models;
using DepositFundsAPI.Domain.Entities;

namespace DepositFundsAPI.Application.Interfaces
{
    public interface ITransactionRepository
    {
        Task<int> AddAsync(Transaction transaction);

    }
}
