using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Duble2.Models;

namespace Duble2.Controllers
{
    public class SubjectsController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: Subjects
        public ActionResult Index()
        {
            return View(db.Subject.ToList());
        }

        // GET: Subjects/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subject.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // GET: Subjects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Subjects/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubjectName,TeachersFIO,Department")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                var results = new List<ValidationResult>();
                var context = new ValidationContext(subject);


                if (Validator.TryValidateObject(subject, context, results, true))
                {
                    //db.Subject.Add(subject);
                    db.SubjectInsertProc(subject.SubjectName,subject.TeachersFIO,subject.Department);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(subject);
        }

        // GET: Subjects/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subject.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: Subjects/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubjectName,TeachersFIO,Department")] Subject subject)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(subject);


            if (Validator.TryValidateObject(subject, context, results, true))
            {
                if (ModelState.IsValid)
                {
                    // db.Entry(subject).State = EntityState.Modified;
                    db.SubjectUpdateProc(subject.SubjectName, subject.TeachersFIO, subject.Department);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(subject);
        }

        // GET: Subjects/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subject.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Subject subject = db.Subject.Find(id);
            //db.Subject.Remove(subject);
            db.SubjectDeleteProc(subject.SubjectName,subject.TeachersFIO,subject.Department);
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
