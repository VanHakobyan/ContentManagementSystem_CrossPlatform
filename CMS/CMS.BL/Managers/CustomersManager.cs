using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.BL.ViewModels;
using CMS.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CMS.BL.Managers
{
    public class CustomersManager : IDisposable
    {
        private readonly CMSContext db = new CMSContext();
        private readonly ModelFactory.ModelFactory factory = new ModelFactory.ModelFactory();

        //TODO: Implement  in projct 
        //private void Update<T>(T entity) where T : class
        //{
        //    var dbEntityEntry = db.Entry(entity);
        //    db.Set<T>().Attach(entity);
        //    dbEntityEntry.State = EntityState.Modified;
        //}
        public IEnumerable<ViewCustomer> GetCustomers()
        {
            return db.Customers.Select(customer => factory.CreateViewCustumerModelFromDb(customer)).ToList();
        }

        // GET: api/Customers/5
        public async Task<ViewCustomer> GetCustomersById(int id)
        {
            var customers = await db.Customers./*Include(x=>x.Employments).ThenInclude(x=>x.Schedules).*/SingleOrDefaultAsync(m => m.Id == id);
            return factory.CreateViewCustumerModelFromDb(customers);
        }

        //GET api/Customers/ff247f5d-95c2-493e-a079-63d962138b19
        public async Task<ViewCustomer> GetCustomersByGuid(Guid guid)
        {
            var customers = await db.Customers./*Include(x=>x.Employments).ThenInclude(a=>a.Schedules).*/SingleOrDefaultAsync(m => m.GuId == guid);
            return factory.CreateViewCustumerModelFromDb(customers);
        }

        // PUT: api/Customers/5
        public async Task<ViewCustomer> PutCustomers(int id, ViewCustomer viewCustomer)
        {
            var customerDb = factory.CreateCustumerModelFromViewModel(viewCustomer);
            var customerLoadDb = await db.Customers.FirstOrDefaultAsync(x => x.Id == id);
            db.Customers.Attach(customerLoadDb);
            factory.CustomerPutMaker(customerDb, customerLoadDb);
            await db.SaveChangesAsync();
            return factory.CreateViewCustumerModelFromDb(customerLoadDb);
        }

        // POST: api/Customers
        public async Task<ViewCustomer> PostCustomers(ViewCustomer customer)
        {
            var modelFromViewModel = factory.CreateCustumerModelFromViewModel(customer);
            await db.Customers.AddAsync(modelFromViewModel);
            await db.SaveChangesAsync();
            return customer;
        }

        // DELETE: api/Customers/5
        public async Task<ViewCustomer> DeleteCustomers(int id)
        {
            //ADO.NET query
            //await db.Database.ExecuteSqlCommandAsync($"Delete from customers where id={id}");
            //db.RemoveRange(customers.Employments);
            var customers = await db.Customers/*.Include(x=>x.Employments)*/.FirstOrDefaultAsync(m => m.Id == id);
            db.Remove(customers);
            await db.SaveChangesAsync();
            return factory.CreateViewCustumerModelFromDb(customers);
        }
        public bool CustomersExists(int id)
        {
            return db.Customers.Any(e => e.Id == id);
        }

        public void Dispose()
        {
            db?.Dispose();
        }

    }
}
