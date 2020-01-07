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
    public class PeopleMapping : IEntityTypeConfiguration<People>
    {
        public void Configure(EntityTypeBuilder<People> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType(DomainParameters.ColumnVarcharOf200);

            builder.Property(p => p.Document)
                .IsRequired()
                .HasColumnType(DomainParameters.ColumnVarcharOf11);

            builder.Property(p => p.Phone)
                .IsRequired()
                .HasColumnType(DomainParameters.ColumnVarcharOf20);

            builder.HasOne(p => p.Address);

            builder.HasMany(p => p.Loans)
                .WithOne(l => l.People)
                .HasForeignKey(l => l.PeopleId);

            builder.ToTable(DomainParameters.TablePeopleName);
        }
    }
}
