using CMS.BL.ViewModels;
using CMS.DAL.Models;


namespace CMS.BL.ModelFactory
{
    public class ModelFactory
    {
       
        public ViewCustomer CreateViewCustumerModelFromDb(Customers customers)
        {
            var c = new ViewCustomer
            {
                FirstName = customers.FirstName,
                LastName = customers.LastName,
                PhoneNumber = customers.PhoneNumber,
                Email = customers.Email,
                BirthDate = customers.BirthDate,
                City = customers.City,
                Country = customers.Country,
            };
            foreach (var products in customers.Products)
            {
                var productsModelFromDb = CreateProductsViewModel(products);
                c.Products.Add(productsModelFromDb);
            }
            return c;
        }
        public Customers CreateCustumerModelFromViewModel(ViewCustomer customer)
        {
            var c = new Customers()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email,
                BirthDate = customer.BirthDate,
                City = customer.City,
                Country = customer.Country,
            };

            if (customer.Products != null)
            {
                foreach (var products in customer.Products)
                {
                    var productsModelFromDb = CreateProductsModelFromDb(products);
                    c.Products.Add(productsModelFromDb);
                }
            }
            return c;
        }
        public ViewProduct CreateProductsViewModel(Products requestProducts)
        {
            return new ViewProduct
            {
                Customer = requestProducts.Customer,
                ProductName = requestProducts.ProductName,
                Color = requestProducts.Color,
                ExpirationDate = requestProducts.ExpirationDate,
                ReleaseDate = requestProducts.ExpirationDate,
                CustomerId = requestProducts.CustomerId,
                Price = requestProducts.Price
            };
        }

        public Products CreateProductsModelFromDb(ViewProduct virweProduct)
        {
            return new Products
            {
                Customer = virweProduct.Customer,
                ProductName = virweProduct.ProductName,
                Color = virweProduct.Color,
                ExpirationDate = virweProduct.ExpirationDate,
                ReleaseDate = virweProduct.ExpirationDate,
                CustomerId = virweProduct.CustomerId,
                Price = virweProduct.Price
            };
        }

        public void ProductPutMaker(ViewProduct product, Products productsInDb)
        {
            productsInDb.Id = product.CustomerId;
            productsInDb.Price = product.Price;
            productsInDb.ProductName = product.ProductName;
            productsInDb.Color = product.Color;
            productsInDb.CustomerId = product.CustomerId;
            productsInDb.ExpirationDate = product.ExpirationDate;
            productsInDb.ReleaseDate = product.ReleaseDate;
            productsInDb.Customer = product.Customer;
        }

        public void CustomerPutMaker(Customers customerDb, Customers customerLoadDb)
        {
            customerLoadDb.City = customerDb.City;
            customerLoadDb.Products = customerDb.Products;
            customerLoadDb.BirthDate = customerDb.BirthDate;
            customerLoadDb.Country = customerDb.Country;
            customerLoadDb.Email = customerDb.Email;
            customerLoadDb.FirstName = customerDb.FirstName;
            customerLoadDb.LastName = customerDb.LastName;
            customerLoadDb.PhoneNumber = customerDb.PhoneNumber;
        }
    }
}
