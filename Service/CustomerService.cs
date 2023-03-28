using Demo_DevOps.Entity;
using Microsoft.EntityFrameworkCore;

namespace Demo_DevOps.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly MyDbContext _myDbContext;

        public CustomerService(MyDbContext myDbContext)
        {
            this._myDbContext = myDbContext;
        }

        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            Customer customer = await _myDbContext.customers.FindAsync(id);
            return customer;
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            List<Customer> customers = await _myDbContext.customers.ToListAsync();
            return customers;
        }
    }
}
