using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalCasestudy.Models;

namespace FinalCasestudy.Controllers
{
    public class DoctorDetailsController : Controller
    {
        private clinicEntities db = new clinicEntities();

        // GET: DoctorDetails
        public ActionResult Index()
        {
            return View(db.DoctorDetails.ToList());
        }

        // GET: DoctorDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorDetail doctorDetail = db.DoctorDetails.Find(id);
            if (doctorDetail == null)
            {
                return HttpNotFound();
            }
            return View(doctorDetail);
        }

        // GET: DoctorDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DoctorDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DoctorId,DoctorName,Specialty,DoctorTiming")] DoctorDetail doctorDetail)
        {
            if (ModelState.IsValid)
            {
                db.DoctorDetails.Add(doctorDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doctorDetail);
        }

        // GET: DoctorDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorDetail doctorDetail = db.DoctorDetails.Find(id);
            if (doctorDetail == null)
            {
                return HttpNotFound();
            }
            return View(doctorDetail);
        }

        // POST: DoctorDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DoctorId,DoctorName,Specialty,DoctorTiming")] DoctorDetail doctorDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctorDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doctorDetail);
        }

        // GET: DoctorDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DoctorDetail doctorDetail = db.DoctorDetails.Find(id);
            if (doctorDetail == null)
            {
                return HttpNotFound();
            }
            return View(doctorDetail);
        }

        // POST: DoctorDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DoctorDetail doctorDetail = db.DoctorDetails.Find(id);
            db.DoctorDetails.Remove(doctorDetail);
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
