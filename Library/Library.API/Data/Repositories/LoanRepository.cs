using Library.API.Business.Interfaces;
using Library.API.Business.Models;
using Library.API.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Data.Repositories
{
    public class LoanRepository : Repository<Loan>, ILoanRepository
    {
        public LoanRepository(AppDbContext context) : base(context) { }
       
        public async Task<IEnumerable<Loan>> GetLoansPeopleByPeopleAsync(Guid peopleId)
        {
            return await Db.Loans
                .AsNoTracking()
                .Include(l => l.People)
                .Where(l => l.PeopleId == peopleId && !l.IsDeleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<Loan>> GetLoansPeopleAsync()
        {
            return await Db.Loans
                 .AsNoTracking()
                .Include(l => l.People)
                .Where(l => !l.IsDeleted) 
                .ToListAsync();
        }

        public async Task<Loan> GetLoanPeopleByIdAsync(Guid id)
        {
            return await Db.Loans
                .AsNoTracking()
                .Include(l => l.People)
                .FirstOrDefaultAsync(l => l.Id == id && !l.IsDeleted);
        }
    }
}
