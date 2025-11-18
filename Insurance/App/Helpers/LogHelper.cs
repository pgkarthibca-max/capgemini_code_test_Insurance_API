using System;
using System.Diagnostics;
using System.Web;

namespace App.Helpers
{
    public static class LogHelper
    {
        // Simple Error logger used by Global.asax.
        // Signature matches the call in Global.asax:
        // LogHelper.Error(Exception ex, object?, object?, string requestUrl, HttpContextBase context)
        public static void Error(Exception ex, object arg1 = null, object arg2 = null, string requestUrl = null, HttpContextBase context = null)
        {
            try
            {
                var ts = DateTime.UtcNow.ToString("o");
                var user = context?.User?.Identity?.Name ?? "unknown";
                var message = $"[{ts}] Unhandled exception: {ex?.ToString()}\nRequestUrl: {requestUrl}\nUser: {user}\nArg1: {arg1}\nArg2: {arg2}";
                Trace.TraceError(message);
            }
            catch
            {
                // Never throw from the global error logger.
            }
        }
    }
}