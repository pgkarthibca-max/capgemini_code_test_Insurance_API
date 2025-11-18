using System;
using System.Web;
using System.Web.Mvc;
using App.Helpers;

namespace App.Filters
{
    public class CustomHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext == null || filterContext.ExceptionHandled)
            {
                base.OnException(filterContext);
                return;
            }

            try
            {
                var ex = filterContext.Exception;
                var url = filterContext.HttpContext?.Request?.Url?.ToString();
                var controller = (string)filterContext.RouteData.Values["controller"] ?? "";
                var action = (string)filterContext.RouteData.Values["action"] ?? "";

                // Fix: Pass HttpContext instead of HttpContextWrapper
                ExceptionLogger.Log(ex, controller, action, url, filterContext.HttpContext);
            }
            catch
            {
                // swallow logging failures
            }

            // Mark handled and show shared Error viewArgument 1: cannot convert from 'System.Web.HttpContextBase' to 'System.Web.HttpContext'
            filterContext.ExceptionHandled = true;
            filterContext.Result = new ViewResult
            {
                ViewName = "Error",
                ViewData = new ViewDataDictionary(filterContext.Controller?.ViewData)
                {
                    Model = filterContext.Exception
                }
            };

            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
        }
    }
}