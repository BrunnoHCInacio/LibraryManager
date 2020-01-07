using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Business.Models
{
    public class People : Entity
    {
        public People()
        {
            Loans = new List<Loan>();
        }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Phone { get; set; }

        public Address Address { get; set; }

        public IEnumerable<Loan> Loans { get; set; }
    }
}
