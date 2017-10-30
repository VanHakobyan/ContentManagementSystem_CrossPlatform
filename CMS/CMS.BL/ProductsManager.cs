using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.BL.ViewModels;
using CMS.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CMS.BL
{
    public class ProductsManager : IDisposable
    {
        private CMSContext db = new CMSContext();
        private ModelFactory.ModelFactory factory = new ModelFactory.ModelFactory();
        // GET: api/Products
        public IEnumerable<ViewProducts> GetProducts()
        {
            return db.Products.Select(product => factory.CreateProductsViewModel(product)).ToList();
        }

        // GET: api/Products/5
        public async Task<ViewProducts> GetProductsById(int id)
        {
            return factory.CreateProductsViewModel(await db.Products.SingleOrDefaultAsync(m => m.Id == id));
        }

        // PUT: api/Products/5
        public async Task<ViewProducts> PutProducts(int id, ViewProducts products)
        {
            try
            {
                
                db.Entry(db.Products.Update(factory.CreateProductsModelFromDb(products))).State=EntityState.Modified;
                await db.SaveChangesAsync();
            }
            catch {/* ignored*/}
            return products;
        }

        // POST: api/Products
        public async Task<ViewProducts> PostProducts(ViewProducts products)
        {
            db.Products.Add(factory.CreateProductsModelFromDb(products));
            await db.SaveChangesAsync();
            return products;
        }

        // DELETE: api/Products/5
        public async Task<ViewProducts> DeleteProducts(int id)
        {
            var products = await db.Products.SingleOrDefaultAsync(m => m.Id == id);
            db.Products.Remove(products);
            await db.SaveChangesAsync();
            return factory.CreateProductsViewModel(products);
        }
        public bool ProductsExists(int id)
        {
            return db.Products.Any(e => e.Id == id);
        }

        public void Dispose()
        {
            db?.Dispose();
        }
    }
}
