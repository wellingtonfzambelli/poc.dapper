﻿using poc.dapper.api.Domain;

namespace poc.dapper.api.Repository;

public interface ICustomerRepository
{
    Task<IEnumerable<Customer>> GetAllAsync();
    Task<Customer> GetByIdAsync(int id);
    Task<int> AddAsync(Customer customer);
    Task<int> UpdateAsync(Customer customer);
    Task<int> DeleteAsync(int id);
}