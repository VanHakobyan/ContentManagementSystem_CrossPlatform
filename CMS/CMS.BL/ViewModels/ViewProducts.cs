using System;
using CMS.DAL.Models;

namespace CMS.BL.ViewModels
{
    public class ViewProducts
    {
        public string ProductName { get; set; }
        public int? Price { get; set; }
        public string Color { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int CustomerId { get; set; }

        public Customers Customer { get; set; }
    }
}
