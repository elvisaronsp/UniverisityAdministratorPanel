using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Univerisity_Project.DAL;
using Univerisity_Project.ViewModel;

namespace Univerisity_Project.Controllers
{
    public class HomeController : Controller
    {
        private UniversityContext db = new UniversityContext();
        public ActionResult Index()
        {
            
            if(Session["loggeduser"] != null)
            {
                return View();
            }
            return RedirectToAction("Login", "Start");
        }

        public ActionResult About()
        {
            //ViewBag.Message = "უნივერსიტეტის ისტორია";
            IQueryable<EnrolmentDateGroup> data = from student in db.Students
                                                   group student by student.EnrollmentDate into dateGroup
                                                   select new EnrolmentDateGroup()
                                                   {
                                                       EnrollmentDate = dateGroup.Key,
                                                       StudentCount = dateGroup.Count()
                                                   };
            return View(data.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}