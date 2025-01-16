using Dapper;
using poc.dapper.api.Domain;
using System.Data;

namespace poc.dapper.api.Repository;

public sealed class CustomerRepository : ICustomerRepository
{
    private readonly IDbConnection _connection;
    private readonly IDbTransaction _transaction;

    public CustomerRepository(IDbConnection connection, IDbTransaction transaction)
    {
        _connection = connection;
        _transaction = transaction;
    }

    public async Task<IEnumerable<Customer>> GetAllAsync() =>
        await _connection.QueryAsync<Customer>(
            "SELECT * FROM customer",
            transaction: _transaction
        );

    public async Task<int> AddAsync(Customer customer)
    {
        var sql = @"INSERT INTO customer
                    (
                        name, 
                        email, 
                        phone, 
                        address, 
                        city, 
                        state, 
                        country, 
                        postal_code, 
                        created_at
                    ) 
                    VALUES 
                    (
                        @Name, 
                        @Email, 
                        @Phone, 
                        @Address, 
                        @City, 
                        @State, 
                        @Country, 
                        @PostalCode, 
                        @CreatedAt
                    )";

        return await _connection.ExecuteAsync(
            sql,
            customer,
            transaction: _transaction
        );
    }

    public Task<Customer> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(Customer customer)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}