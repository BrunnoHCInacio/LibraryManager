using FluentValidation;
using Library.API.Parameters;
using Library.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Business.Models.Validations
{
    public class BookValidation : AbstractValidator<Book>
    {
        public BookValidation()
        {
            RuleFor(b => b.Title)
              .NotEmpty()
              .WithMessage(ValidationDomain.MessageErrorNotEmptyTitle)
              .Length(DomainParameters.LengthSize2, DomainParameters.LengthSize200)
              .WithMessage(ValidationDomain.MessageErrorLengthTitle);
            
            RuleFor(b => b.Author)
              .NotEmpty()
              .WithMessage(ValidationDomain.MessageErrorNotEmptyTitle)
              .Length(DomainParameters.LengthSize2, DomainParameters.LengthSize200)
              .WithMessage(ValidationDomain.MessageErrorLengthTitle); 
            
            RuleFor(b => b.Genre)
              .NotEmpty()
              .WithMessage(ValidationDomain.MessageErrorNotEmptyGenre)
              .Length(DomainParameters.LengthSize2, DomainParameters.LengthSize100)
              .WithMessage(ValidationDomain.MessageErrorLengthGenre);

        }
    }
}
