using System;
using System.Collections.Generic;

namespace CMS.DAL.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Employments = new HashSet<Employments>();
        }

        public int Id { get; set; }
        public Guid GuId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public ICollection<Employments> Employments { get; set; }
    }
}
