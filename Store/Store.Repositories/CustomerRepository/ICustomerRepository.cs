using Store.Entities;

namespace Store.Repositories.CustomerRepository
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetAll();

        Customer Add(Customer customer);
        Customer Update(Customer customer);

        Customer GetCustomer(int id);
        bool IsDuplicateCustomerName(string categoryName);

        Customer GetCustomersById(int id);
        bool CheckIfCustomerExist(int id);
        bool Delete(int id);


    }
}
