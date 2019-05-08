using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using netmvcworkshop.Models; 

namespace netmvcworkshop.Controllers
{
    public class BookController : Controller
    {
        BookEntities db = new BookEntities();
        // GET: Book
        public ActionResult Index()
        {
            var Books = db.BOOK_CODE.OrderBy(m => m.BOOK_CLASS_ID).ToList();
            return View(Books);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create(BOOK_CODE Books)
        {
            db.BOOK_CODE.Add(Books);
            db.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Delete(string BOOK_CLASS_ID)
        {

            var Books = db.BOOK_CODE.Where(m => m.BOOK_CLASS_ID == BOOK_CLASS_ID).FirstOrDefault();
            db.BOOK_CODE.Remove(Books);
            db.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult Edit(String BOOK_CLASS_ID)
        {
            var Books = db.BOOK_CODE.Where(m => m.BOOK_CLASS_ID == BOOK_CLASS_ID).FirstOrDefault();
            return View(Books);
        }
        [HttpPost]

        public ActionResult Edit(BOOK_CODE Book)
        {
            String BOOK_CLASS_ID = Book.BOOK_CLASS_ID;
            var Books = db.BOOK_CODE.Where(m => m.BOOK_CLASS_ID == BOOK_CLASS_ID).FirstOrDefault();
            Books.BOOK_CLASS_NAME = Book.BOOK_CLASS_NAME;
            Books.CREATE_DATE = Book.CREATE_DATE;
            Books.CREATE_USER = Book.CREATE_USER;
            Books.MODIFY_DATE = Book.MODIFY_DATE;
            Books.MODIFY_USER = Books.MODIFY_USER;
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}