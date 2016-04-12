using MyAccountingBook.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyAccountingBook.Models.ViewModels;

namespace MyAccountingBook.Models.Repository
{
    public class BooksResult : IBooksResult
    {
        public List<BooksResultViewModels> Query()
        {
            var Result = new List<BooksResultViewModels>
            {
                new BooksResultViewModels()
                {
                InOut = "支出",
                Date = "2016-01-01",
                Amount = "300"
                },
                new BooksResultViewModels()
                {
                InOut = "支出",
                Date = "2016-01-02",
                Amount = "16,000"
                },
                new BooksResultViewModels()
                {
                InOut = "支出",
                Date = "2016-01-03",
                Amount = "8,000"
                }
            };
            return Result;
        }
    }
}