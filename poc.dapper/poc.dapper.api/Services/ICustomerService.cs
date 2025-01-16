using poc.dapper.api.Domain;

namespace poc.dapper.api.Services;

public interface ICustomerService
{
    Task<int> CreateCustomerAsync(Customer customer);
    Task<int> UpdateCustomerAsync(Customer customer);
    Task<int> DeleteAsync(int id);
    Task<Customer> GetCustomerByIdAsync(int id);
    Task<IEnumerable<Customer>> GetAllCustomersAsync();
}