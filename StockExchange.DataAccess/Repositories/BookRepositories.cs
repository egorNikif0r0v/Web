using Microsoft.EntityFrameworkCore;
using StockExchange.Core.Models;
using StockExchange.DataAccess.Entites;

namespace StockExchange.DataAccess.Repositories
{
    public class BookRepositories : IBookRepository
    {
        private readonly DataExchangeDbContext _dbContext;
        public BookRepositories(DataExchangeDbContext context) 
        {
            _dbContext = context;
        }

        public async Task<List<Book>> Get()
        { 
            var bookEntities = await _dbContext.Books
                .AsNoTracking()
                .ToListAsync();
            var books = bookEntities
                .Select(b => Book.Create(b.Id, b.Title,
                    b.Description, b.Price).book)
                .ToList();

            return books;
        }

        public async Task<Guid> Create(Book book)
        {
            var bookEntity = new BookEntity
            {
                Id = book.Id,
                Description = book.Description,
                Title = book.Title,
                Price = book.Price
            };

            await _dbContext.Books.AddAsync(bookEntity);
            await _dbContext.SaveChangesAsync();

            return bookEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string title, 
            string description, decimal price)
        {
            await _dbContext.Books
                     .Where(b => b.Id == id)
                     .ExecuteUpdateAsync(s => s
                        .SetProperty(b => b.Title, title)
                        .SetProperty(b => b.Description, description)
                        .SetProperty(b => b.Price, price));
            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _dbContext.Books
                     .Where(b => b.Id == id)
                     .ExecuteDeleteAsync();
            return id;
        }
    }
}
