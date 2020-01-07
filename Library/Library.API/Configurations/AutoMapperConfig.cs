using AutoMapper;
using Library.API.Business.Models;
using Library.API.ViewModels;

namespace Library.API.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<People, PeopleViewModel>().ReverseMap();
            CreateMap<Address, AddressViewModel>().ReverseMap();
            CreateMap<Book, BookViewModel>().ReverseMap();
            CreateMap<LoanBookViewModel, LoanBook>();
            CreateMap<LoanBook, LoanBookViewModel>()
                .ForMember(dest =>
                    dest.Title,
                    options => options.MapFrom(lb => lb.Book.Title));
                
                
            CreateMap<LoanViewModel, Loan>();
            CreateMap<Loan, LoanViewModel>()
                .ForMember(dest => 
                    dest.PeopleName, 
                    options=>options.MapFrom(loan=>loan.People.Name))
                .ForMember(dest =>
                    dest.PeopleDocument,
                    options => options.MapFrom(lb => lb.People.Document));
        }
    }
}
