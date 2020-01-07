using Library.API.Parameters;
using Library.API.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.ViewModels
{
    public class PeopleViewModel
    {
        public PeopleViewModel()
        {
            Loans = new List<LoanViewModel>();
        }
        public Guid Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationDomain),
                   ErrorMessageResourceName = "MessageErrorNotEmptyName")]
        [StringLength(DomainParameters.LengthSize200,
                     ErrorMessageResourceType = typeof(ValidationDomain),
                     ErrorMessageResourceName = "MessageErrorLengthName",
                     MinimumLength = DomainParameters.LengthSize2)]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationDomain),
                   ErrorMessageResourceName = "MessageErrorNotEmptyCPF")]
        public string Document { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationDomain),
                   ErrorMessageResourceName = "MessageErrorNotEmptyPhone")]
        public string Phone { get; set; }
        public bool IsDeleted { get; set; }

        public AddressViewModel Address { get; set; }

        public IEnumerable<LoanViewModel> Loans { get; set; }
    }
}
