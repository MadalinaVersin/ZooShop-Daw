using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZooShop.Models.MyValidation
{
    public class GenderValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var animal = (Animal)validationContext.ObjectInstance;
            string gender = animal.Gender;
            bool cond = true;
            if (gender == "Male" || gender == "Female")
                cond = true;
            else cond = false;
            return cond ? ValidationResult.Success : new ValidationResult("Male/Female");
        }
    }
}