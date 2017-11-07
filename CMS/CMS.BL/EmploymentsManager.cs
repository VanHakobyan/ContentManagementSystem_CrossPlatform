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
        public IEnumerable<ViewEmployments> GetProducts()
        {
            return db.Employments.Select(product => factory.CreateEmploymentsViewModel(product)).ToList();
        }

        // GET: api/Employments/5
        public async Task<ViewEmployments> GetProductsById(int id)
        {
            return factory.CreateEmploymentsViewModel(await db.Employments.SingleOrDefaultAsync(m => m.EmploymentId == id));
        }

        // PUT: api/Employments/5
        public async Task<ViewEmployments> PutProducts(int id, ViewEmployments employments)
        {
            //var productsModelFromDb = factory.CreateEmploymentsModelFromDb(employments);
            var employmentsInDb = await db.Employments.FirstOrDefaultAsync(x => x.EmploymentId == id);
            db.Employments.Attach(employmentsInDb);
            factory.EmploymentPutMaker(employments, employmentsInDb);
            db.SaveChanges();
            return employments;
        }

        // POST: api/Employments
        public async Task<ViewEmployments> PostProducts(ViewEmployments employments)
        {
            db.Employments.Add(factory.CreateEmploymentsModelFromDb(employments));
            await db.SaveChangesAsync();
            return employments;
        }

        // DELETE: api/Employments/5
        public async Task<ViewEmployments> DeleteProducts(int id)
        {
            var employments = await db.Employments.SingleOrDefaultAsync(m => m.EmploymentId == id);
            db.Employments.Remove(employments);
            await db.SaveChangesAsync();
            return factory.CreateEmploymentsViewModel(employments);
        }
        public bool ProductsExists(int id)
        {
            return db.Employments.Any(e => e.EmploymentId == id);
        }

        public void Dispose()
        {
            db?.Dispose();
        }
    }
}
