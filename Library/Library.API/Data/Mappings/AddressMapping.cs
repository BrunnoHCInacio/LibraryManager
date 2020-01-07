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
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.ZipCode)
                .IsRequired()
                .HasColumnType(DomainParameters.ColumnVarcharOf8);

            builder.Property(a => a.Street)
                .IsRequired()
                .HasColumnType(DomainParameters.ColumnVarcharOf200);

            builder.Property(a => a.District)
                .IsRequired()
                .HasColumnType(DomainParameters.ColumnVarcharOf100);

            builder.Property(a => a.City)
                .IsRequired()
                .HasColumnType(DomainParameters.ColumnVarcharOf100);

            builder.Property(a => a.State)
                .IsRequired()
                .HasColumnType(DomainParameters.ColumnVarcharOf50);

            builder.Property(a => a.Country)
                .IsRequired()
                .HasColumnType(DomainParameters.ColumnVarcharOf100);

            builder.ToTable(DomainParameters.TableAddressName);
        }
    }
}
