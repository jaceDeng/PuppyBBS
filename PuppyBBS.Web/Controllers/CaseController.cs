using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuppyBBS.Web.Controllers
{
    public class CaseController : Controller
    {
        public IActionResult Case()
        {
            return View();
        }

    }
}
