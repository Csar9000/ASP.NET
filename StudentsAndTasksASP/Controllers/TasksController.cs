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
    public class TasksController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: Tasks
        public ActionResult Index(int? page)
        {
            var tasks = db.Tasks.Include(t => t.Subject);
            tasks = tasks.OrderBy(x => x.idTaskNumber);

            db.Database.CommandTimeout = 5000;

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(tasks.ToPagedList(pageNumber, pageSize));
        }

        // GET: Tasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tasks tasks = db.Tasks.Find(id);
            if (tasks == null)
            {
                return HttpNotFound();
            }
            return View(tasks);
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            ViewBag.Subject_SubjectName = new SelectList(db.Subject, "SubjectName", "SubjectName");
            return View();
        }

        // POST: Tasks/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTaskNumber,TaskNumber,Subject_SubjectName,Summary")] Tasks tasks)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(tasks);


            try
            {

                if (Validator.TryValidateObject(tasks, context, results, true))
                {
                    if (ModelState.IsValid)
                    {
                        db.TasksInsertProc(tasks.idTaskNumber, tasks.TaskNumber, tasks.Subject_SubjectName, tasks.Summary);
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
                    ViewBag.Subject_SubjectName = new SelectList(db.Subject, "SubjectName", "SubjectName", tasks.Subject_SubjectName);
                    return View();
                }
                ModelState.AddModelError(string.Empty, "Error Message");
                ViewBag.Subject_SubjectName = new SelectList(db.Subject, "SubjectName", "SubjectName", tasks.Subject_SubjectName);
                return View();
            }

            ViewBag.Subject_SubjectName = new SelectList(db.Subject, "SubjectName", "SubjectName", tasks.Subject_SubjectName);
            return View(tasks);
        }

        // GET: Tasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tasks tasks = db.Tasks.Find(id);
            if (tasks == null)
            {
                return HttpNotFound();
            }
            ViewBag.Subject_SubjectName = new SelectList(db.Subject, "SubjectName", "SubjectName", tasks.Subject_SubjectName);
            return View(tasks);
        }

        // POST: Tasks/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTaskNumber,TaskNumber,Subject_SubjectName,Summary")] Tasks tasks)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(tasks);

            try
            {

                if (Validator.TryValidateObject(tasks, context, results, true))
                {
                    if (ModelState.IsValid)
                    {
                        db.TasksUPDATEProc(tasks.idTaskNumber, tasks.TaskNumber, tasks.Subject_SubjectName, tasks.Summary);
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
                    ViewBag.Subject_SubjectName = new SelectList(db.Subject, "SubjectName", "SubjectName", tasks.Subject_SubjectName);
                    return View();
                }
                ModelState.AddModelError(string.Empty, "Error Message");
                ViewBag.Subject_SubjectName = new SelectList(db.Subject, "SubjectName", "SubjectName", tasks.Subject_SubjectName);
                return View();
            }

            ViewBag.Subject_SubjectName = new SelectList(db.Subject, "SubjectName", "SubjectName", tasks.Subject_SubjectName);
            return View(tasks);
        }

        // GET: Tasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tasks tasks = db.Tasks.Find(id);
            if (tasks == null)
            {
                return HttpNotFound();
            }
            return View(tasks);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tasks tasks = db.Tasks.Find(id);
            db.TasksDELETEProc(tasks.idTaskNumber, tasks.TaskNumber, tasks.Subject_SubjectName, tasks.Summary);
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
