using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models.Models;
using System.Text;

namespace GP.Controllers
{
    public class StudentsController : Controller
    {
        private GPContext db = new GPContext();

        // GET Student/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: Students/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "id,name,email,password,level,GPA,skills")] Student student)
        {
            if (ModelState.IsValid)
            {
                if (db.Students.Where(m => m.email == student.email).Count() == 1)
                {
                    ModelState.AddModelError("", "This Email is Exist.");
                    return View(student);
                }
                else
                {
                    student.leaderid = 0;
                    student.type = 1;
                    db.Students.Add(student);
                    db.SaveChanges();
                    return RedirectToAction("addIdea", student);
                }
            }

            return View(student);
        }

        // GET: Students/addIdea
        public ActionResult addIdea()
        {
            ViewBag.leaderid = new SelectList(db.Students, "id", "name");
            ViewBag.professor1id = ViewBag.professor2id = ViewBag.professor3id =  new SelectList(db.Professors, "id", "name");
            return View();
        }

        // POST: Students/addIdea
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,leaderid,name,description,tools,professor1id,professor2id,professor3id,isApproved")] Idea idea)
        {
            if (ModelState.IsValid)
            {
                db.Ideas.Add(idea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.leaderid = new SelectList(db.Students, "id", "name", idea.leaderid);
            ViewBag.professor1id = ViewBag.professor2id = ViewBag.professor3id = new SelectList(db.Professors, "id", "name");
            return View(idea);
        }

        // GET: Students/login
        public ActionResult login()
        {
            return View();
        }

        // POST: Students/login
        [HttpPost]
        public ActionResult login([Bind(Include = "email,password")]  Student student)
        {
            var studentList = db.Students.Where(m => m.email == student.email && m.password == student.password && m.type == 1).ToList();

            if (studentList.Count != 0)
                return RedirectToAction("Index");

            else
                return RedirectToAction("login");
        }

        // GET: Students/Add
        public ActionResult Add()
        {
            return View();
        }

        // POST: Students/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "id,name,email,password,level,GPA,skills,leader_id")] Student student)
        {
            if (ModelState.IsValid)
            {
                student.type = 0;
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        //ENCRYPT THE PASSWORD
        public string encrypt(string password)
        {
            string result = "";
            for (int i = 0; i < password.Length; i++)
            {
                result += (char)(password[i] + 1);
            }

            return result;
        }

        public string Decrypt(byte[] Pass)
        {
            string res = Encoding.UTF8.GetString(Pass);
            return res;
        }

        /// <summary>
        /// /////////
        /// </summary>

        // GET: Students
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,type,name,email,password,level,GPA,skills,leader_id")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
