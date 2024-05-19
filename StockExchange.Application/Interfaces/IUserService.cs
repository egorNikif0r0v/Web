using StockExchange.Core.Models;


namespace StockExchange.Application.Interfaces
{
    public interface IUserService
    {
        Task Add(User user);
        Task<User> GetByEmail(string email);
    }
}
