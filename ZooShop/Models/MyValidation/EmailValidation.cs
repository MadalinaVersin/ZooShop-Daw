using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ZooShop.Models.MyValidation
{
    public class EmailValidation: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var distributorContact = (DistributorContactInfoViewModel)validationContext.ObjectInstance;
            string email = distributorContact.Email;
            bool cond = true;
            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
  
            if (!regex.IsMatch(email))
                cond = false;
            
            return cond ? ValidationResult.Success : new ValidationResult("Please enter a valid e-mail adress");
        }
    }
}