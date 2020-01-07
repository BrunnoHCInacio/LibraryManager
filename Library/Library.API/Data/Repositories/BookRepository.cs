using Library.API.Business.Interfaces;
using Library.API.Business.Models;
using Library.API.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Data.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context) {}
        public async Task<Book> GetBookLoansByIdAsync(Guid bookId)
        {
            return await Db.Books
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == bookId && !b.IsDeleted);
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(string author)
        {
            return await SearchAsync(b => b.Author.ToLower().Contains(author.ToLower()) && !b.IsDeleted);
        }

        public async Task<IEnumerable<Book>> GetBooksByTitleAsync(string title)
        {
            return await SearchAsync(b => b.Title.ToLower().Contains(title.ToLower()) && !b.IsDeleted);
        }
    }
}
