using AcmeCorp.CustomerManagement.Domain;

namespace AcmeCorp.CustomerManagement.Infrastructure;

public interface ICustomerRepository : IRepository<Customer>
{

    Task AddAsync(Customer customer);
}