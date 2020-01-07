
using AutoMapper;
using Library.API.Business.Interfaces;
using Library.API.Business.Models;
using Library.API.Resources;
using Library.API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.API.Controllers
{  
    [Authorize]
    [Route("api/books")]
    public class BooksController : MainController
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BooksController(IBookRepository bookRepository,
                               IBookService bookService,
                               IMapper mapper,
                               INotifier notifier) : base(notifier)
        {
            _bookRepository = bookRepository;
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<IEnumerable<BookViewModel>> GetAllBooks()
        {
            var headers = this.Request.Headers;
            
            if (headers.ContainsKey("title") && !string.IsNullOrEmpty(headers["title"]))
            {
                string title = headers["title"];
                return _mapper.Map<IEnumerable<BookViewModel>>(await _bookRepository.GetBooksByTitleAsync(title));
            }
            if (headers.ContainsKey("author") && !string.IsNullOrEmpty(headers["author"]))
            {
                string author = headers["author"];
                return _mapper.Map<IEnumerable<BookViewModel>>(await _bookRepository.GetBooksByAuthorAsync(author));
            }
            return _mapper.Map<IEnumerable<BookViewModel>>(await _bookRepository.GetAllAsync());
        }

        [HttpGet("{id:guid}")]
        public async Task<BookViewModel> GetBookById(Guid id)
        {
            return _mapper.Map<BookViewModel>(await _bookRepository.GetBookLoansByIdAsync(id));
        }

       
        [HttpPost()]
        public async Task<ActionResult> Add(BookViewModel bookViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _bookService.AddAsync(_mapper.Map<Book>(bookViewModel));
            return CustomResponse(bookViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id, BookViewModel bookViewModel)
        {
            if (id != bookViewModel.Id)
            {
                Notify(DomainError.MessageErrorIdDiferent);
                return CustomResponse();
            }
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _bookService.UpdateAsync(_mapper.Map<Book>(bookViewModel));
            return CustomResponse(bookViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Remove(Guid id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null) return NotFound();
            await _bookService.RemoveAsync(book);
            return CustomResponse();
        }
    }
}
