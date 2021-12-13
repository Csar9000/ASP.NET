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
    public class CurriculaController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: Curricula
        public ActionResult Index(int? page)
        {
            var curriculum = db.Curriculum.Include(c => c.Group_2).Include(c => c.Subject);

            curriculum = curriculum.OrderBy(x => x.Group_2_GroupNum);


            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(curriculum.ToPagedList(pageNumber, pageSize));

        }

        // GET: Curricula/Details/5
        public ActionResult Details(string id,string id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curriculum curriculum = db.Curriculum.Find(id,id2);
            if (curriculum == null)
            {
                return HttpNotFound();
            }
            return View(curriculum);
        }

        // GET: Curricula/Create
        public ActionResult Create()
        {
            ViewBag.Group_2_GroupNum = new SelectList(db.Group_2, "GroupNum", "MajorName");
            ViewBag.Subject_SubjectName = new SelectList(db.Subject, "SubjectName", "TeachersFIO");

            return View();
        }

        // POST: Curricula/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Group_2_GroupNum,Subject_SubjectName")] Curriculum curriculum)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(curriculum);



            if (Validator.TryValidateObject(curriculum, context, results, true))
            {
                if (ModelState.IsValid)
                {
                    db.Curriculum.Add(curriculum);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.Group_2_GroupNum = new SelectList(db.Group_2, "GroupNum", "MajorName", curriculum.Group_2_GroupNum);

            ViewBag.Subject_SubjectName = new SelectList(db.Subject, "SubjectName", "TeachersFIO", curriculum.Subject_SubjectName);

            return View(curriculum);
        }

        // GET: Curricula/Edit/5
        public ActionResult Edit(string id, string id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curriculum curriculum = db.Curriculum.Find(id,id2);
            if (curriculum == null)
            {
                return HttpNotFound();
            }
            ViewBag.Group_2_GroupNum = new SelectList(db.Group_2, "GroupNum", "MajorName", curriculum.Group_2_GroupNum);

            ViewBag.Subject_SubjectName = new SelectList(db.Subject, "SubjectName", "TeachersFIO", curriculum.Subject_SubjectName);

            return View(curriculum);
        }

        // POST: Curricula/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. 
        // Дополнительные сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Group_2_GroupNum,Subject_SubjectName")] Curriculum curriculum)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(curriculum);



            if (Validator.TryValidateObject(curriculum, context, results, true))
            {
                if (ModelState.IsValid)
                {
                    db.CurriculumUpdateProc(curriculum.Group_2_GroupNum, curriculum.Subject_SubjectName, curriculum.Subject_SubjectName);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Group_2_GroupNum = new SelectList(db.Group_2, "GroupNum", "MajorName", curriculum.Group_2_GroupNum);

            ViewBag.Subject_SubjectName = new SelectList(db.Subject, "SubjectName", "TeachersFIO", curriculum.Subject_SubjectName);

            return View(curriculum);
        }

        // GET: Curricula/Delete/5
        public ActionResult Delete(string id, string id2)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Curriculum curriculum = db.Curriculum.Find(id,id2);
            if (curriculum == null)
            {
                return HttpNotFound();
            }
            return View(curriculum);
        }

        // POST: Curricula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id, string id2)
        {
            Curriculum curriculum = db.Curriculum.Find(id,id2);
            db.Curriculum.Remove(curriculum);
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
