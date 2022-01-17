using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orion.Models;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Net;
using AutoMapper;
using Orion.ViewModels;

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

        [HttpGet]
        public ViewResult Index()
        {
            var viewModel = new PlanFormViewModel();

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var plan = _context.Plans.SingleOrDefault(m => m.Id == id);

            return View(plan);
        }

        [HttpGet]
        public ActionResult EditPartial(int id)
        {
            var plan = _context.Plans.SingleOrDefault(m => m.Id == id);

            var viewModel = Mapper.Map<Plan, PlanFormViewModel>(plan);

            var renderedView = Utilities.Utilities.RenderPartialToString("~/Views/Plans/Partials/_PlanForm.cshtml", viewModel, ControllerContext);

            return Json(new { view = renderedView }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(PlanFormViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var plan = Mapper.Map<PlanFormViewModel, Plan>(viewModel);

                _context.Plans.AddOrUpdate(t => t.Id, plan);
                _context.SaveChanges();

                return Json(new { message = "Created/Updated successfully" });
            }

            var renderedView = Utilities.Utilities.RenderPartialToString("~/Views/Plans/Partials/_PlanForm.cshtml", viewModel, ControllerContext);
            return Json(new { view = renderedView, message = "Form invalid", status = HttpStatusCode.BadRequest });
        }


    }
}