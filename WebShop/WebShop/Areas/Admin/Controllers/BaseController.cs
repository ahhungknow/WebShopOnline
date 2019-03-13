using Data_Access.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebShop.Common;

namespace WebShop.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        // GET: Admin/Base
        //protected override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    var session = Session[CommonConst.User_Session];
        //    if (session == null)
        //    {
        //        //filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login" , action = "Index", Area="Admin"}));
        //    }
        //    base.OnActionExecuting(filterContext);
        //}
    }
}