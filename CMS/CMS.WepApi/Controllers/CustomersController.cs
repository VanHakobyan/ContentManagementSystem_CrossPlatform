using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CMS.BL;
using CMS.BL.ViewModels;
using CMS.WepApi.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CMS.WepApi.Controllers
{
    [CustomExceptionFilter]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private static ILogger Logger { get; set; }
        private readonly CustomersManager customersManager;
        public CustomersController()
        {
            customersManager = new CustomersManager();
        }

        // GET: api/Customers
        [HttpGet]
        public IEnumerable<ViewCustomer> GetCustomers()
        {
            return customersManager.GetCustomers();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var customers = await customersManager.GetCustomersById(id);
            if (customers == null)
                return NotFound();
            return Ok(customers);
        }

        // GET: api/Customers/ff247f5d-95c2-493e-a079-63d962138b19
        [HttpGet("{guid}")]
        public async Task<IActionResult> GetCustomerByGuid([FromRoute] Guid guid)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var customers = await customersManager.GetCustomersByGuid(guid);
            if (customers == null)
                return NotFound();
            return Ok(customers);
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomers([FromRoute] int id, [FromBody] ViewCustomer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!customersManager.CustomersExists(id))
                return NotFound();
            return Ok(await customersManager.PutCustomers(id, customer));
        }

        // POST: api/Customers
        [HttpPost]
        public async Task<IActionResult> PostCustomers([FromBody] ViewCustomer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var postCustomers = await customersManager.PostCustomers(customer);
            return CreatedAtAction("GetCustomerById", postCustomers);
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
            return Ok(customers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) customersManager.Dispose();
        }
    }
}