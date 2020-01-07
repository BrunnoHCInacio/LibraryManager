using Library.API.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<LoanBook> LoanBooks { get; set; }
        public DbSet<People> Peoples { get; set; }
    }
}
