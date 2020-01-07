using Library.API.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Business.Interfaces
{
    public interface ILoanRepository : IRepository<Loan>
    {
        Task<IEnumerable<Loan>> GetLoansPeopleByPeopleAsync(Guid peopleId);
        Task<IEnumerable<Loan>> GetLoansPeopleAsync();
        Task<Loan> GetLoanPeopleByIdAsync(Guid id);
    }
}
