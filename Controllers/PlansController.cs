using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orion.Models;
using Orion.ViewModels;
using System.Data.Entity;

namespace Orion.Controllers
{
    public class PlansController : Controller
    {
        private ApplicationDbContext _context;

        public PlansController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var plans = _context.Plans.ToList();

            return View(plans);
        }

        public ActionResult Details(int id)
        {
            var plan = _context.Plans.SingleOrDefault(m => m.Id == id);

            return View(plan);
        }

       
    }
}