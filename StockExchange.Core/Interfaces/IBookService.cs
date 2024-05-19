using StockExchange.Core.Models;

namespace StockExchange.Core.Interfaces
{
    public interface IBookService
    {
        Task<Guid> Create(Book book);
        Task<Guid> Delete(Guid id);
        Task<Guid> Update(Guid id, string title,
            string description, decimal price);
        Task<List<Book>> Get();
    }
}
