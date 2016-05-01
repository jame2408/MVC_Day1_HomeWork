using MyAccountingBook.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyAccountingBook.Models.Repository;
using MyAccountingBook.Models.Interface;
using PagedList;

namespace MyAccountingBook.Controllers
{
    public class keepBooksController : Controller
    {
        private IBooksResult BooksResult;
        public keepBooksController()
        {
            this.BooksResult = new BooksResult();
        }

        // GET: keepBooks
        public ActionResult Index()
        {
            return View();
        }
        
        [ChildActionOnly]
        public ActionResult KeepBooksChildAction()
        {
            //List<SelectListItem> mySelectItemList = new List<SelectListItem>();

            //mySelectItemList.Add(new SelectListItem()
            //{
            //    Text = "請選擇",
            //    Value = "0",
            //    Selected = true
            //});

            //mySelectItemList.Add(new SelectListItem()
            //{
            //    Text = "1. 支出",
            //    Value = "1",
            //    Selected = false
            //});

            //mySelectItemList.Add(new SelectListItem()
            //{
            //    Text = "2. 收入",
            //    Value = "2",
            //    Selected = false
            //});

            //ViewData["InOut"] = mySelectItemList;

            return View();
        }

        [HttpPost]
        public ActionResult KeepBooksChildAction(keepBooksViewModels data)
        {
            if (ModelState.IsValid)
            {
                this.BooksResult.Insert(data);
                return View("KeepBooksChildAction");
            }
            return View(data);
        }

        [ChildActionOnly]
        public ActionResult BooksResultChildAction(int? page)
        {
            //return View(this.BooksResult.Query());    

            int PageSize = 10; //每頁顯示幾筆
            int PageNumber = (page ?? 1);

            var BooksResult = this.BooksResult.GetAll(PageNumber, PageSize);
            return View(BooksResult);
        }
    }
}