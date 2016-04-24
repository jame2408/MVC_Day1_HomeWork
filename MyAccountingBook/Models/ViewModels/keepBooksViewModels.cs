using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyAccountingBook.Models.ViewModels
{
    public class keepBooksViewModels
    {
        //[Required]
        [DisplayName("類別")]
        [Range(1, int.MaxValue, ErrorMessage = "請選擇類別")]
        public InOutList InOut { get; set; }
        [Required]
        [DisplayName("金額")]
        public int Amount { get; set; }
        [Required]
        [DisplayName("日期")]
        public DateTime Date { get; set; }
        [Required]
        [DisplayName("備註")]
        public string Memo { get; set; }

    }
    public enum InOutList
    {
        支出 = 1,
        收入 = 2
    }


}