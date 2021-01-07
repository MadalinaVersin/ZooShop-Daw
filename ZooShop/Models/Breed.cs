using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZooShop.Models
{
    public class Breed
    {

        public int BreedId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Breed name cannot be less than 2!"),
        MaxLength(30, ErrorMessage = "Breed name cannot be more than 30!")]
        public string BreedName { get; set; }

        //many-to-one relationship
        public virtual ICollection<Animal> Animals { get; set; }
    }
}