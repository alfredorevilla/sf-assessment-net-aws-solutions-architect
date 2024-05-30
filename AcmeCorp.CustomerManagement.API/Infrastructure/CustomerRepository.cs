using AcmeCorp.CustomerManagement.Domain;
using AcmeCorp.CustomerManagement.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AcmeCorp.CustomerManagement.API.Infrastructure;
public class CustomerRepository(CustomerManagementDbContext dbContext) : ICustomerRepository
{
    private readonly CustomerManagementDbContext _dbContext = dbContext;

    public IUnitOfWork UnitOfWork => _dbContext;

    public async Task AddAsync(Customer customer)
    {

        await _dbContext.AddAsync(customer);
    }
}
