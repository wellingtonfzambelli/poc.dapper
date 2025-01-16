using Microsoft.AspNetCore.Mvc;
using poc.dapper.api.Domain;
using poc.dapper.api.Services;

namespace poc.dapper.api.Controller;

[Route("api/customer")]
[ApiController]
public sealed class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService) =>
        _customerService = customerService;

    [HttpPost]
    public async Task<IActionResult> CreateCustomerAsync([FromBody] Customer customer, CancellationToken cancellation)
    {
        var result = await _customerService.CreateCustomerAsync(customer);

        if (result > 0)
            return Ok(new { message = "Customer created successfully1." });

        return BadRequest("Failed to create customer1.");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomerAsync(int id, CancellationToken cancellation)
    {
        var customer = await _customerService.GetCustomerByIdAsync(id);

        if (customer is null)
            return NotFound("Customer not found1.");

        return Ok(customer);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCustomersAsync(CancellationToken cancellationToken)
    {
        if (await _customerService.GetAllCustomersAsync()
            is var customers && customers is null)
            return NoContent();


        return Ok(customers);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomerAsync
    (
        int id,
        [FromBody] Customer customer,
        CancellationToken cancellationToken
    )
    {
        var customerDB = await _customerService.GetCustomerByIdAsync(id);

        if (customerDB is null)
            return NotFound();

        customerDB.Address = customer.Address;
        customerDB.City = customer.City;
        customerDB.Country = customer.Country;
        customerDB.Email = customer.Email;
        customerDB.Name = customer.Name;
        customerDB.PhoneNumber = customer.PhoneNumber;
        customerDB.PostalCode = customer.PostalCode;
        customerDB.State = customer.State;

        var result = await _customerService.UpdateCustomerAsync(customerDB);

        if (result > 0)
            return Ok(new { message = "Customer updated successfully." });

        return BadRequest("Failed to update customer.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomerAsync(int id, CancellationToken cancellationToken)
    {
        if (await _customerService.DeleteAsync(id)
            is var affectedRows && affectedRows > 0)
            return Ok(new { message = "Customer deleted successfully." });

        return BadRequest("Failed to delete customer.");
    }
}