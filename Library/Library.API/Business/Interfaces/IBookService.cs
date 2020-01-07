using Library.API.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Business.Interfaces
{
    public interface IBookService
    {
        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task RemoveAsync(Book book);
    }
}
