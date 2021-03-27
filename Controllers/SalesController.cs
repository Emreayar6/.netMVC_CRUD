using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models.Entity;

namespace BookStore.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        DbBookStoreEntities db = new DbBookStoreEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult NewSale()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewSale(TBLSALES p)
        {
            db.TBLSALES.Add(p);
            db.SaveChanges();
            return View("Index");

        }
    }
}