using AutoMapper;
using Store.Entities;
using Store.Models;


namespace Store.Mappings
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerModel, Customer>();
            CreateMap<Customer, CustomerModel>();
        }
    }
}
