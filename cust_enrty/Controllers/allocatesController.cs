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
    public class allocatesController : Controller
    {
        private cust_indicationEntities1 db = new cust_indicationEntities1();

        // GET: allocates
        public ActionResult Index()
        {
            if (Session["name"] == null)
            {

                return RedirectToAction("log", "admins");
            }
           
           /* var allocates = db.allocates.Include(a => a.admin).Include(a => a.allocate1).Include(a => a.allocate2).Include(a => a.charges_info).Include(a => a.customer_info);*/
            var n = db.allocates.ToList();
            return View(n);
        }
        [HttpPost]
        public ActionResult Index(string nam)
        {
            var sea = db.allocates.Where(model => model.customer_info.name.StartsWith(nam)).ToList();
            return View(sea);
        }
        
        // GET: allocates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            allocate allocate = db.allocates.Find(id);
            if (allocate == null)
            {
                return HttpNotFound();
            }
            return View(allocate);
        }

        // GET: allocates/Create
        public ActionResult Create()
        {
            ViewBag.amin_id = new SelectList(db.admins, "amin_id", "name");
            ViewBag.allocate_id = new SelectList(db.allocates, "allocate_id", "Date");
            ViewBag.allocate_id = new SelectList(db.allocates, "allocate_id", "Date");
            ViewBag.fee_id = new SelectList(db.charges_info, "fee_id", "total_charges");
            ViewBag.cust_id = new SelectList(db.customer_info, "cust_id", "name");
            ViewBag.paid_id = new SelectList(db.paids, "paid_id", "status");
            return View();
        }

        // POST: allocates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "allocate_id,amin_id,cust_id,fee_id,Date,paid_id")] allocate allocate)
        {
            if (ModelState.IsValid)
            {
                db.allocates.Add(allocate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.amin_id = new SelectList(db.admins, "amin_id", "name", allocate.amin_id);
            ViewBag.allocate_id = new SelectList(db.allocates, "allocate_id", "Date", allocate.allocate_id);
            ViewBag.allocate_id = new SelectList(db.allocates, "allocate_id", "Date", allocate.allocate_id);
            ViewBag.fee_id = new SelectList(db.charges_info, "fee_id", "total_charges");
            ViewBag.cust_id = new SelectList(db.customer_info, "cust_id", "name", allocate.cust_id);
            ViewBag.paid_id = new SelectList(db.paids, "paid_id", "status",allocate.paid_id);
            return View(allocate);
        }

        // GET: allocates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            allocate allocate = db.allocates.Find(id);
            if (allocate == null)
            {
                return HttpNotFound();
            }
            ViewBag.amin_id = new SelectList(db.admins, "amin_id", "name", allocate.amin_id);
            ViewBag.allocate_id = new SelectList(db.allocates, "allocate_id", "Date", allocate.allocate_id);
            ViewBag.allocate_id = new SelectList(db.allocates, "allocate_id", "Date", allocate.allocate_id);
            ViewBag.fee_id = new SelectList(db.charges_info, "fee_id", "total_charges");
            ViewBag.cust_id = new SelectList(db.customer_info, "cust_id", "name", allocate.cust_id);
            ViewBag.paid_id = new SelectList(db.paids, "paid_id", "status");
            return View(allocate);
        }

        // POST: allocates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "allocate_id,amin_id,cust_id,fee_id,total_charges,Date,paid_id")] allocate allocate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(allocate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.amin_id = new SelectList(db.admins, "amin_id", "name", allocate.amin_id);
            ViewBag.allocate_id = new SelectList(db.allocates, "allocate_id", "Date", allocate.allocate_id);
            ViewBag.allocate_id = new SelectList(db.allocates, "allocate_id", "Date", allocate.allocate_id);
            ViewBag.fee_id = new SelectList(db.charges_info, "fee_id", "total_charges", allocate.fee_id);
            ViewBag.cust_id = new SelectList(db.customer_info, "cust_id", "name", allocate.cust_id);
            ViewBag.paid_id = new SelectList(db.paids, "paid_id", "status", allocate.paid_id);
            return View(allocate);
        }

        // GET: allocates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            allocate allocate = db.allocates.Find(id);
            if (allocate == null)
            {
                return HttpNotFound();
            }
            return View(allocate);
        }

        // POST: allocates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            allocate allocate = db.allocates.Find(id);
            db.allocates.Remove(allocate);
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
