using System;
using System.Collections.Generic;

namespace CMS.BL.ViewModels
{
    public partial class ViewCustomer
    {
        public ViewCustomer()
        {
            Products = new HashSet<ViewProduct>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public ICollection<ViewProduct> Products { get; set; }
    }
}
