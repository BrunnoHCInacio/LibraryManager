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
    public class LoanMapping : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.HasKey(l => l.Id);

            builder.HasOne(l => l.People);

            builder.Property(l => l.StatusLoan)
                .HasColumnType(DomainParameters.ColumnVarcharOf50);

            builder.HasMany(l => l.LoanBooks)
                .WithOne(lb => lb.Loan)
                .HasForeignKey(lb =>lb.LoanId);

            builder.ToTable(DomainParameters.TableLoanName);
        }
    }
}
