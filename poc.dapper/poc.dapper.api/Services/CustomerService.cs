using poc.dapper.api.Domain;
using poc.dapper.api.Repository.UnitOfWork;

namespace poc.dapper.api.Services;

public sealed class CustomerService : ICustomerService
{
    private readonly IUnitOfWork _unitOfWork;

    public CustomerService(IUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task CreateCustomerAsync(Customer customer)
    {
        await _unitOfWork.Customers.AddAsync(customer);
        _unitOfWork.Commit();
    }

    public async Task<IEnumerable<Customer>> GetAllCustomersAsync() =>
        await _unitOfWork.Customers.GetAllAsync();
}