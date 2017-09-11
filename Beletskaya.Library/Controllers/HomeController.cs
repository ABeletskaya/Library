using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Beletskaya.Library.Models;
using System.Data.Entity;
using System.Net;
using System.Data;

namespace WebApplicationWithDB.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Book> db;

        public HomeController()
        {
            db = new BookRepository();
        }

        public ActionResult Index()
        {
            return View(db.GetBookList());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Create(book);
                db.Save();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public ActionResult Edit(int id)
        {
            Book book = db.GetBook(id);
            return View(book);
        }
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Update(book);
                db.Save();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.GetBook(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}