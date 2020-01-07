using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
    
namespace Library.API.ViewModels
{
    public class LoanViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid PeopleId { get; set; }
        public string StatusLoan { get; set; }

        public IEnumerable<LoanBookViewModel> LoanBooks { get; set; }

        public string PeopleName { get; set; }
        public string PeopleDocument { get; set; }
        public bool IsDeleted { get; set; }
    }
}
