using Microsoft.AspNetCore.Mvc;
using Store.Models;
using Store.Services.CustomerService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerService customerService;
        // GET: api/<CustomerController>
        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var customer = customerService.GetAll();
            return Ok(customer);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customer = customerService.GetCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        [HttpPost]
        public IActionResult Create([FromBody] CustomerModel customerModel, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdCustomer = customerService.Add(customerModel);
            if (createdCustomer == null)
            {
                return Conflict(new { message = $"An existing record with the given details was already found or the operation failed." });
            }
            return CreatedAtAction(nameof(Get), new
            {
                id = createdCustomer.Custid
            }, createdCustomer);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id , [FromBody] CustomerModel customerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(id  != customerModel.Custid)
            {
                return BadRequest("Customer Id mismatch.");
            }
            var customerToUpdate = customerService.Update(customerModel);
            if(customerToUpdate == null)
            {
                return NotFound();
            }
            return Ok(customerToUpdate);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Încercăm să ștergem clientul folosind serviciul
            var success = customerService.Delete(id);

            // Dacă ștergerea a fost nereușită (clientul nu a fost găsit), returnăm 404 Not Found
            if (!success)
            {
                return NotFound();
            }

            // Dacă ștergerea a fost reușită, returnăm 204 No Content
            return NoContent();

        }
    }
}
