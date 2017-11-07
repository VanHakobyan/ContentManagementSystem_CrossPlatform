using System;
using System.Collections.Generic;

namespace CMS.DAL.Models
{
    public partial class Employments
    {
        public Employments()
        {
            Schedules = new HashSet<Schedules>();
        }

        public int EmploymentId { get; set; }
        public string ProductName { get; set; }
        public string Price { get; set; }
        public DateTime? MakingTime { get; set; }
        public int CustomerId { get; set; }

        public Customers Customer { get; set; }
        public ICollection<Schedules> Schedules { get; set; }
    }
}
