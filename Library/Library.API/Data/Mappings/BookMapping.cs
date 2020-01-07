using Library.API.Business.Models;
using Library.API.Parameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Data.Mappings
{
    public class BookMapping : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b=>b.Id);

            builder.Property(b => b.Title)
                .IsRequired()
                .HasColumnType(DomainParameters.ColumnVarcharOf100);

            builder.Property(b => b.Author)
                .IsRequired()
                .HasColumnType(DomainParameters.ColumnVarcharOf200);

            builder.Property(b => b.Genre)
                .IsRequired()
                .HasColumnType(DomainParameters.ColumnVarcharOf200);

            builder.HasMany(b => b.LoanBooks)
                .WithOne(lb => lb.Book)
                .HasForeignKey(lb => lb.BookId);

            builder.ToTable(DomainParameters.TableBookName);
        }
    }
}
