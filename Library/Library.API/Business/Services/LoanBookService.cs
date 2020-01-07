using Library.API.Business.Interfaces;
using Library.API.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Business.Services
{
    public class LoanBookService : BaseService, ILoanBookService
    {
        private readonly ILoanBookRespository _loanBookRepository;
        public LoanBookService(INotifier notifier, 
                               ILoanBookRespository loanBookRepository) : base(notifier)
        {
            _loanBookRepository = loanBookRepository;
        }
        public async Task AddAsync(LoanBook loanBook)
        {
            await _loanBookRepository.AddAsync(loanBook);
        }
        public async Task UpdateAsync(LoanBook loanBook)
        {
            await _loanBookRepository.UpdateAsync(loanBook);
        }

        public async Task RemoveAsync(LoanBook loanBook)
        {
            loanBook.IsDeleted = true;
            await _loanBookRepository.UpdateAsync(loanBook);
        }

        public async Task ReturnBookAsync(LoanBook loanBook)
        {
            loanBook.IsReturned = true;
            loanBook.DateReturn = new DateTime();
            await UpdateAsync(loanBook);
        }

       
    }
}
