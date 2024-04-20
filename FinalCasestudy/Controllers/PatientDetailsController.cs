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
    public class PatientDetailsController : Controller
    {
        private clinicEntities db = new clinicEntities();

        // GET: PatientDetails
        public ActionResult Index()
        {
            // return View(db.PatientDetails.ToList());
            return Redirect("/PatientDetails/Create");
        }

        // GET: PatientDetails/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    PatientDetail patientDetail = db.PatientDetails.Find(id);
        //    if (patientDetail == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(patientDetail);
        //}

        // GET: PatientDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PatientDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientId,PatientName,ContactNumber,Email")] PatientDetail patientDetail)
        {
            if (ModelState.IsValid)
            {
                db.PatientDetails.Add(patientDetail);
                db.SaveChanges();
                return Redirect("/Home/Login");
            }

            return View(patientDetail);
        }

        // GET: PatientDetails/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    PatientDetail patientDetail = db.PatientDetails.Find(id);
        //    if (patientDetail == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(patientDetail);
        //}

        // POST: PatientDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "PatientId,PatientName,ContactNumber,Email")] PatientDetail patientDetail)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(patientDetail).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(patientDetail);
//        }

//        // GET: PatientDetails/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            PatientDetail patientDetail = db.PatientDetails.Find(id);
//            if (patientDetail == null)
//            {
//                return HttpNotFound();
//            }
//            return View(patientDetail);
//        }

//        // POST: PatientDetails/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            PatientDetail patientDetail = db.PatientDetails.Find(id);
//            db.PatientDetails.Remove(patientDetail);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
   }
}
