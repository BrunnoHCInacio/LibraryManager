using Library.API.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Business.Interfaces
{
    public interface IPeopleRepository : IRepository<People>
    {
        Task<People> GetPeopleAddressLoansByIdAssync(Guid id);
        Task<IEnumerable<People>> GetPeoplesByName(string name);

    }
}
