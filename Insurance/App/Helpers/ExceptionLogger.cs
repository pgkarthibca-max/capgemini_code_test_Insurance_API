using System;
using System.Diagnostics;
using System.Web;

namespace App.Helpers
{
    public static class ExceptionLogger
    {
        public static void Log(Exception ex, string controller = null, string action = null, string url = null, HttpContextBase context = null)
        {
            try
            {
                var user = context?.User?.Identity?.Name ?? "anonymous";
                var message = $"[{DateTime.UtcNow:O}] Exception: {ex}\nController: {controller}\nAction: {action}\nUrl: {url}\nUser: {user}";
                Trace.TraceError(message);
            }
            catch
            {
                // Intentionally swallow logging exceptions to avoid cascading failures
            }
        }
    }
}