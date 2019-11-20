using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using courierf.Models;
using Microsoft.AspNet.Identity;

namespace courierf.Controllers
{
    public class BookingsController : Controller
    {
        private CourierModel db = new CourierModel();

        // GET: Bookings
        public ActionResult Index()
        {
            IQueryable<Booking> bookings;
            String id = System.Web.HttpContext.Current.User.Identity.GetUserName();
            if (User.IsInRole("Customer"))
                bookings = db.Bookings.Include(b => b.Branch).Include(b => b.Customer).Where(b => b.Customer_id == id);
            else
                bookings = db.Bookings.Include(b => b.Branch).Include(b => b.Customer);
            return View(bookings.ToList());
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            Courier courier = db.Couriers.Find(id);
            BookingDetails bd = new BookingDetails();
            bd.booking = booking;
            bd.courier = courier;
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(bd);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            ViewBag.Branch_code = new SelectList(db.Branches, "Branch_code", "Branch_address");
            ViewBag.Booking_id = new SelectList(db.Couriers, "Courier_id", "Courier_type");
            ViewBag.Customer_id = new SelectList(db.Customers, "Customer_id", "Customer_name");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Booking_id,From_add,Amount,Destination,Branch_code,Customer_id,Distance")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                db.SaveChanges();
                TempData["courier_id"] = booking.Booking_id;
                return RedirectToAction("Create","Couriers");
            }

            ViewBag.Branch_code = new SelectList(db.Branches, "Branch_code", "Branch_address", booking.Branch_code);
            ViewBag.Booking_id = new SelectList(db.Couriers, "Courier_id", "Courier_type", booking.Booking_id);
            ViewBag.Customer_id = new SelectList(db.Customers, "Customer_id", "Customer_name", booking.Customer_id);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.Branch_code = new SelectList(db.Branches, "Branch_code", "Branch_address", booking.Branch_code);
            ViewBag.Booking_id = new SelectList(db.Couriers, "Courier_id", "Courier_type", booking.Booking_id);
            ViewBag.Customer_id = new SelectList(db.Customers, "Customer_id", "Customer_name", booking.Customer_id);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Booking_id,From_add,Amount,Destination,Branch_code,Customer_id")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Branch_code = new SelectList(db.Branches, "Branch_code", "Branch_address", booking.Branch_code);
            ViewBag.Booking_id = new SelectList(db.Couriers, "Courier_id", "Courier_type", booking.Booking_id);
            ViewBag.Customer_id = new SelectList(db.Customers, "Customer_id", "Customer_name", booking.Customer_id);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BookCourier()
        {
            ViewBag.Branch_code = new SelectList(db.Branches, "Branch_code", "Branch_address");
            ViewBag.Customer_id = new SelectList(db.Customers, "Customer_id", "Customer_name");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BookCourier([Bind(Include = "Booking_id,From_add,Amount,Destination,Branch_code,Customer_id,Distance")] Booking booking)
        {
            booking.Customer_id = System.Web.HttpContext.Current.User.Identity.GetUserName();
            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                db.SaveChanges();
                TempData["booking"] = booking.Booking_id;
                return RedirectToAction("Create", "Couriers");
            }

            ViewBag.Branch_code = new SelectList(db.Branches, "Branch_code", "Branch_address", booking.Branch_code);
            ViewBag.Customer_id = new SelectList(db.Customers, "Customer_id", "Customer_name", booking.Customer_id);
            return View(booking);
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
