using Library.API.Business.Interfaces;
using Library.API.Business.Models;
using Library.API.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Data.Repositories
{
    public class AddressRepository : Repository<Address>, IAddressService
    {
        public AddressRepository(AppDbContext context) : base(context) {}
    }
}
