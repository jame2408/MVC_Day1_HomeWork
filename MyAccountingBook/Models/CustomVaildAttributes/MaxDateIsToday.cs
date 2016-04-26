using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyAccountingBook.Models.CustomVaildAttributes
{
    public class MaxDateIsToday : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((DateTime)value <= Convert.ToDateTime(DateTime.Today.ToShortDateString()))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("日期不能大於今天.");
            }
            return base.IsValid(value, validationContext);
        }
    }
}