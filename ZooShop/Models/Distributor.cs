using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZooShop.Models
{
    public class Distributor
    {
        public int DistributorId { get; set; }
        
        [Required]
        [MinLength(2, ErrorMessage = "Distributor Name cannot be less than 2!"),
           MaxLength(200, ErrorMessage = "Distributor Name cannot be more than 200!")]
        public string DistributorName { get; set; }

        //many-to-one relationship
        public virtual ICollection<Product> Products { get; set; }
        
        //one-to-one relationship
        [Required]
        public virtual ContactInfo ContactInfo { get; set; }
    }
}