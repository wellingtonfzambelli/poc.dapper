using Microsoft.AspNetCore.Mvc;
using poc.dapper.api.Domain;
using poc.dapper.api.Repository.UnitOfWork;

namespace poc.dapper.api.Controller;

[Route("api/customer")]
[ApiController]
public sealed class CustomerController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public CustomerController(IUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork;

    [HttpPost]
    public async Task<IActionResult> CreateCustomerAsync([FromBody] Customer customer, CancellationToken cancellation)
    {
        var result = await _unitOfWork.Customers.AddAsync(customer);

        if (result > 0)
            return Ok(new { message = "Customer created successfully1." });

        return BadRequest("Failed to create customer1.");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomerAsync(int id, CancellationToken cancellation)
    {
        var customer = _unitOfWork.Customers.GetByIdAsync(id);

        if (customer == null)
            return NotFound("Customer not found1.");

        return Ok(customer);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCustomersAsync(CancellationToken cancellationToken)
    {
        if(await _unitOfWork.Customers.GetAllAsync() 
            is var customers && customers is null)
            return NoContent();

        
        return Ok(customers);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomerAsync(int id, [FromBody] Customer customer, CancellationToken cancellationToken)
    {
        var customerDB = await _unitOfWork.Customers.GetByIdAsync(id);

        if (customerDB is null)
            return NotFound();

        customerDB.Address = customer.Address;
        customerDB.City = customer.City;
        customerDB.Country = customer.Country;
        customerDB.Email = customer.Email;
        customerDB.Name = customer.Name;
        customerDB.Phone = customer.Phone;
        customerDB.PostalCode = customer.PostalCode;
        customerDB.State = customer.State;

        var result = await _unitOfWork.Customers.UpdateAsync(customerDB);

        if (result > 0)
            return Ok(new { message = "Customer updated successfully." });

        return BadRequest("Failed to update customer.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomerAsync(int id, CancellationToken cancellationToken)
    {
        var customerDB = await _unitOfWork.Customers.GetByIdAsync(id);

        if (customerDB is null)
            return NotFound();

        var result = await _unitOfWork.Customers.DeleteAsync(id);

        if (result > 0)
            return Ok(new { message = "Customer deleted successfully." });

        return BadRequest("Failed to delete customer.");
    }
}