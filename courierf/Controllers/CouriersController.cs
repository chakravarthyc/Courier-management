using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using courierf.Models;

namespace courierf.Controllers
{
    public class CouriersController : Controller
    {
        private CourierModel db = new CourierModel();

        // GET: Couriers
        public ActionResult Index()
        {
            return View(db.Couriers.ToList());
        }

        // GET: Couriers/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Courier courier = db.Couriers.Find(id);
            if (courier == null)
            {
                return HttpNotFound();
            }
            return View(courier);
        }

        // GET: Couriers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Couriers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Courier_id,Weight,Courier_type")] Courier courier)
        {
            if (ModelState.IsValid)
            {
                db.Couriers.Add(courier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(courier);
        }

        // GET: Couriers/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Courier courier = db.Couriers.Find(id);
            if (courier == null)
            {
                return HttpNotFound();
            }
            return View(courier);
        }

        // POST: Couriers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Courier_id,Weight,Courier_type")] Courier courier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courier);
        }

        // GET: Couriers/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Courier courier = db.Couriers.Find(id);
            if (courier == null)
            {
                return HttpNotFound();
            }
            return View(courier);
        }

        // POST: Couriers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Courier courier = db.Couriers.Find(id);
            db.Couriers.Remove(courier);
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
