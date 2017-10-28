using System;
using System.Collections.Generic;

namespace CMS.DAL.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Products = new HashSet<Products>();
        }

        public int Id { get; set; }
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
