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
    public class adminsController : Controller
    {
        private cust_indicationEntities1 db = new cust_indicationEntities1();
        public ActionResult log()
        {
            return View();
        }
      [HttpPost]
        public ActionResult log(string name , string pass)
            
        {
            
            Session["name"] = name;
            Session["pass"] = pass;
            if (name.Equals("") == true)
            {
                ModelState.AddModelError("name", "Enter the Name");
                if (pass.Equals("") == true)
                {
                    ModelState.AddModelError("pass", "Enter the password");
                }

            }
            else
            {
                bool isvalid = db.admins.Any(model => model.name == name);

                if (isvalid)
                {
                    if (pass.Equals("") == true)
                    {
                        ModelState.AddModelError("pass", "Enter the password");
                    }
                    else
                    {

                        bool isValid = db.admins.Any(model => model.password == pass);
                        if (isValid)
                        {

                            return RedirectToAction("Index");
                        }
                        else
                        {
                            ModelState.AddModelError("pass", "Incorrect Password!!");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("name", "Incorrect User-Name");
                }

            }

            return View();
        }
        /*<authentication mode = "Forms" >                  (in web config after system.web)

        < forms > loginUrl = "management/log" </ forms >

    </ authentication >*/
        public ActionResult logout()
        {
            if (Session["name"] != null)
            {
                Session.Abandon();
                return RedirectToAction("log","admins");
            }
            else
            {
                return RedirectToAction("log", "admins");
            }
            return View();
        }

        // GET: admins
        public ActionResult Index()
        {
            if (Session["name"] == null)
            {

                return RedirectToAction("log", "admins");
            }
            return View(db.admins.ToList());
        }

        // GET: admins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admin admin = db.admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // GET: admins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "amin_id,name,password,confirm_password")] admin admin)
        {
            if (ModelState.IsValid)
            {
                db.admins.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admin);
        }

        // GET: admins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admin admin = db.admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // POST: admins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "amin_id,name,password,confirm_password")] admin admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admin);
        }

        // GET: admins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            admin admin = db.admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        // POST: admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            admin admin = db.admins.Find(id);
            db.admins.Remove(admin);
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
