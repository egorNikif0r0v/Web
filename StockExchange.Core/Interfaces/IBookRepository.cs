using StockExchange.Core.Models;

namespace StockExchange.DataAccess.Repositories
{
    public interface IBookRepository
    {
        Task<Guid> Create(Book book);
        Task<Guid> Delete(Guid id);
        Task<Guid> Update(Guid id, string title,
            string description, decimal price);
        Task<List<Book>> Get();

    }
}
