using DepositFundsAPI.Application.Interfaces;
using DepositFundsAPI.Application.Models;
using DepositFundsAPI.Domain.Entities;
using DepositFundsAPI.Presentation.Models;


public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly IUserRepository _userRepository;


    public TransactionService(ITransactionRepository transactionRepository, IUserRepository userRepository)
    {
        _transactionRepository = transactionRepository;
        _userRepository = userRepository;

    }

    public async Task<TransactionResult> CreateTransactionAsync(CreateTransactionRequest request)
    {
        try
        {
            
            var user = await _userRepository.GetByUserIdAsync(request.UserId);
            if (user == null)
            {
                return TransactionResult.Failure("User not found", 404);
            }

            var transaction = new Transaction(request.ExternalTransactionId, request.UserId, request.Amount, request.Currency, request.CreatedAt);
            await _transactionRepository.AddAsync(transaction);
            _userRepository.UpdateUser(user, request.Amount);

            return TransactionResult.Success(transaction.TransactionId);

        }
        catch (Exception ex)
        {
            return TransactionResult.Failure("An error occurred while processing the transaction.", 1);
        }
    }


}