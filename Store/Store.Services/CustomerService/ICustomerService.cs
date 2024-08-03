using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.CustomerService
{
    public interface ICustomerService
    {
        IEnumerable<CustomerModel> GetAll();
        CustomerModel Add(CustomerModel customerModel);
        CustomerModel GetCustomer(int id);
        CustomerModel Update(CustomerModel customerModel);
        bool Delete(int id);
        bool CheckIfExists(int id);
    }
}
