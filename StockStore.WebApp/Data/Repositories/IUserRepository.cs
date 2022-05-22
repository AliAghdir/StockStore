using StockStore.WebApp.Models;

namespace StockStore.WebApp.Data.Repositories
{
    public interface IUserRepository
    {
        bool IsExistUserByEmail(string email);
        void AddUser(User user);
        User GetUserForLogin(string email, string password);
    }
}