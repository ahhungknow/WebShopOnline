using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop_Turtorial_ASP.NET_MVC.Areas.Admin.Code
{
    public class SessionHelper
    {
        public static void SetSession(UserSession session)
        {
            HttpContext.Current.Session["loginState"] = session;
        }
        public static UserSession GetSession()
        {
            var session = HttpContext.Current.Session["loginState"];
            if (session == null)
                return null;
            else
                return session as UserSession;
        }
    }
}