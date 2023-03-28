using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MyDbContext : DbContext, IMyDbContext
{

    public MyDbContext() { }

    public MyDbContext(DbContextOptions options):base(options) {
    
    }
    public DbSet<Customer> customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("Server=localhost;Database=demo_devops;Uid=root;Pwd=123456;");
    }
}
