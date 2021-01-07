using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ZooShop.Models.MyValidation;

namespace ZooShop.Models
{
    public class DistributorContactInfoViewModel
    {
        [Required]
        [MinLength(2, ErrorMessage = "Distributor name cannot be less than 2!"),
        MaxLength(30, ErrorMessage = "Distributor name cannot be more than 30!")]
        public string DistributorName { get; set; }

        [Required]
        [RegularExpression(@"^07(\d{8})$", ErrorMessage = "This is not a valid phone number!")]
        public string PhoneNumber { get; set; }

        [Required]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
        ErrorMessage = "Please enter correct email address")]
        public string Email { get; set; }
    }
}