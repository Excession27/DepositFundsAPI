using DepositFundsAPI.Application.Interfaces;
using DepositFundsAPI.Domain.Entities;
using DepositFundsAPI.Infrastucture.Data;

namespace DepositFundsAPI.Infrastucture.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<User> AddAsync(User user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                
                throw new InvalidOperationException("Could not add the user to the database.", ex);
            }
        }

        public async Task<User> GetByUserIdAsync(string id)
        {

            User user = await _context.Users.FindAsync(id);

            return user;


        }

        public void UpdateUser(User user, decimal add)
        {
            user.Funds = user.Funds + add;
            _context.Update(user);
            _context.SaveChangesAsync();
        }
    }
}
