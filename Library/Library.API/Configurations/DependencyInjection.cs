using Library.API.Business.Interfaces;
using Library.API.Business.Notifications;
using Library.API.Business.Services;
using Library.API.Data.Context;
using Library.API.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();
            services.AddScoped<INotifier, Notifier>();

            services.AddScoped<IPeopleRepository, PeopleRepository>();
            services.AddScoped<IAddressService, AddressRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ILoanBookRespository, LoanBookRepository>();

            services.AddScoped<IPeopleService, PeopleService>();
            services.AddScoped<ILoanService, LoanService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ILoanBookService, LoanBookService>();

            return services;
        }
    }
}
