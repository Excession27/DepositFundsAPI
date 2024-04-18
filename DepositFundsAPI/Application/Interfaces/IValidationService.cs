using DepositFundsAPI.Presentation.Models;

namespace DepositFundsAPI.Application.Interfaces
{
    public interface IValidationService
    {
        Task<bool> ValidateHashAsync(CreateTransactionRequest request, string hash);
    }
}
