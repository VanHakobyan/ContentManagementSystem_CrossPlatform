using System;
using System.Collections.Generic;

namespace CMS.DAL.Models
{
    public partial class Schedules
    {
        public int ScheduleId { get; set; }
        public DateTime AllWorkTime { get; set; }
        public DateTime? StartWorkTime { get; set; }
        public DateTime? EndWorkTime { get; set; }
        public bool? IsAccessible { get; set; }
        public int EmploymentEmploymentId { get; set; }

        public Employments EmploymentEmployment { get; set; }
    }
}
