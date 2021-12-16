using System;
using System.Collections.Generic;
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
    public class Task1Controller : Controller
    {
        private Entities1 db = new Entities1();


        private string oldGroupnum = "";

        // GET: Task1
        public ActionResult Index(string groupNum, int? page)
        {

            var g = db.TaskOneProc(groupNum).OrderBy(x => x.SubjectName).ToList();
            //asu-22-1
            //groupNum = "asu-22-102";

            if (!String.IsNullOrEmpty(groupNum))
            {
                oldGroupnum = groupNum;

                g = db.TaskOneProc(groupNum).OrderBy(x => x.SubjectName).ToList();
            }
            else
            {
                g = db.TaskOneProc(oldGroupnum).OrderBy(x => x.SubjectName).ToList();
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(g.ToPagedList(pageNumber, pageSize));

        }
        // GET: Task1
        public ActionResult Index2(string groupNum2,string taskNum, int? page)
        {
            if (groupNum2 != null)
            {
                var g = db.TaskOneProc(groupNum2).OrderBy(x => x.SubjectName).ToList();

                int pageSize = 10;
                int pageNumber = (page ?? 1);
                return View(g.ToPagedList(pageNumber, pageSize));

            }
            else
            {
                var rgroup = db.TaskOneProc(groupNum2);
                return View(rgroup.ToList());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Task1Query([Bind(Include = "GroupNum,MajorName,Year_2")] Group_2 group_2)
        {
            
            if (ModelState.IsValid)
            {
                var l = db.TaskOneProc(group_2.GroupNum);
            }


            return View("Index", group_2);
        }
    }
}
