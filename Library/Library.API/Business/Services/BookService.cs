using Library.API.Business.Interfaces;
using Library.API.Business.Models;
using Library.API.Business.Models.Validations;
using Library.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Business.Services
{
    public class BookService : BaseService, IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILoanBookRespository _loanBookRespository;

        public BookService(IBookRepository bookRepository,
                           INotifier notifier, 
                           ILoanBookRespository loanBookRespository) : base(notifier)
        {
            _bookRepository = bookRepository;
            _loanBookRespository = loanBookRespository;
        }

        public async Task AddAsync(Book book)
        {
            if (!RunValidation(new BookValidation(), book)) return;
            await _bookRepository.AddAsync(book);
        }

        public async Task UpdateAsync(Book book)
        {
            if (!RunValidation(new BookValidation(), book)) return;
            await _bookRepository.UpdateAsync(book);
        }

        public async Task RemoveAsync(Book book)
        {

            var loans = await _loanBookRespository.GetLoanBooksByBookId(book.Id);
            if (loans.Any())
            {
                Notify(DomainError.MessageErrorNotRemoveBookRefLoans);
                return;
            }
            book.IsDeleted = true;
            await UpdateAsync(book);
        }
    }
}
