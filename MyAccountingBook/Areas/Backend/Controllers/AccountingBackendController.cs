using MyAccountingBook.Models.Interface;
using MyAccountingBook.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace MyAccountingBook.Areas.Backend.Controllers
{
    public class AccountingBackendController : Controller
    {
        private IBooksResult BooksResult;
        public AccountingBackendController()
        {
            this.BooksResult = new BooksResult();
        }
        // GET: Backend/AccountingBackend
        public ActionResult Index(int? page)
        {
            int PageSize = 10; //每頁顯示幾筆
            int PageNumber = (page ?? 1);

            var BooksResult = this.BooksResult.GetAll(PageNumber, PageSize);
            return View(BooksResult);
        }

        public ActionResult Edit()
        {
            return View();
        }
    }
}