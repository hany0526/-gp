using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GP.Controllers
{
    public class LoginController : Controller
    {
        private GPContext db = new GPContext();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // POST: login
        [HttpPost]
        public ActionResult Index([Bind(Include = "email,password")]  Student user)
        {
            string pass = user.password.GetHashCode().ToString();

            var studentList = db.Students.Where(m => m.email == user.email && m.password == pass && m.type == 1).ToList();
            if (studentList.Count != 0)
                return Redirect("Students");

            else 
            {
                var professorList = db.Professors.Where(m => m.email == user.email && m.password == user.password).ToList();
                if (professorList.Count != 0)
                    return Redirect("Professors");

                else
                {
                    var adminList = db.Admins.Where(m => m.email == user.email && m.password == user.password).ToList();
                    if (adminList.Count != 0)
                        return Redirect("Admins");

                    else
                    { 
                        ModelState.AddModelError("", "Email Or Password is field.");
                        return View(user);
                    }
                }
            }
        }

    }
}
