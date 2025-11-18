using App.App_Start;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using App.Helpers;
using System;

namespace App
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            Bootstrapper.Initialize();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error()
        {
            try
            {
                var ex = Server.GetLastError();
                if (ex != null)
                {
                    ExceptionLoggerOrNLog(ex);
                }
            }
            catch
            {
                // swallow
            }
            finally
            {
                Server.ClearError();
            }

            // Redirect to Error controller/view
            Response.Clear();
            Response.Redirect("~/Error");
        }

        private void ExceptionLoggerOrNLog(Exception ex)
        {
            // use LogHelper to record global exceptions
            try
            {
                LogHelper.Error(ex, null, null, Request?.Url?.ToString(), new HttpContextWrapper(Context));
            }
            catch
            {
                // keep silent
            }
        }
    }
}
