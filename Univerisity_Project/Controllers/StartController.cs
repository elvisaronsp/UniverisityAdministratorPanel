using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Univerisity_Project.Models;
using Univerisity_Project.DAL;

namespace Univerisity_Project.Controllers
{
    public class StartController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(User user)
        {
            if(user.UserName != null)
            {
                ViewBag.mess = "this user already exist, please enter your password ";
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LogIn model)
        {
            if (ModelState.IsValid )
            {
                UniversityContext db = new UniversityContext();
                var user = db.Users.SingleOrDefault(u => u.Password == model.Password && u.UserName == model.UserName);
                if(user != null)
                {
                    Session["loggeduser"] = model;
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "The user name or password is incorrect");
            return View(model);
        }
        public ActionResult Logout()
        {
            Session["loggeduser"] = null;
            return RedirectToAction("Login");

        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                //  try
                //{
                UniversityContext db = new UniversityContext();
                var user = db.Users.Where(x => x.UserName == model.UserName).FirstOrDefault();
                    if (user == null) 
                    {
                        var user1 = new User
                        {
                            UserName = model.UserName,
                            Password = model.Password
                        };
                        db.Users.Add(user1);
                        db.SaveChanges();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Login", "Start",user);
                    }
               // }
              /*  catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", e.StatusCode.ToString());
                } */
            }
            return View(model);
        } 

    }
}