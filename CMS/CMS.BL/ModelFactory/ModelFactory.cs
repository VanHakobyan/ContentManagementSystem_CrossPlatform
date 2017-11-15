using System;
using System.Collections.Generic;
using System.Linq;
using CMS.BL.ViewModels;
using CMS.DAL.Models;


namespace CMS.BL.ModelFactory
{
    public class ModelFactory
    {
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
                GuId = customers.GuId
            };
            foreach (var employment in customers.Employments)
            {
                var productsModelFromDb = CreateEmploymentsViewModel(employment);
                c.Employments.Add(productsModelFromDb);
            }
            return c;
        }

        //View to Customers
        public Customers CreateCustumerModelFromViewModel(ViewCustomer viewCustomer)
        {
            var customers = new Customers()
            {
                FirstName = viewCustomer.FirstName,
                LastName = viewCustomer.LastName,
                PhoneNumber = viewCustomer.PhoneNumber,
                Email = viewCustomer.Email,
                BirthDate = viewCustomer.BirthDate,
                City = viewCustomer.City,
                Country = viewCustomer.Country,
                GuId = Guid.NewGuid()
            };
            if (viewCustomer.GuId==Guid.Empty)
                viewCustomer.GuId = customers.GuId; 
            //if not contains employments
            if (viewCustomer.Employments.Count == 0) return customers;
            foreach (var products in viewCustomer.Employments)
            {
                var productsModelFromDb = CreateEmploymentsModelFromDb(products);
                customers.Employments.Add(productsModelFromDb);
            }
            return customers;
        }

        //Employments to View
        public ViewEmployments CreateEmploymentsViewModel(Employments requestEmployments)
        {
            var empl = new ViewEmployments
            {
                Customer = requestEmployments.Customer,
                EmploymentName = requestEmployments.EmploymentName,
                CustomerId = requestEmployments.CustomerId,
                MakingTime = requestEmployments.MakingTime,
                Price = requestEmployments.Price,
                GuId = requestEmployments.GuId
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
                AllWorkTime = schedules.AllWorkTime,
                GuId = schedules.GuId
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
                AllWorkTime = viewSchedules.AllWorkTime,
                GuId = Guid.NewGuid()
            };
        }
        //View to Employments
        public Employments CreateEmploymentsModelFromDb(ViewEmployments virweEmployments)
        {
            var employments = new Employments
            {
                Customer = virweEmployments.Customer,
                EmploymentName = virweEmployments.EmploymentName,
                CustomerId = virweEmployments.CustomerId,
                Price = virweEmployments.Price,
                MakingTime = virweEmployments.MakingTime,
                GuId = Guid.NewGuid()
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
            employmentsInDb.Price = employments.Price;
            employmentsInDb.EmploymentName = employments.EmploymentName;
            employmentsInDb.CustomerId = employments.CustomerId;
            employmentsInDb.Customer = employments.Customer;
            employmentsInDb.Schedules = new List<Schedules>();
            for (var i = 0; i < employmentsInDb.Schedules.Count; i++)
            {
                CreateViewSchedules(employmentsInDb.Schedules.ElementAt(i));
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
            customerDb.GuId = customerLoadDb.GuId;
        }
    }
}
