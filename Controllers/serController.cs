using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_TASK3.Models;

namespace MVC_TASK3.Controllers
{
    public class serController : Controller
    {
        private customersEntities db = new customersEntities();

        // GET: ser
        public ActionResult Index()
        {
            return View(db.customer_info.ToList());
        }

        // GET: ser/Details/5
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

        // GET: ser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ser/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "customer_id,first_name,last_name,email,phone,age,job_title,gender")] customer_info customer_info)
        {
            if (ModelState.IsValid)
            {
                db.customer_info.Add(customer_info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer_info);
        }

        // GET: ser/Edit/5
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

        // POST: ser/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "customer_id,first_name,last_name,email,phone,age,job_title,gender")] customer_info customer_info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer_info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer_info);
        }

        // GET: ser/Delete/5
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

        // POST: ser/Delete/5
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
        //public ActionResult ser1(string searching)
        //{
        //    var em = db.customer_info.Where(e => e.last_name.Contains(searching)).ToList();
        //    return View("Index", em);
        //}
        public ActionResult ser1(string searching,string ss)
        {
            if (searching == "fName")
            {
                var fname = db.customer_info.Where(s => s.first_name.Contains(ss) ).ToList();
                return View("Index", fname);
            }
            else if (searching == "lName")
            {
                var lname = db.customer_info.Where(s => s.last_name.Contains(ss)).ToList();
                return View("Index", lname);
            }
            else
            {
                var email = db.customer_info.Where(s => s.email.Contains(ss)).ToList();
                return View("Index", email);
            }
        }
    }
}
