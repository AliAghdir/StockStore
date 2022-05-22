using StockStore.WebApp.Data.Repositories;
using StockStore.WebApp.Models;
using System.Linq;

namespace StockStore.WebApp.Data.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly StockStoreContext _context;
        public UserRepository(StockStoreContext context)
        {
            _context = context;

        }

        public void AddUser(User user)
        {
            if (user != null)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
        }

        public bool IsExistUserByEmail(string email)
        {
            if (_context.Users.Any(u => u.Email == email))
            {
                return true;
            }
            return false;
        }

        public User GetUserForLogin(string email, string password)
        {
            return _context.Users
                .SingleOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}