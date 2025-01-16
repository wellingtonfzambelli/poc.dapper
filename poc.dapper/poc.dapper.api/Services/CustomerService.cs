using poc.dapper.api.Domain;
using poc.dapper.api.Repository.UnitOfWork;
using System.Data.Common;

namespace poc.dapper.api.Services;

public sealed class CustomerService : ICustomerService
{
    private readonly IUnitOfWork _unitOfWork;

    public CustomerService(IUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    public async Task<IEnumerable<Customer>> GetAllCustomersAsync() =>
    await _unitOfWork.Customers.GetAllAsync();

    public async Task<Customer> GetCustomerByIdAsync(int id) =>
        await _unitOfWork.Customers.GetByIdAsync(id);

    public async Task<int> CreateCustomerAsync(Customer customer)
    {
        var affectedRows = await _unitOfWork.Customers.AddAsync(customer);
        _unitOfWork.Commit();

        return affectedRows;
    }

    public async Task<int> UpdateCustomerAsync(Customer customer)
    {
        var affectedRows = await _unitOfWork.Customers.UpdateAsync(customer);
        _unitOfWork.Commit();

        return affectedRows;
    }

    public async Task<int> DeleteAsync(int id)
    {
        var affectedRows = await _unitOfWork.Customers.DeleteAsync(id);
        _unitOfWork.Commit();

        return affectedRows;
    }
}