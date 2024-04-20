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
    public class RequestIdsController : Controller
    {
        private clinicEntities db = new clinicEntities();

        // GET: RequestIds
        public ActionResult Index()
        {
            var requestIds = db.RequestIds.Include(r => r.DoctorDetail);
            return View(requestIds.ToList());
        }

      
        

        // GET: RequestIds/Create
        public ActionResult Create()
        {
            ViewBag.DoctorId = new SelectList(db.DoctorDetails, "DoctorId", "DoctorName");
            return View();
        }

        // POST: RequestIds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RequestId1,PatientName,DoctorId")] RequestId requestId)
        {
            if (ModelState.IsValid)
            {
                db.RequestIds.Add(requestId);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DoctorId = new SelectList(db.DoctorDetails, "DoctorId", "DoctorName", requestId.DoctorId);
            return View(requestId);
        }

      
    }
}
