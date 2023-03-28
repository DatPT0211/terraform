using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Customer class
public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}

// DAL class using Entity Framework
public class CustomerDAL
{
    private readonly DbContext _context;

    public CustomerDAL(DbContext context)
    {
        _context = context;
    }

    public void CreateCustomer(Customer customer)
    {
        _context.Set<Customer>().Add(customer);
        _context.SaveChanges();
    }

    public Customer ReadCustomer(int customerId)
    {
        return _context.Set<Customer>().Find(customerId);
    }

    public void UpdateCustomer(Customer customer)
    {
        _context.Set<Customer>().Update(customer);
        _context.SaveChanges();
    }

    public void DeleteCustomer(int customerId)
    {
        var customer = ReadCustomer(customerId);
        _context.Set<Customer>().Remove(customer);
        _context.SaveChanges();
    }
}