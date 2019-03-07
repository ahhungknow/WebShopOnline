using Data_Access.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Index(Account account)
        //{
        //    //AccountDP result = new AccountDP();
        //    if (Membership.ValidateUser(account.Id, account.Password) && ModelState.IsValid)
        //    {
        //        //SessionHelper.SetSession(new UserSession() { Id = model.Id });
        //        FormsAuthentication.SetAuthCookie(account.Id, true);
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Tên đăng nhập hoặc mặt khẩu không chính xác!!!!");
        //    }
        //    return View(account);
        //}
        //public ActionResult Logout()
        //{
        //    FormsAuthentication.SignOut();
        //    return RedirectToAction("Index", "Login");
        //}
    }
}