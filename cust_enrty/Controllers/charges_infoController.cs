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
    public class charges_infoController : Controller
    {
        private cust_indicationEntities1 db = new cust_indicationEntities1();

        // GET: charges_info
        public ActionResult Index()
        {
            if (Session["name"] == null)
            {

                return RedirectToAction("log", "admins");
            }
            return View(db.charges_info.ToList());
        }

        // GET: charges_info/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            charges_info charges_info = db.charges_info.Find(id);
            if (charges_info == null)
            {
                return HttpNotFound();
            }
            return View(charges_info);
        }

        // GET: charges_info/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: charges_info/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "fee_id,charges,discount,total_charges")] charges_info charges_info)
        {
            if (ModelState.IsValid)
            {
                db.charges_info.Add(charges_info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(charges_info);
        }

        // GET: charges_info/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            charges_info charges_info = db.charges_info.Find(id);
            if (charges_info == null)
            {
                return HttpNotFound();
            }
            return View(charges_info);
        }

        // POST: charges_info/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "fee_id,charges,discount,total_charges")] charges_info charges_info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(charges_info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(charges_info);
        }

        // GET: charges_info/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            charges_info charges_info = db.charges_info.Find(id);
            if (charges_info == null)
            {
                return HttpNotFound();
            }
            return View(charges_info);
        }

        // POST: charges_info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            charges_info charges_info = db.charges_info.Find(id);
            db.charges_info.Remove(charges_info);
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
