using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAccountingBook.Models.ViewModels
{
    public class keepBooksViewModels
    {     

        public InOutList InOut { get; set; }
        public string Amount { get; set; }
        public string Date { get; set; }
        public string Memo { get; set; }

    }
    public enum InOutList
    {        
        支出,
        收入
    }


}