using FluentValidation;
using Library.API.Parameters;
using Library.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Business.Models.Validations
{
    public class AddressValidation : AbstractValidator<Address>
    {
        public AddressValidation()
        {
            RuleFor(a => a.ZipCode)
               .NotEmpty()
               .WithMessage(ValidationDomain.MessageErrorNotEmptyZipCode)
               .Length(DomainParameters.LengthSize8)
               .WithMessage(ValidationDomain.MessageErrorLengthZipCode);

            RuleFor(a => a.Street)
               .NotEmpty()
               .WithMessage(ValidationDomain.MessageErrorNotEmptyStreet)
               .Length(DomainParameters.LengthSize2, DomainParameters.LengthSize200)
               .WithMessage(ValidationDomain.MessageErrorLengthStreet);

            RuleFor(a => a.District)
               .NotEmpty()
               .WithMessage(ValidationDomain.MessageErrorNotEmptyDistrict)
               .Length(DomainParameters.LengthSize2, DomainParameters.LengthSize100)
               .WithMessage(ValidationDomain.MessageErrorLengthDistrict);

            RuleFor(a => a.City)
               .NotEmpty()
               .WithMessage(ValidationDomain.MessageErrorNotEmptyCity)
               .Length(DomainParameters.LengthSize2, DomainParameters.LengthSize100)
               .WithMessage(ValidationDomain.MessageErrorLengthCity);

            RuleFor(a => a.State)
               .NotEmpty()
               .WithMessage(ValidationDomain.MessageErrorNotEmptyState)
               .Length(DomainParameters.LengthSize2, DomainParameters.LengthSize50)
               .WithMessage(ValidationDomain.MessageErrorLengthState);

            RuleFor(a => a.Country)
               .NotEmpty()
               .WithMessage(ValidationDomain.MessageErrorNotEmptyCountry)
               .Length(DomainParameters.LengthSize2, DomainParameters.LengthSize50)
               .WithMessage(ValidationDomain.MessageErrorLengthCountry);
        }
    }
}
