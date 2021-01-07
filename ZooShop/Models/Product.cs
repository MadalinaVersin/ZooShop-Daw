using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZooShop.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Name cannot be less than 2!"),
            MaxLength(200, ErrorMessage = "Name cannot be more than 200!")]
        public string Name { get; set; }
        
        [MinLength(2, ErrorMessage = "Details cannot be less than 2!"),
        MaxLength(5000, ErrorMessage = "Details cannot be more than 5000!")]
        public string Details { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid positive number!")]
        public int Price { get; set; }

        
        //Image
        [DisplayName("Upload a image.")]
        public string ImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }


        //one-to-many relationship
        public int DistributorId { get; set; }
        public virtual Distributor Distributor { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> DistributorList{ get; set; }
    }
}