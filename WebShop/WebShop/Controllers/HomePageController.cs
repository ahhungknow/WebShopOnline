using Data_Access.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebShop.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult MenuRight()
        {
            var model = CategoryDA.Instance.GetCategoryList();
            return PartialView(model);
        }
    }
}