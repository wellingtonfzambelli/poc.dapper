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
                        phonenumber, 
                        address, 
                        city, 
                        state, 
                        country, 
                        postalcode, 
                        createdat
                    ) 
                    VALUES 
                    (
                        @Name, 
                        @Email, 
                        @PhoneNumber, 
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

    public async Task<Customer?> GetByIdAsync(int id) =>
        (await _connection.QueryAsync<Customer>(
            "SELECT * FROM customer WHERE id = @id LIMIT 1",
            new { id },
            transaction: _transaction
        )).FirstOrDefault();


    public async Task<int> UpdateAsync(Customer customer)
    {
        var query = @"
            UPDATE customer
            SET name = @Name,
                email = @Email,
                address = @Address
            WHERE id = @Id";

        var affectedRows = await _connection.ExecuteAsync(query, new
        {
            customer.Name,
            customer.Email,
            customer.Address,
            customer.Id
        }, transaction: _transaction);

        return affectedRows;
    }

    public async Task<int> DeleteAsync(int id) =>
        await _connection.ExecuteAsync(
            "DELETE FROM customer WHERE id = @id",
            new { id },
            transaction: _transaction
        );
}