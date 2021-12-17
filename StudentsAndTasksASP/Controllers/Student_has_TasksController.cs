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
using PagedList;

namespace Duble2.Controllers
{
    public class Student_has_TasksController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: Student_has_Tasks
        public ActionResult Index(int? page)
        {
            var student_has_Tasks = db.Student_has_Tasks.Include(s => s.Student).Include(s => s.Tasks);
            student_has_Tasks = student_has_Tasks.OrderBy(x => x.Student_NumberOfCreditBook);

            ViewBag.Student_NumberOfCreditBook = new SelectList(db.Student, "NumberOfCreditBook", "Group_2_GroupNum");
            ViewBag.Tasks_idTaskNumber = new SelectList(db.Tasks, "idTaskNumber", "Subject_SubjectName");

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(student_has_Tasks.ToPagedList(pageNumber, pageSize));
        }

        // GET: Student_has_Tasks/Details/5
        public ActionResult Details(int? id, int? id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_has_Tasks student_has_Tasks = db.Student_has_Tasks.Find(id,id2);
            if (student_has_Tasks == null)
            {
                return HttpNotFound();
            }
            return View(student_has_Tasks);
        }

        // GET: Student_has_Tasks/Create
        public ActionResult Create()
        {
            ViewBag.Student_NumberOfCreditBook = new SelectList(db.Student, "NumberOfCreditBook", "Group_2_GroupNum");
            ViewBag.Tasks_idTaskNumber = new SelectList(db.Tasks, "idTaskNumber", "Subject_SubjectName");

            //var items = new SelectList(db.Tasks.Include(s => s.Student_has_Tasks).Where(g => g.idTaskNumber != ));

            //ViewBag.Books = new SelectList(items, "GroupNum");

            return View();
        }

        // POST: Student_has_Tasks/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Student_NumberOfCreditBook,Tasks_idTaskNumber,TaskPassDate,TaskGetDate")] Student_has_Tasks student_has_Tasks)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(student_has_Tasks);


            try
            {
                if (Validator.TryValidateObject(student_has_Tasks, context, results, true))
                {
                    if (ModelState.IsValid)
                    {
                        db.Student_TaskInsertProc(student_has_Tasks.Student_NumberOfCreditBook, student_has_Tasks.Tasks_idTaskNumber, student_has_Tasks.TaskPassDate, student_has_Tasks.TaskGetDate);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }


            catch (System.Data.DataException de)
            {
                Exception innerException = de;
                while (innerException.InnerException != null)
                {
                    innerException = innerException.InnerException;
                }
                if (innerException.Message.Contains("Unique_constraint_name"))
                {
                    ModelState.AddModelError(string.Empty, "Error Message");
                    ViewBag.Student_NumberOfCreditBook = new SelectList(db.Student, "NumberOfCreditBook", "Group_2_GroupNum", student_has_Tasks.Student_NumberOfCreditBook);
                    ViewBag.Tasks_idTaskNumber = new SelectList(db.Tasks, "idTaskNumber", "Subject_SubjectName", student_has_Tasks.Tasks_idTaskNumber);
                    return View();
                }
                ModelState.AddModelError(string.Empty, "Error Message");
                ViewBag.Student_NumberOfCreditBook = new SelectList(db.Student, "NumberOfCreditBook", "Group_2_GroupNum", student_has_Tasks.Student_NumberOfCreditBook);
                ViewBag.Tasks_idTaskNumber = new SelectList(db.Tasks, "idTaskNumber", "Subject_SubjectName", student_has_Tasks.Tasks_idTaskNumber);
                return View();
            }

            ViewBag.Student_NumberOfCreditBook = new SelectList(db.Student, "NumberOfCreditBook", "Group_2_GroupNum", student_has_Tasks.Student_NumberOfCreditBook);
            ViewBag.Tasks_idTaskNumber = new SelectList(db.Tasks, "idTaskNumber", "Subject_SubjectName", student_has_Tasks.Tasks_idTaskNumber);
            return View(student_has_Tasks);
        }

        // GET: Student_has_Tasks/Edit/5
        public ActionResult Edit(int? id,int? id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_has_Tasks student_has_Tasks = db.Student_has_Tasks.Find(id,id2);
            if (student_has_Tasks == null)
            {
                return HttpNotFound();
            }
            ViewBag.Student_NumberOfCreditBook = new SelectList(db.Student, "NumberOfCreditBook", "Group_2_GroupNum", student_has_Tasks.Student_NumberOfCreditBook);
            ViewBag.Tasks_idTaskNumber = new SelectList(db.Tasks, "idTaskNumber", "Subject_SubjectName", student_has_Tasks.Tasks_idTaskNumber);
            return View(student_has_Tasks);
        }

        // POST: Student_has_Tasks/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Student_NumberOfCreditBook,Tasks_idTaskNumber,TaskPassDate,TaskGetDate")] Student_has_Tasks student_has_Tasks)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(student_has_Tasks);


            try
            {

                if (Validator.TryValidateObject(student_has_Tasks, context, results, true))
                {
                    if (ModelState.IsValid)
                    {
                        db.Student_TaskUpdateProc(student_has_Tasks.Student_NumberOfCreditBook, student_has_Tasks.Tasks_idTaskNumber, student_has_Tasks.TaskPassDate, student_has_Tasks.TaskGetDate);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }

            catch (System.Data.DataException de)
            {
                Exception innerException = de;
                while (innerException.InnerException != null)
                {
                    innerException = innerException.InnerException;
                }
                if (innerException.Message.Contains("Unique_constraint_name"))
                {
                    ModelState.AddModelError(string.Empty, "Error Message");
                    ViewBag.Student_NumberOfCreditBook = new SelectList(db.Student, "NumberOfCreditBook", "Group_2_GroupNum", student_has_Tasks.Student_NumberOfCreditBook);
                    ViewBag.Tasks_idTaskNumber = new SelectList(db.Tasks, "idTaskNumber", "Subject_SubjectName", student_has_Tasks.Tasks_idTaskNumber);
                    return View();
                }
                ModelState.AddModelError(string.Empty, "Error Message");
                ViewBag.Student_NumberOfCreditBook = new SelectList(db.Student, "NumberOfCreditBook", "Group_2_GroupNum", student_has_Tasks.Student_NumberOfCreditBook);
                ViewBag.Tasks_idTaskNumber = new SelectList(db.Tasks, "idTaskNumber", "Subject_SubjectName", student_has_Tasks.Tasks_idTaskNumber);
                return View();
            }



            ViewBag.Student_NumberOfCreditBook = new SelectList(db.Student, "NumberOfCreditBook", "Group_2_GroupNum", student_has_Tasks.Student_NumberOfCreditBook);
            ViewBag.Tasks_idTaskNumber = new SelectList(db.Tasks, "idTaskNumber", "Subject_SubjectName", student_has_Tasks.Tasks_idTaskNumber);
            return View(student_has_Tasks);
        }

        // GET: Student_has_Tasks/Delete/5
        public ActionResult Delete(int? id,int? id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student_has_Tasks student_has_Tasks = db.Student_has_Tasks.Find(id, id2);
            if (student_has_Tasks == null)
            {
                return HttpNotFound();
            }
            return View(student_has_Tasks);
        }

        // POST: Student_has_Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id,int id2)
        {
            Student_has_Tasks student_has_Tasks = db.Student_has_Tasks.Find(id,id2);
            db.Student_TaskDeleteProc(student_has_Tasks.Student_NumberOfCreditBook,student_has_Tasks.Tasks_idTaskNumber);
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
