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
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return ToIndex();
            }
            else
            {
                var model = ProductDA.Instance.GetById((int)id);
                if (model != null)
                {
                    SetViewBag();
                    return View(model);
                }
                return ToIndex();
            }
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if(ModelState.IsValid)
            {
                if(ProductDA.Instance.InsertProduct(product))
                {
                    return ToIndex(product.Id);
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
                    return ToIndex(product.Id);
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
        public ActionResult Delete(int? id)
        {
            if(ModelState.IsValid || id!=null)
            {
                if(ProductDA.Instance.DeleteProduct((int)id))
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
        public ViewResult ToIndex(int? id=null)
        {
            int i = 1,page=1;
            if (id != null)
            {
                var productList = ProductDA.Instance.GetProductList();
                foreach(var item in productList)
                {
                    if(String.Equals(item.Id,id))
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
            var model = ProductDA.Instance.GetProductList().ToPagedList(page, CommonConst.Page_Size);
            return View("Index", model);
        }
    }
}