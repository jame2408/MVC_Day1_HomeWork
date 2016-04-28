using MyAccountingBook.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyAccountingBook.Models.Repository;
using MyAccountingBook.Models.Interface;

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
        public ActionResult BooksResultChildAction()
        {
            //return View(this.BooksResult.Query());    

            var BooksResult = this.BooksResult.GetAll();
            //收入支出顏色判斷
            ViewBag.InOutColor = new Func<string, string>(InOutColor);
            return View(BooksResult);
        }

        /// <summary>
        /// 依資料庫『類別』資料，轉換成中文並依不同文字給予顏色
        /// </summary>
        /// <param name="InOut">0:支出, 1:收入</param>
        /// <returns></returns>
        private string InOutColor(string InOut)
        {
            if (InOut == "0")
            {
                return "<span style=\"color: red;\">支出</span>";
            }
            else
            {
                return "<span style=\"color: blue;\">收入</span>";
            }
        }
    }
}