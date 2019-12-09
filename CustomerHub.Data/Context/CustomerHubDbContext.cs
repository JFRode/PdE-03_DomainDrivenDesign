using CustomerHub.Domain.Customer;
using CustomerHub.Domain.User;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace CustomerHub.Data.Context
{
    public class CustomerHubDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public CustomerHubDbContext(DbContextOptions<CustomerHubDbContext> options) : base(options)
        {
        }

        public CustomerHubDbContext()
        {
        }
    }
}