using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProjectManagementSystem.Helpers;

namespace ProjectManagementSystem.Middlewares
{
    public class ExceptionMiddleware : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = new ObjectResult(
                     new ResponseHelper<string>(
                         "Something went wrong",
                         context.Exception.Message,
                         false
                     ))
                    {
                        StatusCode = 500
                    };

            context.ExceptionHandled = true;

        }
    }
}
