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
    public class ProductsController : Controller
    {
        private static ILogger Logger { get; set; }
        private readonly ProductsManager productsManager;
        public ProductsController(ILoggerFactory loggerFactory,IServiceProvider serviceProvider)
        {
            Logger = loggerFactory.CreateLogger(GetType().Namespace);
            Logger.LogInformation("created customersController");
            productsManager = new ProductsManager();
        }

        // GET: api/Products
        [HttpGet]
        public IEnumerable<ViewProduct> GetProducts()
        {
            return productsManager.GetProducts();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProducts([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var products = await productsManager.GetProductsById(id);
            if (products == null)
                return NotFound();
            return Ok(products);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts([FromRoute] int id, [FromBody] ViewProduct product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
           if (!productsManager.ProductsExists(id))
                return NotFound();
            return Ok(await productsManager.PutProducts(id, product));
        }

        // POST: api/Products
        [HttpPost]
        public async Task<IActionResult> PostProducts([FromBody] ViewProduct product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var postProducts = await productsManager.PostProducts(product);
            return CreatedAtAction("GetProducts",  postProducts);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducts([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var products = await productsManager.DeleteProducts(id);
            if (products == null)
                return NotFound();
            return Ok(products);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) productsManager.Dispose();
        }
    }
}