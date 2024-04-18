using DepositFundsAPI.Domain.Entities;

namespace DepositFundsAPI.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByUserIdAsync(string id);
        Task<User> AddAsync(User user);
        public void UpdateUser(User user, decimal add);
    }
}
