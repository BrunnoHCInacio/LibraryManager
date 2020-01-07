using AutoMapper;
using Library.API.Business.Interfaces;
using Library.API.Business.Models;
using Library.API.Resources;
using Library.API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Controllers
{
    [Authorize]
    [Route("api/loans")]
    public class LoansController : MainController
    {
        private readonly ILoanRepository _loanRepository;
        private readonly ILoanBookRespository _loanBookRespository;
        private readonly ILoanService _loanService;
        private readonly ILoanBookService _loanBookService;
        private readonly IMapper _mapper;

        public LoansController(ILoanRepository loanRepository,
                               ILoanService loanService,
                               IMapper mapper,
                               INotifier notifier, 
                               ILoanBookService loanBookService, 
                               ILoanBookRespository loanBookRespository) : base(notifier)
        {
            _loanRepository = loanRepository;
            _loanService = loanService;
            _mapper = mapper;
            _loanBookService = loanBookService;
            _loanBookRespository = loanBookRespository;
        }

        public async Task<IEnumerable<LoanViewModel>> GetAllLoans()
        {
            var headers = this.Request.Headers;
            if(headers.ContainsKey("peopleId") && !string.IsNullOrEmpty(headers["peopleId"]))
            {
                var peopleId = Guid.Parse(headers["peopleId"]);
                return _mapper.Map<IEnumerable<LoanViewModel>>(await _loanRepository.GetLoansPeopleByPeopleAsync(peopleId));
            }
            
            return _mapper.Map<IEnumerable<LoanViewModel>>(await _loanRepository.GetLoansPeopleAsync());
        }

        [HttpGet("{id:guid}")]
        public async Task<LoanViewModel> GetLoanById(Guid id)
        {
            var loan = _mapper.Map<LoanViewModel>(await _loanRepository.GetLoanPeopleByIdAsync(id));
            loan.LoanBooks = _mapper.Map<IEnumerable<LoanBookViewModel>>(await _loanBookRespository.GetLoanBooksByLoanId(id));
            return loan;
        }

        [HttpPost()]
        public async Task<ActionResult> Add(LoanViewModel loanViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            if (await _loanService.HasPendingReturnsByPeople(_mapper.Map<Loan>(loanViewModel))) return CustomResponse();
                     
            await _loanService.AddAsync(_mapper.Map<Loan>(loanViewModel));
            return CustomResponse(loanViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id, LoanViewModel loanViewModel)
        {
            if (id != loanViewModel.Id)
            {
                Notify(DomainError.MessageErrorIdDiferent);
                return CustomResponse();
            }
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _loanService.UpdateAsync(_mapper.Map<Loan>(loanViewModel));
            return CustomResponse(loanViewModel);
        }

        [HttpPut("return/{id:guid}")]
        public async Task<ActionResult> ReturnBook(Guid id, LoanBookViewModel loanBookViewModel)
        {
            if (id != loanBookViewModel.Id)
            {
                Notify(DomainError.MessageErrorIdDiferent);
                return CustomResponse();
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _loanBookService.ReturnBookAsync(_mapper.Map<LoanBook>(loanBookViewModel));

            var loan = await _loanRepository.GetByIdAsync(loanBookViewModel.LoanId);
            await _loanService.UpdateStatusAsync(loan);

            return CustomResponse(loanBookViewModel);
        }

        [HttpPut("returnAll/{id:guid}")]
        public async Task<ActionResult> ReturnAllBooks(Guid id, LoanViewModel loanViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var loan = _mapper.Map<Loan>(loanViewModel);
            await _loanService.ReturnAllAsync(loan);

            return CustomResponse();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Remove(Guid id)
        {
            var loan = await _loanRepository.GetByIdAsync(id);
            if (loan == null) return NotFound();
            if (await _loanService.HasPendingReturns(loan)) return CustomResponse();

            var loanBooks = await _loanBookRespository.GetLoanBooksByLoanId(loan.Id);
            if (loanBooks.Any())
            {
                foreach (var loanBook in loanBooks)
                {
                    await _loanBookService.RemoveAsync(loanBook);
                }
            }

            await _loanService.RemoveAsync(loan);
            return CustomResponse();
        }
    }
}
