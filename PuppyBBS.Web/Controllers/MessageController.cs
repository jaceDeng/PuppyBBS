using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuppyBBS.Web.Controllers
{
    public class MessageController : Controller
    {
        public ActionResult Nums()
        {
            return Json(new { status = 0, count = 0 });
        }
    }
}
