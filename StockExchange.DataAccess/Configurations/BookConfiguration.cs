using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StockExchange.Core.Models;
using StockExchange.DataAccess.Entites;

namespace StockExchange.DataAccess.Configurations
{
    internal class BookConfiguration : IEntityTypeConfiguration<BookEntity>
    {
        public void Configure(EntityTypeBuilder<BookEntity> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Title)
                .HasMaxLength(Book.MAX_TITLE_LENGTH)
                .IsRequired();

            builder.Property(b => b.Price)
               .IsRequired();

            builder.Property(b => b.Description)
               .IsRequired();
        }
    }
}
