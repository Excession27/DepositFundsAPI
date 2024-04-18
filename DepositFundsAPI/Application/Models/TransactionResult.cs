using DepositFundsAPI.Domain.Entities;

namespace DepositFundsAPI.Application.Models


{
    public class TransactionResult
    {
        public bool IsSuccess { get; set; }
        public int TransactionId { get; set; }
        public string ErrorMessage { get; set; }
        public int ErrorCode { get; set; }

        // Factory metoda za uspešan rezultat
        public static TransactionResult Success(int id)
        {
            return new TransactionResult { IsSuccess = true, TransactionId = id };
        }

        // Factory metoda za neuspešan rezultat
        public static TransactionResult Failure(string errorMessage, int errorCode)
        {
            return new TransactionResult { IsSuccess = false, ErrorMessage = errorMessage, ErrorCode = errorCode };
        }
    }
}
