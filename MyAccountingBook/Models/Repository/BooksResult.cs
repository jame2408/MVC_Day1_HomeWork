using MyAccountingBook.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyAccountingBook.Models.ViewModels;
using MyAccountingBook.Models.Entity;
using PagedList;
using MyAccountingBook.Models.Enum;

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
                    Id = s.Id,
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

        public keepBooksViewModels GetOne(Guid? id)
        {
            var GetData = db.AccountBook.Where(s => s.Id == id)
                .Select(d => new keepBooksViewModels()
                {
                    Id = d.Id,
                    InOut = (InOutList)(d.Categoryyy == 0 ? 1 : 2),
                    Amount = d.Amounttt,
                    Date = d.Dateee,
                    Memo = d.Remarkkk
                }).SingleOrDefault();
            return GetData;
        }

        public void Update(keepBooksViewModels result)
        {
            var UpdateAccounting = (from s in db.AccountBook
                                    where s.Id == result.Id
                                    select s).SingleOrDefault();
            UpdateAccounting.Categoryyy = (int)result.InOut == 1 ? 0 : 1;
            UpdateAccounting.Amounttt = result.Amount;
            UpdateAccounting.Dateee = result.Date;
            UpdateAccounting.Remarkkk = result.Memo;
            db.SaveChanges();
        }

        public void Delete(Guid? Id)
        {
            var deleteData = db.AccountBook.Where(s => s.Id == Id).SingleOrDefault();
            db.AccountBook.Remove(deleteData);
            db.SaveChanges();
        }
    }
}