using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PuppyBBS.Services;
using PuppyBBS.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.HttpOverrides;
using PuppyBBS.Web.ActionFilters;

namespace PuppyBBS.Web.Controllers
{
    public class UserController : Controller
    {
        private UserServices AppUserServices = null;
        public UserController(UserServices services)
        {
            AppUserServices = services;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Reg()
        {
            return View();
        }


        [HttpPost]
        [VaptchaTokenFilter]
        public IActionResult Reg(RegModel model)
        {
            var user = PuppyBBS.Services.EMapper.Mapper<RegModel, Services.Models.Users>(model);
            AppUserServices.Reg(user);
            return Json(new JsonModel { action = "/login", status = 0, msg = "注册成功" });
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [VaptchaTokenFilter]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = PuppyBBS.Services.EMapper.Mapper<LoginModel, Services.Models.Users>(model);
            bool login = AppUserServices.Login(user);
            if (login)
            {

                var claimIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                claimIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.UID.ToString()));
                claimIdentity.AddClaim(new Claim(ClaimTypes.Name, user.NickName));
                claimIdentity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
                if (user.Avatar != null)
                    claimIdentity.AddClaim(new Claim("Avatar", user.Avatar));
                var claimsPrincipal = new ClaimsPrincipal(claimIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                return Json(new JsonModel { action = "/", status = 0, msg = "登录成功" });
            }
            else
            {
                return Json(new JsonModel { action = "/login", status = -1, msg = "密码错误" });

            }
        }
        public async Task<IActionResult> LoginOut()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
        public IActionResult Forget()
        {
            return View();
        }

        public IActionResult Set()
        {
            return View();
        }

        public IActionResult Message()
        {
            return View();
        }

        public IActionResult Home()
        {
            return View();
        }
    }
}