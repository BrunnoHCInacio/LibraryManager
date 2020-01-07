using Library.API.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Business.Interfaces
{
    public interface IPeopleService
    {
        Task AddAsync(People people);
        Task UpdateAsync(People people);
        Task UpdateAddressAsync(Address address);
        Task RemoveAsync(People people);

    }
}
