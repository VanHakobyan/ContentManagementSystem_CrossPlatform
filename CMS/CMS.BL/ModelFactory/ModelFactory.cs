using System.Collections.Generic;
using System.Linq;
using CMS.BL.ViewModels;
using CMS.DAL.Models;


namespace CMS.BL.ModelFactory
{
    public class ModelFactory
    {
        private ViewSchedules _createViewSchedules;

        //Customers to view 
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
            foreach (var employment in customers.Employments)
            {
                var productsModelFromDb = CreateEmploymentsViewModel(employment);
                c.Employments.Add(productsModelFromDb);
            }
            return c;
        }

        //View to Customers
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

            //if not contains employments
            if (customer.Employments == null) return c;
            foreach (var products in customer.Employments)
            {
                var productsModelFromDb = CreateEmploymentsModelFromDb(products);
                c.Employments.Add(productsModelFromDb);
            }
            return c;
        }

        //Employments to View
        public ViewEmployments CreateEmploymentsViewModel(Employments requestEmployments)
        {
            var empl = new ViewEmployments
            {
                Customer = requestEmployments.Customer,
                ProductName = requestEmployments.ProductName,
                CustomerId = requestEmployments.CustomerId,
                MakingTime = requestEmployments.MakingTime,
                Price = requestEmployments.Price
            };
            foreach (var schedule in requestEmployments.Schedules)
            {
                var viewSchedules = CreateViewSchedules(schedule);
                empl.ViewSchedules.Add(viewSchedules);
            }
            return empl;
        }

        public ViewSchedules CreateViewSchedules(Schedules schedules)
        {
            return new ViewSchedules()
            {
                StartWorkTime = schedules.StartWorkTime,
                EmploymentEmployment = schedules.EmploymentEmployment,
                EmploymentEmploymentId = schedules.EmploymentEmploymentId,
                EndWorkTime = schedules.EndWorkTime,
                IsAccessible = schedules.IsAccessible,
                AllWorkTime = schedules.AllWorkTime
            };
        }
        public Schedules CreateDbSchedules(ViewSchedules viewSchedules)
        {
            return new Schedules()
            {
                StartWorkTime = viewSchedules.StartWorkTime,
                EmploymentEmployment = viewSchedules.EmploymentEmployment,
                EmploymentEmploymentId = viewSchedules.EmploymentEmploymentId,
                EndWorkTime = viewSchedules.EndWorkTime,
                IsAccessible = viewSchedules.IsAccessible,
                AllWorkTime = viewSchedules.AllWorkTime
            };
        }
        //View to Employments
        public Employments CreateEmploymentsModelFromDb(ViewEmployments virweEmployments)
        {
            var employments = new Employments
            {
                Customer = virweEmployments.Customer,
                ProductName = virweEmployments.ProductName,
                CustomerId = virweEmployments.CustomerId,
                Price = virweEmployments.Price,
                MakingTime = virweEmployments.MakingTime,
            };
            foreach (var employmentsViewSchedule in virweEmployments.ViewSchedules)
            {
                var dbSchedules = CreateDbSchedules(employmentsViewSchedule);
                employments.Schedules.Add(dbSchedules);
            }
            return employments;
        }

        //View products time of put
        public void EmploymentPutMaker(ViewEmployments employments, Employments employmentsInDb)
        {
            employmentsInDb.EmploymentId = employments.CustomerId;
            employmentsInDb.Price = employments.Price;
            employmentsInDb.ProductName = employments.ProductName;
            employmentsInDb.CustomerId = employments.CustomerId;
            employmentsInDb.Customer = employments.Customer;
            employmentsInDb.Schedules = (ICollection<Schedules>) employments.ViewSchedules;
            for (var i = 0; i < employmentsInDb.Schedules.Count; i++)
            {
                _createViewSchedules = employments.ViewSchedules.ElementAt(i);
                _createViewSchedules = CreateViewSchedules(employmentsInDb.Schedules.ElementAt(i));
            }
        }

        //Customer time of put
        public void CustomerPutMaker(Customers customerDb, Customers customerLoadDb)
        {
            customerLoadDb.City = customerDb.City;
            customerLoadDb.Employments = customerDb.Employments;
            customerLoadDb.BirthDate = customerDb.BirthDate;
            customerLoadDb.Country = customerDb.Country;
            customerLoadDb.Email = customerDb.Email;
            customerLoadDb.FirstName = customerDb.FirstName;
            customerLoadDb.LastName = customerDb.LastName;
            customerLoadDb.PhoneNumber = customerDb.PhoneNumber;
        }
    }
}
