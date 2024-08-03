using AutoMapper;
using Store.Entities;
using Store.Models;
using Store.Repositories.CustomerRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private  IMapper mapper;

        public CustomerService(ICustomerRepository customerRepository , IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }

        public CustomerModel Add(CustomerModel customerModel)
        {
            var customerName = customerRepository.IsDuplicateCustomerName(customerModel.Contactname);
            if (customerName)
            {
                return null;
            }
            var customerToAdd = mapper.Map<Customer>(customerModel);
            var newCustomer = customerRepository.Add(customerToAdd);
            return mapper.Map<CustomerModel>(newCustomer);
        }

        public bool CheckIfExists(int id)
        {
            return customerRepository.CheckIfCustomerExist(id);
        }

        public bool Delete(int id)
        {
            var itemToDelete = customerRepository.GetCustomersById(id);
            if (itemToDelete == null)
            {
                return false;
            }
            return customerRepository.Delete(id);
        }


        public IEnumerable<CustomerModel> GetAll()
        {
            var customers = customerRepository.GetAll();
            var customersModels = mapper.Map<List<CustomerModel>>(customers);
            return customersModels;
        }

        public CustomerModel GetCustomer(int id)
        {
            var customerById = customerRepository.GetCustomer(id);
            return mapper.Map<CustomerModel>(customerById);
        }

        public CustomerModel Update(CustomerModel customerModel)
        {
            var customerExisting= customerRepository.GetCustomer(customerModel.Custid);
            if(customerExisting == null)
            {
                return null;
            }
            var customerToUpdate = mapper.Map(customerModel , customerExisting);
            var customerFromDb = customerRepository.Update(customerToUpdate);
            return mapper.Map<CustomerModel>(customerFromDb);

        }
    }
}
