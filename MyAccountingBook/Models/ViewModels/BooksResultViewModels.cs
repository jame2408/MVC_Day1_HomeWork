using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MyAccountingBook.Models.ViewModels
{
    public class BooksResultViewModels
    {
        [DisplayName("#")]
        public int seqno { get; set; }
        [DisplayName("類別")]
        public string InOut { get; set; }
        [DisplayName("日期")]
        public string Date { get; set; }
        [DisplayName("金額")]
        public string Amount { get; set; }
    }
}