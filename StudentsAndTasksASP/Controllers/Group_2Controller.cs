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
    public class Group_2Controller : Controller
    {
        private Entities1 db = new Entities1();
        public ActionResult Index(int? page)
        {

            var group = db.Group_2.Include(s=>s.Student);
            group = group.OrderBy(x => x.GroupNum);


            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(group.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group_2 group_2 = db.Group_2.Find(id);
            if (group_2 == null)
            {
                return HttpNotFound();
            }
            return View(group_2);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupNum,MajorName,Year_2")] Group_2 group_2)
        {

            var results = new List<ValidationResult>();
            var context = new ValidationContext(group_2);


            try
            {
                if (Validator.TryValidateObject(group_2, context, results, true))
                {
                    if (ModelState.IsValid)
                    {
                        db.Group_2InsertProc(group_2.GroupNum, group_2.MajorName, group_2.Year_2);
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

                    return View(group_2);
                }
                ModelState.AddModelError(string.Empty, "Error Message");

                return View(group_2);
            }
            return View(group_2);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group_2 group_2 = db.Group_2.Find(id);
            if (group_2 == null)
            {
                return HttpNotFound();
            }
            return View(group_2);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupNum,MajorName,Year_2")] Group_2 group_2)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(group_2);
            try
            {
                if (Validator.TryValidateObject(group_2, context, results, true))
                {
                    if (ModelState.IsValid)
                    {
                        db.GroupUpdateProc(group_2.GroupNum, group_2.MajorName, group_2.Year_2);
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

                    return View();
                }
                ModelState.AddModelError(string.Empty, "Error Message");

                return View();
            }
            return View(group_2);
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group_2 group_2 = db.Group_2.Find(id);
            if (group_2 == null)
            {
                return HttpNotFound();
            }
            return View(group_2);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Group_2 group_2 = db.Group_2.Find(id);
            db.Group_2DeleteProc(group_2.GroupNum);
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
