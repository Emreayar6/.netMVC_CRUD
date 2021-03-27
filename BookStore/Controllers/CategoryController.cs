using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models.Entity;
using PagedList;


namespace BookStore.Controllers
{
    public class CategoryController : Controller
    {

        // GET: Category

        DbBookStoreEntities db = new DbBookStoreEntities();
        public ActionResult Index(int page = 1)
        {
            //var values = db.TBLCATEGORY.ToList();
            var values = db.TBLCATEGORY.ToList().ToPagedList(page, 4);

            return View(values);
        }
        [HttpGet]
        public ActionResult NewCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewCategory(TBLCATEGORY p1)
        {
            if (!ModelState.IsValid)
            {
                return View("NewCategory");
            }
            db.TBLCATEGORY.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult Delete(int id)
        {
            var category = db.TBLCATEGORY.Find(id);
            db.TBLCATEGORY.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BringCategory(int ID)
        {
            var ctgry = db.TBLCATEGORY.Find(ID);
            return View("BringCategory", ctgry);
        }
        public ActionResult Update(TBLCATEGORY p1)
        {
            var ctgry = db.TBLCATEGORY.Find(p1.CATEGORYID);
            ctgry.CATEGORYNAME = p1.CATEGORYNAME;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}