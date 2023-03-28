using Demo_DevOps.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo_DevOps.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService) {
            this.customerService = customerService;
        }

        [HttpGet("all")]
        public async Task<List<Customer>> GetCustomersAsync()
        {
           return await customerService.GetCustomersAsync();    
        }

        [HttpGet("{id}")]
        public async Task<Customer> GetCustomerByIdAsync(int id)
        {
            return await customerService.GetCustomerByIdAsync(id);
        }
    }
}
