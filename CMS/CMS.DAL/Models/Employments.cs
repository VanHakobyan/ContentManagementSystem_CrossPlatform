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
        public Guid GuId { get; set; }
        public string EmploymentName { get; set; }
        public string Price { get; set; }
        public double? MakingTime { get; set; }
        public int CustomerId { get; set; }

        public Customers Customer { get; set; }
        public ICollection<Schedules> Schedules { get; set; }
    }
}
