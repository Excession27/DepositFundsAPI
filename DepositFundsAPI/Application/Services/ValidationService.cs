using DepositFundsAPI.Application.Interfaces;
using DepositFundsAPI.Presentation.Models;

namespace DepositFundsAPI.Application.Services
{
    public class ValidationService : IValidationService
    {
        private readonly string _secretKey = "tajniKljuc123";

        public async Task<bool> ValidateHashAsync(CreateTransactionRequest request, string check)
        {

            var data = $"{request.ExternalTransactionId}{request.UserId}{request.Amount}{request.Currency}{_secretKey}";
            var computedHash = ComputeHash(data);

            return computedHash == check.ToUpper();

        }

        private string ComputeHash(string input)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = System.Text.Encoding.UTF8.GetBytes(input);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToHexString(hash);
            }
        }
    }
}
