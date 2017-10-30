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

        public IEnumerable<ViewCustomers> GetCustomers()
        {
           return db.Customers.Select(customer => factory.CreateViewCustumerModelFromDb(customer)).ToList();
        }

        // GET: api/Customers/5
        public async Task<ViewCustomers> GetCustomersById(int id)
        {
            return factory.CreateViewCustumerModelFromDb(await db.Customers.SingleOrDefaultAsync(m => m.Id == id));
        }

        // PUT: api/Customers/5
        public async Task<ViewCustomers> PutCustomers(int id, ViewCustomers customers)
        {
            try
            {
                db.Entry(customers).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            catch
            {
                // ignored
            }
            return customers;
        }

        // POST: api/Customers
        public async Task<ViewCustomers> PostCustomers(ViewCustomers customers)
        {
            db.Customers.Add(factory.CreateCustumerModelFromViewModel(customers));
            await db.SaveChangesAsync();
            return customers;
        }

        // DELETE: api/Customers/5
        public async Task<ViewCustomers> DeleteCustomers(int id)
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
