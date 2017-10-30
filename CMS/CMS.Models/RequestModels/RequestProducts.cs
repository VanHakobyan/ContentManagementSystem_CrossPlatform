using System;
using System.Collections.Generic;

namespace CMS.Models.RequestModels
{
    public partial class RequestProducts
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
