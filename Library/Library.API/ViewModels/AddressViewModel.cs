using Library.API.Parameters;
using Library.API.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.ViewModels
{
    public class AddressViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid PeopleId { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationDomain),
                    ErrorMessageResourceName = "MessageErrorNotEmptyZipCode")]
        [StringLength(DomainParameters.LengthSize8, 
                      ErrorMessageResourceType = typeof(ValidationDomain),
                      ErrorMessageResourceName = "MessageErrorLengthZipCode",
                      MinimumLength = DomainParameters.LengthSize8)]
        public string ZipCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationDomain),
                    ErrorMessageResourceName = "MessageErrorNotEmptyStreet")]
        [StringLength(DomainParameters.LengthSize200,
                      ErrorMessageResourceType = typeof(ValidationDomain),
                      ErrorMessageResourceName = "MessageErrorLengthStreet",
                      MinimumLength = DomainParameters.LengthSize2)]
        public string Street { get; set; }

        public string Number { get; set; }
        public string Complement { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationDomain),
                    ErrorMessageResourceName = "MessageErrorNotEmptyDistrict")]
        [StringLength(DomainParameters.LengthSize100,
                      ErrorMessageResourceType = typeof(ValidationDomain),
                      ErrorMessageResourceName = "MessageErrorLengthDistrict",
                      MinimumLength = DomainParameters.LengthSize2)]
        public string District { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationDomain),
                    ErrorMessageResourceName = "MessageErrorLengthCity")]
        [StringLength(DomainParameters.LengthSize100,
                      ErrorMessageResourceType = typeof(ValidationDomain),
                      ErrorMessageResourceName = "MessageErrorNotEmptyCity",
                      MinimumLength = DomainParameters.LengthSize2)]
        public string City { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationDomain),
                    ErrorMessageResourceName = "MessageErrorNotEmptyState")]
        [StringLength(DomainParameters.LengthSize50,
                      ErrorMessageResourceType = typeof(ValidationDomain),
                      ErrorMessageResourceName = "MessageErrorLengthState",
                      MinimumLength = DomainParameters.LengthSize2)]
        public string State { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationDomain),
                    ErrorMessageResourceName = "MessageErrorNotEmptyCountry")]
        [StringLength(DomainParameters.LengthSize50,
                      ErrorMessageResourceType = typeof(ValidationDomain),
                      ErrorMessageResourceName = "MessageErrorLengthCountry",
                      MinimumLength = DomainParameters.LengthSize2)]
        public string Country { get; set; }

        public bool IsDeleted { get; set; }
    }
}
