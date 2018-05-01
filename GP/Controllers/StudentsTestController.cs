using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Models.Models;

namespace GP.Controllers
{
    public class StudentsTestController : Controller
    {
        private GPContext db = new GPContext();

        // GET: StudentsTest
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.Department).Include(s => s.leader);
            return View(students.ToList());
        }

        // GET: StudentsTest/Details/5
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

        // GET: StudentsTest/Create
        public ActionResult Create()
        {
            ViewBag.Departmentid = new SelectList(db.Departments, "id", "name");
            ViewBag.leaderid = new SelectList(db.Students, "id", "name");
            return View();
        }

        // POST: StudentsTest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,type,name,email,password,Departmentid,level,GPA,skills,phone,leaderid,file")] Student student)
        {
            if (ModelState.IsValid)
            {
                student.type = 1;
                student.leaderid = 0;
                student.password = student.password.GetHashCode().ToString();
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Departmentid = new SelectList(db.Departments, "id", "name", student.Departmentid);
            ViewBag.leaderid = new SelectList(db.Students, "id", "name", student.leaderid);
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

        // GET: StudentsTest/Edit/5
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
            ViewBag.Departmentid = new SelectList(db.Departments, "id", "name", student.Departmentid);
            ViewBag.leaderid = new SelectList(db.Students, "id", "name", student.leaderid);
            return View(student);
        }

        // POST: StudentsTest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,type,name,email,password,Departmentid,level,GPA,skills,phone,leaderid,file")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departmentid = new SelectList(db.Departments, "id", "name", student.Departmentid);
            ViewBag.leaderid = new SelectList(db.Students, "id", "name", student.leaderid);
            return View(student);
        }

        // GET: StudentsTest/Delete/5
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

        // POST: StudentsTest/Delete/5
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
