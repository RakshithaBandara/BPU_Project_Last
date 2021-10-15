using BPU_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BPU_Project.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            {
                var salesorders = _context.Salesorders.ToList();
                ViewBag.Test = salesorders.Count;
            }
            {
                var salesorders2 = (_context.Salesorders.Where(x => x.Completed == true).ToList());
                ViewBag.Test2 = salesorders2.Count;
            }
            {
                var salesorders3 = (_context.Salesorders.Where(x => x.Completed == false).ToList());
                ViewBag.Test3 = salesorders3.Count;
            }
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