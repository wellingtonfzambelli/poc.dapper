using poc.dapper.api.Domain;

namespace poc.dapper.api.Services;

public interface ICustomerService
{
    Task CreateCustomerAsync(Customer customer);
    Task<IEnumerable<Customer>> GetAllCustomersAsync();
}