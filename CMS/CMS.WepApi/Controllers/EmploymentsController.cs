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
    //[CustomExceptionFilter]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class EmploymentsController : Controller
    {
        private static ILogger Logger { get; set; }
        private readonly EmploymentsManager _employmentsManager;
        public EmploymentsController(ILoggerFactory loggerFactory,IServiceProvider serviceProvider)
        {
            Logger = loggerFactory.CreateLogger(GetType().Namespace);
            Logger.LogInformation("created customersController");
            _employmentsManager = new EmploymentsManager();
        }

        // GET: api/Employments
        [HttpGet]
        public IEnumerable<ViewEmployments> GetProducts()
        {
            return _employmentsManager.GetProducts();
        }

        // GET: api/Employments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducts([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var products = await _employmentsManager.GetProductsById(id);
            if (products == null)
                return NotFound();
            return Ok(products);
        }

        // PUT: api/Employments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts([FromRoute] int id, [FromBody] ViewEmployments employments)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
           if (!_employmentsManager.ProductsExists(id))
                return NotFound();
            return Ok(await _employmentsManager.PutProducts(id, employments));
        }

        // POST: api/Employments
        [HttpPost]
        public async Task<IActionResult> PostProducts([FromBody] ViewEmployments employments)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var postProducts = await _employmentsManager.PostProducts(employments);
            return CreatedAtAction("GetProducts",  postProducts);
        }

        // DELETE: api/Employments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducts([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var products = await _employmentsManager.DeleteProducts(id);
            if (products == null)
                return NotFound();
            return Ok(products);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) _employmentsManager.Dispose();
        }
    }
}