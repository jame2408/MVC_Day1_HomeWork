using MyAccountingBook.Models.CustomVaildAttributes;
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
        [Key]
        public Guid Id { get; set; }
        //[Required]
        [DisplayName("類別")]
        [Range(1, int.MaxValue, ErrorMessage = "請選擇{0}")]
        public InOutList InOut { get; set; }

        [DisplayName("金額")]
        [Required]
        [DisplayFormat(DataFormatString ="{0:N0}")]
        [Range(1, int.MaxValue, ErrorMessage ="{0}需為正整數")]
        public int Amount { get; set; }

        [DisplayName("日期")]
        [Required]
        [DataType(DataType.Date)]
        [MaxDateIsToday(ErrorMessage ="日期不能超過今天")]
        //[DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]        
        public DateTime Date { get; set; }

        [DisplayName("備註")]
        [StringLength(100, ErrorMessage ="{0}不能超過100個字")]
        [Required]
        public string Memo { get; set; }

    }
    public enum InOutList
    {
        [Display(Name ="支出")]
        Expenditure = 1,
        [Display(Name = "收入")]
        Income = 2
    }


}