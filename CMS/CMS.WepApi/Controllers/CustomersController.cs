using System.Collections.Generic;
using System.Threading.Tasks;
using CMS.BL;
using CMS.DAL.Models;
//using CMS.WepApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMS.WepApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly CustomersManager customersManager;
        public CustomersController()
        {
            customersManager = new CustomersManager(); ;
        }

        // GET: api/Customers
        [HttpGet]
        public IEnumerable<Customers> GetCustomers()
        {
            return customersManager.GetCustomers();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var customers = await customersManager.GetCustomersById(id);
            if (customers == null)
                return NotFound();
            return Ok(customers);
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomers([FromRoute] int id, [FromBody] Customers customers)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id != customers.Id)
                return BadRequest();
            if (!customersManager.CustomersExists(id))
                return NotFound();
            return Ok(await customersManager.PutCustomers(id, customers));
        }

        // POST: api/Customers
        [HttpPost]
        public async Task<IActionResult> PostCustomers([FromBody] Customers customers)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var postCustomers = await customersManager.PostCustomers(customers);
            return CreatedAtAction("GetCustomers", new { id = postCustomers.Id }, postCustomers);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var customers = await customersManager.DeleteCustomers(id);
            if (customers == null)
                return NotFound();
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)customersManager.Dispose();
        }
    }
}