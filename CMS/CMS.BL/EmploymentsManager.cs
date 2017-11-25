using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.BL.ViewModels;
using CMS.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CMS.BL
{
    public class EmploymentsManager : IDisposable
    {
        private CMSContext db = new CMSContext();
        private readonly ModelFactory.ModelFactory factory = new ModelFactory.ModelFactory();
        // GET: api/Employments
        public IEnumerable<ViewEmployments> GetEmployments()
        {
            return db.Employments.Select(product => factory.CreateEmploymentsViewModel(product)).ToList();
        }

        // GET: api/Employments/5
        public async Task<ViewEmployments> GetEmploymentsById(int id)
        {
            return factory.CreateEmploymentsViewModel(await db.Employments.SingleOrDefaultAsync(m => m.EmploymentId == id));
        }

        //GET api/Employments/7d02c5fc-3f2c-42e0-b0c8-f420179d4201
        public async Task<ViewEmployments> GetEmploymentsByGuid(Guid guid)
        {
            return factory.CreateEmploymentsViewModel(await db.Employments.SingleOrDefaultAsync(m => m.GuId == guid));
        }
        // PUT: api/Employments/5
        public async Task<ViewEmployments> PutEmployments(int id, ViewEmployments employments)
        {
            //TODO:Correct this schedul put 
            //var productsModelFromDb = factory.CreateEmploymentsModelFromDb(employments);

            var employmentsInDb = await db.Employments.Include(x => x.Schedules).SingleOrDefaultAsync(x => x.EmploymentId == id);

            db.Employments.Attach(employmentsInDb);
            factory.EmploymentPutMaker(employments, employmentsInDb);
            db.SaveChanges();

            return employments;

        }

        // POST: api/Employments
        public async Task<ViewEmployments> PostEmployments(ViewEmployments employments)
        {
            db.Employments.Add(factory.CreateEmploymentsModelFromDb(employments));
            await db.SaveChangesAsync();
            return employments;
        }

        // DELETE: api/Employments/5
        public async Task<ViewEmployments> DeleteEmployments(int id)
        {
            var employments = await db.Employments.Include(x => x.Schedules).SingleOrDefaultAsync(m => m.EmploymentId == id);
            db.Schedules.RemoveRange(employments.Schedules);
            db.Employments.Remove(employments);
            await db.SaveChangesAsync();
            return factory.CreateEmploymentsViewModel(employments);
        }
        public bool EmploymentsExists(int id)
        {
            return db.Employments.Any(e => e.EmploymentId == id);
        }

        public void Dispose()
        {
            db?.Dispose();
        }

    }
}
