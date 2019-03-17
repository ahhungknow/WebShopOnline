using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebShop.Areas.Admin.Controllers
{
    public class BillInfoController : Controller
    {
        // GET: Admin/BillInfo
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/BillInfo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/BillInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/BillInfo/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/BillInfo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/BillInfo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/BillInfo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/BillInfo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
