using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PuppyBBS.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuppyBBS.Web.ActionFilters
{
    public class VaptchaTokenFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //验证对象
            foreach (var item in context.ActionArguments.Values)
            {
                if (item is IVaptchaToken)
                {
                    IVaptchaToken token = item as IVaptchaToken;
                    var result = Core.Captcha.Validate(context.HttpContext.Request.HttpContext.Connection.RemoteIpAddress.ToString(), token);

                    if (!result.GetAwaiter().GetResult())
                    {
                        context.Result = new Microsoft.AspNetCore.Mvc.JsonResult(new Models.JsonModel() { status = 0, msg = "人机验证失败!" });
                    }
                }

            }

        }
    }
}
