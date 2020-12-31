using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZooShop.Models
{
    public class Vaccine
    {
        public int VaccineId { get; set; }

        [MinLength(3, ErrorMessage = "Vaccine name cannot be less than 3!"),
            MaxLength(30, ErrorMessage = "Vaccine name cannot be more than 30!")]
        public string Name { get; set; }
        public int Price { get; set; }

        //many-to-many relationship
        public virtual ICollection<Animal> Animals { get; set; }
    }
}
