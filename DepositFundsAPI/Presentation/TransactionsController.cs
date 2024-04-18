using DepositFundsAPI.Application.Interfaces;
using DepositFundsAPI.Presentation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DepositFundsAPI.Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IValidationService _validationService;
        private readonly ILogger<TransactionsController> _logger;

        public TransactionsController(ITransactionService transactionService, IValidationService validationService, ILogger<TransactionsController> logger)
        {
            _transactionService = transactionService;
            _validationService = validationService;
            _logger = logger;
        }
        
        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit([FromBody] CreateTransactionRequest request)
        {
            _logger.LogInformation("Received a deposit request with ExternalTransactionId: {ExternalTransactionId}", request.ExternalTransactionId);

            
            string hashValue = HttpContext.Request.Headers["X-Hash"].FirstOrDefault();


                if (!await _validationService.ValidateHashAsync(request, hashValue))
                {
                    _logger.LogWarning($"Invalid hash for transaction {request.ExternalTransactionId}");
                    return BadRequest(new { Message = "Invalid request data", Status = 3 });
                }
            
            
            var result = await _transactionService.CreateTransactionAsync(request);
            if (result.IsSuccess)
            {
                _logger.LogInformation($"Request with ExternalTransactionId: {request.ExternalTransactionId} and internal TransactionId: {result.TransactionId} completed successfully.");
                return Ok(new
                {
                    TransactionId = result.TransactionId,
                    Message = "Transaction completed successfully",
                    Status = 0
                }); ;
            }
            else
            {
                _logger.LogWarning($"Transaction failed with code {result.ErrorCode} and message {result.ErrorMessage}");
                return BadRequest(new
                {
                    Message = result.ErrorMessage,
                    Status = result.ErrorCode
                });
            }
        }
    }
}
