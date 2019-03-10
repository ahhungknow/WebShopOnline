using Data_Access.DA;
using Data_Access.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using WebShop.Common;

namespace WebShop.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        [HttpGet]
        public ActionResult Index(int? page,string searchString)
        {
            ViewBag.SearchString = searchString;
            if (page == null || page <= 0)
            {
                var model = CategoryDA.Instance.GetCategoryList(searchString).ToPagedList(1, CommonConst.Page_Size);
                return View(model);
            }
            else
            {
                var model = CategoryDA.Instance.GetCategoryList(searchString).ToPagedList((int)page, CommonConst.Page_Size);
                return View(model);
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var model = CategoryDA.Instance.GetById(Id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductCategory productCategory)
        {
            if(ModelState.IsValid)
            {
                if(CategoryDA.Instance.UpdateCategory(productCategory))
                {
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thất bại!!");
                }
            }
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(int Id)
        {
            if(ModelState.IsValid)
            {
                if(CategoryDA.Instance.DeleteCategory(Id))
                {
                    return View();
                }
                else
                {
                    ModelState.AddModelError("", "Xóa không thành công!!");
                }
            }
            return View();
        }
    }
}