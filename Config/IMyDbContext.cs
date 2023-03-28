using Microsoft.EntityFrameworkCore;

public interface IMyDbContext
{
    DbSet<Customer> customers { get; set; }
}