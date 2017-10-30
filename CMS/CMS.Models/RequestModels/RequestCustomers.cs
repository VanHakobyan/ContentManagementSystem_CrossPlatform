using System;
using System.Collections.Generic;

namespace CMS.Models.RequestModels
{ 
    public class RequestCustomers
    {
        public RequestCustomers()
        {
            Products = new HashSet<Products>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public ICollection<Products> Products { get; set; }
    }
}
