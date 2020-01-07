using Library.API.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Business.Interfaces
{
    public interface ILoanService
    {
        Task AddAsync(Loan loan);
        Task UpdateAsync(Loan loan);
        Task UpdateStatusAsync(Loan loan);
        Task RemoveAsync(Loan loan);
        Task ReturnAllAsync(Loan loan);
        Task<bool> HasPendingReturnsByPeople(Loan loan);
        Task<bool> HasPendingReturns(Loan loan);
    }
}
