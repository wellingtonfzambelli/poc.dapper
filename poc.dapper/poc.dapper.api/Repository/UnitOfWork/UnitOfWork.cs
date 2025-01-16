using System.Data;

namespace poc.dapper.api.Repository.UnitOfWork;

public sealed class UnitOfWork : IUnitOfWork
{
    private IDbConnection _connection;
    private IDbTransaction _transaction;
    private ICustomerRepository _customerRepository;

    public UnitOfWork(IDbConnection connection)
    {
        _connection = connection;
        _connection.Open();
        _transaction = _connection.BeginTransaction();
    }

    public ICustomerRepository Customers =>
        _customerRepository ??= new CustomerRepository(_connection, _transaction);

    public int Commit()
    {
        try
        {
            _transaction.Commit();
            return 1; // Success
        }
        catch
        {
            _transaction.Rollback();
            throw;
        }
    }

    public void Dispose()
    {
        _transaction?.Dispose();
        _connection?.Dispose();
    }
}