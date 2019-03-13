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
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return ToIndex();
            }
            else
            {
                var model = CategoryDA.Instance.GetById((int)id);
                if (model != null)
                {
                    return View(model);
                }
            }
            return ToIndex();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCategory productCategory)
        {
            if (ModelState.IsValid)
            {
                if (CategoryDA.Instance.InsertCategory(productCategory))
                {
                    return ToIndex(productCategory.Id);
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
                    return ToIndex(productCategory.Id);
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thất bại!!");
                }
            }
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if(ModelState.IsValid)
            {
                if(CategoryDA.Instance.DeleteCategory(id))
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
        public ActionResult ToIndex(int? id=null)
        {
            int i = 1, page = 1;
            if (id != null)
            {
                var categoryList = CategoryDA.Instance.GetCategoryList();
                foreach (var item in categoryList)
                {
                    if (String.Equals(item.Id, id))
                    {
                        break;
                    }
                    i++;
                }
                if (i > CommonConst.Page_Size)
                {
                    if (i % CommonConst.Page_Size == 0)
                        page = i / CommonConst.Page_Size;
                    else
                        page = (i / CommonConst.Page_Size) + 1;
                }
                else
                {
                    page = 1;
                }
            }
            var model = CategoryDA.Instance.GetCategoryList().ToPagedList(page, CommonConst.Page_Size);
            return View("Index", model);
        }
    }
}