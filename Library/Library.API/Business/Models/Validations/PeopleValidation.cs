using FluentValidation;
using Library.API.Parameters;
using Library.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Business.Models.Validations
{
    public class PeopleValidation : AbstractValidator<People>
    {
        public PeopleValidation()
        {
            RuleFor(p => p.Name)
             .NotEmpty()
             .WithMessage(ValidationDomain.MessageErrorNotEmptyName)
             .Length(DomainParameters.LengthSize2, DomainParameters.LengthSize200)
             .WithMessage(ValidationDomain.MessageErrorLengthName);

            RuleFor(p => p.Document)
              .NotEmpty()
              .WithMessage(ValidationDomain.MessageErrorNotEmptyCPF);

            RuleFor(p => p.Document.Length)
                .Equal(CpfValidation.LengthCpf)
                .WithMessage(ValidationDomain.MessageErrorLengthCPF);

            RuleFor(p => CpfValidation.Validate(p.Document))
                .Equal(true)
                .WithMessage(ValidationDomain.MessageErrorInvalidDocument);

            RuleFor(p => p.Phone)
              .NotEmpty()
              .WithMessage(ValidationDomain.MessageErrorNotEmptyPhone);
              
        }
    }
}
