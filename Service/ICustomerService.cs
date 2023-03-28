namespace Demo_DevOps.Service
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetCustomersAsync();

        Task<Customer> GetCustomerByIdAsync(int id);
    }
}