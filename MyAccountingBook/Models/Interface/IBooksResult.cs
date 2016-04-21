using MyAccountingBook.Models.Entity;
using MyAccountingBook.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAccountingBook.Models.Interface
{
    public interface IBooksResult
    {
        List<BooksResultViewModels> Query();
        IQueryable<BooksResultViewModels> GetAll();
    }
}