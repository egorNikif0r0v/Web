using StockExchange.Core.Interfaces;
using StockExchange.Core.Models;
using StockExchange.DataAccess.Repositories;


namespace StockExchange.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<Book>> Get()
        {
            return await _bookRepository.Get();
        }
        public async Task<Guid> Create(Book book)
        {
            return  await _bookRepository.Create(book);
        }
        public async Task<Guid> Update(Guid id, string title,
            string description, decimal price)
        {
            return await _bookRepository.Update(id, title, description, price);
        }
        public async Task<Guid> Delete(Guid id)
        {
            return await _bookRepository.Delete(id);
        }
    }
}
