using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MyAccountingBook.Models.ViewModels
{
    public class keepBooksViewModels
    {
        [DisplayName("類別")]
        public InOutList InOut { get; set; }
        [DisplayName("金額")]
        public string Amount { get; set; }
        [DisplayName("日期")]
        public string Date { get; set; }
        [DisplayName("備註")]
        public string Memo { get; set; }

    }
    public enum InOutList
    {        
        支出,
        收入
    }


}