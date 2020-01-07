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
    public class LoanBookRepository : Repository<LoanBook>, ILoanBookRespository
    {
        public LoanBookRepository(AppDbContext context):base(context) { }
        public async Task<IEnumerable<LoanBook>> GetLoanBooks()
        {
            return await Db.LoanBooks
                .AsNoTracking()
                .Include(lb => lb.Book)
                .Include(lb => lb.Loan)
                .Where(lb => !lb.IsDeleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<LoanBook>> GetLoanBooksByBookId(Guid bookId)
        {
            return await Db.LoanBooks
               .AsNoTracking()
               .Include(lb => lb.Book)
               .Include(lb => lb.Loan)
               .Where(lb => lb.BookId == bookId && !lb.IsDeleted)
               .ToListAsync();
        }

        public async Task<IEnumerable<LoanBook>> GetLoanBooksByLoanId(Guid loanId)
        {
            return await Db.LoanBooks
                 .AsNoTracking()
                 .Include(lb => lb.Book)
                 .Include(lb => lb.Loan)
                 .Where(lb => lb.LoanId == loanId && !lb.IsDeleted)
                 .ToListAsync();
        }

        public async Task<IEnumerable<LoanBook>> GetLoanBooksNotReturned()
        {
            return await Db.LoanBooks
               .AsNoTracking()
               .Include(lb => lb.Book)
               .Include(lb => lb.Loan)
               .Where(lb => !lb.IsDeleted && !lb.IsReturned)
               .ToListAsync();
        }

        public async Task<IEnumerable<LoanBook>> GetLoanBooksNotReturnedByBookId(Guid bookId)
        {
            return await Db.LoanBooks
             .AsNoTracking()
             .Include(lb => lb.Book)
             .Include(lb => lb.Loan)
             .Where(lb => !lb.IsDeleted
                    && lb.BookId == bookId
                    && !lb.IsReturned)
             .ToListAsync();
        }
    }
}
