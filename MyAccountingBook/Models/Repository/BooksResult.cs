using MyAccountingBook.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyAccountingBook.Models.ViewModels;
using MyAccountingBook.Models.Entity;
using PagedList;

namespace MyAccountingBook.Models.Repository
{
    public class BooksResult : IBooksResult
    {
        protected AccountBookDbContext db
        {
            get;
            private set;
        }
        public BooksResult()
        {
            this.db = new AccountBookDbContext();
        }
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
        public IPagedList<BooksResultViewModels> GetAll(int PageNumber, int PageSize)
        {
            //var result = from Books in db.AccountBook
            //             select new BooksResultViewModels()
            //             {
            //                 Amount = Books.Amounttt.ToString(),
            //                 Date = Books.Dateee.ToString(),
            //                 InOut = Books.Categoryyy == 0 ? "支出" : "收入"
            //             };
            var result = db.AccountBook
                .OrderByDescending(s => s.Dateee)
                //.Skip((PageNumber - 1) * PageSize)
                //.Take(PageSize)
                .Select(s => new BooksResultViewModels()
                {
                    Amount = s.Amounttt.ToString(),
                    Date = s.Dateee.ToString(),
                    InOut = s.Categoryyy.ToString()
                });
            return result.ToPagedList(PageNumber, PageSize);
        }

        public void Insert(keepBooksViewModels data)
        {
            var InsertAccountBook = new AccountBookModels
            {
                Id = Guid.NewGuid(),
                Amounttt = data.Amount,
                //因選單編號(1:支出, 2:收入)與資料庫儲存編號(0:支出, 1:收入)不同，故做轉換動作
                Categoryyy = (int)data.InOut == 1 ? 0 : 1,
                Dateee = data.Date,
                Remarkkk = data.Memo
            };
            db.AccountBook.Add(InsertAccountBook);
            db.SaveChanges();
        }
    }
}