using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Business.Models
{
    public class Book : Entity
    {
        public Book()
        {
            LoanBooks = new List<LoanBook>();
        }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublicationDate { get; set; }
        public string Genre { get; set; }

        public IEnumerable<LoanBook> LoanBooks { get; set; }
    }
}
