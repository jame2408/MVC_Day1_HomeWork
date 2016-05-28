using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyAccountingBook.Models.ViewModels
{
    public class BooksResultViewModels
    {
        [Key]
        public Guid Id { get; set; }
        [DisplayName("類別")]
        public int InOut { get; set; }
        [DisplayName("日期")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [DisplayName("金額")]
        public int Amount { get; set; }
    }
}