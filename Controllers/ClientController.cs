using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models.Entity;

namespace BookStore.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        DbBookStoreEntities db = new DbBookStoreEntities();
        public ActionResult Index()
        {
            var values = db.TBLCLIENT.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewClient()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewClient(TBLCLIENT p1)
        {
            if (!ModelState.IsValid)
            {
                return View("NewClient");
            }
            db.TBLCLIENT.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult Delete(int id)
        {
            var client = db.TBLCLIENT.Find(id);
            db.TBLCLIENT.Remove(client);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BringClient(int id)
        {
            var clnt = db.TBLCLIENT.Find(id);
            return View("BringClient", clnt);
        }
        public ActionResult Update(TBLCLIENT p1)
        {
            var clnt = db.TBLCLIENT.Find(p1.CLIENTNID);
            clnt.CLIENTNAME = p1.CLIENTNAME;
            clnt.CLIENTSURNAME = p1.CLIENTSURNAME;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}