using Data_Access.DA;
using Data_Access.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebShop.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if(ModelState.IsValid)
            {
                if(ProductDA.Instance.InsertProduct(product))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Lỗi!", "Thêm mới thất bại!!");
                }
            }
            SetViewBag();
            return View();
        }
        public void SetViewBag()
        {
            var categoryList = CategoryDA.Instance.GetCategoryList();
            ViewBag.CategoryId = new SelectList(categoryList, "Id","Name","Id");
        }
    }
}