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
using PagedList.Mvc;

namespace Duble2.Controllers
{
    public class StudentsController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: Students
        public ActionResult Index(int? page)
        {

            var student = db.Student.Include(s => s.Group_2);
            student =  student.OrderBy(x => x.NumberOfCreditBook);


            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(student.ToPagedList(pageNumber, pageSize));

        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.Group_2_GroupNum = new SelectList(db.Group_2, "GroupNum", "MajorName");

            //SelectList books = new SelectList(db.Student.Select(a => new { GroupNum = a.Group_2_GroupNum }).Distinct(), "Group_2_GroupNum", "MajorName");

            var items = db.Group_2.Select(m => m.GroupNum).Distinct();

            ViewBag.Books = new SelectList(items,"GroupNum"); 

            return View();
        }

        // POST: Students/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NumberOfCreditBook,Group_2_GroupNum,FIO")] Student student)
        {

            var results = new List<ValidationResult>();
            var context = new ValidationContext(student);

            var items = db.Group_2.Select(m => m.GroupNum).Distinct();
            ViewBag.Books = new SelectList(items, "GroupNum");


            try
            {
                if (Validator.TryValidateObject(student, context, results, true))
                {
                    if (ModelState.IsValid)
                    {
                        db.StudentInsertProc(student.NumberOfCreditBook, student.Group_2_GroupNum, student.FIO);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }

                    //ViewBag.Group_2_GroupNum = new SelectList(db.Group_2, "GroupNum", "MajorName", student.Group_2_GroupNum);
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

                    return View(student);
                }
                ModelState.AddModelError(string.Empty, "Error Message");

                return View(student);
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
            Student student = db.Student.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.Group_2_GroupNum = new SelectList(db.Group_2, "GroupNum", "MajorName", student.Group_2_GroupNum);

            var items = db.Group_2.Select(m => m.GroupNum).Distinct();
            ViewBag.Groups = new SelectList(items, "GroupNum");
            return View(student);
        }

        // POST: Students/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NumberOfCreditBook,Group_2_GroupNum,FIO")] Student student)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(student);


            var items = db.Group_2.Select(m => m.GroupNum).Distinct();
            ViewBag.Groups = new SelectList(items, "GroupNum");
            //ViewBag.Group_2_GroupNum = new SelectList(db.Group_2, "GroupNum", "MajorName", student.Group_2_GroupNum);


            try
            {
                if (Validator.TryValidateObject(student, context, results, true))
                {
                    if (ModelState.IsValid)
                    {
                        //db.Entry(student).State = EntityState.Modified;
                        db.StudentUpdateProc(student.NumberOfCreditBook, student.Group_2_GroupNum, student.FIO);
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

                    return View(student);
                }
                ModelState.AddModelError(string.Empty, "Error Message");

                return View(student);
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
            Student student = db.Student.Find(id);
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
            Student student = db.Student.Find(id);
            db.StudentDeleteProc(student.NumberOfCreditBook);
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
