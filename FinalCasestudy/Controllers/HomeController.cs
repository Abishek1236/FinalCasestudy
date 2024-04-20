using FinalCasestudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalCasestudy.Controllers
{
   
    public class HomeController : Controller
    {
        clinicEntities db = new clinicEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult AdminLogin(Admin log)
        {
           var Admin= db.Admins.Where(x => x.Username == log.Username && x.Password == log.Password).Count();
            if (Admin > 0)
            {
                return Redirect("AdminOptions");
            }
            else
            {
                return View();
            }

        }

        public ActionResult AdminOptions()
        {
            return View();
        }

        public ActionResult Login(PatientDetail log)
        {
            var Patientdetail = db.PatientDetails.Where(x => x.PatientId == log.PatientId && x.PatientName == log.PatientName && x.Password==log.Password ).Count();
            if (Patientdetail > 0)
            {
                return Redirect("/Home/UserOptions");
            }
            else
            {
                return View();
            }
            
        }

        public ActionResult UserOptions()
        {
            return View();
        }

       

      
    }
}