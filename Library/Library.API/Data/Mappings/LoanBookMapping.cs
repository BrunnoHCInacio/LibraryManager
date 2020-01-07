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
    public class LoanBookMapping : IEntityTypeConfiguration<LoanBook>
    {
        public void Configure(EntityTypeBuilder<LoanBook> builder)
        {
            builder.HasKey(lb=>lb.Id);

            builder.HasOne(lb => lb.Loan);
            builder.HasOne(lb => lb.Book);

            builder.ToTable(DomainParameters.TableLoanBooksName);
        }
    }
}
