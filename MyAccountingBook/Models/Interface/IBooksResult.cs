using MyAccountingBook.Models.Entity;
using MyAccountingBook.Models.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAccountingBook.Models.Interface
{
    public interface IBooksResult
    {
        List<BooksResultViewModels> Query();
        IPagedList<BooksResultViewModels> GetAll(int PageNumber, int PageSize);
        void Insert(keepBooksViewModels data);
    }
}