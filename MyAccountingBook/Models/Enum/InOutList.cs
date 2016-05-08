using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyAccountingBook.Models.Enum
{
    public enum InOutList
    {
        [Display(Name = "支出")]
        Expenditure = 1,
        [Display(Name = "收入")]
        Income = 2
    }
}