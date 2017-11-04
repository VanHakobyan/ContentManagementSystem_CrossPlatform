using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.BL.ViewModels;
using CMS.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CMS.BL
{
    public class ProductsManager : IDisposable
    {
        private CMSContext db = new CMSContext();
        private readonly ModelFactory.ModelFactory factory = new ModelFactory.ModelFactory();
        // GET: api/Products
        public IEnumerable<ViewProduct> GetProducts()
        {
            return db.Products.Select(product => factory.CreateProductsViewModel(product)).ToList();
        }

        // GET: api/Products/5
        public async Task<ViewProduct> GetProductsById(int id)
        {
            return factory.CreateProductsViewModel(await db.Products.SingleOrDefaultAsync(m => m.Id == id));
        }

        // PUT: api/Products/5
        public async Task<ViewProduct> PutProducts(int id, ViewProduct product)
        {
            //var productsModelFromDb = factory.CreateProductsModelFromDb(product);
            var productsInDb = await db.Products.FirstOrDefaultAsync(x => x.Id == id);
            db.Products.Attach(productsInDb);
            factory.ProductPutMaker(product, productsInDb);
            db.SaveChanges();
            return product;
        }

        // POST: api/Products
        public async Task<ViewProduct> PostProducts(ViewProduct product)
        {
            db.Products.Add(factory.CreateProductsModelFromDb(product));
            await db.SaveChangesAsync();
            return product;
        }

        // DELETE: api/Products/5
        public async Task<ViewProduct> DeleteProducts(int id)
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
