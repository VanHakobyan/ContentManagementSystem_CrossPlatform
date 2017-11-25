using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CMS.BL;
using CMS.BL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CMS.WepApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Schedules")]
    public class SchedulesController : Controller
    {
        private readonly SchedulesManager schedulesManager = new SchedulesManager();

        // GET: api/Schedules
        [HttpGet]
        public IEnumerable<ViewSchedules> GetSchedules()
        {
            return schedulesManager.GetSchedules();
        }

        // GET: api/Schedules/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSchedulesById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var schedules = await schedulesManager.GetSchedules(id);
            if (schedules == null)
                return NotFound();
            return Ok(schedules);
        }

        // GET: api/Schedules/2d88b44d-82e3-42b6-9f5c-1ac3696a3ec4
        [HttpGet("{guid}")]
        public async Task<IActionResult> GetSchedulesByGuid([FromRoute] Guid guid)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var schedules = await schedulesManager.GetSchedulesByGuid(guid);
            if (schedules == null)
                return NotFound();
            return Ok(schedules);
        }

        // PUT: api/Schedules/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchedules([FromRoute] int id, [FromBody] ViewSchedules viewSchedules)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var viewSchedulesPut = await schedulesManager.PutSchedules(id, viewSchedules);
            if (viewSchedulesPut != null)
                return Ok(viewSchedulesPut);
            return NoContent();
        }

        // POST: api/Schedules
        [HttpPost]
        public async Task<IActionResult> PostSchedules([FromBody] ViewSchedules viewSchedules)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var postSchedule = await schedulesManager.PostSchedules(viewSchedules);

            return CreatedAtAction("GetSchedules", postSchedule);
        }

        // DELETE: api/Schedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchedules([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var schedulesDelete = await schedulesManager.DeleteSchedules(id);
            if (schedulesDelete == null)
                return NotFound();
            return Ok(schedulesDelete);
        }
    }
}