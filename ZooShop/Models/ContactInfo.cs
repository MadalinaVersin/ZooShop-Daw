using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZooShop.Models
{
    public class ContactInfo
    {
        public int ContactInfoId { set; get; }
        public String Email { get; set; }
        [RegularExpression(@"^07(\d{8})$", ErrorMessage = "This is not a valid phone number!")]
        public String PhoneNumber { get; set; }

        //one-to-one relationship
        public virtual Distributor Distributor { get; set; }
    }
}