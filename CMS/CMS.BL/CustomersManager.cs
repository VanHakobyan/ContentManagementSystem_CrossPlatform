using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.BL.ViewModels;
using CMS.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CMS.BL
{
    public class CustomersManager : IDisposable
    {
        private readonly CMSContext db = new CMSContext();
        private readonly ModelFactory.ModelFactory factory = new ModelFactory.ModelFactory();
        private void Update<T>(T entity) where T : class
        {
            var dbEntityEntry = db.Entry(entity);
            db.Set<T>().Attach(entity);
            dbEntityEntry.State = EntityState.Modified;
        }
        public IEnumerable<ViewCustomer> GetCustomers()
        {
            return db.Customers.Select(customer => factory.CreateViewCustumerModelFromDb(customer)).ToList();
        }

        // GET: api/Customers/5
        public async Task<ViewCustomer> GetCustomersById(int id)
        {
            var customers = await db.Customers.SingleOrDefaultAsync(m => m.Id == id);
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
            return viewCustomer;
        }

        // POST: api/Customers
        public async Task<ViewCustomer> PostCustomers(ViewCustomer customer)
        {
            var modelFromViewModel = factory.CreateCustumerModelFromViewModel(customer);
            try
            {
                db.Customers.Add(modelFromViewModel);
                await db.SaveChangesAsync();
            }
            catch (Exception exception)
            {

                throw;
            }
            return customer;
        }

        // DELETE: api/Customers/5
        public async Task<ViewCustomer> DeleteCustomers(int id)
        {
            var customers = await db.Customers.SingleOrDefaultAsync(m => m.Id == id);
            db.Customers.Remove(customers);
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
