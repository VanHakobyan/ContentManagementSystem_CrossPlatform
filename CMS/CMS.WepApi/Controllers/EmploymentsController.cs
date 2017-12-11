using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CMS.BL.Managers;
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
        private readonly EmploymentsManager employmentsManager;
        public EmploymentsController()
        {
          employmentsManager = new EmploymentsManager();
        }

        // GET: api/Employments
        [HttpGet]
        public IEnumerable<ViewEmployments> GetEmployments()
        {
            return employmentsManager.GetEmployments();
        }

        // GET: api/Employments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmploymentsById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var employments = await employmentsManager.GetEmploymentsById(id);
            if (employments == null)
                return NotFound();
            return Ok(employments);
        }

        // GET: api/Employments/7d02c5fc-3f2c-42e0-b0c8-f420179d4201
        [HttpGet("{guid}")]
        public async Task<IActionResult> GetEmploymentsByGuid([FromRoute] Guid guid)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var employments = await employmentsManager.GetEmploymentsByGuid(guid);
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
           if (!employmentsManager.EmploymentsExists(id))
                return NotFound();
            return Ok(await employmentsManager.PutEmployments(id, employments));
        }

        // POST: api/Employments
        [HttpPost]
        public async Task<IActionResult> PostEmployments([FromBody] ViewEmployments employments)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var postEmployments = await employmentsManager.PostEmployments(employments);
            return CreatedAtAction("GetEmployments", postEmployments);
        }

        // DELETE: api/Employments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployments([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var employments = await employmentsManager.DeleteEmployments(id);
            if (employments == null)
                return NotFound();
            return Ok(employments);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) employmentsManager.Dispose();
        }
    }
}