using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZooShop.Models.MyValidation;

namespace ZooShop.Models
{
    public class Animal
    {
        public int AnimalId { get; set; }

        [MinLength(2, ErrorMessage = "Name cannot be less than 2!"),
           MaxLength(200, ErrorMessage = "Name cannot be more than 200!")]
        public string Name { get; set; }
        [GenderValidator]
        public string Gender { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid positive number!")]
        public int Price { get; set; }

        [MinLength(0, ErrorMessage = "Summary cannot be less than 0!"),
        MaxLength(5000, ErrorMessage = "Summary cannot be more than 5000!")]
        public string Details { get; set; }

        //Image
        [DisplayName("Upload a image!")]
        public string ImagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        //one-to-many relationship
        public int BreedId { get; set; }
        public virtual Breed Breed { get; set; }

        //many-to-many relationship
        public virtual ICollection<Vaccine> Vaccines { get; set; }

        //dropdown list
        [NotMapped]
        public IEnumerable<SelectListItem> BreedList { get; set; }

        //checkboxes list
        [NotMapped]
        public List<CheckBoxViewModel> VaccineList { get; set; }

    }
  
}