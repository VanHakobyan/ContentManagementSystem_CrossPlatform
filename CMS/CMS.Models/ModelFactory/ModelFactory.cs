using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMS.Models.RequestModels;
using CMS.Models.ResponseModels;

namespace CMS.Models.ModelFactory
{
   public class ModelFactory
    {
        public ResponseCustomers CreateResponseCustumer(RequestCustomers requestCustomers)
        {
            return new ResponseCustomers
            {
                FirstName = requestCustomers.FirstName,
                LastName = requestCustomers.LastName,
                PhoneNumber = requestCustomers.PhoneNumber,
                Email = requestCustomers.Email,
                BirthDate = requestCustomers.BirthDate,
                City = requestCustomers.City,
                Country = requestCustomers.Country,
                Products = new List<ResponseProducts>()
            };
        }

       
        public ResponseCustomers CreateResponseCustumerFromDb(Customers customers)
        {
            return new ResponseCustomers
            {
                FirstName = customers.FirstName,
                LastName = customers.LastName,
                PhoneNumber = customers.PhoneNumber,
                Email = customers.Email,
                BirthDate = customers.BirthDate,
                City = customers.City,
                Country = customers.Country,
                Products = (ICollection<ResponseProducts>) customers.Products.Select(CreateResponseProductsFromDb)
            };
        }
        public ResponseProducts CreateResponseProducts(RequestProducts requestProducts)
        {
            return new ResponseProducts
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

        public ResponseProducts CreateResponseProductsFromDb(Products requestProducts)
        {
            return new ResponseProducts
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
}
}
