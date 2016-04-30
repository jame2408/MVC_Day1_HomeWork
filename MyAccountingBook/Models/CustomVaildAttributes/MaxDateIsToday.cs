using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyAccountingBook.Models.CustomVaildAttributes
{
    public class MaxDateIsToday : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }
            if (value is DateTime)
            {
                if ((DateTime)value <= Convert.ToDateTime(DateTime.Today.ToShortDateString()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}