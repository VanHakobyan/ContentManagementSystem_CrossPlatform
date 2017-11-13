using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace CMS.WepApi.Helpers
{
    public class CustomExceptionFilterAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var actionName = context.ActionDescriptor.DisplayName;
            var exceptionStack = context.Exception.StackTrace;
            var exceptionMessage = context.Exception.Message;
            var innerExceptionMessage = context.Exception.InnerException?.Message;
            if (context.Exception is NullReferenceException)
            {
                context.Result = new ContentResult
                {
                    Content = $"{actionName}\n{exceptionMessage}\n{innerExceptionMessage}\n{exceptionStack}\n",
                    ContentType = "Bad Request",
                    StatusCode = (int?)HttpStatusCode.BadRequest
                };
                context.ExceptionHandled = true;
            }
            if (context.Exception is DataException)
            {
                context.Result = new ContentResult
                {
                    Content = $"{actionName}\n{exceptionMessage}\n{innerExceptionMessage}\n{exceptionStack}\n",
                    ContentType = "throwed DataBase Exception",
                    StatusCode = (int?)HttpStatusCode.Conflict
                };
                context.ExceptionHandled = true;
            }
           
            if (context.Exception is DbUpdateException)
            {
                context.Result = new ContentResult
                {
                    Content = $"{actionName}\n{exceptionMessage}\n{innerExceptionMessage}\n{exceptionStack}\n",
                    ContentType = "Bad Request"
                };
                context.ExceptionHandled = true;
            }
            if (context.Exception is NotImplementedException)
            {
                context.Result = new ContentResult
                {
                    Content = $"{actionName}\n{exceptionMessage}\n{innerExceptionMessage}\n{exceptionStack}\n",
                    ContentType = "throwed Not Implemented Exception",
                    StatusCode = (int?)HttpStatusCode.Conflict
                };
                context.ExceptionHandled = true;
            }
            if (context.Exception is FileNotFoundException)
            {
                context.Result = new ContentResult
                {
                    Content = $"{actionName}\n{exceptionMessage}\n{innerExceptionMessage}\n{exceptionStack}\n",
                    ContentType = "Incorrect file",
                    StatusCode = (int?)HttpStatusCode.NotImplemented
                };
                context.ExceptionHandled = true;
            }
            if (context.Exception is IndexOutOfRangeException)
            {
                context.Result = new ContentResult
                {
                    Content = $"{actionName}\n{exceptionMessage}\n{innerExceptionMessage}\n{exceptionStack}\n",
                    ContentType = "Invalid Type of File",
                    StatusCode = (int?)HttpStatusCode.NotImplemented
                };
                context.ExceptionHandled = true;
            }
            if (context.Exception is IOException)
            {
                context.Result = new ContentResult
                {
                    Content = $"{actionName}\n{exceptionMessage}\n{innerExceptionMessage}\n{exceptionStack}\n",
                    ContentType = "throwed IO Exception",
                    StatusCode = (int?)HttpStatusCode.Conflict
                };
                context.ExceptionHandled = true;
            }
            else
            {
                context.Result = new ContentResult
                {
                    Content = $"{actionName}\n{exceptionMessage}\n{innerExceptionMessage}\n{exceptionStack}\n",
                    ContentType = "Internal Server Error. Please Contact your Administrator.",
                    StatusCode = (int?)HttpStatusCode.InternalServerError
                };
                context.ExceptionHandled = true;
            }

        }

    }
}
