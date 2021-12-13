using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using Duble2.Models;
using PagedList;


namespace Duble2.Controllers
{
    public class HomeController : Controller
    {
        private Entities1 db = new Entities1();
        public ActionResult Index()
        {
            var group = db.Group_2.Include(s => s.Student);
            group = group.OrderBy(x => x.GroupNum);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}