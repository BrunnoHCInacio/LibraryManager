using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.ViewModels
{
    public class LoanBookViewModel
    {
        public Guid Id { get; set; }

        public Guid BookId { get; set; }
        public Guid LoanId { get; set; }
        public DateTime ExpectedDateReturn { get; set; }
        public DateTime DateReturn { get; set; }
        public bool IsReturned { get; set; }
        public bool IsDeleted { get; set; }

        public string Title { get; set; }
    }
}
