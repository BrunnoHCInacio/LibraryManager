using Library.API.Business.Interfaces;
using Library.API.Business.Models;
using Library.API.Business.Models.Validations;
using Library.API.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Business.Services
{
    public class PeopleService : BaseService, IPeopleService
    {
        private readonly IPeopleRepository _peopleRepository;
        private readonly IAddressService _addressRepository;
        private readonly ILoanRepository _loanRepository;
        public PeopleService(INotifier notifier,
                             IPeopleRepository peopleRepository,
                             IAddressService addressRepository, 
                             ILoanRepository loanRepository) : base(notifier)
        {
            _peopleRepository = peopleRepository;
            _addressRepository = addressRepository;
            _loanRepository = loanRepository;
        }

        public async Task AddAsync(People people)
        {
            if (!RunValidation(new PeopleValidation(), people)
                || !RunValidation(new AddressValidation(), people.Address)) return;
            if(_peopleRepository.SearchAsync(p=>p.Document == people.Document && !p.IsDeleted).Result.Any())
            {
                Notify(DomainError.MessageErrorHasExistPeopleWithDocument);
                return;
            }
            await _peopleRepository.AddAsync(people);
        }

        public async Task UpdateAsync(People people)
        {
            if (!RunValidation(new PeopleValidation(), people)) return;
            if (_peopleRepository.SearchAsync(p => p.Document == people.Document && p.Id != people.Id && !p.IsDeleted).Result.Any())
            {
                Notify(DomainError.MessageErrorHasExistPeopleWithDocument);
                return;
            }
            await _peopleRepository.UpdateAsync(people);
        }

        public async Task UpdateAddressAsync(Address address)
        {
            if (!RunValidation(new AddressValidation(), address)) return;
            await _addressRepository.UpdateAsync(address);
        }

        public async Task RemoveAsync(People people)
        {
            var loans = await _loanRepository.GetLoansPeopleByPeopleAsync(people.Id);
            if (loans.Any())
            {
                Notify(DomainError.MessageErrorNotRemovePeopleRefLoans);
                return;
            }

            if(people.Address != null)
            {
                people.Address.IsDeleted = true;
                await _addressRepository.UpdateAsync(people.Address);
            }

            people.IsDeleted = true;
            await _peopleRepository.UpdateAsync(people);
        }
    }
}
