using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZooShop.Models
{
    public class DistributorContactInfoViewModel
    {
        [MinLength(2, ErrorMessage = "Distributor name cannot be less than 2!"),
        MaxLength(30, ErrorMessage = "Distributor name cannot be more than 30!")]
        public string DistributorName { get; set; }

        [RegularExpression(@"^07(\d{8})$", ErrorMessage = "This is not a valid phone number!")]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}