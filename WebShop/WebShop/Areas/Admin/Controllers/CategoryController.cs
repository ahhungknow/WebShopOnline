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
    public class CategoryController : BaseController
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
                    SetAlert("Thêm mới loại sản phẩm thành công", 0);
                    return ToIndex(productCategory.Id);
                }
            }
            else
            {
                SetAlert("Thêm loại sản phẩm mới thất bại", 2);
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
                    SetAlert("Sửa thông tin loại sản phẩm thành công", 0);
                    return ToIndex(productCategory.Id);
                }
            }
            else
            {
                SetAlert("Sửa thông tin loại sản phẩm thất bại", 2);
            }
            return View();
        }
        [HttpDelete]
        public void Delete(int id)
        {
            if (CategoryDA.Instance.DeleteCategory(id))
            {
                SetAlert("Đã xóa loại sản phẩm " + CategoryDA.Instance.GetById(id).Name, 1);
            }
            else
            {
                ModelState.AddModelError("", "Xóa không thành công!!");
            }
        }
        public ViewResult ToIndex(int? id=null)
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