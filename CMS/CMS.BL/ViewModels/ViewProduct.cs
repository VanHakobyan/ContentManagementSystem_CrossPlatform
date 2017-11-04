using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CMS.DAL.Models;

namespace CMS.BL.ViewModels
{
    public class ViewProduct
    {
        [DisplayName("Product Name")]
        public string ProductName { get; set; }
        public int? Price { get; set; }
        public string Color { get; set; }

        [DisplayName("Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [DisplayName("Expiration Date")]
        public DateTime? ExpirationDate { get; set; }
        public int CustomerId { get; set; }

        public Customers Customer { get; set; }
    }
}
