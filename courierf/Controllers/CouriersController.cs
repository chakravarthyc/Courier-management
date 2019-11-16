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
        int bid;
        // GET: Couriers
        public ActionResult Index()
        {
            var couriers = db.Couriers;
            return View(couriers.ToList());
        }

        // GET: Couriers/Details/5
        public ActionResult Details(int? id)
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
            ViewBag.Courier_id = new SelectList(db.Bookings, "Booking_id", "From_add");
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
                courier.Courier_id = (int)TempData["booking"];
                db.Couriers.Add(courier);
                db.SaveChanges();
                return RedirectToAction("Index","Bookings");
            }
            else
            {
                return Content("Invalid model");
            }
        }

        // GET: Couriers/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.Courier_id = new SelectList(db.Bookings, "Booking_id", "From_add", courier.Courier_id);
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
            ViewBag.Courier_id = new SelectList(db.Bookings, "Booking_id", "From_add", courier.Courier_id);
            return View(courier);
        }

        // GET: Couriers/Delete/5
        public ActionResult Delete(int? id)
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
        public ActionResult DeleteConfirmed(int id)
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
