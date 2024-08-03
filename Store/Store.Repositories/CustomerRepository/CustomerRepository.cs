using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Entities;
using System.Security.Cryptography.X509Certificates;


namespace Store.Repositories.CustomerRepository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly StoreContext storeContext;

        public CustomerRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public Customer Add(Customer customer)
        {
            var itemAdded = storeContext.Customers.Add(customer);
            storeContext.SaveChanges();
            return itemAdded.Entity;
        }

        public bool CheckIfCustomerExist(int id)
        {
            return storeContext.Customers.Any(x => x.Custid == id);
        }

        public bool Delete(int id)
        {
            try
            {
                // Găsește clientul
                var existingCustomer = storeContext.Customers
                    .FirstOrDefault(x => x.Custid == id);

                if (existingCustomer == null)
                {
                    return false; // Clientul nu a fost găsit
                }

                // Actualizează comenzile pentru a nu mai face referire la client
                var orders = storeContext.Orders.Where(o => o.Custid == id).ToList();
                foreach (var order in orders)
                {
                    order.Custid = null; // Sau o valoare de înlocuire, dacă este permisă
                }

                storeContext.Orders.UpdateRange(orders);

                // Șterge clientul
                storeContext.Customers.Remove(existingCustomer);

                var result = storeContext.SaveChanges() > 0;
                return result;
            }
            catch (DbUpdateException ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            return storeContext.Customers;
        }

        public Customer GetCustomersById(int id)
        {
            return storeContext.Customers.FirstOrDefault(x => x.Custid == id);
        }
        public Customer GetCustomer(int id)
        {
            return storeContext.Customers.Find(id);
        }

        public bool IsDuplicateCustomerName(string categoryName)
        {
            return storeContext.Customers.Where(x => x.Contactname == categoryName).Any();
        }

        public Customer Update(Customer customer)
        {
            var updateCustomer = storeContext.Customers.Update(customer);
            storeContext.SaveChanges();
            return updateCustomer.Entity;
        }
    }
}
