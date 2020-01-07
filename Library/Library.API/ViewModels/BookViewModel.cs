using Library.API.Parameters;
using Library.API.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.ViewModels
{
    public class BookViewModel
    {
        public BookViewModel()
        {
            Loans = new List<LoanViewModel>();
        }
        public Guid Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationDomain),
                   ErrorMessageResourceName = "MessageErrorNotEmptyTitle")]
        [StringLength(DomainParameters.LengthSize200,
                     ErrorMessageResourceType = typeof(ValidationDomain),
                     ErrorMessageResourceName = "MessageErrorLengthTitle",
                     MinimumLength = DomainParameters.LengthSize2)]
        public string Title { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationDomain),
                   ErrorMessageResourceName = "MessageErrorNotEmptyAuthor")]
        [StringLength(DomainParameters.LengthSize200,
                     ErrorMessageResourceType = typeof(ValidationDomain),
                     ErrorMessageResourceName = "MessageErrorLengthAuthor",
                     MinimumLength = DomainParameters.LengthSize2)]
        public string Author { get; set; }

        public DateTime PublicationDate { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationDomain),
                   ErrorMessageResourceName = "MessageErrorNotEmptyGenre")]
        [StringLength(DomainParameters.LengthSize100,
                     ErrorMessageResourceType = typeof(ValidationDomain),
                     ErrorMessageResourceName = "MessageErrorLengthGenre",
                     MinimumLength = DomainParameters.LengthSize2)]
        public string Genre { get; set; }
        public bool IsDeleted { get; set; }

        public IEnumerable<LoanViewModel> Loans { get; set; }
    }
}
