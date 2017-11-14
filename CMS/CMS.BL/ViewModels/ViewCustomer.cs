using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CMS.BL.ViewModels
{
    public partial class ViewCustomer
    {
        public ViewCustomer()
        {
            Employments = new HashSet<ViewEmployments>();
        }
        public Guid GuId { get; set; }

        [Display(Name = "First Name")]
        [Required, StringLength(60)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required, StringLength(60)]
        public string LastName { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone Number")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Text)]
        public string Country { get; set; }

        [DataType(DataType.Text)]
        public string City { get; set; }

        public ICollection<ViewEmployments> Employments { get; set; }
    }
}
