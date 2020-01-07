using Library.API.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Business.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<Book>> GetBooksByTitleAsync(string title);
        Task<IEnumerable<Book>> GetBooksByAuthorAsync(string author);
        Task<Book> GetBookLoansByIdAsync(Guid bookId);
        
    }
}
