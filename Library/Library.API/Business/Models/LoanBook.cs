using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Business.Models
{
    public class LoanBook : Entity
    {
        public Guid BookId { get; set; }
        public Guid LoanId { get; set; }
        public DateTime ExpectedDateReturn { get; set; }
        public DateTime DateReturn { get; set; }
        public bool IsReturned { get; set; }

        public Book Book { get; set; }
        public Loan Loan { get; set; }
    }
}
