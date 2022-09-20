using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cust_enrty.Models;

namespace cust_enrty.Controllers
{
    public class customer_infoController : Controller
    {
        private cust_indicationEntities1 db = new cust_indicationEntities1();

        // GET: customer_info
        public ActionResult Index()
        {
            if (Session["name"] == null)
            {

                return RedirectToAction("log", "admins");
            }
            return View(db.customer_info.ToList());
        }

        // GET: customer_info/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customer_info customer_info = db.customer_info.Find(id);
            if (customer_info == null)
            {
                return HttpNotFound();
            }
            return View(customer_info);
        }

        // GET: customer_info/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: customer_info/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cust_id,name,father_name,email,cnic,address")] customer_info customer_info)
        {
            if (ModelState.IsValid)
            {
                db.customer_info.Add(customer_info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer_info);
        }

        // GET: customer_info/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customer_info customer_info = db.customer_info.Find(id);
            if (customer_info == null)
            {
                return HttpNotFound();
            }
            return View(customer_info);
        }

        // POST: customer_info/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cust_id,name,father_name,email,cnic,address")] customer_info customer_info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer_info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer_info);
        }

        // GET: customer_info/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            customer_info customer_info = db.customer_info.Find(id);
            if (customer_info == null)
            {
                return HttpNotFound();
            }
            return View(customer_info);
        }

        // POST: customer_info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            customer_info customer_info = db.customer_info.Find(id);
            db.customer_info.Remove(customer_info);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
