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
        public IEnumerable<ViewEmployments> GetEmployments()
        {
            return _employmentsManager.GetEmployments();
        }

        // GET: api/Employments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployments([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var employments = await _employmentsManager.GetEmploymentsById(id);
            if (employments == null)
                return NotFound();
            return Ok(employments);
        }

        // PUT: api/Employments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployments([FromRoute] int id, [FromBody] ViewEmployments employments)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
           if (!_employmentsManager.EmploymentsExists(id))
                return NotFound();
            return Ok(await _employmentsManager.PutEmployments(id, employments));
        }

        // POST: api/Employments
        [HttpPost]
        public async Task<IActionResult> PostEmployments([FromBody] ViewEmployments employments)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var postEmployments = await _employmentsManager.PostEmployments(employments);
            return CreatedAtAction("GetEmployments", postEmployments);
        }

        // DELETE: api/Employments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployments([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var employments = await _employmentsManager.DeleteEmployments(id);
            if (employments == null)
                return NotFound();
            return Ok(employments);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) _employmentsManager.Dispose();
        }
    }
}