using Data_Access.DA;
using Data_Access.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebShop.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View(CategoryDA.Instance.GetCategoryList());
        }
        public ActionResult Create(ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                if (CategoryDA.Instance.InsertCategory(productCategory))
                {
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm mới không thành công!!");
                }
            }
            return View();
        }
    }
}