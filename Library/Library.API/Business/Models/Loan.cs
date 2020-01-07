using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Business.Models
{
    public class Loan : Entity
    {
        public Guid PeopleId { get; set; }
        public string StatusLoan { get; set; }
        public IEnumerable<LoanBook> LoanBooks { get; set; }

        public People People { get; set; }
    }
}
