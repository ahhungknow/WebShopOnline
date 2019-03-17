using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebShop.Areas.Admin.Controllers
{
    public class FeedBackController : Controller
    {
        // GET: Admin/FeedBack
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/FeedBack/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/FeedBack/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/FeedBack/Create
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

        // GET: Admin/FeedBack/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/FeedBack/Edit/5
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

        // GET: Admin/FeedBack/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/FeedBack/Delete/5
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
