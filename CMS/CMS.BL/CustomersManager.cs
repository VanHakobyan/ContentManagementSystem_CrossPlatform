using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CMS.BL
{
    public class CustomersManager
    {
        private readonly CMSContext db = new CMSContext();

        public IEnumerable<Customers> GetCustomers()
        {
            return db.Customers;
        }

        // GET: api/Customers/5
        public async Task<Customers> GetCustomersById(int id)
        {
            return await db.Customers.SingleOrDefaultAsync(m => m.Id == id);
        }

        // PUT: api/Customers/5
        public async Task<Customers> PutCustomers(int id, Customers customers)
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
        public async Task<Customers> PostCustomers(Customers customers)
        {
            db.Customers.Add(customers);
            await db.SaveChangesAsync();
            return customers;
        }

        // DELETE: api/Customers/5
        public async Task<Customers> DeleteCustomers(int id)
        {
            var customers = await db.Customers.SingleOrDefaultAsync(m => m.Id == id);
            db.Customers.Remove(customers);
            await db.SaveChangesAsync();
            return customers;
        }
        public bool CustomersExists(int id)
        {
            return db.Customers.Any(e => e.Id == id);
        }
    }
}
