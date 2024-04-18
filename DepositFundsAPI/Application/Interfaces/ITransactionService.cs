namespace DepositFundsAPI.Application.Interfaces
{
    using DepositFundsAPI.Application.Models;
    using DepositFundsAPI.Presentation.Models;
    using System.Threading.Tasks;

    public interface ITransactionService
    {
        Task<TransactionResult> CreateTransactionAsync(CreateTransactionRequest request);
    }
}
