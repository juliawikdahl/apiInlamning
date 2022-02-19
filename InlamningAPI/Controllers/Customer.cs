#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InlamningAPI;
using InlamningAPI.Models.Entities;
using InlamningAPI.Models;
using InlamningAPI.Filters;

namespace InlamningAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[UseApiKey]
    public class Customer : ControllerBase
    {
        private readonly SqlContext _context;

        public Customer(SqlContext context)
        {
            _context = context;
        }

   
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerModel>>> GetCustomers()
        {
            var items = new List<CustomerModel>();

            foreach (var item in await _context.Customers.ToListAsync())
                items.Add(new CustomerModel(item.FirstName, item.LastName, item.Email, item.Address, item.City, item.PostalCode));

            return items;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerModel>> GetCustomerEntity(int id)
        {
            var customerEntity = await _context.Customers.FindAsync(id);

            if (customerEntity == null)
            {
                return NotFound();
            }

            return new CustomerModel(customerEntity.FirstName, customerEntity.LastName, customerEntity.Email, customerEntity.Address, customerEntity.City, customerEntity.PostalCode);
        }

        
 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerEntity(int id, CustomerUpdateModel model)
        {
          
            var customerEntity = await _context.Customers.FindAsync(id);
            if (customerEntity == null)
                return NotFound();

            customerEntity.FirstName = model.FirstName;
            customerEntity.LastName = model.LastName;
            customerEntity.Email = model.Email;
            customerEntity.Password = model.Password;

            _context.Entry(customerEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }



        [HttpPost]
        public async Task<ActionResult<CustomerModel>> PostCustomerEntity(CustomerCreateModel model)
        {
            if (await _context.Customers.AnyAsync(x => x.Email == model.Email))
                return Conflict("A customer with the same email address already exists.");

            var customerEntity = new CustomerEntity(model.Firstname, model.Lastname, model.Email, model.Address, model.City, model.PostalCode);
            _context.Customers.Add(customerEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostCustomerEntity", new { id = customerEntity.Id }, new CustomerModel(customerEntity.FirstName, 
                customerEntity.LastName, customerEntity.Email, customerEntity.Address, customerEntity.City, customerEntity.PostalCode));
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerEntity(int id)
        {
            var customerEntity = await _context.Customers.FindAsync(id);
            if (customerEntity == null)
            {
                return NotFound();
            }

            customerEntity.FirstName = "";
            customerEntity.LastName = "";
            customerEntity.Email = "";
            customerEntity.Password = "";

            _context.Entry(customerEntity).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerEntityExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
