using CMS.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.BL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMS.BL
{
    public class SchedulesManager
    {
        private readonly CMSContext db = new CMSContext();
        private readonly ModelFactory.ModelFactory factory = new ModelFactory.ModelFactory();
        // GET: api/Schedules
        public IEnumerable<ViewSchedules> GetSchedules()
        {
            return db.Schedules.Select(schedule=>factory.CreateViewSchedules(schedule));
        }

        // GET: api/Schedules/5
        [HttpGet("{id}")]
        public async Task<ViewSchedules> GetSchedules(int id)
        {
            Schedules schedules;
            if (SchedulesExists(id)) schedules = await db.Schedules.SingleOrDefaultAsync(m => m.ScheduleId == id);
            else return null;
            return factory.CreateViewSchedules(schedules);
        }

        // GET: api/Schedules/7d02c5fc-3f2c-42e0-b0c8-f420179d4201
        public  async Task<ViewSchedules> GetSchedulesByGuid(Guid guid)
        {
            var schedules = await db.Schedules.SingleOrDefaultAsync(m => m.GuId == guid);
            return schedules == null ? null : factory.CreateViewSchedules(schedules);
        }

        // PUT: api/Schedules/5
        [HttpPut("{id}")]
        public async Task<ViewSchedules> PutSchedules(int id, ViewSchedules viewSchedules)
        {
            var schedulesInDb = await db.Schedules.FirstOrDefaultAsync(x => x.ScheduleId == id);
            db.Schedules.Attach(schedulesInDb);
            factory.ScedulePutMaker(schedulesInDb, viewSchedules);
            await db.SaveChangesAsync();
            return factory.CreateViewSchedules(schedulesInDb);
        }

        public Task GetSchedules(Guid guid)
        {
            throw new NotImplementedException();
        }

        // POST: api/Schedules
        [HttpPost]
        public async Task<ViewSchedules> PostSchedules(ViewSchedules viewSchedules)
        {
            var dbSchedules = factory.CreateDbSchedules(viewSchedules);
            viewSchedules.GuId = dbSchedules.GuId;
            await db.Schedules.AddAsync(dbSchedules);
            await db.SaveChangesAsync();
            return viewSchedules;
        }
        // DELETE: api/Schedules/5
        [HttpDelete("{id}")]
        public async Task<ViewSchedules> DeleteSchedules(int id)
        {

            var schedules = await db.Schedules.SingleOrDefaultAsync(m => m.ScheduleId == id);
            db.Schedules.Remove(schedules);
            await db.SaveChangesAsync();
            return factory.CreateViewSchedules(schedules);
        }

        private bool SchedulesExists(int id)
        {
            return db.Schedules.Any(e => e.ScheduleId == id);
        }

    }
}
