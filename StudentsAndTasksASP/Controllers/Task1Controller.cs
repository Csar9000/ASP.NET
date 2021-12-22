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

        public ActionResult Index(string groupNum,string oldGroupNum, int? page)
        {
            if (groupNum != null )
            {
                page = 1;
            }
            else
            {
                groupNum = oldGroupNum;

            }
               ViewBag.oldGroupNum = groupNum;

            var g = db.TaskOneProc(groupNum).OrderBy(x => x.SubjectName).ToList();

            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(g.ToPagedList(pageNumber, pageSize));
        }     
    }
}
