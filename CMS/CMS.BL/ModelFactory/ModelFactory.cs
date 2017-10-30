using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMS.BL.RequestModels;
using CMS.BL.ViewModels;
using CMS.DAL.Models;


namespace CMS.BL.ModelFactory
{
   public class ModelFactory
    {
        public ViewCustomers CreateViewCustumerModel(RequestCustomers requestCustomers)
        {
            return new ViewCustomers
            {
                FirstName = requestCustomers.FirstName,
                LastName = requestCustomers.LastName,
                PhoneNumber = requestCustomers.PhoneNumber,
                Email = requestCustomers.Email,
                BirthDate = requestCustomers.BirthDate,
                City = requestCustomers.City,
                Country = requestCustomers.Country,
                Products = new List<ViewProducts>()
            };
        }

       
        public ViewCustomers CreateViewCustumerModelFromDb(Customers customers)
        {
            return new ViewCustomers
            {
                FirstName = customers.FirstName,
                LastName = customers.LastName,
                PhoneNumber = customers.PhoneNumber,
                Email = customers.Email,
                BirthDate = customers.BirthDate,
                City = customers.City,
                Country = customers.Country,
                Products = customers.Products.Select(CreateProductsViewModel) as ICollection<ViewProducts>
            };
        }
        public Customers CreateCustumerModelFromViewModel(ViewCustomers customers)
        {
            return new Customers()
            {
                FirstName = customers.FirstName,
                LastName = customers.LastName,
                PhoneNumber = customers.PhoneNumber,
                Email = customers.Email,
                BirthDate = customers.BirthDate,
                City = customers.City,
                Country = customers.Country,
                Products = new  List<Products>()
            };
        }
        public ViewProducts CreateProductsViewModel(Products requestProducts)
        {
            return new ViewProducts
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

        public Products CreateProductsModelFromDb(ViewProducts virweProducts)
        {
            return new Products
            {
                Customer = virweProducts.Customer,
                ProductName = virweProducts.ProductName,
                Color = virweProducts.Color,
                ExpirationDate = virweProducts.ExpirationDate,
                ReleaseDate = virweProducts.ExpirationDate,
                CustomerId = virweProducts.CustomerId,
                Price = virweProducts.Price
            };
        }
}
}
