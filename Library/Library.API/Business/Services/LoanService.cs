using Library.API.Business.Interfaces;
using Library.API.Business.Models;
using Library.API.Parameters;
using Library.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Business.Services
{
    public class LoanService : BaseService, ILoanService
    {
        private readonly ILoanRepository _loanRepository;
        private readonly ILoanBookRespository _loanBookRepository;
        private readonly IBookRepository _bookRepository;
        private readonly ILoanBookService _loanBookService;
        public LoanService(INotifier notifier,
                           ILoanRepository loanRepository,
                           ILoanBookRespository loanBookRepository,
                           IBookRepository bookRepository, ILoanBookService loanBookService) : base(notifier)
        {
            _loanRepository = loanRepository;
            _loanBookRepository = loanBookRepository;
            _bookRepository = bookRepository;
            _loanBookService = loanBookService;
        }

        public async Task<Loan> GetIdCompleteAsync(Guid id)
        {
            var loan = await _loanRepository.GetLoanPeopleByIdAsync(id);
            loan.LoanBooks = await _loanBookRepository.GetLoanBooksByLoanId(id);
            return loan;
        }

        public async Task AddAsync(Loan loan)
        {
            if (await HasPendingReturnsByPeople(loan)) return;
            if (!DateExtepectedIsVaid(loan)) return;

            loan.StatusLoan = DomainParameters.Borrowed;
            await _loanRepository.AddAsync(loan);

            if (loan.LoanBooks.Any())
            {
                foreach (var loanBook in loan.LoanBooks)
                {
                    _loanBookService.AddAsync(loanBook);
                }
            }
            
        }

        public async Task UpdateAsync(Loan loan)
        {
            if (!DateExtepectedIsVaid(loan)) return;
            await _loanRepository.UpdateAsync(loan);
        }

        public async Task UpdateStatusAsync(Loan loan)
        {
            var loanBooks = await _loanBookRepository.GetLoanBooksByLoanId(loan.Id);
            var numberReturn = loanBooks.Count(l => l.IsReturned);

            if (numberReturn > 0 && numberReturn != loanBooks.Count())
            {
                loan.StatusLoan = DomainParameters.PartiallyReturned;
            }
            if (numberReturn == loanBooks.Count())
            {
                loan.StatusLoan = DomainParameters.Returned;
            }
            await _loanRepository.UpdateAsync(loan);
        }

        public async Task RemoveAsync(Loan loan)
        {
            loan.IsDeleted = true;
            await _loanRepository.UpdateAsync(loan);
        }

        public async  Task ReturnAllAsync(Loan loan)
        {
            foreach (var loanBook in loan.LoanBooks)
            {
               await _loanBookService.ReturnBookAsync(loanBook); 
            }
            await UpdateStatusAsync(loan);
            
        }

        public async Task<bool> HasPendingReturns(Loan loan)
        {
            foreach (var loanBook in loan.LoanBooks)
            {
                var loanBooks = await _loanBookRepository.GetLoanBooksNotReturnedByBookAndLoanId(loanBook.BookId, loan.Id);
                if (loanBooks.Any())
                {
                    Notify(DomainError.MessageErrorNotRemoveLoan);
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> HasPendingReturnsByPeople(Loan loan)
        {
            foreach (var loanBook in loan.LoanBooks)
            {
                var loanBooksNotReturneds = await _loanBookRepository.GetLoanBooksNotReturnedByBookId(loanBook.BookId);

                if (loanBooksNotReturneds.Any())
                {
                    foreach (var notReturned in loanBooksNotReturneds)
                    {
                        var lb = await _loanRepository.GetLoanPeopleByIdAsync(notReturned.LoanId);
                        if (lb.PeopleId == loan.PeopleId)
                        {
                            var book = await _bookRepository.GetByIdAsync(notReturned.BookId);
                            Notify("Este livro " + book.Title + " já consta em um emprestimo pendente");
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private bool DateExtepectedIsVaid(Loan loan)
        {
            foreach (var loanBook in loan.LoanBooks)
            {
                if (loanBook.ExpectedDateReturn < DateTime.Now)
                {
                    Notify(DomainError.MessageErrorDateNotValid);
                    return false;
                }
            }
            return true;
        }
    }
}
