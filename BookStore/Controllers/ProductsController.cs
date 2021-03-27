using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models.Entity;


namespace BookStore.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        DbBookStoreEntities db = new DbBookStoreEntities();


        public ActionResult Index()
        {
            var values = db.TBLPRODUCT.ToList();

            return View(values);
        }

        [HttpGet]

        public ActionResult NewProduct()
        {
            
            List<SelectListItem> values = (from i in db.TBLCATEGORY.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.CATEGORYNAME,
                                               Value = i.CATEGORYID.ToString()
                                           }).ToList();
            ViewBag.vls = values;
            return View();
        }

        [HttpPost]

        public ActionResult NewProduct(TBLPRODUCT p1)
        {
            
            var ctgr = db.TBLCATEGORY.Where(m => m.CATEGORYID == p1.TBLCATEGORY.CATEGORYID).FirstOrDefault();
            p1.TBLCATEGORY = ctgr;
            db.TBLPRODUCT.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var prid = db.TBLPRODUCT.Find(id);
            db.TBLPRODUCT.Remove(prid);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BringProduct(int id)
        {
            var prid = db.TBLPRODUCT.Find(id);

            List<SelectListItem> values = (from i in db.TBLCATEGORY.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.CATEGORYNAME,
                                               Value = i.CATEGORYID.ToString()
                                           }).ToList();
            ViewBag.vls = values;

            return View("BringProduct", prid);
        }
        public ActionResult Update(TBLPRODUCT p1)
        {
            var prdct = db.TBLPRODUCT.Find(p1.PRODUCTID);
            prdct.PRODUCTNAME = p1.PRODUCTNAME;
            //prdct.PRODUCTCATEGORY = p1.PRODUCTCATEGORY;
            prdct.PRICE = p1.PRICE;
            prdct.STOCK = p1.STOCK;
            prdct.BRAND = p1.BRAND;
            var ctgr = db.TBLCATEGORY.Where(m => m.CATEGORYID == p1.TBLCATEGORY.CATEGORYID).FirstOrDefault();
            prdct.PRODUCTCATEGORY = ctgr.CATEGORYID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}