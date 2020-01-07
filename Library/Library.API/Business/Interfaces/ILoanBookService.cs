using Library.API.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Business.Interfaces
{
    public interface ILoanBookService
    {
        Task AddAsync(LoanBook loanBook);
        Task UpdateAsync(LoanBook loanBook);
        Task RemoveAsync(LoanBook loanBook);
        Task ReturnBookAsync(LoanBook loanBook);
    }
}
