using Library.API.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.API.Business.Interfaces
{
    public interface ILoanBookRespository : IRepository<LoanBook>
    {
        Task<IEnumerable<LoanBook>> GetLoanBooksByBookId(Guid bookId);
        Task<IEnumerable<LoanBook>> GetLoanBooksByLoanId(Guid loanId);
        Task<IEnumerable<LoanBook>> GetLoanBooks();
        Task<IEnumerable<LoanBook>> GetLoanBooksNotReturned();
        Task<IEnumerable<LoanBook>> GetLoanBooksNotReturnedByBookId(Guid bookId);
        Task<IEnumerable<LoanBook>> GetLoanBooksNotReturnedByBookAndLoanId(Guid bookId, Guid loanId);
    }
}
