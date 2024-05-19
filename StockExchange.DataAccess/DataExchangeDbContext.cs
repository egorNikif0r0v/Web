using Microsoft.EntityFrameworkCore;
using StockExchange.Core.Models;
using StockExchange.DataAccess.Configurations;
using StockExchange.DataAccess.Entites;

namespace StockExchange.DataAccess
{
    public class DataExchangeDbContext(DbContextOptions<DataExchangeDbContext> options) :
        DbContext(options)
    {
        public DbSet<BookEntity> Books { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
