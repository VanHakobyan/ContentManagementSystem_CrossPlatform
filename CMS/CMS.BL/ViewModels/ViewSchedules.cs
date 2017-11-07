using System;
using CMS.DAL.Models;

namespace CMS.BL.ViewModels
{
    public class ViewSchedules
    {
        public DateTime? StartWorkTime { get; set; }
        public DateTime? EndWorkTime { get; set; }
        public DateTime AllWorkTime { get; set; }
        public bool? IsAccessible { get; set; }
        public int EmploymentEmploymentId { get; set; }
        public Employments EmploymentEmployment { get; set; }
    }
}
