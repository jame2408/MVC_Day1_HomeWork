﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyAccountingBook.Filter
{
    public class AuthorizePlusAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            //將Contains改成==，防止類似帳號可以登入
            if (!(filterContext.RequestContext.HttpContext.User.Identity.Name == "admin@gmail.com"))
            {
                filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                                   {
                                       { "action", "Index" },
                                       { "controller", "keepBooks" },
                                       { "area", "" }
                                   });
                return;
            }

            //支援 MVC5 新增的 AllowAnonymous
            var skipAuthorization =
                filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true) ||
                filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute),
                    inherit: true);

            //有設定 AllowAnonymous 就跳過
            if (skipAuthorization)
            {
                return;
            }

            //驗證是否是授權的連線。
            if (filterContext.HttpContext.User.Identity.IsAuthenticated == false)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }

            //驗證是否是授權的連線，並且是 AJAX 呼叫。
            if (filterContext.Result is HttpUnauthorizedResult && filterContext.HttpContext.Request.IsAjaxRequest())
            {
                ContentResult cr = new ContentResult();
                cr.Content = "<p style=\"color:Red;font-weight:bold;\">您尚未登入無法觀看!! 請先登入後再嘗試。</p>";
                filterContext.Result = cr;
            }

        }
    }
}