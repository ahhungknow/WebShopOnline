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
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        [HttpGet]
        public ActionResult Index(int? page,string searchString)
        {
            ViewBag.SearchString = searchString;
            if(page==null || page<0)
            {
                var model=ProductDA.Instance.GetProductList(searchString).ToPagedList(1, CommonConst.Page_Size);
                return View(model);
            }
            else
            {
                var model = ProductDA.Instance.GetProductList(searchString).ToPagedList((int)page, CommonConst.Page_Size);
                return View(model);
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            SetViewBag();
            var model = ProductDA.Instance.GetById(id);
            return View(model);
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
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if(ModelState.IsValid)
            {
                if(ProductDA.Instance.EditProduct(product))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Lỗi!", "Sửa thông tin thất bại!!");
                }
            }
            SetViewBag();
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if(ModelState.IsValid)
            {
                if(ProductDA.Instance.DeleteProduct(id))
                {
                    return View();
                }
                else
                {
                    ModelState.AddModelError("Lỗi!", "Xóa không thành công!!");
                }
            }
            return View();
        }
        public void SetViewBag()
        {
            var categoryList = CategoryDA.Instance.GetCategoryList();
            ViewBag.CategoryId = new SelectList(categoryList, "Id","Name","Id");
        }
    }
}