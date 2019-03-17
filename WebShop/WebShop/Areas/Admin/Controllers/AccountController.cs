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
    public class AccountController : BaseController
    {
        // GET: Admin/Account
        [HttpGet]
        public ViewResult Index(int? page, string searchString = null)
        {
            if (page == null || page < 0)
            {
                var model = AccountDA.Instance.GetAccountList(searchString).ToPagedList(1, CommonConst.Page_Size);
                return View(model);
            }
            else
            {
                var model = AccountDA.Instance.GetAccountList(searchString).ToPagedList((int)page, CommonConst.Page_Size);
                return View(model);
            }
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpGet]
        public ViewResult Edit(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return ToIndex();
            }
            else
            {
                var model = AccountDA.Instance.GetById(id);
                if (model != null)
                {
                    model.Password = Encryptor.Decrypt(model.Password);
                    return View(model);
                }
            }
            return ToIndex();
        }
        [HttpPost]
        public ViewResult Create(Account account)
        {
            account.Password = Encryptor.EnCrypt(account.Password);
            if(ModelState.IsValid)
            {
                if(AccountDA.Instance.InsertAccount(account))
                {
                    SetAlert("Thêm mới tài khoản thành công", 0);
                    return ToIndex(account.Id);
                }
            }
            else
            {
                SetAlert("Thêm mới tài khoản thất bại", 2);
            }
            return View();
        }
        [HttpPost]
        public ViewResult Edit(Account account)
        {
            account.Password = Encryptor.EnCrypt(account.Password);
            if (ModelState.IsValid)
            {
                if(AccountDA.Instance.EditAccount(account))
                {
                    SetAlert("Sửa thông tin tài khoản thành công", 0);
                    return ToIndex(account.Id);
                }
            }
            else
            {
                SetAlert("Sửa thông tin tài khoản thất bại", 2);
            }
            return View();
        }
        [HttpDelete]
        public void Delete(string id)
        {
            if (id != null)
            {
                if (AccountDA.Instance.DeleteAccount(id))
                {
                    SetAlert("Đã xóa tài khoản ", 1);
                }
            }
            else
            {
                SetAlert("Xóa không thành công", 2);
            }
        }
        public ViewResult ToIndex(string id=null)
        {
            int i = 1, page = 1;
            if (id != null)
            {
                var accountList = AccountDA.Instance.GetAccountList();
                foreach(var item in accountList)
                {
                    i++;
                    if (String.Equals(item.Id, id))
                        break;
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
            var model = AccountDA.Instance.GetAccountList().ToPagedList(page, CommonConst.Page_Size);
            return View("Index",model);
        }
        [HttpPost]
        public JsonResult ChangeStatus(string id)
        {
            bool result=AccountDA.Instance.ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }
    }
}