using AutoMapper;
using Library.API.Business.Interfaces;
using Library.API.Business.Models;
using Library.API.Resources;
using Library.API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.API.Controllers
{
    [Authorize]
    [Route("api/peoples")]
    public class PeoplesController : MainController
    {
        private readonly IPeopleRepository _peopleRepository;
        private readonly IPeopleService _peopleService;
        private readonly IMapper _mapper;

        public PeoplesController(INotifier notifier, 
                                 IPeopleRepository peopleRepository, 
                                 IPeopleService peopleService, 
                                 IMapper mapper) : base(notifier)
        {
            _peopleRepository = peopleRepository;
            _peopleService = peopleService;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<IEnumerable<PeopleViewModel>> GetAllPeoples()
        {
            var headers = this.Request.Headers;
            if (headers.ContainsKey("name"))
            {
                string name = headers["name"];
                return _mapper.Map<IEnumerable<PeopleViewModel>>(await _peopleRepository.GetPeoplesByName(name));
            }
            
            return _mapper.Map<IEnumerable<PeopleViewModel>>(await _peopleRepository.GetAllAsync());
        }

        [HttpGet("{id:guid}")]
        public async Task<PeopleViewModel> GetPeopleById(Guid id)
        {
            return _mapper.Map<PeopleViewModel>(await _peopleRepository.GetPeopleAddressLoansByIdAssync(id));
        }

        [HttpPost()]
        public async Task<ActionResult> Add(PeopleViewModel peopleViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _peopleService.AddAsync(_mapper.Map<People>(peopleViewModel));
            return CustomResponse(peopleViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update(Guid id, PeopleViewModel peopleViewModel)
        {
            if(id != peopleViewModel.Id)
            {
                Notify(DomainError.MessageErrorIdDiferent);
                return CustomResponse();
            }
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _peopleService.UpdateAsync(_mapper.Map<People>(peopleViewModel));
            return CustomResponse(peopleViewModel);
        }

        [HttpPut("address/{id:guid}")]
        public async Task<ActionResult> UpdateAddress(Guid id, AddressViewModel addressViewModel)
        {
            if (id != addressViewModel.Id)
            {
                Notify(DomainError.MessageErrorIdDiferent);
                return CustomResponse();
            }
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _peopleService.UpdateAddressAsync(_mapper.Map<Address>(addressViewModel));
            return CustomResponse(addressViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Remove(Guid id)
        {
            var people = await _peopleRepository.GetPeopleAddressLoansByIdAssync(id);
            if (people == null) return NotFound();
            await _peopleService.RemoveAsync(people);            
            return CustomResponse();
        }
    }
}
