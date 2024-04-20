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
    public class TreatmentDetailsController : Controller
    {
        private clinicEntities db = new clinicEntities();

        // GET: TreatmentDetails
        public ActionResult Index()
        {
            return View(db.TreatmentDetails.ToList());
        }

        // GET: TreatmentDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TreatmentDetail treatmentDetail = db.TreatmentDetails.Find(id);
            if (treatmentDetail == null)
            {
                return HttpNotFound();
            }
            return View(treatmentDetail);
        }

        // GET: TreatmentDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TreatmentDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TreatmentId,TreatmentName,TreatmentDescription,TreatmentCharge")] TreatmentDetail treatmentDetail)
        {
            if (ModelState.IsValid)
            {
                db.TreatmentDetails.Add(treatmentDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(treatmentDetail);
        }

        // GET: TreatmentDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TreatmentDetail treatmentDetail = db.TreatmentDetails.Find(id);
            if (treatmentDetail == null)
            {
                return HttpNotFound();
            }
            return View(treatmentDetail);
        }

        // POST: TreatmentDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TreatmentId,TreatmentName,TreatmentDescription,TreatmentCharge")] TreatmentDetail treatmentDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(treatmentDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(treatmentDetail);
        }

        // GET: TreatmentDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TreatmentDetail treatmentDetail = db.TreatmentDetails.Find(id);
            if (treatmentDetail == null)
            {
                return HttpNotFound();
            }
            return View(treatmentDetail);
        }

        // POST: TreatmentDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TreatmentDetail treatmentDetail = db.TreatmentDetails.Find(id);
            db.TreatmentDetails.Remove(treatmentDetail);
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
