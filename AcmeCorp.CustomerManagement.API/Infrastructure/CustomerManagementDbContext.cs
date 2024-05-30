using AcmeCorp.CustomerManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCorp.CustomerManagement.API.Infrastructure;
public class CustomerManagementDbContext(DbContextOptions<CustomerManagementDbContext> options) : DbContext(options), IUnitOfWork
{
    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("customermanagement");
        modelBuilder.ApplyConfiguration(new CustomerEntityTypeConfiguration());
    }

    public async Task AddAsync(Customer customer)
    {
        await Customers.AddAsync(customer);
    }

    public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        this.SaveChangesAsync(cancellationToken);
        return Task.FromResult(true);
    }
}
