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
        public ActionResult Index(int? page, string searchString = null)
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
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Edit(string id)
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
        public ActionResult Create(Account account)
        {
            account.Password = Encryptor.EnCrypt(account.Password);
            if(ModelState.IsValid)
            {
                if(AccountDA.Instance.InsertAccount(account))
                {
                    return ToIndex(account.Id);
                }
                else
                {
                    ModelState.AddModelError("Lỗi", "Thêm mới thất bại!!");
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Account account)
        {
            account.Password = Encryptor.EnCrypt(account.Password);
            if (ModelState.IsValid)
            {
                if(AccountDA.Instance.EditAccount(account))
                {
                    ToIndex(account.Id);
                }
                else
                {
                    ModelState.AddModelError("Lỗi!", "Sửa thông tin thất bại!!");
                }
            }
            return View();
        }
        [HttpDelete]
        public ActionResult Delete(int? id)
        {
            if (ModelState.IsValid)
            {
                if (id != null)
                {
                    AccountDA.Instance.DeleteAccount((int)id);
                }
                else
                {
                    ModelState.AddModelError("Lỗi!", "Xóa thất bại!!");
                }
            }
            return View();
        }
        public ActionResult ToIndex(string id=null)
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