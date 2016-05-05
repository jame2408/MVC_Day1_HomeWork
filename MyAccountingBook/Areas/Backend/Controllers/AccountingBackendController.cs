using MyAccountingBook.Models.Interface;
using MyAccountingBook.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using MyAccountingBook.Models.ViewModels;
using MyAccountingBook.Filter;
using System.Net;

namespace MyAccountingBook.Areas.Backend.Controllers
{
    [AuthorizePlusAttribute(Users ="admin@gmail.com")]
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

        public ActionResult Edit(Guid? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var EditData = this.BooksResult.GetOne(Id);
            if (EditData == null)
            {
                return HttpNotFound();
            }
            return View(EditData);
        }

        [HttpPost]
        public ActionResult Edit(keepBooksViewModels Result)
        {
            try
            {
                this.BooksResult.Update(Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Delete(Guid? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            this.BooksResult.Delete(Id);
            return RedirectToAction("Index");
        }
    }
}