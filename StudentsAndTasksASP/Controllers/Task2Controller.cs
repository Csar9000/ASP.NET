using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Duble2.Models;
using PagedList;

namespace Duble2.Controllers
{
    public class Task2Controller : Controller
    {
        public List<TaskTwoProc1_Result> g;
        private Entities1 db = new Entities1();
        
        // GET: Task2
        public ActionResult Index(string subject, Nullable<int> Ntasks, Nullable<DateTime> date,string lastSub, Nullable<int> lastNtasks, Nullable<DateTime> lastDate, int? page)
        {


            if (subject != null && Ntasks!= null && date!=null)
            {
                page = 1;
            }
            else
            {
                subject = lastSub;
                Ntasks = lastNtasks;
                date = lastDate;
            }

            ViewBag.CurrentSub = subject;
            ViewBag.CurrentNtasks = Ntasks;
            ViewBag.CurrentLastDate = date;

            g = db.TaskTwoProc1(subject, date, Ntasks).ToList();
              g = g.OrderBy(x => x.NumberOfCreditBook1).ToList();

            ViewBag.PagedList = g.ToPagedList(1,10);
              int pageSize = 10;
              int pageNumber = (page ?? 1);
              return View(g.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Page(List<TaskTwoProc1_Result> list, int? page)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(list.ToPagedList(pageNumber, pageSize));
        }

    }
}
