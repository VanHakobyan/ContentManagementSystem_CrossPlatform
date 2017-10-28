using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CMS.BL
{
    public class ProductsManager
    {
        private CMSContext db = new CMSContext();
        // GET: api/Products
        public IEnumerable<Products> GetProducts()
        {
            return db.Products;
        }

        // GET: api/Products/5
        public async Task<Products> GetProductsById(int id)
        {
            return await db.Products.SingleOrDefaultAsync(m => m.Id == id);
        }

        // PUT: api/Products/5
        public async Task<Products> PutProducts(int id, Products products)
        {
            try
            {
                db.Entry(products).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            catch{/* ignored*/}
            return products;
        }

        // POST: api/Products
        public async Task<Products> PostProducts(Products products)
        {
            db.Products.Add(products);
            await db.SaveChangesAsync();
            return products;
        }

        // DELETE: api/Products/5
        public async Task<Products> DeleteProducts(int id)
        {
            var products = await db.Products.SingleOrDefaultAsync(m => m.Id == id);
            db.Products.Remove(products);
            await db.SaveChangesAsync();
            return products;
        }
        public bool ProductsExists(int id)
        {
            return db.Products.Any(e => e.Id == id);
        }
    }
}
