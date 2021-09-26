using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DamianTrans.Middleware
{
    public class ErrorHandler
    {
        private readonly RequestDelegate _next;

        public ErrorHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
                switch (context.Response.StatusCode)
                {
                    case 404:
                        HandlePageNotFound(context);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                HandleException(context, e);
            }
            finally
            {
            }
        }

        //  500
        private static void HandleException(HttpContext context, Exception e)
        {
            context.Response.Redirect("/Home/Error");
        }

        //  404
        private static void HandlePageNotFound(HttpContext context)
        {
            //  Display an information page that displays the bad url using a cookie
            string pageNotFound = context.Request.Path.ToString().TrimStart('/');
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddMilliseconds(10000);
            cookieOptions.IsEssential = true;
            context.Response.Cookies.Append("PageNotFound", pageNotFound, cookieOptions);
            context.Response.Redirect("/Home/PageNotFound");
        }
    }
}
