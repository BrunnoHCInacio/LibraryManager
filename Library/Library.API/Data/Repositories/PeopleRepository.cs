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
    public class PeopleRepository : Repository<People>, IPeopleRepository
    {
        public PeopleRepository(AppDbContext context) : base(context) { }
        public async Task<People> GetPeopleAddressLoansByIdAssync(Guid id)
        {
            var registros = await Db.Peoples
                .AsNoTracking()
                .Include(p=>p.Address)
                .FirstOrDefaultAsync(p=>p.Id == id);

            return registros;
        }

        public async Task<IEnumerable<People>> GetPeoplesByName(string name)
        {
            return await SearchAsync(p => p.Name.ToLower().Contains(name.ToLower()) && !p.IsDeleted);
        }
    }
}
